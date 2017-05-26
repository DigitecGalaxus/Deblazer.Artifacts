module ArtifactTest
    open System
    open Xunit
    open System.Xml.Linq
    open ArtifactClass

    module ArtifactTestClass =
        type ArtifactClassTests() = 
        
            [<Theory>]
            [<InlineData("System.Int32")>]
            [<InlineData("System.DateTime")>]
            [<InlineData("System.DateTimeOffset")>]
            [<InlineData("System.Boolean")>]
            [<InlineData("System.Decimal")>]
            [<InlineData("System.Double")>]
            [<InlineData("System.Char")>]
            member this.``FillerMethod is as specific as Possible for System. Types``(typeName:string) =
                let expected = "Get" + typeName.Replace("System.", "")           
                
                Assert.Equal(expected, getFillerMethodName typeName false)
            
            [<Fact>]
            member this.``FillerMethod for Binary returns GetBinary `` () =
                Assert.Equal("GetBinary", getFillerMethodName "System.Data.Linq.Binary" false)
                
            [<Fact>]
            member this.``FillerMethod for nullable Binary returns GetBinary `` () =
                Assert.Equal("GetBinary", getFillerMethodName "System.Data.Linq.Binary" true)
                
            [<Theory>]
            [<InlineData("System.String")>]
            [<InlineData("System.AppDomain")>]
            [<InlineData("System.IO.File")>]
            member this.``FillerMethod default is GetValue<T>``(typeName:string) =
                let expected = String.Format("GetValue<{0}>", typeName)           
                
                Assert.Equal(expected, getFillerMethodName typeName false)
            
            [<Theory>]
            [<InlineData("PrimaryKeyId")>]
            [<InlineData("SomeColumnName")>]
            member this.``Explicit Generation of IId Interface when the Name of the Column is not Id`` (columnName:string) =

                let table = {
                    Name = { TableName = "" };
                    Member = "";
                    TypeName = "";
                    Associations = Array.empty;
                    Columns = 
                        [| 
                            {                                
                                Name = columnName;
                                Type = "System.Int32";
                                DbType = "Int NOT NULL"
                                CanBeNull = true;
                                IsDbGenerated = None;
                                IsPrimaryKey = Some true;
                                IsVersion = None;
                            }
                        |];
                }
                
                let properties = IIdProperties table
                
                Assert.Equal(2, properties.Length)
            
            [<Theory>]
            [<InlineData("PrimaryKeyId")>]
            [<InlineData("SomeColumnName")>]
            member this.``Explicit Generation of IId Interface when the Name of the Column is not Id int64`` (columnName:string) =

                let table = {
                    Name = { TableName = "" };
                    Member = "";
                    TypeName = "";
                    Associations = Array.empty;
                    Columns = 
                        [| 
                            {                                
                                Name = columnName;
                                Type = "System.Int64";
                                DbType = "Int NOT NULL"
                                CanBeNull = true;
                                IsDbGenerated = None;
                                IsPrimaryKey = Some true;
                                IsVersion = None;
                            }
                        |];
                }
                
                let properties = IIdProperties table
                
                Assert.Equal(1, properties.Length)
                
            [<Fact>]
            member this.``Do not generate IId Property Id if the PrimaryKey is Id already`` () =

                let table = {
                    Name = { TableName = "" };
                    Member = "";
                    TypeName = "";
                    Associations = Array.empty;
                    Columns = 
                        [| 
                            {                                
                                Name = "Id";
                                Type = "System.Int32";
                                DbType = "Int NOT NULL"
                                CanBeNull = true;
                                IsDbGenerated = None;
                                IsPrimaryKey = Some true;
                                IsVersion = None;
                            }
                        |];
                    
                }
                
                let properties = IIdProperties table
                
                Assert.Equal(1, properties.Length)        
                Assert.Equal("longILongId.Id=>Id;", properties.[0].GetText().ToString())
                
            [<Fact>]               
            member this.``Do not generate IId Property Id if the PrimaryKey is Id already int64`` () =

                let table = {
                    Name = { TableName = "" };
                    Member = "";
                    TypeName = "";
                    Associations = Array.empty;
                    Columns = 
                        [| 
                            {                                
                                Name = "Id";
                                Type = "System.Int64";
                                DbType = "Int NOT NULL"
                                CanBeNull = true;
                                IsDbGenerated = None;
                                IsPrimaryKey = Some true;
                                IsVersion = None;
                            }
                        |];
                    
                }
                
                let properties = IIdProperties table
                
                Assert.Equal(0, properties.Length)        
               
            

                