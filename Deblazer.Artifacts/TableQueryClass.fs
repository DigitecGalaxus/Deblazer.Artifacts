module TableQueryClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let getBaseTypes (className:string) =
        [|
            sf.SimpleBaseType(
                sf.GenericName(
                    sf.Identifier(String.Format("{0}Query", className)))
                    .WithTypeArgumentList(
                        sf.TypeArgumentList(
                            sf.SeparatedList(
                                [|
                                    sf.GenericName(sf.Identifier(String.Format("{0}TableQuery", className)))
                                        .WithTypeArgumentList(
                                            sf.TypeArgumentList(
                                                sf.SingletonSeparatedList(
                                                    sf.IdentifierName("T") :> TypeSyntax)))
                                    sf.IdentifierName("T")
                                |],
                                [|
                                    sf.Token(sk.CommaToken)
                                |]
                    )))) :> BaseTypeSyntax
        |]
    let  getConstraints =
        [|
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

    let getConstructor (table:table) = 
        sf.ConstructorDeclaration(
            sf.Identifier(String.Format("{0}TableQuery", table.TypeName)))
            .WithModifiers(sf.TokenList(sf.Token(sk.PublicKeyword)))
            .WithParameterList(sf.ParameterList(sf.SingletonSeparatedList(sf.Parameter(sf.Identifier("db")).WithType(sf.IdentifierName("IDb")))))
            .WithInitializer(
                sf.ConstructorInitializer(
                    sk.BaseConstructorInitializer,
                    sf.ArgumentList(
                        sf.SingletonSeparatedList(
                            sf.Argument(sf.IdentifierName("db"))))))
            .WithBody(sf.Block())

    let getTableQueryClass (table:table) = 
        sf.ClassDeclaration(String.Format("{0}TableQuery", table.TypeName))
            .AddModifiers(sf.Token(sk.PublicKeyword))
            .WithTypeParameterList(sf.TypeParameterList(sf.SingletonSeparatedList(sf.TypeParameter(sf.Identifier("T")))))
            .AddBaseListTypes(getBaseTypes table.TypeName)
            .AddConstraintClauses(getConstraints)
            .AddMembers(getConstructor table)
            
            :> MemberDeclarationSyntax 