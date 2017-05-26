module BasicFunctionTests
    open System
    open Xunit
    
    type Tests() =
         [<Theory>]
         [<InlineData("City")>]
         [<InlineData("TEst")>]
         [<InlineData("_")>]
         [<InlineData(".")>]
         [<InlineData("1")>]
         member this.``Storage adds a underscore to the value`` (value:string) =                
             Assert.Equal(String.Format("_{0}", value), getStorage value ) 
             
