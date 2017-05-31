module WrapperClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    type QueryElColumn = { queryElMemberIdentifier:string; queryElMemberType:string; fieldName:string }

    let wrapperInstance (className:string) =
        let wrapperName = String.Format("{0}Wrapper", className)
        sf.FieldDeclaration(
            sf.VariableDeclaration(
                sf.IdentifierName(wrapperName))
                .WithVariables(
                    sf.SingletonSeparatedList(
                        sf.VariableDeclarator(
                            sf.Identifier("Instance"))
                            .WithInitializer(
                                sf.EqualsValueClause(
                                    sf.ObjectCreationExpression(
                                        sf.IdentifierName(wrapperName))
                                        .WithArgumentList(sf.ArgumentList()))))))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(SyntaxKind.PublicKeyword)
                        sf.Token(SyntaxKind.StaticKeyword)
                        sf.Token(SyntaxKind.ReadOnlyKeyword)
                    |])) :> MemberDeclarationSyntax
                    
    let getQueryElMemberTypeNonFk (isNullableType:bool) = 
        match isNullableType with
        | true -> "QueryElMember"
        | false -> "QueryElMemberStruct"


    let getQueryElMemberTypeFk (isNullableType:bool) (compileType: Type)  = 
        match (isNullableType, compileType) with
        | (true, _) when compileType = typeof<int64> -> "QueryElMemberLongNullableId"
        | (false, _) when compileType = typeof<int64> -> "QueryElMemberLongId"
        | (true, _) -> "QueryElMemberNullableId"
        | (false, _) -> "QueryElMemberId"
         

    let queryElMembers (columns:QueryElColumn[]) = 
        columns
            |> Array.map (fun x -> 
                sf.FieldDeclaration(
                    sf.VariableDeclaration(
                        sf.GenericName(
                            sf.Identifier(x.queryElMemberIdentifier))
                            .WithTypeArgumentList(
                                sf.TypeArgumentList(
                                    sf.SingletonSeparatedList(
                                        sf.IdentifierName(x.queryElMemberType) :> TypeSyntax))))
                        .WithVariables(
                            sf.SingletonSeparatedList(
                                sf.VariableDeclarator(sf.Identifier(x.fieldName))
                                    .WithInitializer(
                                        sf.EqualsValueClause(
                                            sf.ObjectCreationExpression(
                                                sf.GenericName(sf.Identifier(x.queryElMemberIdentifier))
                                                    .WithTypeArgumentList(
                                                        sf.TypeArgumentList(
                                                            sf.SingletonSeparatedList(
                                                                sf.IdentifierName(x.queryElMemberType) :> TypeSyntax))))
                                                .WithArgumentList(
                                                    sf.ArgumentList(
                                                        sf.SingletonSeparatedList(
                                                            sf.Argument(
                                                                sf.LiteralExpression(
                                                                    sk.StringLiteralExpression,
                                                                    sf.Literal(x.fieldName)))))))))))
                        .WithModifiers(
                            sf.TokenList(
                                [|
                                    sf.Token(sk.PublicKeyword)
                                    sf.Token(sk.ReadOnlyKeyword)
                                |])) :> MemberDeclarationSyntax)
    
    let queryElMemberFields (table:table) =
        let wrapperName = String.Format("{0}Wrapper", table.TypeName)
        
        let nonForeignKeyColumns = 
            table.NonForeignKeyColumns 
                |> Array.map (fun column ->
                    {
                        queryElMemberIdentifier = getQueryElMemberTypeNonFk column.IsNullableType;
                        queryElMemberType = column.Type ;
                        fieldName = column.Member
                    })
        
        let foreignKeyColumns = 
            table.ForeignKeyColumns 
                |> Array.map (fun fk ->
                    {
                        queryElMemberIdentifier =  getQueryElMemberTypeFk fk.Column.IsNullableType fk.Column.CompileType;
                        queryElMemberType = fk.Association.Type;
                        fieldName = fk.Column.Member
                    })
        
        queryElMembers <| Array.append foreignKeyColumns nonForeignKeyColumns
             
    let getFields (table:table) = 
        Array.append 
            (queryElMemberFields table)
            [|
                wrapperInstance table.TypeName
            |]
    let getBaseTypes (table:table) =
        let t = table.PrimaryKeyColumn.Value.CompileType
        let baseTypeIdentifier =
            match t with
            | _ when t = typeof<int64> -> "QueryLongWrapper"
            | _ when t = typeof<int> -> "QueryWrapper"
            | _  -> raise(NotSupportedException("only int32 and int64 primary keys supportet"))
        
        [|
            sf.SimpleBaseType(
                sf.GenericName(
                    sf.Identifier(baseTypeIdentifier))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SingletonSeparatedList(
                                sf.IdentifierName(table.TypeName) :> TypeSyntax
                    )))) :> BaseTypeSyntax
        |]
    let getConstructor (table:table) (className:string) =
        sf.ConstructorDeclaration(className)
            .AddModifiers(sf.Token(sk.PrivateKeyword))
            .WithInitializer(
                sf.ConstructorInitializer(
                    sk.BaseConstructorInitializer,
                    sf.ArgumentList(
                        sf.SeparatedList(
                            [|
                                sf.Argument(
                                    sf.LiteralExpression(
                                        sk.StringLiteralExpression,
                                        sf.Literal(table.Name.WithSquareBrackets)))
                                sf.Argument(
                                    sf.LiteralExpression(
                                        sk.StringLiteralExpression,
                                        sf.Literal(table.TypeName)))
                            |],
                            [|
                                sf.Token(sk.CommaToken)
                            |]))))
            .WithBody(sf.Block()) :> MemberDeclarationSyntax
            

    let getWrapperClass (table:table) = 
        let className = String.Format("{0}Wrapper", table.TypeName)
        sf.ClassDeclaration(className)
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddBaseListTypes(getBaseTypes table)
            .AddMembers(getFields table)
            .AddMembers(getConstructor table className)
            //.AddMembers(insertStatementField table)
            //.AddMembers(fillInsertCommandMethod table)
            //.AddMembers(executeInsertCommand table)
            //.AddMembers(wrapperInstance table)
            //.AddMembers(wrapperProperty table)
            
            //.AddMembers(queryMethods table)
            
            :> MemberDeclarationSyntax 