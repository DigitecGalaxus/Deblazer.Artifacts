module CliParser
    open System
    
    type CliArguments = { DbmlPath: string; OutputPath:string; CreateDbClass:bool; }  
    
    let defaultCliOptions = {
            DbmlPath = "";
            OutputPath = "./";
            CreateDbClass = false;
            }
    
    let rec parseCli arglist options = 
        match arglist with
        | [] -> options
        | "-dbml" :: xs -> 
            let newOptions = { options with DbmlPath = xs.Head  } 
            parseCli xs.Tail newOptions
        | "-o" :: xs ->
            let newOptions = { options with OutputPath = xs.Head  } 
            parseCli xs.Tail newOptions
        | "true" :: xs -> 
            let newOptions = { options with CreateDbClass = true  } 
            parseCli xs.Tail newOptions
        | "false" :: xs -> 
            let newOptions = { options with CreateDbClass = false  } 
            parseCli xs.Tail newOptions
        | x::xs ->
            printfn "Option '%s' is unrecognized" x
            parseCli xs options