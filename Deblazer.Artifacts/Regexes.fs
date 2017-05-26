module Regexes
    open System.Text.RegularExpressions
    
    let (|MaxLengthRegex|_|) input = 
        let m = Regex.Match(input, "\(((\d+|MAX)?)\)")
        if(m.Success) 
        then Some m.Groups.[1].Value
        else None
