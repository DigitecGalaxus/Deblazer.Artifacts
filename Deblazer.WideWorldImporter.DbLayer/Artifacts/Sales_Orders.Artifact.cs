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
    public partial class Sales_Order : DbEntity, IId
    {
        private DbValue<System.Int32> _OrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _SalespersonPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PickedByPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _ContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _BackorderOrderID = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _OrderDate = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ExpectedDeliveryDate = new DbValue<System.DateTime>();
        private DbValue<System.String> _CustomerPurchaseOrderNumber = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsUndersupplyBackordered = new DbValue<System.Boolean>();
        private DbValue<System.String> _Comments = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryInstructions = new DbValue<System.String>();
        private DbValue<System.String> _InternalComments = new DbValue<System.String>();
        private DbValue<System.DateTime> _PickingCompletedWhen = new DbValue<System.DateTime>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices;
        private IDbEntitySet<Sales_OrderLine> _Sales_OrderLines;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Sales_Order> _BackorderOrder;
        private IDbEntitySet<Sales_Order> _Orders;
        private IDbEntityRef<Application_People> _ContactPerson;
        private IDbEntityRef<Sales_Customer> _Sales_Customer;
        private IDbEntityRef<Application_People> _PickedByPerson;
        private IDbEntityRef<Application_People> _SalespersonPerson;
        public int Id => OrderID;
        long ILongId.Id => OrderID;
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
        public System.Int32 SalespersonPersonID
        {
            get
            {
                return _SalespersonPersonID.Entity;
            }

            set
            {
                _SalespersonPersonID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PickedByPersonID
        {
            get
            {
                return _PickedByPersonID.Entity;
            }

            set
            {
                _PickedByPersonID.Entity = value;
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
        public System.Int32 BackorderOrderID
        {
            get
            {
                return _BackorderOrderID.Entity;
            }

            set
            {
                _BackorderOrderID.Entity = value;
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
        public System.String CustomerPurchaseOrderNumber
        {
            get
            {
                return _CustomerPurchaseOrderNumber.Entity;
            }

            set
            {
                _CustomerPurchaseOrderNumber.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsUndersupplyBackordered
        {
            get
            {
                return _IsUndersupplyBackordered.Entity;
            }

            set
            {
                _IsUndersupplyBackordered.Entity = value;
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
        public System.String DeliveryInstructions
        {
            get
            {
                return _DeliveryInstructions.Entity;
            }

            set
            {
                _DeliveryInstructions.Entity = value;
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
        public IDbEntitySet<Sales_Invoice> Sales_Invoices
        {
            get
            {
                if (_Sales_Invoices == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices = new DbEntitySetCached<Sales_Order, Sales_Invoice>(() => _OrderID.Entity);
                    }
                }
                else
                    _Sales_Invoices = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _OrderID.Entity}, new[]{"[OrderID]"}, (member, root) => member.Sales_Order = root as Sales_Order, this, _lazyLoadChildren, e => e.Sales_Order = this, e =>
                    {
                        var x = e.Sales_Order;
                        e.Sales_Order = null;
                        new UpdateSetVisitor(true, new[]{"OrderID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_OrderLine> Sales_OrderLines
        {
            get
            {
                if (_Sales_OrderLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_OrderLines = new DbEntitySetCached<Sales_Order, Sales_OrderLine>(() => _OrderID.Entity);
                    }
                }
                else
                    _Sales_OrderLines = new DbEntitySet<Sales_OrderLine>(_db, false, new Func<long ? >[]{() => _OrderID.Entity}, new[]{"[OrderID]"}, (member, root) => member.Sales_Order = root as Sales_Order, this, _lazyLoadChildren, e => e.Sales_Order = this, e =>
                    {
                        var x = e.Sales_Order;
                        e.Sales_Order = null;
                        new UpdateSetVisitor(true, new[]{"OrderID"}, false).Process(x);
                    }

                    );
                return _Sales_OrderLines;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Orders.Add(this);
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

                AssignDbEntity<Application_People, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_Orders, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Order BackorderOrder
        {
            get
            {
                Action<Sales_Order> beforeRightsCheckAction = e => e.BackorderOrder = this;
                if (_BackorderOrder != null)
                {
                    return _BackorderOrder.GetEntity(beforeRightsCheckAction);
                }

                _BackorderOrder = GetDbEntityRef(true, new[]{"[BackorderOrderID]"}, new Func<long ? >[]{() => _BackorderOrderID.Entity}, beforeRightsCheckAction);
                return (BackorderOrder != null) ? _BackorderOrder.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_BackorderOrder == null)
                {
                    _BackorderOrder = new DbEntityRef<Sales_Order>(_db, true, new[]{"[BackorderOrderID]"}, new Func<long ? >[]{() => _BackorderOrderID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Order, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.OrderID}, _BackorderOrder, new long ? []{_BackorderOrderID.Entity}, new Action<long ? >[]{x => BackorderOrderID = (int ? )x ?? default (int)}, x => x.Orders, null, BackorderOrderIDChanged);
            }
        }

        void BackorderOrderIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Order)
                _BackorderOrderID.Entity = (int)((Sales_Order)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Sales_Order> Orders
        {
            get
            {
                if (_Orders == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Orders = new DbEntitySetCached<Sales_Order, Sales_Order>(() => _OrderID.Entity);
                    }
                }
                else
                    _Orders = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _OrderID.Entity}, new[]{"[BackorderOrderID]"}, (member, root) => member.BackorderOrder = root as Sales_Order, this, _lazyLoadChildren, e => e.BackorderOrder = this, e =>
                    {
                        var x = e.BackorderOrder;
                        e.BackorderOrder = null;
                        new UpdateSetVisitor(true, new[]{"BackorderOrderID"}, false).Process(x);
                    }

                    );
                return _Orders;
            }
        }

        [Validate]
        public Application_People ContactPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Orders.Add(this);
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

                AssignDbEntity<Application_People, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _ContactPerson, new long ? []{_ContactPersonID.Entity}, new Action<long ? >[]{x => ContactPersonID = (int ? )x ?? default (int)}, x => x.Sales_Orders, null, ContactPersonIDChanged);
            }
        }

        void ContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _ContactPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Customer Sales_Customer
        {
            get
            {
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Sales_Orders.Add(this);
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

                AssignDbEntity<Sales_Customer, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Sales_Customer, new long ? []{_CustomerID.Entity}, new Action<long ? >[]{x => CustomerID = (int ? )x ?? default (int)}, x => x.Sales_Orders, null, CustomerIDChanged);
            }
        }

        void CustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _CustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public Application_People PickedByPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Orders.Add(this);
                if (_PickedByPerson != null)
                {
                    return _PickedByPerson.GetEntity(beforeRightsCheckAction);
                }

                _PickedByPerson = GetDbEntityRef(true, new[]{"[PickedByPersonID]"}, new Func<long ? >[]{() => _PickedByPersonID.Entity}, beforeRightsCheckAction);
                return (PickedByPerson != null) ? _PickedByPerson.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_PickedByPerson == null)
                {
                    _PickedByPerson = new DbEntityRef<Application_People>(_db, true, new[]{"[PickedByPersonID]"}, new Func<long ? >[]{() => _PickedByPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _PickedByPerson, new long ? []{_PickedByPersonID.Entity}, new Action<long ? >[]{x => PickedByPersonID = (int ? )x ?? default (int)}, x => x.Sales_Orders, null, PickedByPersonIDChanged);
            }
        }

        void PickedByPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _PickedByPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_People SalespersonPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Orders.Add(this);
                if (_SalespersonPerson != null)
                {
                    return _SalespersonPerson.GetEntity(beforeRightsCheckAction);
                }

                _SalespersonPerson = GetDbEntityRef(true, new[]{"[SalespersonPersonID]"}, new Func<long ? >[]{() => _SalespersonPersonID.Entity}, beforeRightsCheckAction);
                return (SalespersonPerson != null) ? _SalespersonPerson.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_SalespersonPerson == null)
                {
                    _SalespersonPerson = new DbEntityRef<Application_People>(_db, true, new[]{"[SalespersonPersonID]"}, new Func<long ? >[]{() => _SalespersonPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Sales_Order>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _SalespersonPerson, new long ? []{_SalespersonPersonID.Entity}, new Action<long ? >[]{x => SalespersonPersonID = (int ? )x ?? default (int)}, x => x.Sales_Orders, null, SalespersonPersonIDChanged);
            }
        }

        void SalespersonPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _SalespersonPersonID.Entity = (int)((Application_People)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _OrderID.Load(visitor.GetInt32());
            SendIdChanged();
            _CustomerID.Load(visitor.GetInt32());
            _SalespersonPersonID.Load(visitor.GetInt32());
            _PickedByPersonID.Load(visitor.GetInt32());
            _ContactPersonID.Load(visitor.GetInt32());
            _BackorderOrderID.Load(visitor.GetInt32());
            _OrderDate.Load(visitor.GetDateTime());
            _ExpectedDeliveryDate.Load(visitor.GetDateTime());
            _CustomerPurchaseOrderNumber.Load(visitor.GetValue<System.String>());
            _IsUndersupplyBackordered.Load(visitor.GetBoolean());
            _Comments.Load(visitor.GetValue<System.String>());
            _DeliveryInstructions.Load(visitor.GetValue<System.String>());
            _InternalComments.Load(visitor.GetValue<System.String>());
            _PickingCompletedWhen.Load(visitor.GetDateTime());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _OrderID.Welcome(visitor, "OrderID", "Int NOT NULL", false);
            _CustomerID.Welcome(visitor, "CustomerID", "Int NOT NULL", false);
            _SalespersonPersonID.Welcome(visitor, "SalespersonPersonID", "Int NOT NULL", false);
            _PickedByPersonID.Welcome(visitor, "PickedByPersonID", "Int", false);
            _ContactPersonID.Welcome(visitor, "ContactPersonID", "Int NOT NULL", false);
            _BackorderOrderID.Welcome(visitor, "BackorderOrderID", "Int", false);
            _OrderDate.Welcome(visitor, "OrderDate", "Date NOT NULL", false);
            _ExpectedDeliveryDate.Welcome(visitor, "ExpectedDeliveryDate", "Date NOT NULL", false);
            _CustomerPurchaseOrderNumber.Welcome(visitor, "CustomerPurchaseOrderNumber", "NVarChar(20)", false);
            _IsUndersupplyBackordered.Welcome(visitor, "IsUndersupplyBackordered", "Bit NOT NULL", false);
            _Comments.Welcome(visitor, "Comments", "NVarChar(MAX)", false);
            _DeliveryInstructions.Welcome(visitor, "DeliveryInstructions", "NVarChar(MAX)", false);
            _InternalComments.Welcome(visitor, "InternalComments", "NVarChar(MAX)", false);
            _PickingCompletedWhen.Welcome(visitor, "PickingCompletedWhen", "DateTime2(7)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Sales_Invoices);
            visitor.ProcessAssociation(this, _Sales_OrderLines);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _BackorderOrder);
            visitor.ProcessAssociation(this, _Orders);
            visitor.ProcessAssociation(this, _ContactPerson);
            visitor.ProcessAssociation(this, _Sales_Customer);
            visitor.ProcessAssociation(this, _PickedByPerson);
            visitor.ProcessAssociation(this, _SalespersonPerson);
        }
    }

    public static class Db_Sales_OrderQueryGetterExtensions
    {
        public static Sales_OrderTableQuery<Sales_Order> Sales_Orders(this IDb db)
        {
            var query = new Sales_OrderTableQuery<Sales_Order>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_OrderQuery<K, T> : Query<K, T, Sales_Order, Sales_OrderWrapper, Sales_OrderQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_OrderQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_OrderWrapper GetWrapper()
        {
            return Sales_OrderWrapper.Instance;
        }

        public Sales_InvoiceQuery<Sales_OrderQuery<K, T>, T> JoinSales_Invoices(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Sales_OrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[OrderID] = {1}.[OrderID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Order)o).Sales_Invoices.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).OrderID, attach);
        }

        public Sales_OrderLineQuery<Sales_OrderQuery<K, T>, T> JoinSales_OrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderLineQuery<Sales_OrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderLineTableQuery<Sales_OrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[OrderLines] AS {1} {0} ON", "{2}.[OrderID] = {1}.[OrderID]"), (p, ids) => ((Sales_OrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Order)o).Sales_OrderLines.Attach(v.Cast<Sales_OrderLine>()), p => (long)((Sales_OrderLine)p).OrderID, attach);
        }

        public Application_PeopleQuery<Sales_OrderQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_Order)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_OrderQuery<Sales_OrderQuery<K, T>, T> JoinBackorderOrder(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_OrderQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[BackorderOrderID] = {1}.[OrderID]"), o => ((Sales_Order)o)?.BackorderOrder, (e, fv, ppe) =>
            {
                var child = (Sales_Order)ppe(QueryHelpers.Fill<Sales_Order>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).BackorderOrder = child;
                }

                return child;
            }

            , typeof (Sales_Order), preloadEntities);
        }

        public Sales_OrderQuery<Sales_OrderQuery<K, T>, T> JoinOrders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Sales_OrderQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[OrderID] = {1}.[BackorderOrderID]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Order)o).Orders.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).BackorderOrderID, attach);
        }

        public Application_PeopleQuery<Sales_OrderQuery<K, T>, T> JoinContactPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[ContactPersonID] = {1}.[PersonID]"), o => ((Sales_Order)o)?.ContactPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).ContactPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_OrderQuery<K, T>, T> JoinSales_Customer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), o => ((Sales_Order)o)?.Sales_Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).Sales_Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Application_PeopleQuery<Sales_OrderQuery<K, T>, T> JoinPickedByPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[PickedByPersonID] = {1}.[PersonID]"), o => ((Sales_Order)o)?.PickedByPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).PickedByPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Sales_OrderQuery<K, T>, T> JoinSalespersonPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_OrderQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[SalespersonPersonID] = {1}.[PersonID]"), o => ((Sales_Order)o)?.SalespersonPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Order)e).SalespersonPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }
    }

    public class Sales_OrderTableQuery<T> : Sales_OrderQuery<Sales_OrderTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_OrderTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_OrderHelper : QueryHelper<Sales_Order>, IHelper<Sales_Order>
    {
        string[] columnsInSelectStatement = new[]{"{0}.OrderID", "{0}.CustomerID", "{0}.SalespersonPersonID", "{0}.PickedByPersonID", "{0}.ContactPersonID", "{0}.BackorderOrderID", "{0}.OrderDate", "{0}.ExpectedDeliveryDate", "{0}.CustomerPurchaseOrderNumber", "{0}.IsUndersupplyBackordered", "{0}.Comments", "{0}.DeliveryInstructions", "{0}.InternalComments", "{0}.PickingCompletedWhen", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.OrderID", "{0}.CustomerID", "{0}.SalespersonPersonID", "{0}.PickedByPersonID", "{0}.ContactPersonID", "{0}.BackorderOrderID", "{0}.OrderDate", "{0}.ExpectedDeliveryDate", "{0}.CustomerPurchaseOrderNumber", "{0}.IsUndersupplyBackordered", "{0}.Comments", "{0}.DeliveryInstructions", "{0}.InternalComments", "{0}.PickingCompletedWhen", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_Order ([OrderID] Int NOT NULL,[CustomerID] Int NOT NULL,[SalespersonPersonID] Int NOT NULL,[PickedByPersonID] Int,[ContactPersonID] Int NOT NULL,[BackorderOrderID] Int,[OrderDate] Date NOT NULL,[ExpectedDeliveryDate] Date NOT NULL,[CustomerPurchaseOrderNumber] NVarChar(20),[IsUndersupplyBackordered] Bit NOT NULL,[Comments] NVarChar(MAX),[DeliveryInstructions] NVarChar(MAX),[InternalComments] NVarChar(MAX),[PickingCompletedWhen] DateTime2(7),[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[Orders]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_Invoice) || other == typeof (Sales_OrderLine) || other == typeof (Sales_Order);
        }

        private const string insertCommand = "INSERT INTO [Sales].[Orders] ([{TableName = \"Sales].[Orders\";}].[OrderID], [{TableName = \"Sales].[Orders\";}].[CustomerID], [{TableName = \"Sales].[Orders\";}].[SalespersonPersonID], [{TableName = \"Sales].[Orders\";}].[PickedByPersonID], [{TableName = \"Sales].[Orders\";}].[ContactPersonID], [{TableName = \"Sales].[Orders\";}].[BackorderOrderID], [{TableName = \"Sales].[Orders\";}].[OrderDate], [{TableName = \"Sales].[Orders\";}].[ExpectedDeliveryDate], [{TableName = \"Sales].[Orders\";}].[CustomerPurchaseOrderNumber], [{TableName = \"Sales].[Orders\";}].[IsUndersupplyBackordered], [{TableName = \"Sales].[Orders\";}].[Comments], [{TableName = \"Sales].[Orders\";}].[DeliveryInstructions], [{TableName = \"Sales].[Orders\";}].[InternalComments], [{TableName = \"Sales].[Orders\";}].[PickingCompletedWhen], [{TableName = \"Sales].[Orders\";}].[LastEditedBy], [{TableName = \"Sales].[Orders\";}].[LastEditedWhen]) VALUES ([@OrderID],[@CustomerID],[@SalespersonPersonID],[@PickedByPersonID],[@ContactPersonID],[@BackorderOrderID],[@OrderDate],[@ExpectedDeliveryDate],[@CustomerPurchaseOrderNumber],[@IsUndersupplyBackordered],[@Comments],[@DeliveryInstructions],[@InternalComments],[@PickingCompletedWhen],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_Order _Sales_Order)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@OrderID", _Sales_Order.OrderID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Sales_Order.CustomerID);
            sqlCommand.Parameters.AddWithValue("@SalespersonPersonID", _Sales_Order.SalespersonPersonID);
            sqlCommand.Parameters.AddWithValue("@PickedByPersonID", _Sales_Order.PickedByPersonID);
            sqlCommand.Parameters.AddWithValue("@ContactPersonID", _Sales_Order.ContactPersonID);
            sqlCommand.Parameters.AddWithValue("@BackorderOrderID", _Sales_Order.BackorderOrderID);
            sqlCommand.Parameters.AddWithValue("@OrderDate", _Sales_Order.OrderDate);
            sqlCommand.Parameters.AddWithValue("@ExpectedDeliveryDate", _Sales_Order.ExpectedDeliveryDate);
            sqlCommand.Parameters.AddWithValue("@CustomerPurchaseOrderNumber", _Sales_Order.CustomerPurchaseOrderNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsUndersupplyBackordered", _Sales_Order.IsUndersupplyBackordered);
            sqlCommand.Parameters.AddWithValue("@Comments", _Sales_Order.Comments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryInstructions", _Sales_Order.DeliveryInstructions ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@InternalComments", _Sales_Order.InternalComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PickingCompletedWhen", _Sales_Order.PickingCompletedWhen);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_Order.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_Order.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_Order _Sales_Order)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_Order.OrderID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_OrderWrapper _wrapper = Sales_OrderWrapper.Instance;
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
    public class Sales_OrderWrapper : QueryWrapper<Sales_Order>
    {
        public readonly QueryElMemberId<Sales_Customer> CustomerID = new QueryElMemberId<Sales_Customer>("CustomerID");
        public readonly QueryElMemberId<Application_People> SalespersonPersonID = new QueryElMemberId<Application_People>("SalespersonPersonID");
        public readonly QueryElMemberId<Application_People> PickedByPersonID = new QueryElMemberId<Application_People>("PickedByPersonID");
        public readonly QueryElMemberId<Application_People> ContactPersonID = new QueryElMemberId<Application_People>("ContactPersonID");
        public readonly QueryElMemberId<Sales_Order> BackorderOrderID = new QueryElMemberId<Sales_Order>("BackorderOrderID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> OrderDate = new QueryElMemberStruct<System.DateTime>("OrderDate");
        public readonly QueryElMemberStruct<System.DateTime> ExpectedDeliveryDate = new QueryElMemberStruct<System.DateTime>("ExpectedDeliveryDate");
        public readonly QueryElMember<System.String> CustomerPurchaseOrderNumber = new QueryElMember<System.String>("CustomerPurchaseOrderNumber");
        public readonly QueryElMemberStruct<System.Boolean> IsUndersupplyBackordered = new QueryElMemberStruct<System.Boolean>("IsUndersupplyBackordered");
        public readonly QueryElMember<System.String> Comments = new QueryElMember<System.String>("Comments");
        public readonly QueryElMember<System.String> DeliveryInstructions = new QueryElMember<System.String>("DeliveryInstructions");
        public readonly QueryElMember<System.String> InternalComments = new QueryElMember<System.String>("InternalComments");
        public readonly QueryElMemberStruct<System.DateTime> PickingCompletedWhen = new QueryElMemberStruct<System.DateTime>("PickingCompletedWhen");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_OrderWrapper Instance = new Sales_OrderWrapper();
        private Sales_OrderWrapper(): base ("[Sales].[Orders]", "Sales_Order")
        {
        }
    }
}