using System;
using System.Linq;
using System.Xml;
using Dg.Deblazer.Visitors;
using Xunit;

namespace Deblazer.WideWorldImporter.DbLayer.Test
{
    public class IntegrationTestsWithDbConnection : IClassFixture<ConnectionStringFixture>
    {
        private readonly ConnectionStringFixture fixture;

        public IntegrationTestsWithDbConnection(ConnectionStringFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ConnectionStringEnvironment_IsRequired()
        {
            Assert.NotNull(fixture.ConnectionString);
        }
        
        [Fact]
        public void BasicConnectionTest()
        {
            const int defaultPeopleCount = 1111;
            var db = new Db(fixture.ConnectionString);

            var peopleCount = db.Application_Peoples().CountDb();

            Assert.Equal(defaultPeopleCount, peopleCount);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(int.MaxValue)]
        public void Take10People(int takeCount)
        {
            var db = new Db(fixture.ConnectionString);

            var maxTakeCount = db.Application_Peoples().CountDb();

            var topTenPeople = db.Application_Peoples()
                .TakeDb(takeCount)
                .ToList();

            switch (takeCount)
            {
                case var c when c <= 0:
                    Assert.Equal(0, topTenPeople.Count);
                    break;
                case var c when c > maxTakeCount:
                    Assert.Equal(maxTakeCount, topTenPeople.Count);
                    break;
                default:
                    Assert.Equal(takeCount, topTenPeople.Count);
                    break;
            }
        }
        
        [Fact]
        public void JoinTable_PreloadWithQuery()
        {
            var db = new Db(fixture.ConnectionString);

            var entity = db.Application_SystemParameters()
                .JoinApplication_City(preloadEntities: true)
                .TakeDb(1)
                .ToList()
                .First();

            Assert.NotNull(entity);
            Assert.NotNull(entity.Application_City);
            Assert.True(entity.Application_City.CityID > 0);
        }
    }
}