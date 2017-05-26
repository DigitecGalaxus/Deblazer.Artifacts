module ArtifactClass
    open Attributes
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let usings (nameSpace:string) = 
        [|
           sf.UsingDirective(sf.ParseName("System"))
           sf.UsingDirective(sf.ParseName("System.ComponentModel"))
           sf.UsingDirective(sf.ParseName("System.Data.Linq"))
           sf.UsingDirective(sf.ParseName("System.Linq"))
           sf.UsingDirective(sf.ParseName("System.Data.Linq.Mapping"))
           sf.UsingDirective(sf.ParseName("System.Data.SqlClient"))
           sf.UsingDirective(sf.ParseName("System.Data"))
           sf.UsingDirective(sf.ParseName("System.Collections.Generic"))
           sf.UsingDirective(sf.ParseName("System.Runtime.Serialization"))
           sf.UsingDirective(sf.ParseName("System.Reflection"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.Validation"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.CodeAnnotation"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.Api"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.Visitors"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.Cache"))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.SqlGeneration"))
           sf.UsingDirective(sf.ParseName(String.Format("{0}.Queries", nameSpace)))
           sf.UsingDirective(sf.ParseName(String.Format("{0}.Wrappers", nameSpace)))
           sf.UsingDirective(sf.ParseName("Dg.Deblazer.Read"))           
        |]

    let baseTypes (iidType:string) = 
        [|
            sf.SimpleBaseType(sf.ParseTypeName("DbEntity")) :> BaseTypeSyntax
            sf.SimpleBaseType(sf.ParseTypeName(iidType)) :> BaseTypeSyntax
            //sf.SimpleBaseType(sf.ParseTypeName("ISerializable")) :> BaseTypeSyntax
        |]
    let columnFields (table:table) = 
        table.Columns 
            |> Array.map (fun column -> 
                let typeSyntax = sf.ParseTypeName("DbValue<"+column.Type+">")
                sf.FieldDeclaration(
                    sf
                        .VariableDeclaration(                            
                                typeSyntax,
                                sf.SingletonSeparatedList(sf.VariableDeclarator(sf.ParseToken(column.Storage)).WithInitializer(sf.EqualsValueClause(sf.ObjectCreationExpression(typeSyntax).WithArgumentList(sf.ArgumentList()))))))
                        
                    .AddModifiers(sf.Token(sk.PrivateKeyword)) 
                :> MemberDeclarationSyntax)

    let genericAssociationClass (association:association)= 
        match association.IsMany with
        | true -> "IDbEntitySet"
        | false -> "IDbEntityRef" 
        
    let associationFields (table:table) =
        table.Associations 
            |> Array.map (fun association -> 
                

                let typeSyntax = sf.ParseTypeName(String.Format("{0}<{1}>", genericAssociationClass association, association.Type))
                sf.FieldDeclaration(
                    sf.VariableDeclaration(                            
                        typeSyntax,
                        sf.SingletonSeparatedList(sf.VariableDeclarator(sf.ParseToken(association.Storage)))))
                        
                    .AddModifiers(sf.Token(sk.PrivateKeyword)) 
                :> MemberDeclarationSyntax)
    let fields (table:table) = 
        Array.append 
            (columnFields table)
            (associationFields table)

    let propertyAttributes (column:column) = 
        [|
            stringColumnAttribute column.MaxLength column.CanBeNull
            validateAttribute
        |]
        |> Array.filter (fun x -> x.IsSome) |> Array.map (fun x -> x.Value)

    let constructorBody (columns:column[]) = 
         columns |> Array.map (fun column -> sf.ParseStatement(String.Format("{0} = new DbValue<{1}>();", column.Storage, column.Type)))


    let getConstructor (table:table) =
        sf.ConstructorDeclaration(table.Member)
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddBodyStatements(constructorBody table.Columns)

    let checkProperiesMethodBody (columns:column[]) = 
        columns |> Array.map (fun column -> 
            sf.ExpressionStatement(
                sf.InvocationExpression(
                    sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.IdentifierName(column.Storage), sf.IdentifierName("Welcome")))
            .WithArgumentList(sf.ArgumentList(sf.SeparatedList(
                                                [|
                                                    sf.Argument(sf.IdentifierName("visitor"))
                                                    sf.Argument(sf.LiteralExpression(sk.StringLiteralExpression, sf.Literal(column.Member)))
                                                    sf.Argument(sf.LiteralExpression(sk.StringLiteralExpression, sf.Literal(column.DbType)))
                                                    sf.Argument(sf.LiteralExpression(sk.FalseLiteralExpression))
                                                |],
                                                [|
                                                    sf.Token(sk.CommaToken)
                                                    sf.Token(sk.CommaToken)
                                                    sf.Token(sk.CommaToken)
                                                |])))) :> StatementSyntax)  

    let checkProperiesMethod (columns:column[]) = 
        sf.MethodDeclaration(sf.PredefinedType(sf.Token(sk.VoidKeyword)), sf.Identifier("CheckProperties"))
            .WithModifiers(sf.TokenList(
                            [|
                                sf.Token(sk.ProtectedKeyword)
                                sf.Token(sk.SealedKeyword)
                                sf.Token(sk.OverrideKeyword)
                            |]))
            .WithParameterList(sf.ParameterList(sf.SingletonSeparatedList<ParameterSyntax>(sf.Parameter(sf.Identifier("visitor")).WithType(sf.IdentifierName("IUpdateVisitor")))))
            .WithBody(
                sf.Block(checkProperiesMethodBody columns)) :> MemberDeclarationSyntax

    let handleChildrenMethodBody (associations:association[]) =
        associations |> Array.map (fun association -> 
            sf.ExpressionStatement(
                sf.InvocationExpression(sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.IdentifierName("visitor"), sf.IdentifierName("ProcessAssociation")))
            .WithArgumentList(sf.ArgumentList(sf.SeparatedList(
                                                [|
                                                    sf.Argument(sf.ThisExpression())
                                                    sf.Argument(sf.IdentifierName(association.Storage))
                                                |],
                                                [|
                                                    sf.Token(sk.CommaToken)
                                                |])))) :> StatementSyntax)
    let handleChildrenMethod (associations:association[]) =
        sf.MethodDeclaration(sf.PredefinedType(sf.Token(sk.VoidKeyword)), sf.Identifier("HandleChildren"))
            .WithModifiers(sf.TokenList(
                            [|
                                sf.Token(sk.ProtectedKeyword)
                                sf.Token(sk.OverrideKeyword)
                            |]))
            .WithParameterList(sf.ParameterList(sf.SingletonSeparatedList(
                                                    sf.Parameter(sf.Identifier("visitor")).WithType(sf.IdentifierName("DbEntityVisitorBase")))))
            .WithBody(sf.Block(handleChildrenMethodBody associations)) :> MemberDeclarationSyntax

    let getFillerMethodName (typeString:string) (isNullable:bool) =
        
        match (typeString, isNullable) with
        | "RowVersion", _ -> "GetRowVersion"
        | "System.Date", _ -> "GetDate"
        | "System.Data.Linq.Binary", _ -> "GetBinary"
        | _ 
            -> match Type.GetType(typeString) with
                | t when 
                    t = typeof<decimal> || 
                    t = typeof<bool> || 
                    t = typeof<int> || 
                    t = typeof<double> ||
                    t = typeof<char> || 
                    t = typeof<byte> || 
                    t = typeof<DateTime> || 
                    t = typeof<DateTimeOffset> || 
                    t = typeof<TimeSpan>  
                    -> 
                        let shortenedType = typeString.Replace("System.", String.Empty)
                        String.Format("Get{0}", shortenedType)
                | t when t = typeof<Nullable<char>> 
                    -> "GetNullableChar"
                | t when t = typeof<Nullable<int>> 
                    -> "GetNullableInt32"
                | t when t = typeof<Nullable<decimal>> 
                    -> "GetNullableDecimal"
                | _ 
                    -> String.Format("GetValue<{0}>", typeString)

    let modifyInternalStateLoadFieldExpression (column:column) = 
        sf.ExpressionStatement(
            sf.InvocationExpression(
                sf.MemberAccessExpression(
                    sk.SimpleMemberAccessExpression, 
                    sf.IdentifierName(column.Storage), 
                    sf.IdentifierName("Load")))
                .WithArgumentList(
                    sf.ArgumentList(
                        sf.SingletonSeparatedList(
                            sf.Argument(
                                sf.InvocationExpression(
                                    sf.MemberAccessExpression(
                                        sk.SimpleMemberAccessExpression, 
                                        sf.IdentifierName("visitor"), 
                                        sf.IdentifierName((getFillerMethodName column.Type column.IsNullableType)))))))))

    let modifyInternalStateLoadFieldExpressions (columns:column[]) = 
        columns |> Array.map (fun column -> 
            match column.IsPrimaryKey with
            | Some true ->
                [|
                    sf.ExpressionStatement(sf.InvocationExpression(sf.IdentifierName("SendIdChanging"))) :> StatementSyntax
                    modifyInternalStateLoadFieldExpression column :> StatementSyntax
                    sf.ExpressionStatement(sf.InvocationExpression(sf.IdentifierName("SendIdChanged"))) :> StatementSyntax
                |]
            | _ -> [| modifyInternalStateLoadFieldExpression column :> StatementSyntax |]
        ) |> Array.collect (fun x -> x)
    let modifyInternalStateMethod (columns:column[]) = 
        sf.MethodDeclaration(sf.PredefinedType(sf.Token(sk.VoidKeyword)), sf.Identifier("ModifyInternalState"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.ProtectedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithParameterList(sf.ParameterList(sf.SingletonSeparatedList<ParameterSyntax>(sf.Parameter(sf.Identifier("visitor")).WithType(sf.IdentifierName("FillVisitor")))))
            .WithBody(
                sf.Block(
                    Array.append
                        (modifyInternalStateLoadFieldExpressions columns)
                        [|
                            sf.ExpressionStatement(
                                sf.AssignmentExpression( // this._readDb = visitor.Db
                                    sk.SimpleAssignmentExpression, 
                                    sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.ThisExpression(), sf.IdentifierName("_db")),
                                    sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.IdentifierName("visitor"), sf.IdentifierName("Db"))))
                            sf.ExpressionStatement(
                                sf.AssignmentExpression(
                                    sk.SimpleAssignmentExpression,
                                    sf.IdentifierName("isLoaded"),
                                    sf.LiteralExpression(sk.TrueLiteralExpression)))
                        |]
            )) :> MemberDeclarationSyntax

    let methods (table:table) = 
        [|
            modifyInternalStateMethod table.Columns
            checkProperiesMethod table.EditableColumns
            handleChildrenMethod table.Associations
        |]
    let oneToOne (thisTypeName:string) (otherTypeName:string) =
        sf.LocalDeclarationStatement(
            sf.VariableDeclaration(
                sf.GenericName(
                    sf.Identifier("Action"))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SingletonSeparatedList<TypeSyntax>(
                                sf.IdentifierName(otherTypeName)))))
                .WithVariables(
                    sf.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        sf.VariableDeclarator(
                            sf.Identifier("beforeRightsCheckAction"))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.SimpleLambdaExpression(
                                        sf.Parameter(
                                            sf.Identifier("e")),
                                        sf.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            sf.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                sf.IdentifierName("e"),
                                                sf.IdentifierName(thisTypeName)),
                                            sf.ThisExpression()))))))) :> StatementSyntax
    let entityRefGetProperty (table:table) (association:association) =
        let className = table.Name
        sf.AccessorDeclaration(
                sk.GetAccessorDeclaration)
            .WithBody(
                sf.Block(
                    [|
                        (match table.TypeName with
                        | typeName when typeName = association.Type -> oneToOne association.Member association.Type
                        | typeName when association.ThisKey = table.PrimaryKeyColumn.Value.Name -> oneToOne typeName association.Type
                        | _ -> 
                            sf.LocalDeclarationStatement(
                                sf.VariableDeclaration(
                                    sf.GenericName(
                                        sf.Identifier("Action"))
                                        .WithTypeArgumentList(
                                            sf.TypeArgumentList(
                                                sf.SingletonSeparatedList<TypeSyntax>(
                                                    sf.IdentifierName(association.Type)))))
                                    .WithVariables(
                                        sf.SingletonSeparatedList(
                                            sf.VariableDeclarator(
                                                sf.Identifier("beforeRightsCheckAction"))
                                                .WithInitializer(
                                                    sf.EqualsValueClause(
                                                        sf.SimpleLambdaExpression(
                                                            sf.Parameter(sf.Identifier("e")),
                                                            sf.InvocationExpression(
                                                                sf.MemberAccessExpression(
                                                                    sk.SimpleMemberAccessExpression,
                                                                    sf.MemberAccessExpression(
                                                                        sk.SimpleMemberAccessExpression,
                                                                        sf.IdentifierName("e"),
                                                                        sf.IdentifierName(table.Member)), // Type.Name == association.Type dann 1:1 beziehung
                                                                    sf.IdentifierName("Add")))
                                                                .WithArgumentList(
                                                                    sf.ArgumentList(
                                                                        sf.SingletonSeparatedList(
                                                                            sf.Argument(
                                                                                sf.ThisExpression())))))))))) :> StatementSyntax)
                        sf.IfStatement(
                            sf.BinaryExpression(
                                sk.NotEqualsExpression,
                                sf.IdentifierName(association.Storage),
                                sf.LiteralExpression(
                                    sk.NullLiteralExpression)),
                            sf.Block(
                                sf.SingletonList(
                                    sf.ReturnStatement(
                                        sf.InvocationExpression(
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.IdentifierName(association.Storage),
                                                sf.IdentifierName("GetEntity")))
                                            .WithArgumentList(
                                                sf.ArgumentList(
                                                    sf.SingletonSeparatedList<ArgumentSyntax>(
                                                        sf.Argument(
                                                            sf.IdentifierName("beforeRightsCheckAction")))))) :> StatementSyntax ))) :> StatementSyntax
                        sf.ExpressionStatement(
                            sf.AssignmentExpression(
                                sk.SimpleAssignmentExpression,
                                sf.IdentifierName(association.Storage),
                                sf.InvocationExpression(
                                    sf.IdentifierName("GetDbEntityRef"))
                                    .WithArgumentList(
                                        sf.ArgumentList(
                                            sf.SeparatedList(
                                                [|
                                                    sf.Argument(sf.LiteralExpression(sk.TrueLiteralExpression))
                                                    sf.Argument(
                                                        sf.ImplicitArrayCreationExpression(
                                                            sf.InitializerExpression(
                                                                sk.ArrayInitializerExpression,
                                                                sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                    sf.LiteralExpression(
                                                                        sk.StringLiteralExpression,
                                                                        sf.Literal(sqlSquareBrackets association.ThisKey))))))
                                                    sf.Argument(
                                                        sf.ArrayCreationExpression(
                                                            sf.ArrayType(
                                                                sf.GenericName(
                                                                    sf.Identifier("Func"))
                                                                    .WithTypeArgumentList(
                                                                        sf.TypeArgumentList(
                                                                            sf.SingletonSeparatedList<TypeSyntax>(
                                                                                sf.NullableType(
                                                                                    sf.PredefinedType(
                                                                                        sf.Token(sk.LongKeyword)))))))
                                                                .WithRankSpecifiers(
                                                                    sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                        sf.ArrayRankSpecifier(
                                                                            sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                sf.OmittedArraySizeExpression())))))
                                                            .WithInitializer(
                                                                sf.InitializerExpression(
                                                                    sk.ArrayInitializerExpression,
                                                                    sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                        sf.ParenthesizedLambdaExpression(
                                                                            sf.MemberAccessExpression(
                                                                                sk.SimpleMemberAccessExpression,
                                                                                sf.IdentifierName(association.ThisKeyStorage),
                                                                                sf.IdentifierName("Entity")))))))
                                                    sf.Argument(sf.IdentifierName("beforeRightsCheckAction"))
                                                |],
                                                [|
                                                    sf.Token(sk.CommaToken)
                                                    sf.Token(sk.CommaToken)
                                                    sf.Token(sk.CommaToken)
                                                |]
                                                        ))))):> StatementSyntax
                        sf.ReturnStatement(
                            sf.ConditionalExpression(
                                sf.ParenthesizedExpression(
                                    sf.BinaryExpression(
                                        sk.NotEqualsExpression,
                                        sf.IdentifierName(association.Member),
                                        sf.LiteralExpression(
                                            sk.NullLiteralExpression))),
                                sf.InvocationExpression(
                                    sf.MemberAccessExpression(
                                        sk.SimpleMemberAccessExpression,
                                        sf.IdentifierName(association.Storage),
                                        sf.IdentifierName("GetEntity")))
                                        .WithArgumentList(
                                            sf.ArgumentList(
                                                sf.SingletonSeparatedList<ArgumentSyntax>(
                                                    sf.Argument(
                                                        sf.IdentifierName("beforeRightsCheckAction"))))),
                                sf.LiteralExpression(
                                    sk.NullLiteralExpression))) :> StatementSyntax
                    |]))
    let getOtherSideSetMember (association:association) (tableMember:string)=
        match association with
        | fk when association.OtherSideAssociation.IsSome && association.OtherSideAssociation.Value.IsMany -> association.OtherSideAssociation.Value.Member
        | _ -> tableMember

    

    let entityRefSetProperty (table:table) (association:association) =
        let className = table.TypeName
        let classMember = table.Member

        let isOne2One = table.PrimaryKeyColumn.Value.Name = association.ThisKey
        let othersideSetArgument = 
            if isOne2One then
                sf.Argument(sf.LiteralExpression(sk.NullLiteralExpression))
            else
                sf.Argument(
                    sf.SimpleLambdaExpression(
                        sf.Parameter(sf.Identifier("x")),
                        sf.MemberAccessExpression(
                            sk.SimpleMemberAccessExpression,
                            sf.IdentifierName("x"),
                            sf.IdentifierName(getOtherSideSetMember association table.Member))))
                
            
        let othersideEntityArgument =
            if isOne2One then
                sf.Argument(
                    sf.ParenthesizedLambdaExpression(
                        sf.AssignmentExpression(
                            sk.SimpleAssignmentExpression,
                            sf.MemberAccessExpression(
                                sk.SimpleMemberAccessExpression,
                                sf.IdentifierName("x"),
                                sf.IdentifierName(table.TypeName)),
                            sf.IdentifierName("y")))
                            .WithParameterList(
                                sf.ParameterList(
                                    sf.SeparatedList(
                                        [|
                                            sf.Parameter(sf.Identifier("x"))
                                            sf.Parameter(sf.Identifier("y"))
                                        |],
                                        [|
                                            sf.Token(sk.CommaToken)
                                        |]))))
            else
                sf.Argument(sf.LiteralExpression(sk.NullLiteralExpression))
            
        sf.AccessorDeclaration(sk.SetAccessorDeclaration)
            .WithBody(
                sf.Block(
                    [|
                        sf.IfStatement(
                            sf.BinaryExpression(
                                sk.EqualsExpression,
                                sf.IdentifierName(association.Storage),
                                sf.LiteralExpression(
                                    sk.NullLiteralExpression)),
                            sf.Block(
                                sf.SingletonList<StatementSyntax>(
                                    sf.ExpressionStatement(
                                        sf.AssignmentExpression(
                                            sk.SimpleAssignmentExpression,
                                            sf.IdentifierName(association.Storage),
                                            sf.ObjectCreationExpression(
                                                sf.GenericName(
                                                    sf.Identifier("DbEntityRef"))
                                                    .WithTypeArgumentList(
                                                        sf.TypeArgumentList(
                                                            sf.SingletonSeparatedList<TypeSyntax>(
                                                                sf.IdentifierName(association.Type)))))
                                                .WithArgumentList(
                                                    sf.ArgumentList(
                                                        sf.SeparatedList<ArgumentSyntax>(
                                                            [|                                                        
                                                                sf.Argument(sf.IdentifierName("_db"))
                                                                sf.Argument(sf.LiteralExpression(sk.TrueLiteralExpression))
                                                                sf.Argument(
                                                                    sf.ImplicitArrayCreationExpression(
                                                                        sf.InitializerExpression(
                                                                            sk.ArrayInitializerExpression,
                                                                            sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                sf.LiteralExpression(
                                                                                    sk.StringLiteralExpression,
                                                                                    sf.Literal(sqlSquareBrackets association.ThisKey))))))
                                                                sf.Argument(
                                                                    sf.ArrayCreationExpression(
                                                                        sf.ArrayType(
                                                                            sf.GenericName(
                                                                                sf.Identifier("Func"))
                                                                                .WithTypeArgumentList(
                                                                                    sf.TypeArgumentList(
                                                                                        sf.SingletonSeparatedList<TypeSyntax>(
                                                                                            sf.NullableType(
                                                                                                sf.PredefinedType(
                                                                                                    sf.Token(sk.LongKeyword)))))))
                                                                            .WithRankSpecifiers(
                                                                                sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                                    sf.ArrayRankSpecifier(
                                                                                        sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                            sf.OmittedArraySizeExpression())))))
                                                                        .WithInitializer(
                                                                            sf.InitializerExpression(
                                                                                sk.ArrayInitializerExpression,
                                                                                sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                    sf.ParenthesizedLambdaExpression(
                                                                                        sf.MemberAccessExpression(
                                                                                            sk.SimpleMemberAccessExpression,
                                                                                            sf.IdentifierName(association.ThisKeyStorage),
                                                                                            sf.IdentifierName("Entity")))))))                                                           
                                                                sf.Argument(sf.IdentifierName("_lazyLoadChildren"))                                                            
                                                                sf.Argument(sf.IdentifierName("_getChildrenFromCache"))
                                                            |],
                                                            [|
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                            |]
                                                                
                                                                    )))))))) :> StatementSyntax
                        sf.ExpressionStatement(
                            sf.InvocationExpression(
                                sf.GenericName(
                                    sf.Identifier("AssignDbEntity"))
                                    .WithTypeArgumentList(
                                        sf.TypeArgumentList(
                                            sf.SeparatedList<TypeSyntax>(
                                                [|
                                                    sf.IdentifierName(association.Type)
                                                    sf.IdentifierName(className)
                                                |],
                                                [|
                                                    sf.Token(sk.CommaToken)
                                                |]))))
                                .WithArgumentList(
                                    sf.ArgumentList(
                                        sf.SeparatedList<ArgumentSyntax>(
                                            [|
                                                sf.Argument(sf.IdentifierName("value"))
                                                sf.Argument(
                                                    sf.ConditionalExpression(
                                                        sf.BinaryExpression(
                                                            sk.EqualsExpression,
                                                            sf.IdentifierName("value"),
                                                            sf.LiteralExpression(
                                                                sk.NullLiteralExpression)),
                                                        sf.ArrayCreationExpression(
                                                            sf.ArrayType(
                                                                sf.NullableType(
                                                                    sf.PredefinedType(
                                                                        sf.Token(sk.LongKeyword))))
                                                                .WithRankSpecifiers(
                                                                    sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                        sf.ArrayRankSpecifier(
                                                                            sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                sf.LiteralExpression(
                                                                                    sk.NumericLiteralExpression,
                                                                                    sf.Literal(0))))))),
                                                        sf.ArrayCreationExpression(
                                                            sf.ArrayType(
                                                               sf. NullableType(
                                                                    sf.PredefinedType(
                                                                        sf.Token(sk.LongKeyword))))
                                                                .WithRankSpecifiers(
                                                                    sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                        sf.ArrayRankSpecifier(
                                                                            sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                sf.OmittedArraySizeExpression())))))
                                                            .WithInitializer(
                                                                sf.InitializerExpression(
                                                                    sk.ArrayInitializerExpression,
                                                                    sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                        sf.CastExpression(
                                                                            sf.NullableType(
                                                                                sf.PredefinedType(
                                                                                    sf.Token(sk.LongKeyword))),
                                                                            sf.MemberAccessExpression(
                                                                                sk.SimpleMemberAccessExpression,
                                                                                sf.IdentifierName("value"),
                                                                                sf.IdentifierName(association.OtherKey))))))))
                                                sf.Argument(sf.IdentifierName(association.Storage))
                                                sf.Argument(
                                                    sf.ArrayCreationExpression(
                                                        sf.ArrayType(
                                                            sf.NullableType(
                                                                sf.PredefinedType(
                                                                    sf.Token(sk.LongKeyword))))
                                                            .WithRankSpecifiers(
                                                                sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                    sf.ArrayRankSpecifier(
                                                                        sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                            sf.OmittedArraySizeExpression())))))
                                                        .WithInitializer(
                                                            sf.InitializerExpression(
                                                                sk.ArrayInitializerExpression,
                                                                sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                    sf.MemberAccessExpression(
                                                                        sk.SimpleMemberAccessExpression,
                                                                        sf.IdentifierName(association.ThisKeyStorage),
                                                                        sf.IdentifierName("Entity"))))))
                                                sf.Argument(
                                                    sf.ArrayCreationExpression(
                                                        sf.ArrayType(
                                                            sf.GenericName(sf.Identifier("Action"))
                                                                .WithTypeArgumentList(
                                                                    sf.TypeArgumentList(
                                                                        sf.SingletonSeparatedList<TypeSyntax>(
                                                                            sf.NullableType(
                                                                                sf.PredefinedType(
                                                                                    sf.Token(sk.LongKeyword)))))))
                                                            .WithRankSpecifiers(
                                                                sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                    sf.ArrayRankSpecifier(
                                                                        sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                            sf.OmittedArraySizeExpression())))))
                                                        .WithInitializer(
                                                            sf.InitializerExpression(
                                                                sk.ArrayInitializerExpression,
                                                                sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                    sf.SimpleLambdaExpression(
                                                                        sf.Parameter(sf.Identifier("x")),
                                                                        sf.AssignmentExpression(
                                                                            sk.SimpleAssignmentExpression,
                                                                            sf.IdentifierName(association.ThisKey),
                                                                            sf.BinaryExpression(
                                                                                sk.CoalesceExpression,
                                                                                sf.CastExpression(
                                                                                    sf.NullableType(
                                                                                        sf.PredefinedType(
                                                                                            sf.Token(sk.IntKeyword))),
                                                                                    sf.IdentifierName("x")),
                                                                                sf.DefaultExpression(
                                                                                    sf.PredefinedType(
                                                                                        sf.Token(sk.IntKeyword))))))))))
                                                othersideSetArgument
                                                othersideEntityArgument
                                                sf.Argument(sf.IdentifierName(String.Format("{0}Changed", association.ThisKey)))
                                                    
                                            |],
                                            [|
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                                sf.Token(sk.CommaToken)
                                            |]
                                                    
                                                    
                                                    )))) :> StatementSyntax
                    |]))
    let entitySetGetProperty (className:string) (primaryKeyColumnStorage:string) (association:association) =
        let parentEntity = 
            if association.OtherSideAssociation.IsSome then 
               association.OtherSideAssociation.Value.Member
            else
                className
            
    
        sf.AccessorDeclaration(sk.GetAccessorDeclaration)
            .WithBody(
                sf.Block(
                    [|
                        sf.IfStatement(
                            sf.BinaryExpression(sk.EqualsExpression, sf.IdentifierName(association.Storage), sf.LiteralExpression(sk.NullLiteralExpression)),
                            sf.Block(
                                [|
                                    sf.IfStatement(
                                        sf.IdentifierName("_getChildrenFromCache"),
                                        sf.Block(
                                            [|
                                                sf.ExpressionStatement(
                                                    sf.AssignmentExpression(
                                                        sk.SimpleAssignmentExpression, 
                                                        sf.IdentifierName(association.Storage),
                                                        sf.ObjectCreationExpression(
                                                            sf.GenericName(
                                                                sf.Identifier("DbEntitySetCached"))
                                                                .WithTypeArgumentList(
                                                                    sf.TypeArgumentList(
                                                                        sf.SeparatedList(
                                                                            [|
                                                                                sf.IdentifierName(className)
                                                                                sf.IdentifierName(association.Type)
                                                                            |],
                                                                            [|
                                                                                sf.Token(sk.CommaToken)
                                                                            |]))))
                                                            .WithArgumentList(
                                                                sf.ArgumentList(
                                                                    sf.SingletonSeparatedList<ArgumentSyntax>(
                                                                        sf.Argument(
                                                                            sf.ParenthesizedLambdaExpression(
                                                                                sf.MemberAccessExpression(
                                                                                    sk.SimpleMemberAccessExpression,
                                                                                    sf.IdentifierName(primaryKeyColumnStorage),
                                                                                    sf.IdentifierName("Entity")))
                                                                    )))))
                                                ) :> StatementSyntax
                                            |]
                                        )) :> StatementSyntax
                                |]))
                            .WithElse(
                                sf.ElseClause(
                                    sf.ExpressionStatement(
                                        sf.AssignmentExpression(
                                            sk.SimpleAssignmentExpression,
                                            sf.IdentifierName(association.Storage),
                                            sf.ObjectCreationExpression(
                                                sf.GenericName(sf.Identifier("DbEntitySet"))
                                                    .WithTypeArgumentList(
                                                        sf.TypeArgumentList(
                                                            sf.SingletonSeparatedList<TypeSyntax>(
                                                                sf.IdentifierName(association.Type)))))
                                                .WithArgumentList(
                                                    sf.ArgumentList(
                                                        sf.SeparatedList<ArgumentSyntax>(
                                                            [|
                                                                sf.Argument(sf.IdentifierName("_db"))
                                                                sf.Argument(sf.LiteralExpression(sk.FalseLiteralExpression))
                                                                sf.Argument(
                                                                    sf.ArrayCreationExpression(
                                                                        sf.ArrayType(
                                                                            sf.GenericName(sf.Identifier("Func"))
                                                                                .WithTypeArgumentList(
                                                                                    sf.TypeArgumentList(
                                                                                        sf.SingletonSeparatedList<TypeSyntax>(
                                                                                            sf.NullableType(
                                                                                                sf.PredefinedType(
                                                                                                    sf.Token(sk.LongKeyword)))))))
                                                                            .WithRankSpecifiers(
                                                                                sf.SingletonList<ArrayRankSpecifierSyntax>(
                                                                                    sf.ArrayRankSpecifier(
                                                                                        sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                            sf.OmittedArraySizeExpression())))))
                                                                        .WithInitializer(
                                                                            sf.InitializerExpression(
                                                                                sk.ArrayInitializerExpression,
                                                                                sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                    sf.ParenthesizedLambdaExpression(
                                                                                        sf.MemberAccessExpression(
                                                                                            sk.SimpleMemberAccessExpression,
                                                                                            sf.IdentifierName(primaryKeyColumnStorage),
                                                                                            sf.IdentifierName("Entity")))))))
                                                                sf.Argument(
                                                                    sf.ImplicitArrayCreationExpression(
                                                                        sf.InitializerExpression(
                                                                            sk.ArrayInitializerExpression,
                                                                            sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                sf.LiteralExpression(
                                                                                    sk.StringLiteralExpression,
                                                                                    sf.Literal(sqlSquareBrackets association.OtherKey))))))
                                                                sf.Argument(
                                                                    sf.ParenthesizedLambdaExpression(
                                                                        sf.AssignmentExpression(
                                                                            sk.SimpleAssignmentExpression,
                                                                            sf.MemberAccessExpression(
                                                                                sk.SimpleMemberAccessExpression,
                                                                                sf.IdentifierName("member"),
                                                                                // nur bei to one?
                                                                                sf.IdentifierName(parentEntity)),
                                                                            sf.BinaryExpression(
                                                                                sk.AsExpression,
                                                                                sf.IdentifierName("root"),
                                                                                sf.IdentifierName(className))))
                                                                        .WithParameterList(
                                                                            sf.ParameterList(
                                                                                sf.SeparatedList<ParameterSyntax>(
                                                                                    [|
                                                                                        sf.Parameter(sf.Identifier("member"))
                                                                                        sf.Parameter(sf.Identifier("root"))
                                                                                    |],
                                                                                    [|
                                                                                        sf.Token(sk.CommaToken)
                                                                                    |]))))
                                                                sf.Argument(
                                                                    sf.ThisExpression())
                                                                sf.Argument(
                                                                    sf.IdentifierName("_lazyLoadChildren"))


                                                                (if association.OtherSideAssociation.IsSome && association.OtherSideAssociation.Value.IsMany then
                                                                    sf.Argument(
                                                                        sf.SimpleLambdaExpression(
                                                                           sf. Parameter(
                                                                                sf.Identifier("e")),
                                                                            sf.AssignmentExpression(
                                                                                sk.SimpleAssignmentExpression,
                                                                                sf.MemberAccessExpression(
                                                                                    sk.SimpleMemberAccessExpression,
                                                                                    sf.IdentifierName("e"),
                                                                                    sf.IdentifierName(parentEntity)),
                                                                                sf.IdentifierName(association.OtherSideAssociation.Value.Member))))
                                                                else
                                                                    sf.Argument(
                                                                        sf.SimpleLambdaExpression(
                                                                           sf. Parameter(
                                                                                sf.Identifier("e")),
                                                                            sf.AssignmentExpression(
                                                                                sk.SimpleAssignmentExpression,
                                                                                sf.MemberAccessExpression(
                                                                                    sk.SimpleMemberAccessExpression,
                                                                                    sf.IdentifierName("e"),
                                                                                    sf.IdentifierName(parentEntity)),
                                                                                sf.ThisExpression())))
                                                                )
                                                                sf.Argument(
                                                                    sf.SimpleLambdaExpression(
                                                                        sf.Parameter(
                                                                            sf.Identifier("e")),
                                                                        sf.Block(
                                                                            sf.LocalDeclarationStatement(
                                                                                sf.VariableDeclaration(
                                                                                    sf.IdentifierName("var"))
                                                                                    .WithVariables(
                                                                                        sf.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                                                            sf.VariableDeclarator(
                                                                                                sf.Identifier("x"))
                                                                                                .WithInitializer(
                                                                                                    sf.EqualsValueClause(
                                                                                                        sf.MemberAccessExpression(
                                                                                                            sk.SimpleMemberAccessExpression,
                                                                                                            sf.IdentifierName("e"),
                                                                                                            sf.IdentifierName(parentEntity))))))),
                                                                                                            
                                                                            sf.ExpressionStatement(
                                                                                sf.AssignmentExpression(
                                                                                    sk.SimpleAssignmentExpression,
                                                                                    sf.MemberAccessExpression(
                                                                                        sk.SimpleMemberAccessExpression,
                                                                                        sf.IdentifierName("e"),
                                                                                        sf.IdentifierName(parentEntity)),
                                                                                    sf.LiteralExpression(
                                                                                        sk.NullLiteralExpression))),
                                                                            sf.ExpressionStatement(
                                                                                sf.InvocationExpression(
                                                                                    sf.MemberAccessExpression(
                                                                                        sk.SimpleMemberAccessExpression,
                                                                                        sf.ObjectCreationExpression(
                                                                                            sf.IdentifierName("UpdateSetVisitor"))
                                                                                            .WithArgumentList(
                                                                                                sf.ArgumentList(
                                                                                                    sf.SeparatedList<ArgumentSyntax>(
                                                                                                        [|
                                                                                                            sf.Argument(
                                                                                                                sf.LiteralExpression(
                                                                                                                    sk.TrueLiteralExpression))
                                                                                                            sf.Argument(
                                                                                                                sf.ImplicitArrayCreationExpression(
                                                                                                                   sf. InitializerExpression(
                                                                                                                        sk.ArrayInitializerExpression,
                                                                                                                        sf.SingletonSeparatedList<ExpressionSyntax>(
                                                                                                                            sf.LiteralExpression(
                                                                                                                                sk.StringLiteralExpression,
                                                                                                                                sf.Literal(association.OtherKey))))))
                                                                                                            sf.Argument(
                                                                                                               sf. LiteralExpression(
                                                                                                                    sk.FalseLiteralExpression))
                                                                                                        |],
                                                                                                        [|
                                                                                                            sf.Token(sk.CommaToken)
                                                                                                            sf.Token(sk.CommaToken)
                                                                                                        |]))),
                                                                                        sf.IdentifierName("Process")))
                                                                                    .WithArgumentList(
                                                                                        sf.ArgumentList(
                                                                                            sf.SingletonSeparatedList<ArgumentSyntax>(
                                                                                                sf.Argument(
                                                                                                    sf.IdentifierName("x")))))))))
                                                                                                
                                                            |],
                                                            [|
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                                sf.Token(sk.CommaToken)
                                                            |]))))))) :> StatementSyntax
                        sf.ReturnStatement(sf.IdentifierName(association.Storage)) :> StatementSyntax
                    |]))
    //sf.AccessorDeclaration(sk.SetAccessorDeclaration).WithBody(
    //    sf.Block(
    //        sf.SingletonList<StatementSyntax>(
    //            sf.ExpressionStatement(
    //                sf.AssignmentExpression(sk.SimpleAssignmentExpression, sf.IdentifierName(association.Storage), sf.IdentifierName("value"))
    //            )
    //        )
    //    )
    //)
    let setOrRefProperty (table:table) (primaryKeyColumnStorage:string) (association:association) =
        match association.IsMany with
        | true ->
            [| 
                entitySetGetProperty table.TypeName primaryKeyColumnStorage association
            |]
        | false -> 
            [|                
                entityRefGetProperty table association
                entityRefSetProperty table association
            |]
    let propertyDeclaration (table:table) (primaryKeyColumn:column) (association:association) = //(association:association) =
        let pd =
                match association.IsMany with
                | true ->
                    sf.PropertyDeclaration(
                        sf.GenericName(sf.Identifier(genericAssociationClass association))
                            .AddTypeArgumentListArguments(sf.IdentifierName(association.Type)), sf.Identifier(association.Member))
                | false ->
                    sf.PropertyDeclaration(
                        sf.IdentifierName(association.Type),
                        sf.Identifier(association.Member))

        pd
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddAttributeLists(validateAttribute.Value)
            .AddAccessorListAccessors(setOrRefProperty table primaryKeyColumn.Storage association) :> MemberDeclarationSyntax
    let propertyChangedMethod (association:association) =
        match association.IsMany with
        | true -> None
        | false ->
            Some(
                sf.MethodDeclaration(
                    sf.PredefinedType(sf.Token(sk.VoidKeyword)),sf.Identifier(String.Format("{0}Changed", association.ThisKey)))
                    .WithParameterList(
                        sf.ParameterList(
                            sf.SeparatedList<ParameterSyntax>(
                                [|
                                    sf.Parameter(sf.Identifier("sender"))
                                        .WithType(
                                            sf.PredefinedType(
                                                sf.Token(sk.ObjectKeyword)))
                                    sf.Parameter(sf.Identifier("eventArgs"))
                                        .WithType(sf.IdentifierName("EventArgs"))
                                |],
                                [|
                                    sf.Token(sk.CommaToken)
                                |])))
                    .WithBody(
                        sf.Block(
                            sf.SingletonList<StatementSyntax>(
                                sf.IfStatement(
                                    sf.BinaryExpression(
                                        sk.IsExpression,
                                        sf.IdentifierName("sender"),
                                        sf.IdentifierName(association.Type)),
                                    sf.ExpressionStatement(
                                        sf.AssignmentExpression(
                                            sk.SimpleAssignmentExpression,
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.IdentifierName(association.ThisKeyStorage),
                                                sf.IdentifierName("Entity")),
                                            sf.CastExpression(
                                                sf.PredefinedType(
                                                    sf.Token(sk.IntKeyword)),
                                                sf.MemberAccessExpression(
                                                    sk.SimpleMemberAccessExpression,
                                                    sf.ParenthesizedExpression(
                                                        sf.CastExpression(
                                                            sf.IdentifierName(association.Type),
                                                            sf.IdentifierName("sender"))),
                                                    sf.IdentifierName("Id"))))))))) :> MemberDeclarationSyntax)
                                                    //sf.IdentifierName(association.OtherKeyStorage))))))))) :> MemberDeclarationSyntax
    let associationProperties (table:table) =
        match table.PrimaryKeyColumn with
        | None -> Array.empty
        | Some primaryKeyColumn ->
            table.Associations
                |> Array.map (fun association ->
                    [|
                        Some(propertyDeclaration table primaryKeyColumn association)
                        propertyChangedMethod association
                    |])
                |> Array.collect id
                |> Array.filter (fun x -> x.IsSome)
                |> Array.map (fun x -> x.Value)
    let columnProperties (columns:column[]) =
        columns |> Array.map (fun column -> 
            sf.PropertyDeclaration(sf.ParseTypeName(column.Type), column.Member)
                .WithAttributeLists(sf.List(propertyAttributes column))
                .AddModifiers(sf.Token(sk.PublicKeyword))
                .AddAccessorListAccessors(
                    [|
                        sf.AccessorDeclaration(sk.GetAccessorDeclaration).WithBody(sf.Block(sf.ReturnStatement(sf.ParseExpression(String.Format("{0}.Entity", column.Storage)))))
                        sf.AccessorDeclaration(sk.SetAccessorDeclaration).WithBody(
                            sf.Block(sf.SingletonList<StatementSyntax>(
                                        sf.ExpressionStatement(
                                            sf.AssignmentExpression(sk.SimpleAssignmentExpression, sf.IdentifierName(String.Format("{0}.Entity", column.Storage)), sf.IdentifierName("value"))))))
                    |]) :> MemberDeclarationSyntax)

    let properties (table:table) =
        Array.append 
            (columnProperties table.Columns)
            (associationProperties table)
    let IIdProperties (table:table) =
    
        let longId = 
            sf.PropertyDeclaration(
                sf.PredefinedType(sf.Token(sk.LongKeyword)),
                        sf.Identifier("Id"))
                    .WithExplicitInterfaceSpecifier(
                        sf.ExplicitInterfaceSpecifier(
                            sf.IdentifierName("ILongId")))
                    .WithExpressionBody(
                        sf.ArrowExpressionClause(
                            sf.IdentifierName(table.PrimaryKeyColumn.Value.Name)))
                    .WithSemicolonToken(
                        sf.Token(sk.SemicolonToken)) :> MemberDeclarationSyntax
        let id = 
            sf.PropertyDeclaration(
                    sf.PredefinedType(
                        sf.Token(sk.IntKeyword)),
                        sf.Identifier("Id"))
                    .WithModifiers(sf.TokenList(sf.Token(sk.PublicKeyword)))
                    .WithExpressionBody(
                        sf.ArrowExpressionClause(
                            sf.IdentifierName(table.PrimaryKeyColumn.Value.Name)))
                    .WithSemicolonToken(sf.Token(sk.SemicolonToken)) :> MemberDeclarationSyntax
                    
        match table.PrimaryKeyColumn.Value with
        | pk when pk.CompileType = typeof<int64> && pk.Name = "Id" -> Array.empty
        | pk when pk.CompileType = typeof<int64> -> [| longId |] 
        | pk when pk.Name = "Id" -> [| longId |] 
        | _ -> [| id; longId |]