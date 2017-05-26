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
    public partial class Purchasing_PurchaseOrderLine : DbEntity, IId
    {
        private DbValue<System.Int32> _PurchaseOrderLineID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PurchaseOrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _OrderedOuters = new DbValue<System.Int32>();
        private DbValue<System.String> _Description = new DbValue<System.String>();
        private DbValue<System.Int32> _ReceivedOuters = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PackageTypeID = new DbValue<System.Int32>();
        private DbValue<System.Decimal> _ExpectedUnitPricePerOuter = new DbValue<System.Decimal>();
        private DbValue<System.DateTime> _LastReceiptDate = new DbValue<System.DateTime>();
        private DbValue<System.Boolean> _IsOrderLineFinalized = new DbValue<System.Boolean>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Warehouse_PackageType> _Warehouse_PackageType;
        private IDbEntityRef<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrder;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => PurchaseOrderLineID;
        long ILongId.Id => PurchaseOrderLineID;
        [Validate]
        public System.Int32 PurchaseOrderLineID
        {
            get
            {
                return _PurchaseOrderLineID.Entity;
            }

            set
            {
                _PurchaseOrderLineID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PurchaseOrderID
        {
            get
            {
                return _PurchaseOrderID.Entity;
            }

            set
            {
                _PurchaseOrderID.Entity = value;
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

        [Validate]
        public System.Int32 OrderedOuters
        {
            get
            {
                return _OrderedOuters.Entity;
            }

            set
            {
                _OrderedOuters.Entity = value;
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
        public System.Int32 ReceivedOuters
        {
            get
            {
                return _ReceivedOuters.Entity;
            }

            set
            {
                _ReceivedOuters.Entity = value;
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
        public System.Decimal ExpectedUnitPricePerOuter
        {
            get
            {
                return _ExpectedUnitPricePerOuter.Entity;
            }

            set
            {
                _ExpectedUnitPricePerOuter.Entity = value;
            }
        }

        [Validate]
        public System.DateTime LastReceiptDate
        {
            get
            {
                return _LastReceiptDate.Entity;
            }

            set
            {
                _LastReceiptDate.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsOrderLineFinalized
        {
            get
            {
                return _IsOrderLineFinalized.Entity;
            }

            set
            {
                _IsOrderLineFinalized.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrderLines.Add(this);
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

                AssignDbEntity<Application_People, Purchasing_PurchaseOrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrderLines, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Warehouse_PackageType Warehouse_PackageType
        {
            get
            {
                Action<Warehouse_PackageType> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrderLines.Add(this);
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

                AssignDbEntity<Warehouse_PackageType, Purchasing_PurchaseOrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PackageTypeID}, _Warehouse_PackageType, new long ? []{_PackageTypeID.Entity}, new Action<long ? >[]{x => PackageTypeID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrderLines, null, PackageTypeIDChanged);
            }
        }

        void PackageTypeIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_PackageType)
                _PackageTypeID.Entity = (int)((Warehouse_PackageType)sender).Id;
        }

        [Validate]
        public Purchasing_PurchaseOrder Purchasing_PurchaseOrder
        {
            get
            {
                Action<Purchasing_PurchaseOrder> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrderLines.Add(this);
                if (_Purchasing_PurchaseOrder != null)
                {
                    return _Purchasing_PurchaseOrder.GetEntity(beforeRightsCheckAction);
                }

                _Purchasing_PurchaseOrder = GetDbEntityRef(true, new[]{"[PurchaseOrderID]"}, new Func<long ? >[]{() => _PurchaseOrderID.Entity}, beforeRightsCheckAction);
                return (Purchasing_PurchaseOrder != null) ? _Purchasing_PurchaseOrder.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Purchasing_PurchaseOrder == null)
                {
                    _Purchasing_PurchaseOrder = new DbEntityRef<Purchasing_PurchaseOrder>(_db, true, new[]{"[PurchaseOrderID]"}, new Func<long ? >[]{() => _PurchaseOrderID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Purchasing_PurchaseOrder, Purchasing_PurchaseOrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PurchaseOrderID}, _Purchasing_PurchaseOrder, new long ? []{_PurchaseOrderID.Entity}, new Action<long ? >[]{x => PurchaseOrderID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrderLines, null, PurchaseOrderIDChanged);
            }
        }

        void PurchaseOrderIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_PurchaseOrder)
                _PurchaseOrderID.Entity = (int)((Purchasing_PurchaseOrder)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrderLines.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Purchasing_PurchaseOrderLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrderLines, null, StockItemIDChanged);
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
            _PurchaseOrderLineID.Load(visitor.GetInt32());
            SendIdChanged();
            _PurchaseOrderID.Load(visitor.GetInt32());
            _StockItemID.Load(visitor.GetInt32());
            _OrderedOuters.Load(visitor.GetInt32());
            _Description.Load(visitor.GetValue<System.String>());
            _ReceivedOuters.Load(visitor.GetInt32());
            _PackageTypeID.Load(visitor.GetInt32());
            _ExpectedUnitPricePerOuter.Load(visitor.GetDecimal());
            _LastReceiptDate.Load(visitor.GetDateTime());
            _IsOrderLineFinalized.Load(visitor.GetBoolean());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _PurchaseOrderLineID.Welcome(visitor, "PurchaseOrderLineID", "Int NOT NULL", false);
            _PurchaseOrderID.Welcome(visitor, "PurchaseOrderID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _OrderedOuters.Welcome(visitor, "OrderedOuters", "Int NOT NULL", false);
            _Description.Welcome(visitor, "Description", "NVarChar(100) NOT NULL", false);
            _ReceivedOuters.Welcome(visitor, "ReceivedOuters", "Int NOT NULL", false);
            _PackageTypeID.Welcome(visitor, "PackageTypeID", "Int NOT NULL", false);
            _ExpectedUnitPricePerOuter.Welcome(visitor, "ExpectedUnitPricePerOuter", "Decimal(18,2)", false);
            _LastReceiptDate.Welcome(visitor, "LastReceiptDate", "Date", false);
            _IsOrderLineFinalized.Welcome(visitor, "IsOrderLineFinalized", "Bit NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_PackageType);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrder);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Purchasing_PurchaseOrderLineQueryGetterExtensions
    {
        public static Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine> Purchasing_PurchaseOrderLines(this IDb db)
        {
            var query = new Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Purchasing_PurchaseOrderLineQuery<K, T> : Query<K, T, Purchasing_PurchaseOrderLine, Purchasing_PurchaseOrderLineWrapper, Purchasing_PurchaseOrderLineQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Purchasing_PurchaseOrderLineQuery(IDb db): base (db)
        {
        }

        protected sealed override Purchasing_PurchaseOrderLineWrapper GetWrapper()
        {
            return Purchasing_PurchaseOrderLineWrapper.Instance;
        }

        public Application_PeopleQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Purchasing_PurchaseOrderLine)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrderLine)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_PackageTypeQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T> JoinWarehouse_PackageType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), o => ((Purchasing_PurchaseOrderLine)o)?.Warehouse_PackageType, (e, fv, ppe) =>
            {
                var child = (Warehouse_PackageType)ppe(QueryHelpers.Fill<Warehouse_PackageType>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrderLine)e).Warehouse_PackageType = child;
                }

                return child;
            }

            , typeof (Warehouse_PackageType), preloadEntities);
        }

        public Purchasing_PurchaseOrderQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T> JoinPurchasing_PurchaseOrder(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), o => ((Purchasing_PurchaseOrderLine)o)?.Purchasing_PurchaseOrder, (e, fv, ppe) =>
            {
                var child = (Purchasing_PurchaseOrder)ppe(QueryHelpers.Fill<Purchasing_PurchaseOrder>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrderLine)e).Purchasing_PurchaseOrder = child;
                }

                return child;
            }

            , typeof (Purchasing_PurchaseOrder), preloadEntities);
        }

        public Warehouse_StockItemQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Purchasing_PurchaseOrderLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Purchasing_PurchaseOrderLine)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrderLine)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Purchasing_PurchaseOrderLineTableQuery<T> : Purchasing_PurchaseOrderLineQuery<Purchasing_PurchaseOrderLineTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Purchasing_PurchaseOrderLineTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Purchasing_PurchaseOrderLineHelper : QueryHelper<Purchasing_PurchaseOrderLine>, IHelper<Purchasing_PurchaseOrderLine>
    {
        string[] columnsInSelectStatement = new[]{"{0}.PurchaseOrderLineID", "{0}.PurchaseOrderID", "{0}.StockItemID", "{0}.OrderedOuters", "{0}.Description", "{0}.ReceivedOuters", "{0}.PackageTypeID", "{0}.ExpectedUnitPricePerOuter", "{0}.LastReceiptDate", "{0}.IsOrderLineFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.PurchaseOrderLineID", "{0}.PurchaseOrderID", "{0}.StockItemID", "{0}.OrderedOuters", "{0}.Description", "{0}.ReceivedOuters", "{0}.PackageTypeID", "{0}.ExpectedUnitPricePerOuter", "{0}.LastReceiptDate", "{0}.IsOrderLineFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Purchasing_PurchaseOrderLine ([PurchaseOrderLineID] Int NOT NULL,[PurchaseOrderID] Int NOT NULL,[StockItemID] Int NOT NULL,[OrderedOuters] Int NOT NULL,[Description] NVarChar(100) NOT NULL,[ReceivedOuters] Int NOT NULL,[PackageTypeID] Int NOT NULL,[ExpectedUnitPricePerOuter] Decimal(18,2),[LastReceiptDate] Date,[IsOrderLineFinalized] Bit NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Purchasing].[PurchaseOrderLines]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Purchasing].[PurchaseOrderLines] ([{TableName = \"Purchasing].[PurchaseOrderLines\";}].[PurchaseOrderLineID], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[PurchaseOrderID], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[StockItemID], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[OrderedOuters], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[Description], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[ReceivedOuters], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[PackageTypeID], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[ExpectedUnitPricePerOuter], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[LastReceiptDate], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[IsOrderLineFinalized], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[LastEditedBy], [{TableName = \"Purchasing].[PurchaseOrderLines\";}].[LastEditedWhen]) VALUES ([@PurchaseOrderLineID],[@PurchaseOrderID],[@StockItemID],[@OrderedOuters],[@Description],[@ReceivedOuters],[@PackageTypeID],[@ExpectedUnitPricePerOuter],[@LastReceiptDate],[@IsOrderLineFinalized],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Purchasing_PurchaseOrderLine _Purchasing_PurchaseOrderLine)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderLineID", _Purchasing_PurchaseOrderLine.PurchaseOrderLineID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", _Purchasing_PurchaseOrderLine.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Purchasing_PurchaseOrderLine.StockItemID);
            sqlCommand.Parameters.AddWithValue("@OrderedOuters", _Purchasing_PurchaseOrderLine.OrderedOuters);
            sqlCommand.Parameters.AddWithValue("@Description", _Purchasing_PurchaseOrderLine.Description ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ReceivedOuters", _Purchasing_PurchaseOrderLine.ReceivedOuters);
            sqlCommand.Parameters.AddWithValue("@PackageTypeID", _Purchasing_PurchaseOrderLine.PackageTypeID);
            sqlCommand.Parameters.AddWithValue("@ExpectedUnitPricePerOuter", _Purchasing_PurchaseOrderLine.ExpectedUnitPricePerOuter);
            sqlCommand.Parameters.AddWithValue("@LastReceiptDate", _Purchasing_PurchaseOrderLine.LastReceiptDate);
            sqlCommand.Parameters.AddWithValue("@IsOrderLineFinalized", _Purchasing_PurchaseOrderLine.IsOrderLineFinalized);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Purchasing_PurchaseOrderLine.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Purchasing_PurchaseOrderLine.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Purchasing_PurchaseOrderLine _Purchasing_PurchaseOrderLine)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Purchasing_PurchaseOrderLine.PurchaseOrderLineID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Purchasing_PurchaseOrderLineWrapper _wrapper = Purchasing_PurchaseOrderLineWrapper.Instance;
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
    public class Purchasing_PurchaseOrderLineWrapper : QueryWrapper<Purchasing_PurchaseOrderLine>
    {
        public readonly QueryElMemberId<Purchasing_PurchaseOrder> PurchaseOrderID = new QueryElMemberId<Purchasing_PurchaseOrder>("PurchaseOrderID");
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Warehouse_PackageType> PackageTypeID = new QueryElMemberId<Warehouse_PackageType>("PackageTypeID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.Int32> OrderedOuters = new QueryElMemberStruct<System.Int32>("OrderedOuters");
        public readonly QueryElMember<System.String> Description = new QueryElMember<System.String>("Description");
        public readonly QueryElMemberStruct<System.Int32> ReceivedOuters = new QueryElMemberStruct<System.Int32>("ReceivedOuters");
        public readonly QueryElMemberStruct<System.Decimal> ExpectedUnitPricePerOuter = new QueryElMemberStruct<System.Decimal>("ExpectedUnitPricePerOuter");
        public readonly QueryElMemberStruct<System.DateTime> LastReceiptDate = new QueryElMemberStruct<System.DateTime>("LastReceiptDate");
        public readonly QueryElMemberStruct<System.Boolean> IsOrderLineFinalized = new QueryElMemberStruct<System.Boolean>("IsOrderLineFinalized");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Purchasing_PurchaseOrderLineWrapper Instance = new Purchasing_PurchaseOrderLineWrapper();
        private Purchasing_PurchaseOrderLineWrapper(): base ("[Purchasing].[PurchaseOrderLines]", "Purchasing_PurchaseOrderLine")
        {
        }
    }
}