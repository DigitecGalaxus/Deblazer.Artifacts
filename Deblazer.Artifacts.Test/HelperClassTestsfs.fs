namespace Tests
    open System
    open Xunit
    open System.Xml.Linq
    open HelperClass

    module HelperClass =
        
        type HelperClassTests() = 
            [<Fact>]
            member this.``HelperClass: Generate Square Brachets for Schema + Table`` () =
                Assert.Equal("[dbo].[TestTable]", sqlSquareBrackets "dbo.TestTable")

            member this.``HelperClass: Generate Square Brachets for Schema + Table + Column`` () =
                Assert.Equal("[dbo].[TestTable].[ColumX]", sqlSquareBrackets "dbo.TestTable.ColumX")
                