[<AutoOpen>]
module CommonFunctions
    open System
    
    let getStorage (value:string) = 
        String.Format("_{0}", value)
    
    let sqlSquareBrackets (tableName:string) = 
        tableName.Split('.') |> Array.map (fun x -> String.Format("[{0}]", x)) |> String.concat(".")
        
    