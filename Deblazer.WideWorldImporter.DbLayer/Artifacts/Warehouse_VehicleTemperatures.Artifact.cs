using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;
using Dg.Deblazer;
using Dg.Deblazer.Validation;
using Dg.Deblazer.CodeAnnotation;
using Dg.Deblazer.Api;
using Dg.Deblazer.Visitors;
using Dg.Deblazer.Cache;
using Dg.Deblazer.SqlGeneration;
using Deblazer.WideWorldImporter.DbLayer.Queries;
using Deblazer.WideWorldImporter.DbLayer.Wrappers;
using Dg.Deblazer.Read;

namespace Deblazer.WideWorldImporter.DbLayer
{
    public partial class Warehouse_VehicleTemperature : DbEntity, ILongId
    {
        private DbValue<System.Int64> _VehicleTemperatureID = new DbValue<System.Int64>();
        private DbValue<System.String> _VehicleRegistration = new DbValue<System.String>();
        private DbValue<System.Int32> _ChillerSensorNumber = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _RecordedWhen = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _Temperature = new DbValue<System.Decimal>();
        private DbValue<System.String> _FullSensorData = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsCompressed = new DbValue<System.Boolean>();
        private DbValue<System.Data.Linq.Binary> _CompressedSensorData = new DbValue<System.Data.Linq.Binary>();
        long ILongId.Id => VehicleTemperatureID;
        [Validate]
        public System.Int64 VehicleTemperatureID
        {
            get
            {
                return _VehicleTemperatureID.Entity;
            }

            set
            {
                _VehicleTemperatureID.Entity = value;
            }
        }

        [StringColumn(20, false)]
        [Validate]
        public System.String VehicleRegistration
        {
            get
            {
                return _VehicleRegistration.Entity;
            }

            set
            {
                _VehicleRegistration.Entity = value;
            }
        }

        [Validate]
        public System.Int32 ChillerSensorNumber
        {
            get
            {
                return _ChillerSensorNumber.Entity;
            }

            set
            {
                _ChillerSensorNumber.Entity = value;
            }
        }

        [StringColumn(7, false)]
        [Validate]
        public System.DateTime RecordedWhen
        {
            get
            {
                return _RecordedWhen.Entity;
            }

            set
            {
                _RecordedWhen.Entity = value;
            }
        }

        [Validate]
        public System.Decimal Temperature
        {
            get
            {
                return _Temperature.Entity;
            }

            set
            {
                _Temperature.Entity = value;
            }
        }

        [StringColumn(1000, true)]
        [Validate]
        public System.String FullSensorData
        {
            get
            {
                return _FullSensorData.Entity;
            }

            set
            {
                _FullSensorData.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsCompressed
        {
            get
            {
                return _IsCompressed.Entity;
            }

            set
            {
                _IsCompressed.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.Data.Linq.Binary CompressedSensorData
        {
            get
            {
                return _CompressedSensorData.Entity;
            }

            set
            {
                _CompressedSensorData.Entity = value;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _VehicleTemperatureID.Load(visitor.GetValue<System.Int64>());
            SendIdChanged();
            _VehicleRegistration.Load(visitor.GetValue<System.String>());
            _ChillerSensorNumber.Load(visitor.GetInt32());
            _RecordedWhen.Load(visitor.GetDateTime());
            _Temperature.Load(visitor.GetDecimal());
            _FullSensorData.Load(visitor.GetValue<System.String>());
            _IsCompressed.Load(visitor.GetBoolean());
            _CompressedSensorData.Load(visitor.GetBinary());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _VehicleRegistration.Welcome(visitor, "VehicleRegistration", "NVarChar(20) NOT NULL", false);
            _ChillerSensorNumber.Welcome(visitor, "ChillerSensorNumber", "Int NOT NULL", false);
            _RecordedWhen.Welcome(visitor, "RecordedWhen", "DateTime2(7) NOT NULL", false);
            _Temperature.Welcome(visitor, "Temperature", "Decimal(10,2) NOT NULL", false);
            _FullSensorData.Welcome(visitor, "FullSensorData", "NVarChar(1000)", false);
            _IsCompressed.Welcome(visitor, "IsCompressed", "Bit NOT NULL", false);
            _CompressedSensorData.Welcome(visitor, "CompressedSensorData", "VarBinary(MAX)", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
        }
    }

    public static class Db_Warehouse_VehicleTemperatureQueryGetterExtensions
    {
        public static Warehouse_VehicleTemperatureTableQuery<Warehouse_VehicleTemperature> Warehouse_VehicleTemperatures(this IDb db)
        {
            var query = new Warehouse_VehicleTemperatureTableQuery<Warehouse_VehicleTemperature>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_VehicleTemperatureQuery<K, T> : Query<K, T, Warehouse_VehicleTemperature, Warehouse_VehicleTemperatureWrapper, Warehouse_VehicleTemperatureQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_VehicleTemperatureQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_VehicleTemperatureWrapper GetWrapper()
        {
            return Warehouse_VehicleTemperatureWrapper.Instance;
        }
    }

    public class Warehouse_VehicleTemperatureTableQuery<T> : Warehouse_VehicleTemperatureQuery<Warehouse_VehicleTemperatureTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_VehicleTemperatureTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_VehicleTemperatureHelper : QueryHelper<Warehouse_VehicleTemperature>, IHelper<Warehouse_VehicleTemperature>
    {
        string[] columnsInSelectStatement = new[]{"{0}.VehicleTemperatureID", "{0}.VehicleRegistration", "{0}.ChillerSensorNumber", "{0}.RecordedWhen", "{0}.Temperature", "{0}.FullSensorData", "{0}.IsCompressed", "{0}.CompressedSensorData"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.VehicleRegistration", "{0}.ChillerSensorNumber", "{0}.RecordedWhen", "{0}.Temperature", "{0}.FullSensorData", "{0}.IsCompressed", "{0}.CompressedSensorData"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_VehicleTemperature ([VehicleRegistration] NVarChar(20) NOT NULL,[ChillerSensorNumber] Int NOT NULL,[RecordedWhen] DateTime2(7) NOT NULL,[Temperature] Decimal(10,2) NOT NULL,[FullSensorData] NVarChar(1000),[IsCompressed] Bit NOT NULL,[CompressedSensorData] VarBinary(MAX), [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[VehicleTemperatures]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[VehicleTemperatures] ([{TableName = \"Warehouse].[VehicleTemperatures\";}].[VehicleRegistration], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[ChillerSensorNumber], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[RecordedWhen], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[Temperature], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[FullSensorData], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[IsCompressed], [{TableName = \"Warehouse].[VehicleTemperatures\";}].[CompressedSensorData]) VALUES ([@VehicleRegistration],[@ChillerSensorNumber],[@RecordedWhen],[@Temperature],[@FullSensorData],[@IsCompressed],[@CompressedSensorData]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_VehicleTemperature _Warehouse_VehicleTemperature)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@VehicleRegistration", _Warehouse_VehicleTemperature.VehicleRegistration ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ChillerSensorNumber", _Warehouse_VehicleTemperature.ChillerSensorNumber);
            sqlCommand.Parameters.AddWithValue("@RecordedWhen", _Warehouse_VehicleTemperature.RecordedWhen);
            sqlCommand.Parameters.AddWithValue("@Temperature", _Warehouse_VehicleTemperature.Temperature);
            sqlCommand.Parameters.AddWithValue("@FullSensorData", _Warehouse_VehicleTemperature.FullSensorData ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsCompressed", _Warehouse_VehicleTemperature.IsCompressed);
            sqlCommand.Parameters.AddWithValue("@CompressedSensorData", _Warehouse_VehicleTemperature.CompressedSensorData ?? (object)DBNull.Value);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_VehicleTemperature _Warehouse_VehicleTemperature)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_VehicleTemperature.VehicleTemperatureID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_VehicleTemperatureWrapper _wrapper = Warehouse_VehicleTemperatureWrapper.Instance;
        public QueryWrapper Wrapper
        {
            get
            {
                return _wrapper;
            }
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Wrappers
{
    public class Warehouse_VehicleTemperatureWrapper : QueryLongWrapper<Warehouse_VehicleTemperature>
    {
        public readonly QueryElMember<System.String> VehicleRegistration = new QueryElMember<System.String>("VehicleRegistration");
        public readonly QueryElMemberStruct<System.Int32> ChillerSensorNumber = new QueryElMemberStruct<System.Int32>("ChillerSensorNumber");
        public readonly QueryElMemberStruct<System.DateTime> RecordedWhen = new QueryElMemberStruct<System.DateTime>("RecordedWhen");
        public readonly QueryElMemberStruct<System.Decimal> Temperature = new QueryElMemberStruct<System.Decimal>("Temperature");
        public readonly QueryElMember<System.String> FullSensorData = new QueryElMember<System.String>("FullSensorData");
        public readonly QueryElMemberStruct<System.Boolean> IsCompressed = new QueryElMemberStruct<System.Boolean>("IsCompressed");
        public readonly QueryElMember<System.Data.Linq.Binary> CompressedSensorData = new QueryElMember<System.Data.Linq.Binary>("CompressedSensorData");
        public static readonly Warehouse_VehicleTemperatureWrapper Instance = new Warehouse_VehicleTemperatureWrapper();
        private Warehouse_VehicleTemperatureWrapper(): base ("[Warehouse].[VehicleTemperatures]", "Warehouse_VehicleTemperature")
        {
        }
    }
}