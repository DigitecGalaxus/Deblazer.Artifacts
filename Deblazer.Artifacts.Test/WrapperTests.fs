module WrapperTests
    open System
    open Xunit
    open System.Xml.Linq
    open WrapperClass

    module WrapperTestClass =
        type WrapperClassTests() = 
            [<Fact>]
            member this.``Testing Query El Member Selection long?`` () =                
                Assert.Equal("QueryElMemberLongNullableId", getQueryElMemberTypeFk true typeof<int64>)

            [<Fact>]
            member this.``Testing Query El Member Selection long`` () =                
                Assert.Equal("QueryElMemberLongId", getQueryElMemberTypeFk false typeof<int64>)

            [<Fact>]
            member this.``Testing Query El Member Selection int?`` () =                
                Assert.Equal("QueryElMemberNullableId", getQueryElMemberTypeFk true typeof<int>)

            [<Fact>]
            member this.``Testing Query El Member Selection int`` () =                
                Assert.Equal("QueryElMemberId", getQueryElMemberTypeFk false typeof<int>)

            [<Fact>]
            member this.``Testing Query El Member for non Foreign Keys`` () =                
                Assert.Equal("QueryElMemberStruct", getQueryElMemberTypeNonFk false)

            [<Fact>]
            member this.``Testing Query El Member for non nullable Foreign Keys`` () =                
                Assert.Equal("QueryElMember", getQueryElMemberTypeNonFk true)

                
