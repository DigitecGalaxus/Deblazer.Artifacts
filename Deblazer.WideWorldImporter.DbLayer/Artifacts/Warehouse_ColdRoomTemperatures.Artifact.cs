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
    public partial class Warehouse_ColdRoomTemperature : DbEntity, ILongId
    {
        private DbValue<System.Int64> _ColdRoomTemperatureID = new DbValue<System.Int64>();
        private DbValue<System.Int32> _ColdRoomSensorNumber = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _RecordedWhen = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _Temperature = new DbValue<System.Decimal>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        long ILongId.Id => ColdRoomTemperatureID;
        [Validate]
        public System.Int64 ColdRoomTemperatureID
        {
            get
            {
                return _ColdRoomTemperatureID.Entity;
            }

            set
            {
                _ColdRoomTemperatureID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 ColdRoomSensorNumber
        {
            get
            {
                return _ColdRoomSensorNumber.Entity;
            }

            set
            {
                _ColdRoomSensorNumber.Entity = value;
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

        [StringColumn(7, false)]
        [Validate]
        public System.DateTime ValidFrom
        {
            get
            {
                return _ValidFrom.Entity;
            }

            set
            {
                _ValidFrom.Entity = value;
            }
        }

        [StringColumn(7, false)]
        [Validate]
        public System.DateTime ValidTo
        {
            get
            {
                return _ValidTo.Entity;
            }

            set
            {
                _ValidTo.Entity = value;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _ColdRoomTemperatureID.Load(visitor.GetValue<System.Int64>());
            SendIdChanged();
            _ColdRoomSensorNumber.Load(visitor.GetInt32());
            _RecordedWhen.Load(visitor.GetDateTime());
            _Temperature.Load(visitor.GetDecimal());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _ColdRoomSensorNumber.Welcome(visitor, "ColdRoomSensorNumber", "Int NOT NULL", false);
            _RecordedWhen.Welcome(visitor, "RecordedWhen", "DateTime2(7) NOT NULL", false);
            _Temperature.Welcome(visitor, "Temperature", "Decimal(10,2) NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
        }
    }

    public static class Db_Warehouse_ColdRoomTemperatureQueryGetterExtensions
    {
        public static Warehouse_ColdRoomTemperatureTableQuery<Warehouse_ColdRoomTemperature> Warehouse_ColdRoomTemperatures(this IDb db)
        {
            var query = new Warehouse_ColdRoomTemperatureTableQuery<Warehouse_ColdRoomTemperature>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_ColdRoomTemperatureQuery<K, T> : Query<K, T, Warehouse_ColdRoomTemperature, Warehouse_ColdRoomTemperatureWrapper, Warehouse_ColdRoomTemperatureQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_ColdRoomTemperatureQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_ColdRoomTemperatureWrapper GetWrapper()
        {
            return Warehouse_ColdRoomTemperatureWrapper.Instance;
        }
    }

    public class Warehouse_ColdRoomTemperatureTableQuery<T> : Warehouse_ColdRoomTemperatureQuery<Warehouse_ColdRoomTemperatureTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_ColdRoomTemperatureTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_ColdRoomTemperatureHelper : QueryHelper<Warehouse_ColdRoomTemperature>, IHelper<Warehouse_ColdRoomTemperature>
    {
        string[] columnsInSelectStatement = new[]{"{0}.ColdRoomTemperatureID", "{0}.ColdRoomSensorNumber", "{0}.RecordedWhen", "{0}.Temperature", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.ColdRoomSensorNumber", "{0}.RecordedWhen", "{0}.Temperature", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_ColdRoomTemperature ([ColdRoomSensorNumber] Int NOT NULL,[RecordedWhen] DateTime2(7) NOT NULL,[Temperature] Decimal(10,2) NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[ColdRoomTemperatures]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[ColdRoomTemperatures] ([{TableName = \"Warehouse].[ColdRoomTemperatures\";}].[ColdRoomSensorNumber], [{TableName = \"Warehouse].[ColdRoomTemperatures\";}].[RecordedWhen], [{TableName = \"Warehouse].[ColdRoomTemperatures\";}].[Temperature], [{TableName = \"Warehouse].[ColdRoomTemperatures\";}].[ValidFrom], [{TableName = \"Warehouse].[ColdRoomTemperatures\";}].[ValidTo]) VALUES ([@ColdRoomSensorNumber],[@RecordedWhen],[@Temperature],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_ColdRoomTemperature _Warehouse_ColdRoomTemperature)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@ColdRoomSensorNumber", _Warehouse_ColdRoomTemperature.ColdRoomSensorNumber);
            sqlCommand.Parameters.AddWithValue("@RecordedWhen", _Warehouse_ColdRoomTemperature.RecordedWhen);
            sqlCommand.Parameters.AddWithValue("@Temperature", _Warehouse_ColdRoomTemperature.Temperature);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Warehouse_ColdRoomTemperature.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Warehouse_ColdRoomTemperature.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_ColdRoomTemperature _Warehouse_ColdRoomTemperature)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_ColdRoomTemperature.ColdRoomTemperatureID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_ColdRoomTemperatureWrapper _wrapper = Warehouse_ColdRoomTemperatureWrapper.Instance;
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
    public class Warehouse_ColdRoomTemperatureWrapper : QueryLongWrapper<Warehouse_ColdRoomTemperature>
    {
        public readonly QueryElMemberStruct<System.Int32> ColdRoomSensorNumber = new QueryElMemberStruct<System.Int32>("ColdRoomSensorNumber");
        public readonly QueryElMemberStruct<System.DateTime> RecordedWhen = new QueryElMemberStruct<System.DateTime>("RecordedWhen");
        public readonly QueryElMemberStruct<System.Decimal> Temperature = new QueryElMemberStruct<System.Decimal>("Temperature");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Warehouse_ColdRoomTemperatureWrapper Instance = new Warehouse_ColdRoomTemperatureWrapper();
        private Warehouse_ColdRoomTemperatureWrapper(): base ("[Warehouse].[ColdRoomTemperatures]", "Warehouse_ColdRoomTemperature")
        {
        }
    }
}