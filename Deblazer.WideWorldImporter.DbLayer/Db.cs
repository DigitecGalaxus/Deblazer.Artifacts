using Dg.Deblazer.Write;

namespace Deblazer.WideWorldImporter.DbLayer
{
    public class Db : WriteDb
    {
        public Db(string connectionString) : base(connectionString, allowLoadingBinaryData: true)
        {
        }
    }
}