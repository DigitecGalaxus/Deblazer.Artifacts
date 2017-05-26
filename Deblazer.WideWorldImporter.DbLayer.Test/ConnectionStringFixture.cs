using System;

namespace Deblazer.WideWorldImporter.DbLayer.Test
{
    public class ConnectionStringFixture
    {
        public string ConnectionString { get; private set; }
        
        public ConnectionStringFixture()
        {
            ConnectionString = Environment.GetEnvironmentVariable("WideWorldImporterConnection", EnvironmentVariableTarget.User);
        }
    }
}