module QueryClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let queryBaseTypes (typeName:string) =
        [|
            sf.SimpleBaseType(
                sf.GenericName(
                    sf.Identifier("Query"))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SeparatedList(
                                [|
                                    sf.IdentifierName("K")
                                    sf.IdentifierName("T")
                                    sf.IdentifierName(typeName)
                                    sf.IdentifierName(String.Format("{0}Wrapper", typeName))
                                    sf.GenericName(
                                        sf.Identifier(String.Format("{0}Query", typeName)))
                                        .WithTypeArgumentList(
                                            sf.TypeArgumentList(
                                                sf.SeparatedList(
                                                    [|
                                                        sf.IdentifierName("K")
                                                        sf.IdentifierName("T")
                                                    |],
                                                    [|
                                                        sf.Token(sk.CommaToken)
                                                    |]
                                                )))
                                |],
                                [|
                                    sf.Token(sk.CommaToken)
                                    sf.Token(sk.CommaToken)
                                    sf.Token(sk.CommaToken)
                                    sf.Token(sk.CommaToken)
                                |]
                    )))) :> BaseTypeSyntax
        |]
    let queryClassConstraints =
        [|
            sf.TypeParameterConstraintClause(sf.IdentifierName("K")).WithConstraints(sf.SingletonSeparatedList(sf.TypeConstraint(sf.IdentifierName("QueryBase")) :> TypeParameterConstraintSyntax))
            sf.TypeParameterConstraintClause(sf.IdentifierName("T"))
                .WithConstraints(
                    sf.SeparatedList(
                        [|
                            sf.TypeConstraint(sf.IdentifierName("DbEntity")) :> TypeParameterConstraintSyntax
                            sf.TypeConstraint(sf.IdentifierName("ILongId")) :> TypeParameterConstraintSyntax
                        |],
                        [|
                            sf.Token(sk.CommaToken)
                        |]))
        |]

    let getQueryConstructor (table:table) =
        sf.ConstructorDeclaration(String.Format("{0}Query", table.TypeName))
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddParameterListParameters(sf.Parameter(sf.Identifier("db")).WithType(sf.IdentifierName("IDb")))
            .WithInitializer(
            sf.ConstructorInitializer(
                sk.BaseConstructorInitializer,
                sf.ArgumentList(sf.SingletonSeparatedList(sf.Argument(sf.IdentifierName("db"))))))
            .WithBody(sf.Block())

    let returnJoinSet (className:string) (association:association) =
        let x = association.OtherTableName.WithSquareBrackets
        sf.ReturnStatement(
            sf.InvocationExpression(
                sf.IdentifierName("JoinSet"))
                .WithArgumentList(
                    sf.ArgumentList(
                        sf.SeparatedList(
                            [|
                                sf.Argument(
                                    sf.ParenthesizedLambdaExpression(
                                        sf.ObjectCreationExpression(
                                            sf.GenericName(
                                                sf.Identifier(String.Format("{0}TableQuery", association.Type)))
                                                .WithTypeArgumentList(
                                                    sf.TypeArgumentList(
                                                        sf.SingletonSeparatedList(
                                                            sf.IdentifierName(association.Type) :> TypeSyntax))))
                                            .WithArgumentList(
                                                sf.ArgumentList(
                                                    sf.SingletonSeparatedList(
                                                        sf.Argument(sf.IdentifierName("Db")))))))

                                sf.Argument(sf.IdentifierName("joinedQuery"))
                                sf.Argument(
                                    sf.InvocationExpression(
                                        sf.MemberAccessExpression(
                                            sk.SimpleMemberAccessExpression,
                                            sf.PredefinedType(sf.Token(sk.StringKeyword)),
                                            sf.IdentifierName("Concat")))
                                        .WithArgumentList(
                                            sf.ArgumentList(
                                                sf.SeparatedList(
                                                    [|
                                                        sf.Argument(
                                                            sf.InvocationExpression(
                                                                sf.MemberAccessExpression(
                                                                    sk.SimpleMemberAccessExpression,
                                                                    sf.IdentifierName("joinType"),
                                                                    sf.IdentifierName("GetJoinString"))))
                                                        sf.Argument(
                                                            sf.LiteralExpression(
                                                                sk.StringLiteralExpression,
                                                                sf.Literal(String.Format(" {0} AS {{1}} {{0}} ON", association.OtherTableName.WithSquareBrackets))))
                                                        sf.Argument(
                                                            sf.LiteralExpression(
                                                                sk.StringLiteralExpression,
                                                                sf.Literal(String.Format("{{2}}.[{0}] = {{1}}.[{1}]", association.ThisKey, association.OtherKey ))))
                                                    |],
                                                    [|
                                                        sf.Token(sk.CommaToken)
                                                        sf.Token(sk.CommaToken)
                                                    |]
                                                ))))
                                sf.Argument(
                                    sf.ParenthesizedLambdaExpression(
                                        sf.InvocationExpression(
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.MemberAccessExpression(
                                                    sk.SimpleMemberAccessExpression,
                                                    sf.ParenthesizedExpression(
                                                        sf.CastExpression(
                                                            sf.IdentifierName(String.Format("{0}Wrapper", association.Type)),
                                                            sf.IdentifierName("p"))),
                                                    sf.IdentifierName("Id")),
                                                sf.IdentifierName("In")))
                                            .WithArgumentList(
                                                sf.ArgumentList(
                                                    sf.SingletonSeparatedList(
                                                        sf.Argument(
                                                            sf.InvocationExpression(
                                                                sf.MemberAccessExpression(
                                                                    sk.SimpleMemberAccessExpression,
                                                                    sf.IdentifierName("ids"),
                                                                    sf.IdentifierName("Select")))
                                                                .WithArgumentList(
                                                                    sf.ArgumentList(
                                                                        sf.SingletonSeparatedList(
                                                                            sf.Argument(
                                                                                sf.SimpleLambdaExpression(
                                                                                    sf.Parameter(sf.Identifier("id")),
                                                                                    sf.CastExpression(
                                                                                        sf.QualifiedName(
                                                                                            sf.IdentifierName("System"),
                                                                                            sf.IdentifierName("Int32")),
                                                                                        sf.IdentifierName("id"))))))))))))
                                        .WithParameterList(
                                            sf.ParameterList(
                                                sf.SeparatedList(
                                                    [|
                                                        sf.Parameter(sf.Identifier("p"))
                                                        sf.Parameter(sf.Identifier("ids"))
                                                    |],
                                                    [|
                                                        sf.Token(sk.CommaToken)
                                                    |]
                                                )
                                            )))
                                sf.Argument(
                                    sf.ParenthesizedLambdaExpression(
                                        sf.InvocationExpression(
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.MemberAccessExpression(
                                                    sk.SimpleMemberAccessExpression,
                                                    sf.ParenthesizedExpression(
                                                        sf.CastExpression(
                                                            sf.IdentifierName(className),
                                                            sf.IdentifierName("o"))),
                                                     sf.IdentifierName(association.Member)),
                                                 sf.IdentifierName("Attach")))
                                             .WithArgumentList(
                                                sf.ArgumentList(
                                                    sf.SingletonSeparatedList(
                                                        sf.Argument(
                                                            sf.InvocationExpression(
                                                                sf.MemberAccessExpression(
                                                                    sk.SimpleMemberAccessExpression,
                                                                    sf.IdentifierName("v"),
                                                                    sf.GenericName(
                                                                        sf.Identifier("Cast"))
                                                                        .WithTypeArgumentList(
                                                                            sf.TypeArgumentList(
                                                                                sf.SingletonSeparatedList(
                                                                                    sf.IdentifierName(association.Type) :> TypeSyntax))))))))))
                                        .WithParameterList(
                                            sf.ParameterList(
                                                sf.SeparatedList(
                                                    [|
                                                        sf.Parameter(sf.Identifier("o"))
                                                        sf.Parameter(sf.Identifier("v"))
                                                    |],
                                                    [|
                                                        sf.Token(sk.CommaToken)
                                                    |]
                                                ))
                                        ))
                                sf.Argument(
                                    sf.SimpleLambdaExpression(
                                        sf.Parameter(sf.Identifier("p")),
                                        sf.CastExpression(
                                            sf.PredefinedType(sf.Token(sk.LongKeyword)),
                                            sf.MemberAccessExpression(
                                                sk.SimpleMemberAccessExpression,
                                                sf.ParenthesizedExpression(
                                                    sf.CastExpression(
                                                        sf.IdentifierName(association.Type),
                                                        sf.IdentifierName("p"))),
                                                    sf.IdentifierName(association.OtherKey)))))
                                sf.Argument(sf.IdentifierName("attach"))
                            |],
                            [|
                                sf.Token(sk.CommaToken)
                                sf.Token(sk.CommaToken)
                                sf.Token(sk.CommaToken)
                                sf.Token(sk.CommaToken)
                                sf.Token(sk.CommaToken)
                                sf.Token(sk.CommaToken)
                            |]
                        )))) :> StatementSyntax
    let returnJoin (className:string) (association:association) =
        sf.ReturnStatement(
            sf.InvocationExpression(sf.IdentifierName("Join"))
                .WithArgumentList(
                    sf.ArgumentList(
                        sf.SeparatedList<ArgumentSyntax>(
                            [|
                                sf.Argument(
                                    sf.IdentifierName("joinedQuery"))
                                sf.Argument(
                                    sf.InvocationExpression(
                                        sf.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            sf.PredefinedType(
                                                sf.Token(SyntaxKind.StringKeyword)),
                                            sf.IdentifierName("Concat")))
                                        .WithArgumentList(
                                            sf.ArgumentList(
                                                sf.SeparatedList<ArgumentSyntax>(
                                                    [|
                                                        sf.Argument(
                                                            sf.InvocationExpression(
                                                                sf.MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    sf.IdentifierName("joinType"),
                                                                    sf.IdentifierName("GetJoinString"))))
                                                        sf.Argument(
                                                            sf.LiteralExpression(
                                                                SyntaxKind.StringLiteralExpression,
                                                                sf.Literal(String.Format(" {0} AS {{1}} {{0}} ON", association.OtherTableName.WithSquareBrackets))))
                                                        sf.Argument(
                                                            sf.LiteralExpression(
                                                                SyntaxKind.StringLiteralExpression,
                                                                sf.Literal(String.Format("{{2}}.[{0}] = {{1}}.[{1}]", association.ThisKey, association.OtherKey ))))
                                                    |],
                                                    [|
                                                        sf.Token(SyntaxKind.CommaToken)
                                                        sf.Token(SyntaxKind.CommaToken)
                                                    |]))))
                                sf.Argument(
                                    sf.SimpleLambdaExpression(
                                        sf.Parameter(sf.Identifier("o")),
                                        sf.ConditionalAccessExpression(
                                            sf.ParenthesizedExpression(
                                                sf.CastExpression(
                                                    sf.IdentifierName(className),
                                                    sf.IdentifierName("o"))),
                                            sf.MemberBindingExpression(
                                                sf.IdentifierName(association.Member)))))
                                sf.Argument(
                                    sf.ParenthesizedLambdaExpression(
                                        sf.Block(
                                            [|
                                                sf.LocalDeclarationStatement(
                                                    sf.VariableDeclaration(
                                                        sf.IdentifierName("var"))
                                                        .WithVariables(
                                                            sf.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                                sf.VariableDeclarator(sf.Identifier("child"))
                                                                    .WithInitializer(
                                                                        sf.EqualsValueClause(
                                                                            sf.CastExpression(
                                                                                sf.IdentifierName(association.Type),
                                                                                sf.InvocationExpression(sf.IdentifierName("ppe"))
                                                                                    .WithArgumentList(
                                                                                        sf.ArgumentList(
                                                                                            sf.SingletonSeparatedList<ArgumentSyntax>(
                                                                                                sf.Argument(
                                                                                                    sf.InvocationExpression(
                                                                                                        sf.MemberAccessExpression(
                                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                                            sf.IdentifierName("QueryHelpers"),
                                                                                                            sf.GenericName(sf.Identifier("Fill"))
                                                                                                                .WithTypeArgumentList(
                                                                                                                    sf.TypeArgumentList(
                                                                                                                        sf.SingletonSeparatedList<TypeSyntax>(
                                                                                                                            sf.IdentifierName(association.Type))))))
                                                                                                        .WithArgumentList(
                                                                                                            sf.ArgumentList(
                                                                                                                sf.SeparatedList<ArgumentSyntax>(
                                                                                                                    [|
                                                                                                                        sf.Argument(sf.LiteralExpression(SyntaxKind.NullLiteralExpression))
                                                                                                                        sf.Argument(sf.IdentifierName("fv"))
                                                                                                                    |],
                                                                                                                    [|
                                                                                                                        sf.Token(SyntaxKind.CommaToken)
                                                                                                                    |]))))))))))))) :> StatementSyntax
                                                sf.IfStatement(
                                                    sf.BinaryExpression(
                                                        SyntaxKind.NotEqualsExpression,
                                                        sf.IdentifierName("e"),
                                                        sf.LiteralExpression(
                                                            SyntaxKind.NullLiteralExpression)),
                                                    sf.Block(
                                                        sf.SingletonList<StatementSyntax>(
                                                            sf.ExpressionStatement(
                                                                sf.AssignmentExpression(
                                                                    SyntaxKind.SimpleAssignmentExpression,
                                                                    sf.MemberAccessExpression(
                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                        sf.ParenthesizedExpression(
                                                                            sf.CastExpression(
                                                                                sf.IdentifierName(className),
                                                                                sf.IdentifierName("e"))),
                                                                        sf.IdentifierName(association.Member)),
                                                                    sf.IdentifierName("child")))))) :> StatementSyntax
                                                sf.ReturnStatement(sf.IdentifierName("child")):> StatementSyntax
                                            |]
                                                    
                                                    )) 
                                        .WithParameterList(
                                            sf.ParameterList(
                                                sf.SeparatedList<ParameterSyntax>(
                                                    [|
                                                        sf.Parameter(sf.Identifier("e"))
                                                        sf.Parameter(sf.Identifier("fv"))
                                                        sf.Parameter(sf.Identifier("ppe"))
                                                    |],
                                                    [|
                                                        sf.Token(SyntaxKind.CommaToken)
                                                        sf.Token(SyntaxKind.CommaToken)
                                                    |]))))
                                sf.Argument(
                                    sf.TypeOfExpression(
                                        sf.IdentifierName(association.Type)))
                                sf.Argument(sf.IdentifierName("preloadEntities"))
                            |],
                            [|
                                sf.Token(SyntaxKind.CommaToken)
                                sf.Token(SyntaxKind.CommaToken)
                                sf.Token(SyntaxKind.CommaToken)
                                sf.Token(SyntaxKind.CommaToken)
                                sf.Token(SyntaxKind.CommaToken)
                            |])))) :> StatementSyntax

    let returnJoinStatementSet (className:string) (association:association) =
        match association.IsMany with
        | true -> returnJoinSet className association
        | false -> returnJoin className association
    let getJoinMethods (table:table) =
        table.Associations |> Array.map (fun association ->
            sf.MethodDeclaration(
                sf.GenericName(
                    sf.Identifier(String.Format("{0}Query", association.Type)))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SeparatedList(
                                [|
                                    sf.GenericName(sf.Identifier(String.Format("{0}Query", table.TypeName)))
                                        .WithTypeArgumentList(
                                            sf.TypeArgumentList(
                                                sf.SeparatedList(
                                                    [|
                                                        sf.IdentifierName("K")
                                                        sf.IdentifierName("T")
                                                    |],
                                                    [|
                                                        sf.Token(sk.CommaToken)
                                                    |]
                                                )))
                                    sf.IdentifierName("T")
                                |],
                                [|
                                    sf.Token(sk.CommaToken)
                                |]))),
                sf.Identifier(String.Format("Join{0}", association.Member)))
                .WithModifiers(sf.TokenList(sf.Token(sk.PublicKeyword)))
                .WithParameterList(
                    sf.ParameterList(
                        sf.SeparatedList(
                            [|
                                sf.Parameter(
                                    sf.Identifier("joinType"))
                                    .WithType(sf.IdentifierName("JoinType"))
                                    .WithDefault(sf.EqualsValueClause(sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.IdentifierName("JoinType"), sf.IdentifierName("Inner"))))
                                sf.Parameter(
                                    sf.Identifier(if association.IsMany then "attach" else "preloadEntities"))
                                    .WithType(sf.PredefinedType(sf.Token(sk.BoolKeyword)))
                                    .WithDefault(sf.EqualsValueClause(sf.LiteralExpression(sk.FalseLiteralExpression)))
                            |],
                            [|
                                sf.Token(sk.CommaToken)
                            |])))
                .WithBody(
                    sf.Block(
                        [|
                            sf.LocalDeclarationStatement(
                                sf.VariableDeclaration(sf.IdentifierName("var"))
                                    .WithVariables(
                                        sf.SingletonSeparatedList(
                                            sf.VariableDeclarator(sf.Identifier("joinedQuery"))
                                                .WithInitializer(
                                                    sf.EqualsValueClause(
                                                        sf.ObjectCreationExpression(
                                                            sf.GenericName(sf.Identifier(String.Format("{0}Query", association.Type)))
                                                                .WithTypeArgumentList(
                                                                    sf.TypeArgumentList(
                                                                        sf.SeparatedList(
                                                                            [|
                                                                                sf.GenericName(sf.Identifier(String.Format("{0}Query", table.TypeName)))
                                                                                    .WithTypeArgumentList(
                                                                                        sf.TypeArgumentList(
                                                                                            sf.SeparatedList(
                                                                                                [|
                                                                                                    sf.IdentifierName("K")
                                                                                                    sf.IdentifierName("T")
                                                                                                |],
                                                                                                [|
                                                                                                    sf.Token(sk.CommaToken)
                                                                                                |]
                                                                                            )
                                                                                        ))
                                                                                sf.IdentifierName("T")
                                                                            |],
                                                                            [|
                                                                                sf.Token(sk.CommaToken)
                                                                            |]))))
                                                            .WithArgumentList(sf.ArgumentList(sf.SingletonSeparatedList(sf.Argument(sf.IdentifierName("Db")))))))))) :> StatementSyntax
                            returnJoinStatementSet table.TypeName association
                        |]
                    )) :> MemberDeclarationSyntax
        )

    let getQueryWrapper (table:table) =
        let tableWrapper = String.Format("{0}Wrapper", table.TypeName)
        sf.MethodDeclaration(
            sf.IdentifierName(tableWrapper), sf.Identifier("GetWrapper"))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.ProtectedKeyword)
                        sf.Token(sk.SealedKeyword)
                        sf.Token(sk.OverrideKeyword)
                    |]))
            .WithBody(
                sf.Block(
                    [|
                        sf.ReturnStatement(sf.MemberAccessExpression(sk.SimpleMemberAccessExpression, sf.IdentifierName(tableWrapper), sf.IdentifierName("Instance"))) :> StatementSyntax
                    |]
                ))
        :> MemberDeclarationSyntax
    let queryMethods (table:table) =
        Array.append [| getQueryWrapper table |] (getJoinMethods table)

    let getQueryClass (table:table) =
        sf.ClassDeclaration(String.Format("{0}Query", table.TypeName))
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .AddBaseListTypes(queryBaseTypes table.TypeName)
            .WithTypeParameterList(
                sf.TypeParameterList(
                    sf.SeparatedList(
                        [|
                            sf.TypeParameter(sf.Identifier("K"))
                            sf.TypeParameter(sf.Identifier("T"))
                        |],
                        [|
                            sf.Token(sk.CommaToken)
                        |])))
            .AddConstraintClauses(queryClassConstraints)
            .AddMembers(getQueryConstructor table)
            .AddMembers(queryMethods table)

            :> MemberDeclarationSyntax