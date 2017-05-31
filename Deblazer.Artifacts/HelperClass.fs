module HelperClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let getBaseTypes (table:table) =
        [|
            sf.SimpleBaseType(
                sf.GenericName(
                    sf.Identifier("QueryHelper"))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SingletonSeparatedList(
                                sf.IdentifierName(table.TypeName) :> TypeSyntax
                    )))) :> BaseTypeSyntax
            sf.SimpleBaseType(
                sf.GenericName(
                    sf.Identifier("IHelper"))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SingletonSeparatedList(
                                sf.IdentifierName(table.TypeName) :> TypeSyntax
                    )))) :> BaseTypeSyntax
        |]
    let getSelectStatement (columns:column[]) = 
        columns |> Array.map (fun column ->
            sf.LiteralExpression(
                sk.StringLiteralExpression,
                sf.Literal(String.Format("{{0}}.{0}", column.Member))) :> ExpressionSyntax
        )

    let getInsertStatement (columns:column[]) = 
        columns |> Array.map (fun column ->
            sf.LiteralExpression(
                sk.StringLiteralExpression,
                sf.Literal(column.Member)) :> ExpressionSyntax
        )

    let getSqlStatementField (fieldName:string) (columns:column[])=
        sf.FieldDeclaration(
            sf.VariableDeclaration(
                sf.ArrayType(
                    sf.PredefinedType(sf.Token(sk.StringKeyword)))
                    .WithRankSpecifiers(
                        sf.SingletonList(sf.ArrayRankSpecifier(sf.SingletonSeparatedList(sf.OmittedArraySizeExpression() :> ExpressionSyntax)))))
                        
                .WithVariables(
                    sf.SingletonSeparatedList(
                        sf.VariableDeclarator(sf.Identifier(fieldName))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.ImplicitArrayCreationExpression(
                                        sf.InitializerExpression(
                                            sk.ArrayInitializerExpression,
                                            sf.SeparatedList(
                                                getSelectStatement columns,
                                                sf.getCommaTokens columns.Length)))))))) :> MemberDeclarationSyntax
    let getSqlStatementProperty (propertyName:string) (fieldName:string) =
        sf.PropertyDeclaration(
            sf.ArrayType(
                sf.PredefinedType(sf.Token(sk.StringKeyword)))
                .WithRankSpecifiers(
                        sf.SingletonList(sf.ArrayRankSpecifier(sf.SingletonSeparatedList(sf.OmittedArraySizeExpression() :> ExpressionSyntax)))),
            sf.Identifier(propertyName)) 
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithExpressionBody(sf.ArrowExpressionClause(sf.IdentifierName(fieldName)))
            .WithSemicolonToken(sf.Token(sk.SemicolonToken))
            :> MemberDeclarationSyntax

    let tempTableSql (table:table)=
        let columns = table.EditableColumns |> Array.map (fun column -> String.Format("[{0}] {1}", column.Member, column.DbType))

        String.Format(
            "CREATE TABLE #{0} ({1}, [RowIndexForSqlBulkCopy] INT NOT NULL)", 
            table.TypeName,
            String.concat(",") <| columns)

    let getTempTableField (table:table) =
        sf.FieldDeclaration(
            sf.VariableDeclaration(
                sf.PredefinedType(sf.Token(sk.StringKeyword)))
                .WithVariables(
                    sf.SingletonSeparatedList(
                        sf.VariableDeclarator(
                            sf.Identifier("createTempTableCommand"))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.LiteralExpression(
                                        sk.StringLiteralExpression,
                                        sf.Literal(tempTableSql table)) :> ExpressionSyntax)))))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PrivateKeyword)
                        sf.Token(sk.StaticKeyword)
                        sf.Token(sk.ReadOnlyKeyword)
                    |]))
        
        :> MemberDeclarationSyntax

    let getTempTableProperty =
        sf.PropertyDeclaration(
            sf.PredefinedType(sf.Token(sk.StringKeyword)), sf.Identifier("CreateTempTableCommand"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithExpressionBody(sf.ArrowExpressionClause(sf.IdentifierName("createTempTableCommand")))
            .WithSemicolonToken(sf.Token(sk.SemicolonToken))
        :> MemberDeclarationSyntax

    let getFullTableNamePropery (tableName:SqlQualifiedTable) =
        sf.PropertyDeclaration(
            sf.PredefinedType(sf.Token(sk.StringKeyword)), sf.Identifier("FullTableName"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithExpressionBody(sf.ArrowExpressionClause(sf.LiteralExpression(sk.StringLiteralExpression, sf.Literal(tableName.WithSquareBrackets))))
            .WithSemicolonToken(sf.Token(sk.SemicolonToken))
        :> MemberDeclarationSyntax

    let getFields (table:table)= 
        [|
            getSqlStatementField "columnsInSelectStatement" table.Columns
            getSqlStatementProperty "ColumnsInSelectStatement" "columnsInSelectStatement"
            getSqlStatementField "columnsInInsertStatement" table.EditableColumns
            getSqlStatementProperty "ColumnsInInsertStatement" "columnsInInsertStatement"
            getTempTableField table
            getTempTableProperty
            getFullTableNamePropery table.Name
        |]

    let getBinaryStatement (className:string) =
        sf.BinaryExpression(
                sk.EqualsExpression,
                sf.IdentifierName("other"),
                sf.TypeOfExpression(sf.IdentifierName(className)))

    let getOrStatement (firstExpression:BinaryExpressionSyntax) (secondExpression:BinaryExpressionSyntax) =
        sf.BinaryExpression(
            sk.LogicalOrExpression,
            firstExpression,
            secondExpression)

    let IsForeignKeyTo (associations:association[]) = 
        let fkAssociations = associations |> Array.filter (fun x -> x.IsForeignKey)

        let getReturnStatement  = 
            match fkAssociations.Length with
            | 0 -> sf.ReturnStatement(sf.LiteralExpression(sk.FalseLiteralExpression))
            | _ -> 
                sf.ReturnStatement(
                    fkAssociations 
                        |> Array.map (fun assocation -> getBinaryStatement assocation.Type)
                        |> Array.reduce (fun a1 a2 -> getOrStatement a1 a2))

        sf.MethodDeclaration(
            sf.PredefinedType(sf.Token(sk.BoolKeyword)),
            sf.Identifier("IsForeignKeyTo"))
            .WithModifiers(
                    sf.TokenList(
                        [|
                            sf.Token(sk.PublicKeyword)
                            sf.Token(sk.SealedKeyword)
                            sf.Token(sk.OverrideKeyword)
                        |]))
                .WithParameterList(
                    sf.ParameterList(
                        sf.SingletonSeparatedList<ParameterSyntax>(
                            sf.Parameter(
                                sf.Identifier("other"))
                                .WithType(sf.IdentifierName("Type")))))
                .WithBody(
                    sf.Block(
                        sf.SingletonList<StatementSyntax>(getReturnStatement)))
        :> MemberDeclarationSyntax
    let sqlInsertStatement (table:table) =
        let editableColumns = table.EditableColumns
        let columnDefinitions = 
            editableColumns
                |> Array.map (fun column -> sqlSquareBrackets (String.Format("{0}.{1}", table.Name, column.Name)))
                |> String.concat(", ")
        let columnParameters = 
            editableColumns
                |> Array.map (fun column -> sqlSquareBrackets (String.Format("@{0}", column.Name)))
                |> String.concat(",")
        String.Format(
            "INSERT INTO {0} ({1}) VALUES ({2}); SELECT SCOPE_IDENTITY()",
            table.Name.WithSquareBrackets,
            columnDefinitions,
            columnParameters)

    let insertStatementField (table:table) = 
        sf.FieldDeclaration(
            sf.VariableDeclaration(
                sf.PredefinedType(
                    sf.Token(sk.StringKeyword)))
                .WithVariables(
                    sf.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        sf.VariableDeclarator(
                            sf.Identifier("insertCommand"))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.LiteralExpression(
                                        sk.StringLiteralExpression,
                                        sf.Literal(sqlInsertStatement table)))))))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PrivateKeyword)
                        sf.Token(sk.ConstKeyword)
                    |]                            )) :> MemberDeclarationSyntax

    let fillInsertCommandMethod (table:table) = 
        let defaultArgument (column:column) =
            match column.IsNullableType with
            | true -> 
                [|
                    sf.Argument(sf.LiteralExpression(sk.StringLiteralExpression, sf.Literal(String.Format("@{0}", column.Name))))
                    sf.Argument(
                        sf.BinaryExpression(
                            sk.CoalesceExpression,
                            sf.MemberAccessExpression(
                                sk.SimpleMemberAccessExpression,
                                sf.IdentifierName(table.Storage),
                                sf.IdentifierName(column.Member)),
                            sf.CastExpression(
                                sf.PredefinedType(
                                    sf.Token(sk.ObjectKeyword)),
                                sf.MemberAccessExpression(
                                    sk.SimpleMemberAccessExpression,
                                    sf.IdentifierName("DBNull"),
                                    sf.IdentifierName("Value")))))
                |]
            | false -> 
                [|
                    sf.Argument(sf.LiteralExpression(sk.StringLiteralExpression, sf.Literal(String.Format("@{0}", column.Name))))
                    sf.Argument(
                        sf.MemberAccessExpression(
                                sk.SimpleMemberAccessExpression,
                                sf.IdentifierName(table.Storage),
                                sf.IdentifierName(column.Member)))
                |]
        let addWithValueExpressions =
            table.EditableColumns
                |> Array.map  (fun column -> 
                    sf.ExpressionStatement(
                            sf.InvocationExpression(
                                sf.MemberAccessExpression(
                                    sk.SimpleMemberAccessExpression,
                                    sf.MemberAccessExpression(
                                        sk.SimpleMemberAccessExpression,
                                        sf.IdentifierName("sqlCommand"),
                                        sf.IdentifierName("Parameters")),
                                    sf.IdentifierName("AddWithValue")))
                                .WithArgumentList(
                                    sf.ArgumentList(
                                        sf.SeparatedList(
                                            defaultArgument column,
                                            [|
                                                sf.Token(sk.CommaToken)
                                            |])))) :> StatementSyntax)
        sf.MethodDeclaration(
            sf.PredefinedType(sf.Token(sk.VoidKeyword)),
            sf.Identifier("FillInsertCommand"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithParameterList(
                    sf.ParameterList(
                        sf.SeparatedList(
                            [|
                                sf.Parameter(sf.Identifier("sqlCommand")).WithType(sf.IdentifierName("SqlCommand"))
                                sf.Parameter(sf.Identifier(table.Storage)).WithType(sf.IdentifierName(table.TypeName))
                            |],
                            [|
                                sf.Token(sk.CommaToken)
                            |])))
            .WithBody(
                sf.Block(
                    Array.append
                        [|
                            sf.ExpressionStatement(
                                sf.AssignmentExpression(
                                    sk.SimpleAssignmentExpression,
                                    sf.MemberAccessExpression(
                                        sk.SimpleMemberAccessExpression,
                                        sf.IdentifierName("sqlCommand"),
                                        sf.IdentifierName("CommandText")),
                                    sf.IdentifierName("insertCommand"))) :> StatementSyntax
                        |]
                        (addWithValueExpressions)))
         :> MemberDeclarationSyntax
    let executeInsertCommand (table:table) = 
        sf.MethodDeclaration(
            sf.PredefinedType(sf.Token(sk.VoidKeyword)),
            sf.Identifier("ExecuteInsertCommand"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithParameterList(
                    sf.ParameterList(
                        sf.SeparatedList(
                            [|
                                sf.Parameter(sf.Identifier("sqlCommand")).WithType(sf.IdentifierName("SqlCommand"))
                                sf.Parameter(sf.Identifier(table.Storage)).WithType(sf.IdentifierName(table.TypeName))
                            |],
                            [|
                                sf.Token(sk.CommaToken)
                            |])))
            .WithBody(
                sf.Block(
                    [|
                        sf.UsingStatement(
                            sf.Block(
                                [|
                                    sf.ExpressionStatement(
                                        sf.InvocationExpression(
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.IdentifierName("sqlDataReader"),
                                                sf.IdentifierName("Read")))) :> StatementSyntax
                                    sf.ExpressionStatement(
                                        sf.AssignmentExpression(
                                            sk.SimpleAssignmentExpression,
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.IdentifierName(String.Format("_{0}", table.TypeName)),
                                                sf.IdentifierName(table.PrimaryKeyColumn.Value.Name)),
                                            sf.InvocationExpression(
                                                sf.MemberAccessExpression(
                                                    sk.SimpleMemberAccessExpression,
                                                    sf.IdentifierName("Convert"),
                                                    sf.IdentifierName("ToInt32")))
                                                .WithArgumentList(
                                                    sf.ArgumentList(
                                                        sf.SingletonSeparatedList(
                                                            sf.Argument(
                                                                sf.InvocationExpression(
                                                                    sf.MemberAccessExpression(
                                                                        sk.SimpleMemberAccessExpression,
                                                                        sf.IdentifierName("sqlDataReader"),
                                                                        sf.IdentifierName("GetValue")))
                                                                    .WithArgumentList(
                                                                        sf.ArgumentList(
                                                                            sf.SingletonSeparatedList<ArgumentSyntax>(
                                                                                sf.Argument(
                                                                                    sf.LiteralExpression(
                                                                                        sk.NumericLiteralExpression,
                                                                                        sf.Literal(0)))))))))))) :> StatementSyntax
                                |]))
                            .WithDeclaration(
                                sf.VariableDeclaration(
                                    sf.IdentifierName("var"))
                                    .WithVariables(
                                        sf.SingletonSeparatedList(
                                            sf.VariableDeclarator(
                                                sf.Identifier("sqlDataReader"))
                                                .WithInitializer(
                                                    sf.EqualsValueClause(
                                                        sf.InvocationExpression(
                                                            sf.MemberAccessExpression(
                                                                sk.SimpleMemberAccessExpression,
                                                                sf.IdentifierName("sqlCommand"),
                                                                sf.IdentifierName("ExecuteReader")))
                                                            .WithArgumentList(
                                                                sf.ArgumentList(
                                                                    sf.SingletonSeparatedList(
                                                                        sf.Argument(
                                                                            sf.MemberAccessExpression(
                                                                                sk.SimpleMemberAccessExpression,
                                                                                sf.IdentifierName("CommandBehavior"),
                                                                                sf.IdentifierName("SequentialAccess"))))))))))) :> StatementSyntax
                    |]))
         :> MemberDeclarationSyntax
    let wrapperInstance (table:table) = 
        let wrapperName = String.Format("{0}Wrapper", table.TypeName)
        sf.FieldDeclaration(
            sf.VariableDeclaration(
                sf.IdentifierName(wrapperName))
                .WithVariables(
                    sf.SingletonSeparatedList(
                        sf.VariableDeclarator(
                            sf.Identifier("_wrapper"))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.MemberAccessExpression(
                                        sk.SimpleMemberAccessExpression,
                                        sf.IdentifierName(wrapperName),
                                        sf.IdentifierName("Instance")))))))
                            .WithModifiers(
                                sf.TokenList(
                                    [|
                                        sf.Token(sk.PrivateKeyword)
                                        sf.Token(sk.StaticKeyword)
                                    |]))
        :> MemberDeclarationSyntax
    let wrapperProperty (table:table) = 
        sf.PropertyDeclaration(
            sf.IdentifierName("QueryWrapper"),
            sf.Identifier("Wrapper"))
            .WithModifiers(
                sf.TokenList(sf.Token(sk.PublicKeyword)))
            .WithAccessorList(
                sf.AccessorList(
                    sf.SingletonList(
                        sf.AccessorDeclaration(sk.GetAccessorDeclaration)
                            .WithBody(
                                sf.Block(
                                    sf.SingletonList(
                                        sf.ReturnStatement(
                                            sf.IdentifierName("_wrapper")) :> StatementSyntax))))))
        :> MemberDeclarationSyntax
    let getHelperClass (table:table) = 
        sf.ClassDeclaration(String.Format("{0}Helper", table.TypeName))
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddBaseListTypes(getBaseTypes table)
            .AddMembers(getFields table)
            .AddMembers(IsForeignKeyTo table.Associations)
            .AddMembers(insertStatementField table)
            .AddMembers(fillInsertCommandMethod table)
            .AddMembers(executeInsertCommand table)
            .AddMembers(wrapperInstance table)
            .AddMembers(wrapperProperty table)
            
            //.AddMembers(queryMethods table)
            
            :> MemberDeclarationSyntax 