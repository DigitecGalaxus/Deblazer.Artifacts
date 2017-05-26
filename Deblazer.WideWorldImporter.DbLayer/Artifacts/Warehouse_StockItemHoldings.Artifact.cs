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
    public partial class Warehouse_StockItemHolding : DbEntity, IId
    {
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _QuantityOnHand = new DbValue<System.Int32>();
        private DbValue<System.String> _BinLocation = new DbValue<System.String>();
        private DbValue<System.Int32> _LastStocktakeQuantity = new DbValue<System.Int32>();
        private DbValue<System.Decimal> _LastCostPrice = new DbValue<System.Decimal>();
        private DbValue<System.Int32> _ReorderLevel = new DbValue<System.Int32>();
        private DbValue<System.Int32> _TargetStockLevel = new DbValue<System.Int32>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => StockItemID;
        long ILongId.Id => StockItemID;
        [Validate]
        public System.Int32 StockItemID
        {
            get
            {
                return _StockItemID.Entity;
            }

            set
            {
                _StockItemID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 QuantityOnHand
        {
            get
            {
                return _QuantityOnHand.Entity;
            }

            set
            {
                _QuantityOnHand.Entity = value;
            }
        }

        [StringColumn(20, false)]
        [Validate]
        public System.String BinLocation
        {
            get
            {
                return _BinLocation.Entity;
            }

            set
            {
                _BinLocation.Entity = value;
            }
        }

        [Validate]
        public System.Int32 LastStocktakeQuantity
        {
            get
            {
                return _LastStocktakeQuantity.Entity;
            }

            set
            {
                _LastStocktakeQuantity.Entity = value;
            }
        }

        [Validate]
        public System.Decimal LastCostPrice
        {
            get
            {
                return _LastCostPrice.Entity;
            }

            set
            {
                _LastCostPrice.Entity = value;
            }
        }

        [Validate]
        public System.Int32 ReorderLevel
        {
            get
            {
                return _ReorderLevel.Entity;
            }

            set
            {
                _ReorderLevel.Entity = value;
            }
        }

        [Validate]
        public System.Int32 TargetStockLevel
        {
            get
            {
                return _TargetStockLevel.Entity;
            }

            set
            {
                _TargetStockLevel.Entity = value;
            }
        }

        [Validate]
        public System.Int32 LastEditedBy
        {
            get
            {
                return _LastEditedBy.Entity;
            }

            set
            {
                _LastEditedBy.Entity = value;
            }
        }

        [StringColumn(7, false)]
        [Validate]
        public System.DateTime LastEditedWhen
        {
            get
            {
                return _LastEditedWhen.Entity;
            }

            set
            {
                _LastEditedWhen.Entity = value;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_StockItemHoldings.Add(this);
                if (_Application_People != null)
                {
                    return _Application_People.GetEntity(beforeRightsCheckAction);
                }

                _Application_People = GetDbEntityRef(true, new[]{"[LastEditedBy]"}, new Func<long ? >[]{() => _LastEditedBy.Entity}, beforeRightsCheckAction);
                return (Application_People != null) ? _Application_People.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_People == null)
                {
                    _Application_People = new DbEntityRef<Application_People>(_db, true, new[]{"[LastEditedBy]"}, new Func<long ? >[]{() => _LastEditedBy.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Warehouse_StockItemHolding>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemHoldings, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Warehouse_StockItemHolding = this;
                if (_Warehouse_StockItem != null)
                {
                    return _Warehouse_StockItem.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_StockItem = GetDbEntityRef(true, new[]{"[StockItemID]"}, new Func<long ? >[]{() => _StockItemID.Entity}, beforeRightsCheckAction);
                return (Warehouse_StockItem != null) ? _Warehouse_StockItem.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_StockItem == null)
                {
                    _Warehouse_StockItem = new DbEntityRef<Warehouse_StockItem>(_db, true, new[]{"[StockItemID]"}, new Func<long ? >[]{() => _StockItemID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_StockItem, Warehouse_StockItemHolding>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, null, (x, y) => x.Warehouse_StockItemHolding = y, StockItemIDChanged);
            }
        }

        void StockItemIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_StockItem)
                _StockItemID.Entity = (int)((Warehouse_StockItem)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _StockItemID.Load(visitor.GetInt32());
            SendIdChanged();
            _QuantityOnHand.Load(visitor.GetInt32());
            _BinLocation.Load(visitor.GetValue<System.String>());
            _LastStocktakeQuantity.Load(visitor.GetInt32());
            _LastCostPrice.Load(visitor.GetDecimal());
            _ReorderLevel.Load(visitor.GetInt32());
            _TargetStockLevel.Load(visitor.GetInt32());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _QuantityOnHand.Welcome(visitor, "QuantityOnHand", "Int NOT NULL", false);
            _BinLocation.Welcome(visitor, "BinLocation", "NVarChar(20) NOT NULL", false);
            _LastStocktakeQuantity.Welcome(visitor, "LastStocktakeQuantity", "Int NOT NULL", false);
            _LastCostPrice.Welcome(visitor, "LastCostPrice", "Decimal(18,2) NOT NULL", false);
            _ReorderLevel.Welcome(visitor, "ReorderLevel", "Int NOT NULL", false);
            _TargetStockLevel.Welcome(visitor, "TargetStockLevel", "Int NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Warehouse_StockItemHoldingQueryGetterExtensions
    {
        public static Warehouse_StockItemHoldingTableQuery<Warehouse_StockItemHolding> Warehouse_StockItemHoldings(this IDb db)
        {
            var query = new Warehouse_StockItemHoldingTableQuery<Warehouse_StockItemHolding>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_StockItemHoldingQuery<K, T> : Query<K, T, Warehouse_StockItemHolding, Warehouse_StockItemHoldingWrapper, Warehouse_StockItemHoldingQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_StockItemHoldingQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_StockItemHoldingWrapper GetWrapper()
        {
            return Warehouse_StockItemHoldingWrapper.Instance;
        }

        public Application_PeopleQuery<Warehouse_StockItemHoldingQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_StockItemHoldingQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_StockItemHolding)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemHolding)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockItemQuery<Warehouse_StockItemHoldingQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_StockItemHoldingQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Warehouse_StockItemHolding)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemHolding)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Warehouse_StockItemHoldingTableQuery<T> : Warehouse_StockItemHoldingQuery<Warehouse_StockItemHoldingTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_StockItemHoldingTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_StockItemHoldingHelper : QueryHelper<Warehouse_StockItemHolding>, IHelper<Warehouse_StockItemHolding>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StockItemID", "{0}.QuantityOnHand", "{0}.BinLocation", "{0}.LastStocktakeQuantity", "{0}.LastCostPrice", "{0}.ReorderLevel", "{0}.TargetStockLevel", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StockItemID", "{0}.QuantityOnHand", "{0}.BinLocation", "{0}.LastStocktakeQuantity", "{0}.LastCostPrice", "{0}.ReorderLevel", "{0}.TargetStockLevel", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_StockItemHolding ([StockItemID] Int NOT NULL,[QuantityOnHand] Int NOT NULL,[BinLocation] NVarChar(20) NOT NULL,[LastStocktakeQuantity] Int NOT NULL,[LastCostPrice] Decimal(18,2) NOT NULL,[ReorderLevel] Int NOT NULL,[TargetStockLevel] Int NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[StockItemHoldings]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[StockItemHoldings] ([{TableName = \"Warehouse].[StockItemHoldings\";}].[StockItemID], [{TableName = \"Warehouse].[StockItemHoldings\";}].[QuantityOnHand], [{TableName = \"Warehouse].[StockItemHoldings\";}].[BinLocation], [{TableName = \"Warehouse].[StockItemHoldings\";}].[LastStocktakeQuantity], [{TableName = \"Warehouse].[StockItemHoldings\";}].[LastCostPrice], [{TableName = \"Warehouse].[StockItemHoldings\";}].[ReorderLevel], [{TableName = \"Warehouse].[StockItemHoldings\";}].[TargetStockLevel], [{TableName = \"Warehouse].[StockItemHoldings\";}].[LastEditedBy], [{TableName = \"Warehouse].[StockItemHoldings\";}].[LastEditedWhen]) VALUES ([@StockItemID],[@QuantityOnHand],[@BinLocation],[@LastStocktakeQuantity],[@LastCostPrice],[@ReorderLevel],[@TargetStockLevel],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemHolding _Warehouse_StockItemHolding)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Warehouse_StockItemHolding.StockItemID);
            sqlCommand.Parameters.AddWithValue("@QuantityOnHand", _Warehouse_StockItemHolding.QuantityOnHand);
            sqlCommand.Parameters.AddWithValue("@BinLocation", _Warehouse_StockItemHolding.BinLocation ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastStocktakeQuantity", _Warehouse_StockItemHolding.LastStocktakeQuantity);
            sqlCommand.Parameters.AddWithValue("@LastCostPrice", _Warehouse_StockItemHolding.LastCostPrice);
            sqlCommand.Parameters.AddWithValue("@ReorderLevel", _Warehouse_StockItemHolding.ReorderLevel);
            sqlCommand.Parameters.AddWithValue("@TargetStockLevel", _Warehouse_StockItemHolding.TargetStockLevel);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_StockItemHolding.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Warehouse_StockItemHolding.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemHolding _Warehouse_StockItemHolding)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_StockItemHolding.StockItemID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_StockItemHoldingWrapper _wrapper = Warehouse_StockItemHoldingWrapper.Instance;
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
    public class Warehouse_StockItemHoldingWrapper : QueryWrapper<Warehouse_StockItemHolding>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.Int32> QuantityOnHand = new QueryElMemberStruct<System.Int32>("QuantityOnHand");
        public readonly QueryElMember<System.String> BinLocation = new QueryElMember<System.String>("BinLocation");
        public readonly QueryElMemberStruct<System.Int32> LastStocktakeQuantity = new QueryElMemberStruct<System.Int32>("LastStocktakeQuantity");
        public readonly QueryElMemberStruct<System.Decimal> LastCostPrice = new QueryElMemberStruct<System.Decimal>("LastCostPrice");
        public readonly QueryElMemberStruct<System.Int32> ReorderLevel = new QueryElMemberStruct<System.Int32>("ReorderLevel");
        public readonly QueryElMemberStruct<System.Int32> TargetStockLevel = new QueryElMemberStruct<System.Int32>("TargetStockLevel");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Warehouse_StockItemHoldingWrapper Instance = new Warehouse_StockItemHoldingWrapper();
        private Warehouse_StockItemHoldingWrapper(): base ("[Warehouse].[StockItemHoldings]", "Warehouse_StockItemHolding")
        {
        }
    }
}