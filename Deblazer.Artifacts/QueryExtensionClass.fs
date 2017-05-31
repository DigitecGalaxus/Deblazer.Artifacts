module QueryExtensionClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let queryMethod (table:table) =
        sf.MethodDeclaration(
            sf.GenericName(sf.Identifier(String.Format("{0}TableQuery", table.TypeName)))
                .WithTypeArgumentList(
                    sf.TypeArgumentList(
                        sf.SingletonSeparatedList(sf.IdentifierName(table.TypeName) :> TypeSyntax))),
            sf.Identifier(table.Member))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.StaticKeyword)
                    |]))
            .WithParameterList(
                sf.ParameterList(
                    sf.SingletonSeparatedList(
                        sf.Parameter(
                            sf.Identifier("db"))
                            .WithModifiers(
                                sf.TokenList(sf.Token(sk.ThisKeyword)))
                            .WithType(sf.IdentifierName("IDb")))))
            .WithBody(
                sf.Block(
                    [|
                        sf.LocalDeclarationStatement(
                            sf.VariableDeclaration(sf.IdentifierName("var"))
                                .WithVariables(
                                    sf.SingletonSeparatedList(
                                        sf.VariableDeclarator(
                                            sf.Identifier("query"))
                                            .WithInitializer(
                                                sf.EqualsValueClause(
                                                    sf.ObjectCreationExpression(
                                                        sf.GenericName(
                                                            sf.Identifier(String.Format("{0}TableQuery", table.TypeName)))
                                                            .WithTypeArgumentList(
                                                                sf.TypeArgumentList(
                                                                    sf.SingletonSeparatedList(
                                                                        sf.IdentifierName(table.TypeName) :> TypeSyntax))))
                                                        .WithArgumentList(
                                                            sf.ArgumentList(
                                                                sf.SingletonSeparatedList(
                                                                    sf.Argument(
                                                                        sf.BinaryExpression(
                                                                            sk.AsExpression,
                                                                            sf.IdentifierName("db"),
                                                                            sf.IdentifierName("IDb")))))))))))
                            :> StatementSyntax
                        sf.ReturnStatement(sf.IdentifierName("query")) :> StatementSyntax
                    |]))
            :> MemberDeclarationSyntax


    let getQueryExtensionsClass (table:table) =
        sf.ClassDeclaration(String.Format("Db_{0}QueryGetterExtensions", table.TypeName))
            .WithModifiers(
                sf.TokenList(
                    [|
                        sf.Token(sk.PublicKeyword)
                        sf.Token(sk.StaticKeyword)
                    |]))
            .WithMembers(sf.SingletonList(queryMethod table))
            :> MemberDeclarationSyntax 