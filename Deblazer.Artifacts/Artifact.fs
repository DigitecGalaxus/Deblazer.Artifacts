module Artifact
    open ArtifactClass
    open QueryClass
    open TableQueryClass
    open QueryExtensionClass
    open HelperClass
    open WrapperClass
    open System
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax
    
    let getArtifactClass (table:table) = 
        sf.ClassDeclaration(table.TypeName)
            .AddModifiers(sf.Token(sk.PublicKeyword), sf.Token(sk.PartialKeyword))
            .AddBaseListTypes(baseTypes table.BaseIIdType)
            .AddMembers(fields table)
            .AddMembers(IIdProperties table)
            .AddMembers(properties table)
            .AddMembers(methods table)
            :> MemberDeclarationSyntax  
    
       

    let getArtifactCompilationUnit (table:table) (nameSpace:string) =
        let namespaceSyntax = sf.NamespaceDeclaration(sf.ParseName(nameSpace))
        let queryNameSpace = sf.NamespaceDeclaration(sf.ParseName(String.Format("{0}.Queries", nameSpace)))
        let helperNameSpace = sf.NamespaceDeclaration(sf.ParseName(String.Format("{0}.Helpers", nameSpace)))
        let wrapperNameSpace = sf.NamespaceDeclaration(sf.ParseName(String.Format("{0}.Wrappers", nameSpace)))

        sf.CompilationUnit()
            .AddUsings(usings nameSpace)
            .AddMembers(namespaceSyntax.AddMembers(
                            [|
                                getArtifactClass table
                                getQueryExtensionsClass table
                            |]))
            .AddMembers(queryNameSpace.AddMembers(
                            [|
                                getQueryClass table
                                getTableQueryClass table
                            |]))
            .AddMembers(helperNameSpace.AddMembers(getHelperClass table))
            .AddMembers(wrapperNameSpace.AddMembers(getWrapperClass table))