module Attributes
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax

    let asAttributeListSyntax (attribute:AttributeSyntax) = 
        sf.AttributeList(sf.SingletonSeparatedList<AttributeSyntax>(attribute))

    let stringColumnAttribute maxLength isNullable =
        let nullableLiteralKind =
            match isNullable with
            | true -> sk.TrueLiteralExpression
            | false -> sk.FalseLiteralExpression
        match maxLength with
        | length when length > 0 -> 
            Some (sf.Attribute(sf.IdentifierName("StringColumn"))
                    .WithArgumentList(
                        sf.AttributeArgumentList(
                            sf.SeparatedList<AttributeArgumentSyntax>(
                                [|
                                    sf.AttributeArgument(sf.LiteralExpression(sk.NumericLiteralExpression, sf.Literal(length)))
                                    sf.AttributeArgument(sf.LiteralExpression(nullableLiteralKind))
                                |])))
                |> asAttributeListSyntax)
        | _ -> None
        
    let validateAttribute = 
        Some (sf.Attribute(sf.IdentifierName("Validate")) |> asAttributeListSyntax)