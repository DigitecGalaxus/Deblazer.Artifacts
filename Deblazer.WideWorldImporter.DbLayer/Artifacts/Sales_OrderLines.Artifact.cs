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
    public partial class Sales_OrderLine : DbEntity, IId
    {
        private DbValue<System.Int32> _OrderLineID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _OrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.String> _Description = new DbValue<System.String>();
        private DbValue<System.Int32> _PackageTypeID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _Quantity = new DbValue<System.Int32>();
        private DbValue<System.Decimal> _UnitPrice = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TaxRate = new DbValue<System.Decimal>();
        private DbValue<System.Int32> _PickedQuantity = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _PickingCompletedWhen = new DbValue<System.DateTime>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Sales_Order> _Sales_Order;
        private IDbEntityRef<Warehouse_PackageType> _Warehouse_PackageType;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => OrderLineID;
        long ILongId.Id => OrderLineID;
        [Validate]
        public System.Int32 OrderLineID
        {
            get
            {
                return _OrderLineID.Entity;
            }

            set
            {
                _OrderLineID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 OrderID
        {
            get
            {
                return _OrderID.Entity;
            }

            set
            {
                _OrderID.Entity = value;
            }
        }

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

        [StringColumn(100, false)]
        [Validate]
        public System.String Description
        {
            get
            {
                return _Description.Entity;
            }

            set
            {
                _Description.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PackageTypeID
        {
            get
            {
                return _PackageTypeID.Entity;
            }

            set
            {
                _PackageTypeID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 Quantity
        {
            get
            {
                return _Quantity.Entity;
            }

            set
            {
                _Quantity.Entity = value;
            }
        }

        [Validate]
        public System.Decimal UnitPrice
        {
            get
            {
                return _UnitPrice.Entity;
            }

            set
            {
                _UnitPrice.Entity = value;
            }
        }

        [Validate]
        public System.Decimal TaxRate
        {
            get
            {
                return _TaxRate.Entity;
            }

            set
            {
                _TaxRate.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PickedQuantity
        {
            get
            {
                return _PickedQuantity.Entity;
            }

            set
            {
                _PickedQuantity.Entity = value;
            }
        }

        [StringColumn(7, true)]
        [Validate]
        public System.DateTime PickingCompletedWhen
        {
            get
            {
                return _PickingCompletedWhen.Entity;
            }

            set
            {
                _PickingCompletedWhen.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_OrderLines.Add(this);
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

                AssignDbEntity<Application_People, Sales_OrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_OrderLines, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Order Sales_Order
        {
            get
            {
                Action<Sales_Order> beforeRightsCheckAction = e => e.Sales_OrderLines.Add(this);
                if (_Sales_Order != null)
                {
                    return _Sales_Order.GetEntity(beforeRightsCheckAction);
                }

                _Sales_Order = GetDbEntityRef(true, new[]{"[OrderID]"}, new Func<long ? >[]{() => _OrderID.Entity}, beforeRightsCheckAction);
                return (Sales_Order != null) ? _Sales_Order.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_Order == null)
                {
                    _Sales_Order = new DbEntityRef<Sales_Order>(_db, true, new[]{"[OrderID]"}, new Func<long ? >[]{() => _OrderID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Order, Sales_OrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.OrderID}, _Sales_Order, new long ? []{_OrderID.Entity}, new Action<long ? >[]{x => OrderID = (int ? )x ?? default (int)}, x => x.Sales_OrderLines, null, OrderIDChanged);
            }
        }

        void OrderIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Order)
                _OrderID.Entity = (int)((Sales_Order)sender).Id;
        }

        [Validate]
        public Warehouse_PackageType Warehouse_PackageType
        {
            get
            {
                Action<Warehouse_PackageType> beforeRightsCheckAction = e => e.Sales_OrderLines.Add(this);
                if (_Warehouse_PackageType != null)
                {
                    return _Warehouse_PackageType.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_PackageType = GetDbEntityRef(true, new[]{"[PackageTypeID]"}, new Func<long ? >[]{() => _PackageTypeID.Entity}, beforeRightsCheckAction);
                return (Warehouse_PackageType != null) ? _Warehouse_PackageType.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_PackageType == null)
                {
                    _Warehouse_PackageType = new DbEntityRef<Warehouse_PackageType>(_db, true, new[]{"[PackageTypeID]"}, new Func<long ? >[]{() => _PackageTypeID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_PackageType, Sales_OrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PackageTypeID}, _Warehouse_PackageType, new long ? []{_PackageTypeID.Entity}, new Action<long ? >[]{x => PackageTypeID = (int ? )x ?? default (int)}, x => x.Sales_OrderLines, null, PackageTypeIDChanged);
            }
        }

        void PackageTypeIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_PackageType)
                _PackageTypeID.Entity = (int)((Warehouse_PackageType)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Sales_OrderLines.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Sales_OrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Sales_OrderLines, null, StockItemIDChanged);
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
            _OrderLineID.Load(visitor.GetInt32());
            SendIdChanged();
            _OrderID.Load(visitor.GetInt32());
            _StockItemID.Load(visitor.GetInt32());
            _Description.Load(visitor.GetValue<System.String>());
            _PackageTypeID.Load(visitor.GetInt32());
            _Quantity.Load(visitor.GetInt32());
            _UnitPrice.Load(visitor.GetDecimal());
            _TaxRate.Load(visitor.GetDecimal());
            _PickedQuantity.Load(visitor.GetInt32());
            _PickingCompletedWhen.Load(visitor.GetDateTime());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _OrderLineID.Welcome(visitor, "OrderLineID", "Int NOT NULL", false);
            _OrderID.Welcome(visitor, "OrderID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _Description.Welcome(visitor, "Description", "NVarChar(100) NOT NULL", false);
            _PackageTypeID.Welcome(visitor, "PackageTypeID", "Int NOT NULL", false);
            _Quantity.Welcome(visitor, "Quantity", "Int NOT NULL", false);
            _UnitPrice.Welcome(visitor, "UnitPrice", "Decimal(18,2)", false);
            _TaxRate.Welcome(visitor, "TaxRate", "Decimal(18,3) NOT NULL", false);
            _PickedQuantity.Welcome(visitor, "PickedQuantity", "Int NOT NULL", false);
            _PickingCompletedWhen.Welcome(visitor, "PickingCompletedWhen", "DateTime2(7)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Sales_Order);
            visitor.ProcessAssociation(this, _Warehouse_PackageType);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Sales_OrderLineQueryGetterExtensions
    {
        public static Sales_OrderLineTableQuery<Sales_OrderLine> Sales_OrderLines(this IDb db)
        {
            var query = new Sales_OrderLineTableQuery<Sales_OrderLine>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_OrderLineQuery<K, T> : Query<K, T, Sales_OrderLine, Sales_OrderLineWrapper, Sales_OrderLineQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_OrderLineQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_OrderLineWrapper GetWrapper()
        {
            return Sales_OrderLineWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_OrderLineQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_OrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_OrderLine)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_OrderLine)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_OrderQuery<Sales_OrderLineQuery<K, T>, T> JoinSales_Order(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_OrderQuery<Sales_OrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[OrderID] = {1}.[OrderID]"), o => ((Sales_OrderLine)o)?.Sales_Order, (e, fv, ppe) =>
            {
                var child = (Sales_Order)ppe(QueryHelpers.Fill<Sales_Order>(null, fv));
                if (e != null)
                {
                    ((Sales_OrderLine)e).Sales_Order = child;
                }

                return child;
            }

            , typeof (Sales_Order), preloadEntities);
        }

        public Warehouse_PackageTypeQuery<Sales_OrderLineQuery<K, T>, T> JoinWarehouse_PackageType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Sales_OrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), o => ((Sales_OrderLine)o)?.Warehouse_PackageType, (e, fv, ppe) =>
            {
                var child = (Warehouse_PackageType)ppe(QueryHelpers.Fill<Warehouse_PackageType>(null, fv));
                if (e != null)
                {
                    ((Sales_OrderLine)e).Warehouse_PackageType = child;
                }

                return child;
            }

            , typeof (Warehouse_PackageType), preloadEntities);
        }

        public Warehouse_StockItemQuery<Sales_OrderLineQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Sales_OrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Sales_OrderLine)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Sales_OrderLine)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Sales_OrderLineTableQuery<T> : Sales_OrderLineQuery<Sales_OrderLineTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_OrderLineTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_OrderLineHelper : QueryHelper<Sales_OrderLine>, IHelper<Sales_OrderLine>
    {
        string[] columnsInSelectStatement = new[]{"{0}.OrderLineID", "{0}.OrderID", "{0}.StockItemID", "{0}.Description", "{0}.PackageTypeID", "{0}.Quantity", "{0}.UnitPrice", "{0}.TaxRate", "{0}.PickedQuantity", "{0}.PickingCompletedWhen", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.OrderLineID", "{0}.OrderID", "{0}.StockItemID", "{0}.Description", "{0}.PackageTypeID", "{0}.Quantity", "{0}.UnitPrice", "{0}.TaxRate", "{0}.PickedQuantity", "{0}.PickingCompletedWhen", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_OrderLine ([OrderLineID] Int NOT NULL,[OrderID] Int NOT NULL,[StockItemID] Int NOT NULL,[Description] NVarChar(100) NOT NULL,[PackageTypeID] Int NOT NULL,[Quantity] Int NOT NULL,[UnitPrice] Decimal(18,2),[TaxRate] Decimal(18,3) NOT NULL,[PickedQuantity] Int NOT NULL,[PickingCompletedWhen] DateTime2(7),[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[OrderLines]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Sales].[OrderLines] ([{TableName = \"Sales].[OrderLines\";}].[OrderLineID], [{TableName = \"Sales].[OrderLines\";}].[OrderID], [{TableName = \"Sales].[OrderLines\";}].[StockItemID], [{TableName = \"Sales].[OrderLines\";}].[Description], [{TableName = \"Sales].[OrderLines\";}].[PackageTypeID], [{TableName = \"Sales].[OrderLines\";}].[Quantity], [{TableName = \"Sales].[OrderLines\";}].[UnitPrice], [{TableName = \"Sales].[OrderLines\";}].[TaxRate], [{TableName = \"Sales].[OrderLines\";}].[PickedQuantity], [{TableName = \"Sales].[OrderLines\";}].[PickingCompletedWhen], [{TableName = \"Sales].[OrderLines\";}].[LastEditedBy], [{TableName = \"Sales].[OrderLines\";}].[LastEditedWhen]) VALUES ([@OrderLineID],[@OrderID],[@StockItemID],[@Description],[@PackageTypeID],[@Quantity],[@UnitPrice],[@TaxRate],[@PickedQuantity],[@PickingCompletedWhen],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_OrderLine _Sales_OrderLine)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@OrderLineID", _Sales_OrderLine.OrderLineID);
            sqlCommand.Parameters.AddWithValue("@OrderID", _Sales_OrderLine.OrderID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Sales_OrderLine.StockItemID);
            sqlCommand.Parameters.AddWithValue("@Description", _Sales_OrderLine.Description ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PackageTypeID", _Sales_OrderLine.PackageTypeID);
            sqlCommand.Parameters.AddWithValue("@Quantity", _Sales_OrderLine.Quantity);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", _Sales_OrderLine.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@TaxRate", _Sales_OrderLine.TaxRate);
            sqlCommand.Parameters.AddWithValue("@PickedQuantity", _Sales_OrderLine.PickedQuantity);
            sqlCommand.Parameters.AddWithValue("@PickingCompletedWhen", _Sales_OrderLine.PickingCompletedWhen);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_OrderLine.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_OrderLine.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_OrderLine _Sales_OrderLine)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_OrderLine.OrderLineID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_OrderLineWrapper _wrapper = Sales_OrderLineWrapper.Instance;
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
    public class Sales_OrderLineWrapper : QueryWrapper<Sales_OrderLine>
    {
        public readonly QueryElMemberId<Sales_Order> OrderID = new QueryElMemberId<Sales_Order>("OrderID");
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Warehouse_PackageType> PackageTypeID = new QueryElMemberId<Warehouse_PackageType>("PackageTypeID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> Description = new QueryElMember<System.String>("Description");
        public readonly QueryElMemberStruct<System.Int32> Quantity = new QueryElMemberStruct<System.Int32>("Quantity");
        public readonly QueryElMemberStruct<System.Decimal> UnitPrice = new QueryElMemberStruct<System.Decimal>("UnitPrice");
        public readonly QueryElMemberStruct<System.Decimal> TaxRate = new QueryElMemberStruct<System.Decimal>("TaxRate");
        public readonly QueryElMemberStruct<System.Int32> PickedQuantity = new QueryElMemberStruct<System.Int32>("PickedQuantity");
        public readonly QueryElMemberStruct<System.DateTime> PickingCompletedWhen = new QueryElMemberStruct<System.DateTime>("PickingCompletedWhen");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_OrderLineWrapper Instance = new Sales_OrderLineWrapper();
        private Sales_OrderLineWrapper(): base ("[Sales].[OrderLines]", "Sales_OrderLine")
        {
        }
    }
}