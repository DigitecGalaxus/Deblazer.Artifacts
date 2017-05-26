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
    public partial class Purchasing_PurchaseOrder : DbEntity, IId
    {
        private DbValue<System.Int32> _PurchaseOrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _SupplierID = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _OrderDate = new DbValue<System.DateTime>();
        private DbValue<System.Int32> _DeliveryMethodID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _ContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ExpectedDeliveryDate = new DbValue<System.DateTime>();
        private DbValue<System.String> _SupplierReference = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsOrderFinalized = new DbValue<System.Boolean>();
        private DbValue<System.String> _Comments = new DbValue<System.String>();
        private DbValue<System.String> _InternalComments = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntitySet<Purchasing_PurchaseOrderLine> _Purchasing_PurchaseOrderLines;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_People> _ContactPerson;
        private IDbEntityRef<Application_DeliveryMethod> _Application_DeliveryMethod;
        private IDbEntityRef<Purchasing_Supplier> _Purchasing_Supplier;
        private IDbEntitySet<Purchasing_SupplierTransaction> _Purchasing_SupplierTransactions;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => PurchaseOrderID;
        long ILongId.Id => PurchaseOrderID;
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
        public System.DateTime OrderDate
        {
            get
            {
                return _OrderDate.Entity;
            }

            set
            {
                _OrderDate.Entity = value;
            }
        }

        [Validate]
        public System.Int32 DeliveryMethodID
        {
            get
            {
                return _DeliveryMethodID.Entity;
            }

            set
            {
                _DeliveryMethodID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 ContactPersonID
        {
            get
            {
                return _ContactPersonID.Entity;
            }

            set
            {
                _ContactPersonID.Entity = value;
            }
        }

        [Validate]
        public System.DateTime ExpectedDeliveryDate
        {
            get
            {
                return _ExpectedDeliveryDate.Entity;
            }

            set
            {
                _ExpectedDeliveryDate.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String SupplierReference
        {
            get
            {
                return _SupplierReference.Entity;
            }

            set
            {
                _SupplierReference.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsOrderFinalized
        {
            get
            {
                return _IsOrderFinalized.Entity;
            }

            set
            {
                _IsOrderFinalized.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String Comments
        {
            get
            {
                return _Comments.Entity;
            }

            set
            {
                _Comments.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String InternalComments
        {
            get
            {
                return _InternalComments.Entity;
            }

            set
            {
                _InternalComments.Entity = value;
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
        public IDbEntitySet<Purchasing_PurchaseOrderLine> Purchasing_PurchaseOrderLines
        {
            get
            {
                if (_Purchasing_PurchaseOrderLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrderLines = new DbEntitySetCached<Purchasing_PurchaseOrder, Purchasing_PurchaseOrderLine>(() => _PurchaseOrderID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrderLines = new DbEntitySet<Purchasing_PurchaseOrderLine>(_db, false, new Func<long ? >[]{() => _PurchaseOrderID.Entity}, new[]{"[PurchaseOrderID]"}, (member, root) => member.Purchasing_PurchaseOrder = root as Purchasing_PurchaseOrder, this, _lazyLoadChildren, e => e.Purchasing_PurchaseOrder = this, e =>
                    {
                        var x = e.Purchasing_PurchaseOrder;
                        e.Purchasing_PurchaseOrder = null;
                        new UpdateSetVisitor(true, new[]{"PurchaseOrderID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrderLines;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrders.Add(this);
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

                AssignDbEntity<Application_People, Purchasing_PurchaseOrder>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrders, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_People ContactPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrders.Add(this);
                if (_ContactPerson != null)
                {
                    return _ContactPerson.GetEntity(beforeRightsCheckAction);
                }

                _ContactPerson = GetDbEntityRef(true, new[]{"[ContactPersonID]"}, new Func<long ? >[]{() => _ContactPersonID.Entity}, beforeRightsCheckAction);
                return (ContactPerson != null) ? _ContactPerson.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_ContactPerson == null)
                {
                    _ContactPerson = new DbEntityRef<Application_People>(_db, true, new[]{"[ContactPersonID]"}, new Func<long ? >[]{() => _ContactPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Purchasing_PurchaseOrder>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _ContactPerson, new long ? []{_ContactPersonID.Entity}, new Action<long ? >[]{x => ContactPersonID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrders, null, ContactPersonIDChanged);
            }
        }

        void ContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _ContactPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_DeliveryMethod Application_DeliveryMethod
        {
            get
            {
                Action<Application_DeliveryMethod> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrders.Add(this);
                if (_Application_DeliveryMethod != null)
                {
                    return _Application_DeliveryMethod.GetEntity(beforeRightsCheckAction);
                }

                _Application_DeliveryMethod = GetDbEntityRef(true, new[]{"[DeliveryMethodID]"}, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, beforeRightsCheckAction);
                return (Application_DeliveryMethod != null) ? _Application_DeliveryMethod.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_DeliveryMethod == null)
                {
                    _Application_DeliveryMethod = new DbEntityRef<Application_DeliveryMethod>(_db, true, new[]{"[DeliveryMethodID]"}, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_DeliveryMethod, Purchasing_PurchaseOrder>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.DeliveryMethodID}, _Application_DeliveryMethod, new long ? []{_DeliveryMethodID.Entity}, new Action<long ? >[]{x => DeliveryMethodID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrders, null, DeliveryMethodIDChanged);
            }
        }

        void DeliveryMethodIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_DeliveryMethod)
                _DeliveryMethodID.Entity = (int)((Application_DeliveryMethod)sender).Id;
        }

        [Validate]
        public Purchasing_Supplier Purchasing_Supplier
        {
            get
            {
                Action<Purchasing_Supplier> beforeRightsCheckAction = e => e.Purchasing_PurchaseOrders.Add(this);
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

                AssignDbEntity<Purchasing_Supplier, Purchasing_PurchaseOrder>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.SupplierID}, _Purchasing_Supplier, new long ? []{_SupplierID.Entity}, new Action<long ? >[]{x => SupplierID = (int ? )x ?? default (int)}, x => x.Purchasing_PurchaseOrders, null, SupplierIDChanged);
            }
        }

        void SupplierIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_Supplier)
                _SupplierID.Entity = (int)((Purchasing_Supplier)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Purchasing_SupplierTransaction> Purchasing_SupplierTransactions
        {
            get
            {
                if (_Purchasing_SupplierTransactions == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_SupplierTransactions = new DbEntitySetCached<Purchasing_PurchaseOrder, Purchasing_SupplierTransaction>(() => _PurchaseOrderID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierTransactions = new DbEntitySet<Purchasing_SupplierTransaction>(_db, false, new Func<long ? >[]{() => _PurchaseOrderID.Entity}, new[]{"[PurchaseOrderID]"}, (member, root) => member.Purchasing_PurchaseOrder = root as Purchasing_PurchaseOrder, this, _lazyLoadChildren, e => e.Purchasing_PurchaseOrder = this, e =>
                    {
                        var x = e.Purchasing_PurchaseOrder;
                        e.Purchasing_PurchaseOrder = null;
                        new UpdateSetVisitor(true, new[]{"PurchaseOrderID"}, false).Process(x);
                    }

                    );
                return _Purchasing_SupplierTransactions;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItemTransaction> Warehouse_StockItemTransactions
        {
            get
            {
                if (_Warehouse_StockItemTransactions == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Purchasing_PurchaseOrder, Warehouse_StockItemTransaction>(() => _PurchaseOrderID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _PurchaseOrderID.Entity}, new[]{"[PurchaseOrderID]"}, (member, root) => member.Purchasing_PurchaseOrder = root as Purchasing_PurchaseOrder, this, _lazyLoadChildren, e => e.Purchasing_PurchaseOrder = this, e =>
                    {
                        var x = e.Purchasing_PurchaseOrder;
                        e.Purchasing_PurchaseOrder = null;
                        new UpdateSetVisitor(true, new[]{"PurchaseOrderID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _PurchaseOrderID.Load(visitor.GetInt32());
            SendIdChanged();
            _SupplierID.Load(visitor.GetInt32());
            _OrderDate.Load(visitor.GetDateTime());
            _DeliveryMethodID.Load(visitor.GetInt32());
            _ContactPersonID.Load(visitor.GetInt32());
            _ExpectedDeliveryDate.Load(visitor.GetDateTime());
            _SupplierReference.Load(visitor.GetValue<System.String>());
            _IsOrderFinalized.Load(visitor.GetBoolean());
            _Comments.Load(visitor.GetValue<System.String>());
            _InternalComments.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _PurchaseOrderID.Welcome(visitor, "PurchaseOrderID", "Int NOT NULL", false);
            _SupplierID.Welcome(visitor, "SupplierID", "Int NOT NULL", false);
            _OrderDate.Welcome(visitor, "OrderDate", "Date NOT NULL", false);
            _DeliveryMethodID.Welcome(visitor, "DeliveryMethodID", "Int NOT NULL", false);
            _ContactPersonID.Welcome(visitor, "ContactPersonID", "Int NOT NULL", false);
            _ExpectedDeliveryDate.Welcome(visitor, "ExpectedDeliveryDate", "Date", false);
            _SupplierReference.Welcome(visitor, "SupplierReference", "NVarChar(20)", false);
            _IsOrderFinalized.Welcome(visitor, "IsOrderFinalized", "Bit NOT NULL", false);
            _Comments.Welcome(visitor, "Comments", "NVarChar(MAX)", false);
            _InternalComments.Welcome(visitor, "InternalComments", "NVarChar(MAX)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrderLines);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _ContactPerson);
            visitor.ProcessAssociation(this, _Application_DeliveryMethod);
            visitor.ProcessAssociation(this, _Purchasing_Supplier);
            visitor.ProcessAssociation(this, _Purchasing_SupplierTransactions);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Purchasing_PurchaseOrderQueryGetterExtensions
    {
        public static Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder> Purchasing_PurchaseOrders(this IDb db)
        {
            var query = new Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Purchasing_PurchaseOrderQuery<K, T> : Query<K, T, Purchasing_PurchaseOrder, Purchasing_PurchaseOrderWrapper, Purchasing_PurchaseOrderQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Purchasing_PurchaseOrderQuery(IDb db): base (db)
        {
        }

        protected sealed override Purchasing_PurchaseOrderWrapper GetWrapper()
        {
            return Purchasing_PurchaseOrderWrapper.Instance;
        }

        public Purchasing_PurchaseOrderLineQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinPurchasing_PurchaseOrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderLineQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrderLines] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), (p, ids) => ((Purchasing_PurchaseOrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_PurchaseOrder)o).Purchasing_PurchaseOrderLines.Attach(v.Cast<Purchasing_PurchaseOrderLine>()), p => (long)((Purchasing_PurchaseOrderLine)p).PurchaseOrderID, attach);
        }

        public Application_PeopleQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Purchasing_PurchaseOrder)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrder)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinContactPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[ContactPersonID] = {1}.[PersonID]"), o => ((Purchasing_PurchaseOrder)o)?.ContactPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrder)e).ContactPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_DeliveryMethodQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinApplication_DeliveryMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_DeliveryMethodQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[DeliveryMethods] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), o => ((Purchasing_PurchaseOrder)o)?.Application_DeliveryMethod, (e, fv, ppe) =>
            {
                var child = (Application_DeliveryMethod)ppe(QueryHelpers.Fill<Application_DeliveryMethod>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrder)e).Application_DeliveryMethod = child;
                }

                return child;
            }

            , typeof (Application_DeliveryMethod), preloadEntities);
        }

        public Purchasing_SupplierQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinPurchasing_Supplier(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), o => ((Purchasing_PurchaseOrder)o)?.Purchasing_Supplier, (e, fv, ppe) =>
            {
                var child = (Purchasing_Supplier)ppe(QueryHelpers.Fill<Purchasing_Supplier>(null, fv));
                if (e != null)
                {
                    ((Purchasing_PurchaseOrder)e).Purchasing_Supplier = child;
                }

                return child;
            }

            , typeof (Purchasing_Supplier), preloadEntities);
        }

        public Purchasing_SupplierTransactionQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinPurchasing_SupplierTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierTransactionQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierTransactions] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), (p, ids) => ((Purchasing_SupplierTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_PurchaseOrder)o).Purchasing_SupplierTransactions.Attach(v.Cast<Purchasing_SupplierTransaction>()), p => (long)((Purchasing_SupplierTransaction)p).PurchaseOrderID, attach);
        }

        public Warehouse_StockItemTransactionQuery<Purchasing_PurchaseOrderQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Purchasing_PurchaseOrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_PurchaseOrder)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).PurchaseOrderID, attach);
        }
    }

    public class Purchasing_PurchaseOrderTableQuery<T> : Purchasing_PurchaseOrderQuery<Purchasing_PurchaseOrderTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Purchasing_PurchaseOrderTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Purchasing_PurchaseOrderHelper : QueryHelper<Purchasing_PurchaseOrder>, IHelper<Purchasing_PurchaseOrder>
    {
        string[] columnsInSelectStatement = new[]{"{0}.PurchaseOrderID", "{0}.SupplierID", "{0}.OrderDate", "{0}.DeliveryMethodID", "{0}.ContactPersonID", "{0}.ExpectedDeliveryDate", "{0}.SupplierReference", "{0}.IsOrderFinalized", "{0}.Comments", "{0}.InternalComments", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.PurchaseOrderID", "{0}.SupplierID", "{0}.OrderDate", "{0}.DeliveryMethodID", "{0}.ContactPersonID", "{0}.ExpectedDeliveryDate", "{0}.SupplierReference", "{0}.IsOrderFinalized", "{0}.Comments", "{0}.InternalComments", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Purchasing_PurchaseOrder ([PurchaseOrderID] Int NOT NULL,[SupplierID] Int NOT NULL,[OrderDate] Date NOT NULL,[DeliveryMethodID] Int NOT NULL,[ContactPersonID] Int NOT NULL,[ExpectedDeliveryDate] Date,[SupplierReference] NVarChar(20),[IsOrderFinalized] Bit NOT NULL,[Comments] NVarChar(MAX),[InternalComments] NVarChar(MAX),[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Purchasing].[PurchaseOrders]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_PurchaseOrderLine) || other == typeof (Purchasing_SupplierTransaction) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Purchasing].[PurchaseOrders] ([{TableName = \"Purchasing].[PurchaseOrders\";}].[PurchaseOrderID], [{TableName = \"Purchasing].[PurchaseOrders\";}].[SupplierID], [{TableName = \"Purchasing].[PurchaseOrders\";}].[OrderDate], [{TableName = \"Purchasing].[PurchaseOrders\";}].[DeliveryMethodID], [{TableName = \"Purchasing].[PurchaseOrders\";}].[ContactPersonID], [{TableName = \"Purchasing].[PurchaseOrders\";}].[ExpectedDeliveryDate], [{TableName = \"Purchasing].[PurchaseOrders\";}].[SupplierReference], [{TableName = \"Purchasing].[PurchaseOrders\";}].[IsOrderFinalized], [{TableName = \"Purchasing].[PurchaseOrders\";}].[Comments], [{TableName = \"Purchasing].[PurchaseOrders\";}].[InternalComments], [{TableName = \"Purchasing].[PurchaseOrders\";}].[LastEditedBy], [{TableName = \"Purchasing].[PurchaseOrders\";}].[LastEditedWhen]) VALUES ([@PurchaseOrderID],[@SupplierID],[@OrderDate],[@DeliveryMethodID],[@ContactPersonID],[@ExpectedDeliveryDate],[@SupplierReference],[@IsOrderFinalized],[@Comments],[@InternalComments],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Purchasing_PurchaseOrder _Purchasing_PurchaseOrder)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", _Purchasing_PurchaseOrder.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@SupplierID", _Purchasing_PurchaseOrder.SupplierID);
            sqlCommand.Parameters.AddWithValue("@OrderDate", _Purchasing_PurchaseOrder.OrderDate);
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodID", _Purchasing_PurchaseOrder.DeliveryMethodID);
            sqlCommand.Parameters.AddWithValue("@ContactPersonID", _Purchasing_PurchaseOrder.ContactPersonID);
            sqlCommand.Parameters.AddWithValue("@ExpectedDeliveryDate", _Purchasing_PurchaseOrder.ExpectedDeliveryDate);
            sqlCommand.Parameters.AddWithValue("@SupplierReference", _Purchasing_PurchaseOrder.SupplierReference ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsOrderFinalized", _Purchasing_PurchaseOrder.IsOrderFinalized);
            sqlCommand.Parameters.AddWithValue("@Comments", _Purchasing_PurchaseOrder.Comments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@InternalComments", _Purchasing_PurchaseOrder.InternalComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Purchasing_PurchaseOrder.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Purchasing_PurchaseOrder.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Purchasing_PurchaseOrder _Purchasing_PurchaseOrder)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Purchasing_PurchaseOrder.PurchaseOrderID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Purchasing_PurchaseOrderWrapper _wrapper = Purchasing_PurchaseOrderWrapper.Instance;
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
    public class Purchasing_PurchaseOrderWrapper : QueryWrapper<Purchasing_PurchaseOrder>
    {
        public readonly QueryElMemberId<Purchasing_Supplier> SupplierID = new QueryElMemberId<Purchasing_Supplier>("SupplierID");
        public readonly QueryElMemberId<Application_DeliveryMethod> DeliveryMethodID = new QueryElMemberId<Application_DeliveryMethod>("DeliveryMethodID");
        public readonly QueryElMemberId<Application_People> ContactPersonID = new QueryElMemberId<Application_People>("ContactPersonID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> OrderDate = new QueryElMemberStruct<System.DateTime>("OrderDate");
        public readonly QueryElMemberStruct<System.DateTime> ExpectedDeliveryDate = new QueryElMemberStruct<System.DateTime>("ExpectedDeliveryDate");
        public readonly QueryElMember<System.String> SupplierReference = new QueryElMember<System.String>("SupplierReference");
        public readonly QueryElMemberStruct<System.Boolean> IsOrderFinalized = new QueryElMemberStruct<System.Boolean>("IsOrderFinalized");
        public readonly QueryElMember<System.String> Comments = new QueryElMember<System.String>("Comments");
        public readonly QueryElMember<System.String> InternalComments = new QueryElMember<System.String>("InternalComments");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Purchasing_PurchaseOrderWrapper Instance = new Purchasing_PurchaseOrderWrapper();
        private Purchasing_PurchaseOrderWrapper(): base ("[Purchasing].[PurchaseOrders]", "Purchasing_PurchaseOrder")
        {
        }
    }
}