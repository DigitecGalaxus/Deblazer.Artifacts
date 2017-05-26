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
    public partial class Warehouse_StockItemTransaction : DbEntity, IId
    {
        private DbValue<System.Int32> _StockItemTransactionID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _TransactionTypeID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _InvoiceID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _SupplierID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PurchaseOrderID = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _TransactionOccurredWhen = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _Quantity = new DbValue<System.Decimal>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Sales_Customer> _Sales_Customer;
        private IDbEntityRef<Sales_Invoice> _Sales_Invoice;
        private IDbEntityRef<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrder;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        private IDbEntityRef<Purchasing_Supplier> _Purchasing_Supplier;
        private IDbEntityRef<Application_TransactionType> _Application_TransactionType;
        public int Id => StockItemTransactionID;
        long ILongId.Id => StockItemTransactionID;
        [Validate]
        public System.Int32 StockItemTransactionID
        {
            get
            {
                return _StockItemTransactionID.Entity;
            }

            set
            {
                _StockItemTransactionID.Entity = value;
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
        public System.Int32 TransactionTypeID
        {
            get
            {
                return _TransactionTypeID.Entity;
            }

            set
            {
                _TransactionTypeID.Entity = value;
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
        public System.Int32 InvoiceID
        {
            get
            {
                return _InvoiceID.Entity;
            }

            set
            {
                _InvoiceID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 SupplierID
        {
            get
            {
                return _SupplierID.Entity;
            }

            set
            {
                _SupplierID.Entity = value;
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

        [StringColumn(7, false)]
        [Validate]
        public System.DateTime TransactionOccurredWhen
        {
            get
            {
                return _TransactionOccurredWhen.Entity;
            }

            set
            {
                _TransactionOccurredWhen.Entity = value;
            }
        }

        [Validate]
        public System.Decimal Quantity
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
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Customer Sales_Customer
        {
            get
            {
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
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

                AssignDbEntity<Sales_Customer, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Sales_Customer, new long ? []{_CustomerID.Entity}, new Action<long ? >[]{x => CustomerID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, CustomerIDChanged);
            }
        }

        void CustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _CustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public Sales_Invoice Sales_Invoice
        {
            get
            {
                Action<Sales_Invoice> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
                if (_Sales_Invoice != null)
                {
                    return _Sales_Invoice.GetEntity(beforeRightsCheckAction);
                }

                _Sales_Invoice = GetDbEntityRef(true, new[]{"[InvoiceID]"}, new Func<long ? >[]{() => _InvoiceID.Entity}, beforeRightsCheckAction);
                return (Sales_Invoice != null) ? _Sales_Invoice.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_Invoice == null)
                {
                    _Sales_Invoice = new DbEntityRef<Sales_Invoice>(_db, true, new[]{"[InvoiceID]"}, new Func<long ? >[]{() => _InvoiceID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Invoice, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.InvoiceID}, _Sales_Invoice, new long ? []{_InvoiceID.Entity}, new Action<long ? >[]{x => InvoiceID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, InvoiceIDChanged);
            }
        }

        void InvoiceIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Invoice)
                _InvoiceID.Entity = (int)((Sales_Invoice)sender).Id;
        }

        [Validate]
        public Purchasing_PurchaseOrder Purchasing_PurchaseOrder
        {
            get
            {
                Action<Purchasing_PurchaseOrder> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
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

                AssignDbEntity<Purchasing_PurchaseOrder, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PurchaseOrderID}, _Purchasing_PurchaseOrder, new long ? []{_PurchaseOrderID.Entity}, new Action<long ? >[]{x => PurchaseOrderID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, PurchaseOrderIDChanged);
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
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, StockItemIDChanged);
            }
        }

        void StockItemIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_StockItem)
                _StockItemID.Entity = (int)((Warehouse_StockItem)sender).Id;
        }

        [Validate]
        public Purchasing_Supplier Purchasing_Supplier
        {
            get
            {
                Action<Purchasing_Supplier> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
                if (_Purchasing_Supplier != null)
                {
                    return _Purchasing_Supplier.GetEntity(beforeRightsCheckAction);
                }

                _Purchasing_Supplier = GetDbEntityRef(true, new[]{"[SupplierID]"}, new Func<long ? >[]{() => _SupplierID.Entity}, beforeRightsCheckAction);
                return (Purchasing_Supplier != null) ? _Purchasing_Supplier.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Purchasing_Supplier == null)
                {
                    _Purchasing_Supplier = new DbEntityRef<Purchasing_Supplier>(_db, true, new[]{"[SupplierID]"}, new Func<long ? >[]{() => _SupplierID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Purchasing_Supplier, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.SupplierID}, _Purchasing_Supplier, new long ? []{_SupplierID.Entity}, new Action<long ? >[]{x => SupplierID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, SupplierIDChanged);
            }
        }

        void SupplierIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_Supplier)
                _SupplierID.Entity = (int)((Purchasing_Supplier)sender).Id;
        }

        [Validate]
        public Application_TransactionType Application_TransactionType
        {
            get
            {
                Action<Application_TransactionType> beforeRightsCheckAction = e => e.Warehouse_StockItemTransactions.Add(this);
                if (_Application_TransactionType != null)
                {
                    return _Application_TransactionType.GetEntity(beforeRightsCheckAction);
                }

                _Application_TransactionType = GetDbEntityRef(true, new[]{"[TransactionTypeID]"}, new Func<long ? >[]{() => _TransactionTypeID.Entity}, beforeRightsCheckAction);
                return (Application_TransactionType != null) ? _Application_TransactionType.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_TransactionType == null)
                {
                    _Application_TransactionType = new DbEntityRef<Application_TransactionType>(_db, true, new[]{"[TransactionTypeID]"}, new Func<long ? >[]{() => _TransactionTypeID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_TransactionType, Warehouse_StockItemTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.TransactionTypeID}, _Application_TransactionType, new long ? []{_TransactionTypeID.Entity}, new Action<long ? >[]{x => TransactionTypeID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemTransactions, null, TransactionTypeIDChanged);
            }
        }

        void TransactionTypeIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_TransactionType)
                _TransactionTypeID.Entity = (int)((Application_TransactionType)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _StockItemTransactionID.Load(visitor.GetInt32());
            SendIdChanged();
            _StockItemID.Load(visitor.GetInt32());
            _TransactionTypeID.Load(visitor.GetInt32());
            _CustomerID.Load(visitor.GetInt32());
            _InvoiceID.Load(visitor.GetInt32());
            _SupplierID.Load(visitor.GetInt32());
            _PurchaseOrderID.Load(visitor.GetInt32());
            _TransactionOccurredWhen.Load(visitor.GetDateTime());
            _Quantity.Load(visitor.GetDecimal());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StockItemTransactionID.Welcome(visitor, "StockItemTransactionID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _TransactionTypeID.Welcome(visitor, "TransactionTypeID", "Int NOT NULL", false);
            _CustomerID.Welcome(visitor, "CustomerID", "Int", false);
            _InvoiceID.Welcome(visitor, "InvoiceID", "Int", false);
            _SupplierID.Welcome(visitor, "SupplierID", "Int", false);
            _PurchaseOrderID.Welcome(visitor, "PurchaseOrderID", "Int", false);
            _TransactionOccurredWhen.Welcome(visitor, "TransactionOccurredWhen", "DateTime2(7) NOT NULL", false);
            _Quantity.Welcome(visitor, "Quantity", "Decimal(18,3) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Sales_Customer);
            visitor.ProcessAssociation(this, _Sales_Invoice);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrder);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
            visitor.ProcessAssociation(this, _Purchasing_Supplier);
            visitor.ProcessAssociation(this, _Application_TransactionType);
        }
    }

    public static class Db_Warehouse_StockItemTransactionQueryGetterExtensions
    {
        public static Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction> Warehouse_StockItemTransactions(this IDb db)
        {
            var query = new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_StockItemTransactionQuery<K, T> : Query<K, T, Warehouse_StockItemTransaction, Warehouse_StockItemTransactionWrapper, Warehouse_StockItemTransactionQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_StockItemTransactionQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_StockItemTransactionWrapper GetWrapper()
        {
            return Warehouse_StockItemTransactionWrapper.Instance;
        }

        public Application_PeopleQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_StockItemTransaction)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinSales_Customer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), o => ((Warehouse_StockItemTransaction)o)?.Sales_Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Sales_Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Sales_InvoiceQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinSales_Invoice(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), o => ((Warehouse_StockItemTransaction)o)?.Sales_Invoice, (e, fv, ppe) =>
            {
                var child = (Sales_Invoice)ppe(QueryHelpers.Fill<Sales_Invoice>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Sales_Invoice = child;
                }

                return child;
            }

            , typeof (Sales_Invoice), preloadEntities);
        }

        public Purchasing_PurchaseOrderQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinPurchasing_PurchaseOrder(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), o => ((Warehouse_StockItemTransaction)o)?.Purchasing_PurchaseOrder, (e, fv, ppe) =>
            {
                var child = (Purchasing_PurchaseOrder)ppe(QueryHelpers.Fill<Purchasing_PurchaseOrder>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Purchasing_PurchaseOrder = child;
                }

                return child;
            }

            , typeof (Purchasing_PurchaseOrder), preloadEntities);
        }

        public Warehouse_StockItemQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Warehouse_StockItemTransaction)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }

        public Purchasing_SupplierQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinPurchasing_Supplier(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), o => ((Warehouse_StockItemTransaction)o)?.Purchasing_Supplier, (e, fv, ppe) =>
            {
                var child = (Purchasing_Supplier)ppe(QueryHelpers.Fill<Purchasing_Supplier>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Purchasing_Supplier = child;
                }

                return child;
            }

            , typeof (Purchasing_Supplier), preloadEntities);
        }

        public Application_TransactionTypeQuery<Warehouse_StockItemTransactionQuery<K, T>, T> JoinApplication_TransactionType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_TransactionTypeQuery<Warehouse_StockItemTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[TransactionTypes] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), o => ((Warehouse_StockItemTransaction)o)?.Application_TransactionType, (e, fv, ppe) =>
            {
                var child = (Application_TransactionType)ppe(QueryHelpers.Fill<Application_TransactionType>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemTransaction)e).Application_TransactionType = child;
                }

                return child;
            }

            , typeof (Application_TransactionType), preloadEntities);
        }
    }

    public class Warehouse_StockItemTransactionTableQuery<T> : Warehouse_StockItemTransactionQuery<Warehouse_StockItemTransactionTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_StockItemTransactionTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_StockItemTransactionHelper : QueryHelper<Warehouse_StockItemTransaction>, IHelper<Warehouse_StockItemTransaction>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StockItemTransactionID", "{0}.StockItemID", "{0}.TransactionTypeID", "{0}.CustomerID", "{0}.InvoiceID", "{0}.SupplierID", "{0}.PurchaseOrderID", "{0}.TransactionOccurredWhen", "{0}.Quantity", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StockItemTransactionID", "{0}.StockItemID", "{0}.TransactionTypeID", "{0}.CustomerID", "{0}.InvoiceID", "{0}.SupplierID", "{0}.PurchaseOrderID", "{0}.TransactionOccurredWhen", "{0}.Quantity", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_StockItemTransaction ([StockItemTransactionID] Int NOT NULL,[StockItemID] Int NOT NULL,[TransactionTypeID] Int NOT NULL,[CustomerID] Int,[InvoiceID] Int,[SupplierID] Int,[PurchaseOrderID] Int,[TransactionOccurredWhen] DateTime2(7) NOT NULL,[Quantity] Decimal(18,3) NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[StockItemTransactions]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[StockItemTransactions] ([{TableName = \"Warehouse].[StockItemTransactions\";}].[StockItemTransactionID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[StockItemID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[TransactionTypeID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[CustomerID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[InvoiceID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[SupplierID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[PurchaseOrderID], [{TableName = \"Warehouse].[StockItemTransactions\";}].[TransactionOccurredWhen], [{TableName = \"Warehouse].[StockItemTransactions\";}].[Quantity], [{TableName = \"Warehouse].[StockItemTransactions\";}].[LastEditedBy], [{TableName = \"Warehouse].[StockItemTransactions\";}].[LastEditedWhen]) VALUES ([@StockItemTransactionID],[@StockItemID],[@TransactionTypeID],[@CustomerID],[@InvoiceID],[@SupplierID],[@PurchaseOrderID],[@TransactionOccurredWhen],[@Quantity],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemTransaction _Warehouse_StockItemTransaction)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StockItemTransactionID", _Warehouse_StockItemTransaction.StockItemTransactionID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Warehouse_StockItemTransaction.StockItemID);
            sqlCommand.Parameters.AddWithValue("@TransactionTypeID", _Warehouse_StockItemTransaction.TransactionTypeID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Warehouse_StockItemTransaction.CustomerID);
            sqlCommand.Parameters.AddWithValue("@InvoiceID", _Warehouse_StockItemTransaction.InvoiceID);
            sqlCommand.Parameters.AddWithValue("@SupplierID", _Warehouse_StockItemTransaction.SupplierID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", _Warehouse_StockItemTransaction.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@TransactionOccurredWhen", _Warehouse_StockItemTransaction.TransactionOccurredWhen);
            sqlCommand.Parameters.AddWithValue("@Quantity", _Warehouse_StockItemTransaction.Quantity);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_StockItemTransaction.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Warehouse_StockItemTransaction.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemTransaction _Warehouse_StockItemTransaction)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_StockItemTransaction.StockItemTransactionID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_StockItemTransactionWrapper _wrapper = Warehouse_StockItemTransactionWrapper.Instance;
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
    public class Warehouse_StockItemTransactionWrapper : QueryWrapper<Warehouse_StockItemTransaction>
    {
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Application_TransactionType> TransactionTypeID = new QueryElMemberId<Application_TransactionType>("TransactionTypeID");
        public readonly QueryElMemberId<Sales_Customer> CustomerID = new QueryElMemberId<Sales_Customer>("CustomerID");
        public readonly QueryElMemberId<Sales_Invoice> InvoiceID = new QueryElMemberId<Sales_Invoice>("InvoiceID");
        public readonly QueryElMemberId<Purchasing_Supplier> SupplierID = new QueryElMemberId<Purchasing_Supplier>("SupplierID");
        public readonly QueryElMemberId<Purchasing_PurchaseOrder> PurchaseOrderID = new QueryElMemberId<Purchasing_PurchaseOrder>("PurchaseOrderID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> TransactionOccurredWhen = new QueryElMemberStruct<System.DateTime>("TransactionOccurredWhen");
        public readonly QueryElMemberStruct<System.Decimal> Quantity = new QueryElMemberStruct<System.Decimal>("Quantity");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Warehouse_StockItemTransactionWrapper Instance = new Warehouse_StockItemTransactionWrapper();
        private Warehouse_StockItemTransactionWrapper(): base ("[Warehouse].[StockItemTransactions]", "Warehouse_StockItemTransaction")
        {
        }
    }
}