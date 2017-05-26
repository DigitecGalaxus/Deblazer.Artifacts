module Dbml
    open Attributes
    open Artifact
    open System
    open System.Linq
    open FSharp.Data
    open Microsoft.CodeAnalysis.Formatting
    open Microsoft.CodeAnalysis
    open Microsoft.CodeAnalysis.CSharp
    open Microsoft.CodeAnalysis.CSharp.Syntax
    open Microsoft.CodeAnalysis.Text
    open Microsoft.CodeAnalysis.MSBuild    
    open System.IO
    open Microsoft.FSharp.Collections
    open Microsoft.FSharp
    open System.Threading
    open System.Diagnostics
    open System.Xml
    open CliParser
    
    [<NoComparison>]
    type DocName = { Id:DocumentId; Name:string; }
    
    [<NoComparison>]
    type CSharpClass = { Name:string;  Content:SyntaxNode; }
    
     
    let generate (node: CSharpClass) (location:string) = 
        let fileName = String.Format("{0}.Artifact.cs", node.Name)
        use writer = new StreamWriter(Path.Combine(location, fileName))

        node.Content
            .NormalizeWhitespace()
            .WriteTo(writer)
    
    [<EntryPoint>]
    let main args =
    
        let arglist = args |> List.ofSeq
        let options = parseCli arglist defaultCliOptions
        
        let sw = Stopwatch.StartNew()
        let dbmlContent = System.IO.File.ReadAllText(options.DbmlPath)
        sw.Stop()
        let elapsed = sw.Elapsed
        Console.WriteLine(String.Format("Reading DBML File in {0} seconds", elapsed.TotalSeconds))
        sw.Restart()
        
        
        let xml =  dc.Parse(dbmlContent)
        let database = parseTypeProvider xml
        sw.Stop()
        let elapsed = sw.Elapsed
        Console.WriteLine(String.Format("Parsing DBML {0} seconds", elapsed.TotalSeconds))
        sw.Restart()
        
        
       
        Console.WriteLine("Generating Entites for " + xml.EntityNamespace)        
        
        let classes = 
            database.Tables
                // 27.04.2017 Deblazer only supports Tables with Primary Key Columns
                |> Array.filter (fun table -> table.HasPrimaryKey) 
                |> Array.Parallel.map (fun table -> 
                    {
                        Name = table.Member;
                        Content = getArtifactCompilationUnit table xml.EntityNamespace
                    }) 
        sw.Stop()
        let elapsed = sw.Elapsed
        Console.WriteLine(String.Format("Generated {0} Entites in {1} seconds", classes.Length, elapsed.TotalSeconds))
        sw.Restart()
        
        classes |> Array.Parallel.iter (fun newClass -> generate newClass options.OutputPath )

        sw.Stop()
        let elapsed = sw.Elapsed
        Console.WriteLine(String.Format("Wrote Files to disk in {0} seconds", elapsed.TotalSeconds))
        Console.ReadLine() |> ignore
        0 
        