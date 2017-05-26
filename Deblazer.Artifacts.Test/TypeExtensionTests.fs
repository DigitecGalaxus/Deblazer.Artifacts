namespace Tests    
    open System
    open Xunit
    open System.Xml.Linq

    module TypeExtension =
//        let testColumnXml = "<Column Name=\"CustomerID\" Type=\"System.Int32\" DbType=\"Int NOT NULL\" IsPrimaryKey=\"true\" CanBeNull=\"false\" />"
        let testcolum = {
            Name = "TestColumn";
            Type = "TestType";
            DbType = "Int NOT NULL"
            CanBeNull = true;
            IsDbGenerated = None;
            IsPrimaryKey = None
            IsVersion = None;
        }  
        
        let baseAssociation = {
            Name = "FK_SOME_TO_OTHER";
            Member = "MyMembers";
            Type = "MyMember";
            ThisKey = "ThisKey";
            OtherKey = "OtherKey";
            OtherSideAssociation = None;
            IsForeignKey = false;       
            Cardinality = cardinality.One;
            OtherTableName = { TableName = "Schema.MyMember" };
        }

        let testManyAssociation = baseAssociation
        let testOneAssociation =  { baseAssociation with IsForeignKey = true; }
        let testCardinalityOne = { baseAssociation with Cardinality = cardinality.One; }
        let testCardinalityMany = { baseAssociation with Cardinality = cardinality.Many; }

        type TypeExtensionTests() = 
            [<Fact>]
            member this.``CommaTokens: return 1 less than supplied with the collection`` () =
                Assert.Equal(4, (sf.getCommaTokens 5).Length)
        
            [<Fact>]
            member this.``Fail when using 0 length`` () =
                Assert.Equal(0, (sf.getCommaTokens 0).Length)

            [<Fact>]
            member this.``ColumnType: Storage has underline prefix`` () =
                Assert.Equal("_TestColumn", testcolum.Storage)
            
            [<Fact>]
            member this.``ColumnType: Member Is same as the name`` () =
                Assert.Equal(testcolum.Name, testcolum.Member)
            
            // CASE NOT YET IMPLEMENTED
//            [<Fact>]
//            member this.``ColumnType: Member needs suffix when name is same as classname`` () =
//                Assert.Equal(testcolum.Name + "1+", testcolum.Member)
            
            
            [<Fact>]
            member this.``Assoiaction: Cardinality is set to "Many"`` () =
                Assert.Equal(true, testCardinalityMany.IsMany)            

            [<Fact>]
            member this.``Assoiaction: Cardinality is set to "One" so IsMany is false`` () =
                Assert.Equal(false, testCardinalityOne.IsMany)
                
            [<Fact>]
            member this.``Assoiaction: Is FK so IsMany is false`` () =
                Assert.Equal(false, testOneAssociation.IsMany)