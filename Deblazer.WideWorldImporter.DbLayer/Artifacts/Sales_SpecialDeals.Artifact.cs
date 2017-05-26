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
    public partial class Sales_SpecialDeal : DbEntity, IId
    {
        private DbValue<System.Int32> _SpecialDealID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _BuyingGroupID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerCategoryID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockGroupID = new DbValue<System.Int32>();
        private DbValue<System.String> _DealDescription = new DbValue<System.String>();
        private DbValue<System.DateTime> _StartDate = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _EndDate = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _DiscountAmount = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _DiscountPercentage = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _UnitPrice = new DbValue<System.Decimal>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Sales_BuyingGroup> _Sales_BuyingGroup;
        private IDbEntityRef<Sales_CustomerCategory> _Sales_CustomerCategory;
        private IDbEntityRef<Sales_Customer> _Sales_Customer;
        private IDbEntityRef<Warehouse_StockGroup> _Warehouse_StockGroup;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => SpecialDealID;
        long ILongId.Id => SpecialDealID;
        [Validate]
        public System.Int32 SpecialDealID
        {
            get
            {
                return _SpecialDealID.Entity;
            }

            set
            {
                _SpecialDealID.Entity = value;
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
        public System.Int32 CustomerID
        {
            get
            {
                return _CustomerID.Entity;
            }

            set
            {
                _CustomerID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 BuyingGroupID
        {
            get
            {
                return _BuyingGroupID.Entity;
            }

            set
            {
                _BuyingGroupID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 CustomerCategoryID
        {
            get
            {
                return _CustomerCategoryID.Entity;
            }

            set
            {
                _CustomerCategoryID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 StockGroupID
        {
            get
            {
                return _StockGroupID.Entity;
            }

            set
            {
                _StockGroupID.Entity = value;
            }
        }

        [StringColumn(30, false)]
        [Validate]
        public System.String DealDescription
        {
            get
            {
                return _DealDescription.Entity;
            }

            set
            {
                _DealDescription.Entity = value;
            }
        }

        [Validate]
        public System.DateTime StartDate
        {
            get
            {
                return _StartDate.Entity;
            }

            set
            {
                _StartDate.Entity = value;
            }
        }

        [Validate]
        public System.DateTime EndDate
        {
            get
            {
                return _EndDate.Entity;
            }

            set
            {
                _EndDate.Entity = value;
            }
        }

        [Validate]
        public System.Decimal DiscountAmount
        {
            get
            {
                return _DiscountAmount.Entity;
            }

            set
            {
                _DiscountAmount.Entity = value;
            }
        }

        [Validate]
        public System.Decimal DiscountPercentage
        {
            get
            {
                return _DiscountPercentage.Entity;
            }

            set
            {
                _DiscountPercentage.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
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

                AssignDbEntity<Application_People, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_BuyingGroup Sales_BuyingGroup
        {
            get
            {
                Action<Sales_BuyingGroup> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
                if (_Sales_BuyingGroup != null)
                {
                    return _Sales_BuyingGroup.GetEntity(beforeRightsCheckAction);
                }

                _Sales_BuyingGroup = GetDbEntityRef(true, new[]{"[BuyingGroupID]"}, new Func<long ? >[]{() => _BuyingGroupID.Entity}, beforeRightsCheckAction);
                return (Sales_BuyingGroup != null) ? _Sales_BuyingGroup.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_BuyingGroup == null)
                {
                    _Sales_BuyingGroup = new DbEntityRef<Sales_BuyingGroup>(_db, true, new[]{"[BuyingGroupID]"}, new Func<long ? >[]{() => _BuyingGroupID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_BuyingGroup, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.BuyingGroupID}, _Sales_BuyingGroup, new long ? []{_BuyingGroupID.Entity}, new Action<long ? >[]{x => BuyingGroupID = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, BuyingGroupIDChanged);
            }
        }

        void BuyingGroupIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_BuyingGroup)
                _BuyingGroupID.Entity = (int)((Sales_BuyingGroup)sender).Id;
        }

        [Validate]
        public Sales_CustomerCategory Sales_CustomerCategory
        {
            get
            {
                Action<Sales_CustomerCategory> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
                if (_Sales_CustomerCategory != null)
                {
                    return _Sales_CustomerCategory.GetEntity(beforeRightsCheckAction);
                }

                _Sales_CustomerCategory = GetDbEntityRef(true, new[]{"[CustomerCategoryID]"}, new Func<long ? >[]{() => _CustomerCategoryID.Entity}, beforeRightsCheckAction);
                return (Sales_CustomerCategory != null) ? _Sales_CustomerCategory.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_CustomerCategory == null)
                {
                    _Sales_CustomerCategory = new DbEntityRef<Sales_CustomerCategory>(_db, true, new[]{"[CustomerCategoryID]"}, new Func<long ? >[]{() => _CustomerCategoryID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_CustomerCategory, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerCategoryID}, _Sales_CustomerCategory, new long ? []{_CustomerCategoryID.Entity}, new Action<long ? >[]{x => CustomerCategoryID = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, CustomerCategoryIDChanged);
            }
        }

        void CustomerCategoryIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_CustomerCategory)
                _CustomerCategoryID.Entity = (int)((Sales_CustomerCategory)sender).Id;
        }

        [Validate]
        public Sales_Customer Sales_Customer
        {
            get
            {
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
                if (_Sales_Customer != null)
                {
                    return _Sales_Customer.GetEntity(beforeRightsCheckAction);
                }

                _Sales_Customer = GetDbEntityRef(true, new[]{"[CustomerID]"}, new Func<long ? >[]{() => _CustomerID.Entity}, beforeRightsCheckAction);
                return (Sales_Customer != null) ? _Sales_Customer.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_Customer == null)
                {
                    _Sales_Customer = new DbEntityRef<Sales_Customer>(_db, true, new[]{"[CustomerID]"}, new Func<long ? >[]{() => _CustomerID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Customer, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Sales_Customer, new long ? []{_CustomerID.Entity}, new Action<long ? >[]{x => CustomerID = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, CustomerIDChanged);
            }
        }

        void CustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _CustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public Warehouse_StockGroup Warehouse_StockGroup
        {
            get
            {
                Action<Warehouse_StockGroup> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
                if (_Warehouse_StockGroup != null)
                {
                    return _Warehouse_StockGroup.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_StockGroup = GetDbEntityRef(true, new[]{"[StockGroupID]"}, new Func<long ? >[]{() => _StockGroupID.Entity}, beforeRightsCheckAction);
                return (Warehouse_StockGroup != null) ? _Warehouse_StockGroup.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_StockGroup == null)
                {
                    _Warehouse_StockGroup = new DbEntityRef<Warehouse_StockGroup>(_db, true, new[]{"[StockGroupID]"}, new Func<long ? >[]{() => _StockGroupID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_StockGroup, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockGroupID}, _Warehouse_StockGroup, new long ? []{_StockGroupID.Entity}, new Action<long ? >[]{x => StockGroupID = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, StockGroupIDChanged);
            }
        }

        void StockGroupIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_StockGroup)
                _StockGroupID.Entity = (int)((Warehouse_StockGroup)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Sales_SpecialDeals.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Sales_SpecialDeal>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Sales_SpecialDeals, null, StockItemIDChanged);
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
            _SpecialDealID.Load(visitor.GetInt32());
            SendIdChanged();
            _StockItemID.Load(visitor.GetInt32());
            _CustomerID.Load(visitor.GetInt32());
            _BuyingGroupID.Load(visitor.GetInt32());
            _CustomerCategoryID.Load(visitor.GetInt32());
            _StockGroupID.Load(visitor.GetInt32());
            _DealDescription.Load(visitor.GetValue<System.String>());
            _StartDate.Load(visitor.GetDateTime());
            _EndDate.Load(visitor.GetDateTime());
            _DiscountAmount.Load(visitor.GetDecimal());
            _DiscountPercentage.Load(visitor.GetDecimal());
            _UnitPrice.Load(visitor.GetDecimal());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _SpecialDealID.Welcome(visitor, "SpecialDealID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int", false);
            _CustomerID.Welcome(visitor, "CustomerID", "Int", false);
            _BuyingGroupID.Welcome(visitor, "BuyingGroupID", "Int", false);
            _CustomerCategoryID.Welcome(visitor, "CustomerCategoryID", "Int", false);
            _StockGroupID.Welcome(visitor, "StockGroupID", "Int", false);
            _DealDescription.Welcome(visitor, "DealDescription", "NVarChar(30) NOT NULL", false);
            _StartDate.Welcome(visitor, "StartDate", "Date NOT NULL", false);
            _EndDate.Welcome(visitor, "EndDate", "Date NOT NULL", false);
            _DiscountAmount.Welcome(visitor, "DiscountAmount", "Decimal(18,2)", false);
            _DiscountPercentage.Welcome(visitor, "DiscountPercentage", "Decimal(18,3)", false);
            _UnitPrice.Welcome(visitor, "UnitPrice", "Decimal(18,2)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Sales_BuyingGroup);
            visitor.ProcessAssociation(this, _Sales_CustomerCategory);
            visitor.ProcessAssociation(this, _Sales_Customer);
            visitor.ProcessAssociation(this, _Warehouse_StockGroup);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Sales_SpecialDealQueryGetterExtensions
    {
        public static Sales_SpecialDealTableQuery<Sales_SpecialDeal> Sales_SpecialDeals(this IDb db)
        {
            var query = new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_SpecialDealQuery<K, T> : Query<K, T, Sales_SpecialDeal, Sales_SpecialDealWrapper, Sales_SpecialDealQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_SpecialDealQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_SpecialDealWrapper GetWrapper()
        {
            return Sales_SpecialDealWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_SpecialDealQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_SpecialDeal)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_BuyingGroupQuery<Sales_SpecialDealQuery<K, T>, T> JoinSales_BuyingGroup(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_BuyingGroupQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[BuyingGroups] AS {1} {0} ON", "{2}.[BuyingGroupID] = {1}.[BuyingGroupID]"), o => ((Sales_SpecialDeal)o)?.Sales_BuyingGroup, (e, fv, ppe) =>
            {
                var child = (Sales_BuyingGroup)ppe(QueryHelpers.Fill<Sales_BuyingGroup>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Sales_BuyingGroup = child;
                }

                return child;
            }

            , typeof (Sales_BuyingGroup), preloadEntities);
        }

        public Sales_CustomerCategoryQuery<Sales_SpecialDealQuery<K, T>, T> JoinSales_CustomerCategory(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerCategoryQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerCategories] AS {1} {0} ON", "{2}.[CustomerCategoryID] = {1}.[CustomerCategoryID]"), o => ((Sales_SpecialDeal)o)?.Sales_CustomerCategory, (e, fv, ppe) =>
            {
                var child = (Sales_CustomerCategory)ppe(QueryHelpers.Fill<Sales_CustomerCategory>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Sales_CustomerCategory = child;
                }

                return child;
            }

            , typeof (Sales_CustomerCategory), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_SpecialDealQuery<K, T>, T> JoinSales_Customer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), o => ((Sales_SpecialDeal)o)?.Sales_Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Sales_Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Warehouse_StockGroupQuery<Sales_SpecialDealQuery<K, T>, T> JoinWarehouse_StockGroup(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockGroupQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockGroups] AS {1} {0} ON", "{2}.[StockGroupID] = {1}.[StockGroupID]"), o => ((Sales_SpecialDeal)o)?.Warehouse_StockGroup, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockGroup)ppe(QueryHelpers.Fill<Warehouse_StockGroup>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Warehouse_StockGroup = child;
                }

                return child;
            }

            , typeof (Warehouse_StockGroup), preloadEntities);
        }

        public Warehouse_StockItemQuery<Sales_SpecialDealQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Sales_SpecialDealQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Sales_SpecialDeal)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Sales_SpecialDeal)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Sales_SpecialDealTableQuery<T> : Sales_SpecialDealQuery<Sales_SpecialDealTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_SpecialDealTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_SpecialDealHelper : QueryHelper<Sales_SpecialDeal>, IHelper<Sales_SpecialDeal>
    {
        string[] columnsInSelectStatement = new[]{"{0}.SpecialDealID", "{0}.StockItemID", "{0}.CustomerID", "{0}.BuyingGroupID", "{0}.CustomerCategoryID", "{0}.StockGroupID", "{0}.DealDescription", "{0}.StartDate", "{0}.EndDate", "{0}.DiscountAmount", "{0}.DiscountPercentage", "{0}.UnitPrice", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.SpecialDealID", "{0}.StockItemID", "{0}.CustomerID", "{0}.BuyingGroupID", "{0}.CustomerCategoryID", "{0}.StockGroupID", "{0}.DealDescription", "{0}.StartDate", "{0}.EndDate", "{0}.DiscountAmount", "{0}.DiscountPercentage", "{0}.UnitPrice", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_SpecialDeal ([SpecialDealID] Int NOT NULL,[StockItemID] Int,[CustomerID] Int,[BuyingGroupID] Int,[CustomerCategoryID] Int,[StockGroupID] Int,[DealDescription] NVarChar(30) NOT NULL,[StartDate] Date NOT NULL,[EndDate] Date NOT NULL,[DiscountAmount] Decimal(18,2),[DiscountPercentage] Decimal(18,3),[UnitPrice] Decimal(18,2),[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[SpecialDeals]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Sales].[SpecialDeals] ([{TableName = \"Sales].[SpecialDeals\";}].[SpecialDealID], [{TableName = \"Sales].[SpecialDeals\";}].[StockItemID], [{TableName = \"Sales].[SpecialDeals\";}].[CustomerID], [{TableName = \"Sales].[SpecialDeals\";}].[BuyingGroupID], [{TableName = \"Sales].[SpecialDeals\";}].[CustomerCategoryID], [{TableName = \"Sales].[SpecialDeals\";}].[StockGroupID], [{TableName = \"Sales].[SpecialDeals\";}].[DealDescription], [{TableName = \"Sales].[SpecialDeals\";}].[StartDate], [{TableName = \"Sales].[SpecialDeals\";}].[EndDate], [{TableName = \"Sales].[SpecialDeals\";}].[DiscountAmount], [{TableName = \"Sales].[SpecialDeals\";}].[DiscountPercentage], [{TableName = \"Sales].[SpecialDeals\";}].[UnitPrice], [{TableName = \"Sales].[SpecialDeals\";}].[LastEditedBy], [{TableName = \"Sales].[SpecialDeals\";}].[LastEditedWhen]) VALUES ([@SpecialDealID],[@StockItemID],[@CustomerID],[@BuyingGroupID],[@CustomerCategoryID],[@StockGroupID],[@DealDescription],[@StartDate],[@EndDate],[@DiscountAmount],[@DiscountPercentage],[@UnitPrice],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_SpecialDeal _Sales_SpecialDeal)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@SpecialDealID", _Sales_SpecialDeal.SpecialDealID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Sales_SpecialDeal.StockItemID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Sales_SpecialDeal.CustomerID);
            sqlCommand.Parameters.AddWithValue("@BuyingGroupID", _Sales_SpecialDeal.BuyingGroupID);
            sqlCommand.Parameters.AddWithValue("@CustomerCategoryID", _Sales_SpecialDeal.CustomerCategoryID);
            sqlCommand.Parameters.AddWithValue("@StockGroupID", _Sales_SpecialDeal.StockGroupID);
            sqlCommand.Parameters.AddWithValue("@DealDescription", _Sales_SpecialDeal.DealDescription ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@StartDate", _Sales_SpecialDeal.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", _Sales_SpecialDeal.EndDate);
            sqlCommand.Parameters.AddWithValue("@DiscountAmount", _Sales_SpecialDeal.DiscountAmount);
            sqlCommand.Parameters.AddWithValue("@DiscountPercentage", _Sales_SpecialDeal.DiscountPercentage);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", _Sales_SpecialDeal.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_SpecialDeal.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_SpecialDeal.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_SpecialDeal _Sales_SpecialDeal)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_SpecialDeal.SpecialDealID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_SpecialDealWrapper _wrapper = Sales_SpecialDealWrapper.Instance;
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
    public class Sales_SpecialDealWrapper : QueryWrapper<Sales_SpecialDeal>
    {
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Sales_Customer> CustomerID = new QueryElMemberId<Sales_Customer>("CustomerID");
        public readonly QueryElMemberId<Sales_BuyingGroup> BuyingGroupID = new QueryElMemberId<Sales_BuyingGroup>("BuyingGroupID");
        public readonly QueryElMemberId<Sales_CustomerCategory> CustomerCategoryID = new QueryElMemberId<Sales_CustomerCategory>("CustomerCategoryID");
        public readonly QueryElMemberId<Warehouse_StockGroup> StockGroupID = new QueryElMemberId<Warehouse_StockGroup>("StockGroupID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> DealDescription = new QueryElMember<System.String>("DealDescription");
        public readonly QueryElMemberStruct<System.DateTime> StartDate = new QueryElMemberStruct<System.DateTime>("StartDate");
        public readonly QueryElMemberStruct<System.DateTime> EndDate = new QueryElMemberStruct<System.DateTime>("EndDate");
        public readonly QueryElMemberStruct<System.Decimal> DiscountAmount = new QueryElMemberStruct<System.Decimal>("DiscountAmount");
        public readonly QueryElMemberStruct<System.Decimal> DiscountPercentage = new QueryElMemberStruct<System.Decimal>("DiscountPercentage");
        public readonly QueryElMemberStruct<System.Decimal> UnitPrice = new QueryElMemberStruct<System.Decimal>("UnitPrice");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_SpecialDealWrapper Instance = new Sales_SpecialDealWrapper();
        private Sales_SpecialDealWrapper(): base ("[Sales].[SpecialDeals]", "Sales_SpecialDeal")
        {
        }
    }
}