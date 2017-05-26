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
    public partial class Sales_Invoice : DbEntity, IId
    {
        private DbValue<System.Int32> _InvoiceID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _BillToCustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _OrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _DeliveryMethodID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _ContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _AccountsPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _SalespersonPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PackedByPersonID = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _InvoiceDate = new DbValue<System.DateTime>();
        private DbValue<System.String> _CustomerPurchaseOrderNumber = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsCreditNote = new DbValue<System.Boolean>();
        private DbValue<System.String> _CreditNoteReason = new DbValue<System.String>();
        private DbValue<System.String> _Comments = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryInstructions = new DbValue<System.String>();
        private DbValue<System.String> _InternalComments = new DbValue<System.String>();
        private DbValue<System.Int32> _TotalDryItems = new DbValue<System.Int32>();
        private DbValue<System.Int32> _TotalChillerItems = new DbValue<System.Int32>();
        private DbValue<System.String> _DeliveryRun = new DbValue<System.String>();
        private DbValue<System.String> _RunPosition = new DbValue<System.String>();
        private DbValue<System.String> _ReturnedDeliveryData = new DbValue<System.String>();
        private DbValue<System.DateTime> _ConfirmedDeliveryTime = new DbValue<System.DateTime>();
        private DbValue<System.String> _ConfirmedReceivedBy = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntitySet<Sales_CustomerTransaction> _Sales_CustomerTransactions;
        private IDbEntitySet<Sales_InvoiceLine> _Sales_InvoiceLines;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_People> _LastEditedByApplication_People;
        private IDbEntityRef<Sales_Customer> _Sales_Customer;
        private IDbEntityRef<Application_People> _ContactPerson;
        private IDbEntityRef<Sales_Customer> _Customer;
        private IDbEntityRef<Application_DeliveryMethod> _Application_DeliveryMethod;
        private IDbEntityRef<Sales_Order> _Sales_Order;
        private IDbEntityRef<Application_People> _PackedByPerson;
        private IDbEntityRef<Application_People> _SalespersonPerson;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => InvoiceID;
        long ILongId.Id => InvoiceID;
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
        public System.Int32 BillToCustomerID
        {
            get
            {
                return _BillToCustomerID.Entity;
            }

            set
            {
                _BillToCustomerID.Entity = value;
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
        public System.Int32 AccountsPersonID
        {
            get
            {
                return _AccountsPersonID.Entity;
            }

            set
            {
                _AccountsPersonID.Entity = value;
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
        public System.Int32 PackedByPersonID
        {
            get
            {
                return _PackedByPersonID.Entity;
            }

            set
            {
                _PackedByPersonID.Entity = value;
            }
        }

        [Validate]
        public System.DateTime InvoiceDate
        {
            get
            {
                return _InvoiceDate.Entity;
            }

            set
            {
                _InvoiceDate.Entity = value;
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
        public System.Boolean IsCreditNote
        {
            get
            {
                return _IsCreditNote.Entity;
            }

            set
            {
                _IsCreditNote.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String CreditNoteReason
        {
            get
            {
                return _CreditNoteReason.Entity;
            }

            set
            {
                _CreditNoteReason.Entity = value;
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

        [Validate]
        public System.Int32 TotalDryItems
        {
            get
            {
                return _TotalDryItems.Entity;
            }

            set
            {
                _TotalDryItems.Entity = value;
            }
        }

        [Validate]
        public System.Int32 TotalChillerItems
        {
            get
            {
                return _TotalChillerItems.Entity;
            }

            set
            {
                _TotalChillerItems.Entity = value;
            }
        }

        [StringColumn(5, true)]
        [Validate]
        public System.String DeliveryRun
        {
            get
            {
                return _DeliveryRun.Entity;
            }

            set
            {
                _DeliveryRun.Entity = value;
            }
        }

        [StringColumn(5, true)]
        [Validate]
        public System.String RunPosition
        {
            get
            {
                return _RunPosition.Entity;
            }

            set
            {
                _RunPosition.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String ReturnedDeliveryData
        {
            get
            {
                return _ReturnedDeliveryData.Entity;
            }

            set
            {
                _ReturnedDeliveryData.Entity = value;
            }
        }

        [StringColumn(7, true)]
        [Validate]
        public System.DateTime ConfirmedDeliveryTime
        {
            get
            {
                return _ConfirmedDeliveryTime.Entity;
            }

            set
            {
                _ConfirmedDeliveryTime.Entity = value;
            }
        }

        [StringColumn(4000, true)]
        [Validate]
        public System.String ConfirmedReceivedBy
        {
            get
            {
                return _ConfirmedReceivedBy.Entity;
            }

            set
            {
                _ConfirmedReceivedBy.Entity = value;
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
        public IDbEntitySet<Sales_CustomerTransaction> Sales_CustomerTransactions
        {
            get
            {
                if (_Sales_CustomerTransactions == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_CustomerTransactions = new DbEntitySetCached<Sales_Invoice, Sales_CustomerTransaction>(() => _InvoiceID.Entity);
                    }
                }
                else
                    _Sales_CustomerTransactions = new DbEntitySet<Sales_CustomerTransaction>(_db, false, new Func<long ? >[]{() => _InvoiceID.Entity}, new[]{"[InvoiceID]"}, (member, root) => member.Sales_Invoice = root as Sales_Invoice, this, _lazyLoadChildren, e => e.Sales_Invoice = this, e =>
                    {
                        var x = e.Sales_Invoice;
                        e.Sales_Invoice = null;
                        new UpdateSetVisitor(true, new[]{"InvoiceID"}, false).Process(x);
                    }

                    );
                return _Sales_CustomerTransactions;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_InvoiceLine> Sales_InvoiceLines
        {
            get
            {
                if (_Sales_InvoiceLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_InvoiceLines = new DbEntitySetCached<Sales_Invoice, Sales_InvoiceLine>(() => _InvoiceID.Entity);
                    }
                }
                else
                    _Sales_InvoiceLines = new DbEntitySet<Sales_InvoiceLine>(_db, false, new Func<long ? >[]{() => _InvoiceID.Entity}, new[]{"[InvoiceID]"}, (member, root) => member.Sales_Invoice = root as Sales_Invoice, this, _lazyLoadChildren, e => e.Sales_Invoice = this, e =>
                    {
                        var x = e.Sales_Invoice;
                        e.Sales_Invoice = null;
                        new UpdateSetVisitor(true, new[]{"InvoiceID"}, false).Process(x);
                    }

                    );
                return _Sales_InvoiceLines;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
                if (_Application_People != null)
                {
                    return _Application_People.GetEntity(beforeRightsCheckAction);
                }

                _Application_People = GetDbEntityRef(true, new[]{"[AccountsPersonID]"}, new Func<long ? >[]{() => _AccountsPersonID.Entity}, beforeRightsCheckAction);
                return (Application_People != null) ? _Application_People.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_People == null)
                {
                    _Application_People = new DbEntityRef<Application_People>(_db, true, new[]{"[AccountsPersonID]"}, new Func<long ? >[]{() => _AccountsPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_AccountsPersonID.Entity}, new Action<long ? >[]{x => AccountsPersonID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, AccountsPersonIDChanged);
            }
        }

        void AccountsPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _AccountsPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_People LastEditedByApplication_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
                if (_LastEditedByApplication_People != null)
                {
                    return _LastEditedByApplication_People.GetEntity(beforeRightsCheckAction);
                }

                _LastEditedByApplication_People = GetDbEntityRef(true, new[]{"[LastEditedBy]"}, new Func<long ? >[]{() => _LastEditedBy.Entity}, beforeRightsCheckAction);
                return (LastEditedByApplication_People != null) ? _LastEditedByApplication_People.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_LastEditedByApplication_People == null)
                {
                    _LastEditedByApplication_People = new DbEntityRef<Application_People>(_db, true, new[]{"[LastEditedBy]"}, new Func<long ? >[]{() => _LastEditedBy.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _LastEditedByApplication_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, LastEditedByChanged);
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
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
                if (_Sales_Customer != null)
                {
                    return _Sales_Customer.GetEntity(beforeRightsCheckAction);
                }

                _Sales_Customer = GetDbEntityRef(true, new[]{"[BillToCustomerID]"}, new Func<long ? >[]{() => _BillToCustomerID.Entity}, beforeRightsCheckAction);
                return (Sales_Customer != null) ? _Sales_Customer.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Sales_Customer == null)
                {
                    _Sales_Customer = new DbEntityRef<Sales_Customer>(_db, true, new[]{"[BillToCustomerID]"}, new Func<long ? >[]{() => _BillToCustomerID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Customer, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Sales_Customer, new long ? []{_BillToCustomerID.Entity}, new Action<long ? >[]{x => BillToCustomerID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, BillToCustomerIDChanged);
            }
        }

        void BillToCustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _BillToCustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public Application_People ContactPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
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

                AssignDbEntity<Application_People, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _ContactPerson, new long ? []{_ContactPersonID.Entity}, new Action<long ? >[]{x => ContactPersonID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, ContactPersonIDChanged);
            }
        }

        void ContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _ContactPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Customer Customer
        {
            get
            {
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
                if (_Customer != null)
                {
                    return _Customer.GetEntity(beforeRightsCheckAction);
                }

                _Customer = GetDbEntityRef(true, new[]{"[CustomerID]"}, new Func<long ? >[]{() => _CustomerID.Entity}, beforeRightsCheckAction);
                return (Customer != null) ? _Customer.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Customer == null)
                {
                    _Customer = new DbEntityRef<Sales_Customer>(_db, true, new[]{"[CustomerID]"}, new Func<long ? >[]{() => _CustomerID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Customer, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Customer, new long ? []{_CustomerID.Entity}, new Action<long ? >[]{x => CustomerID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, CustomerIDChanged);
            }
        }

        void CustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _CustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public Application_DeliveryMethod Application_DeliveryMethod
        {
            get
            {
                Action<Application_DeliveryMethod> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
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

                AssignDbEntity<Application_DeliveryMethod, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.DeliveryMethodID}, _Application_DeliveryMethod, new long ? []{_DeliveryMethodID.Entity}, new Action<long ? >[]{x => DeliveryMethodID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, DeliveryMethodIDChanged);
            }
        }

        void DeliveryMethodIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_DeliveryMethod)
                _DeliveryMethodID.Entity = (int)((Application_DeliveryMethod)sender).Id;
        }

        [Validate]
        public Sales_Order Sales_Order
        {
            get
            {
                Action<Sales_Order> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
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

                AssignDbEntity<Sales_Order, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.OrderID}, _Sales_Order, new long ? []{_OrderID.Entity}, new Action<long ? >[]{x => OrderID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, OrderIDChanged);
            }
        }

        void OrderIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Order)
                _OrderID.Entity = (int)((Sales_Order)sender).Id;
        }

        [Validate]
        public Application_People PackedByPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
                if (_PackedByPerson != null)
                {
                    return _PackedByPerson.GetEntity(beforeRightsCheckAction);
                }

                _PackedByPerson = GetDbEntityRef(true, new[]{"[PackedByPersonID]"}, new Func<long ? >[]{() => _PackedByPersonID.Entity}, beforeRightsCheckAction);
                return (PackedByPerson != null) ? _PackedByPerson.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_PackedByPerson == null)
                {
                    _PackedByPerson = new DbEntityRef<Application_People>(_db, true, new[]{"[PackedByPersonID]"}, new Func<long ? >[]{() => _PackedByPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _PackedByPerson, new long ? []{_PackedByPersonID.Entity}, new Action<long ? >[]{x => PackedByPersonID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, PackedByPersonIDChanged);
            }
        }

        void PackedByPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _PackedByPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_People SalespersonPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Invoices.Add(this);
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

                AssignDbEntity<Application_People, Sales_Invoice>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _SalespersonPerson, new long ? []{_SalespersonPersonID.Entity}, new Action<long ? >[]{x => SalespersonPersonID = (int ? )x ?? default (int)}, x => x.Sales_Invoices, null, SalespersonPersonIDChanged);
            }
        }

        void SalespersonPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _SalespersonPersonID.Entity = (int)((Application_People)sender).Id;
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Sales_Invoice, Warehouse_StockItemTransaction>(() => _InvoiceID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _InvoiceID.Entity}, new[]{"[InvoiceID]"}, (member, root) => member.Sales_Invoice = root as Sales_Invoice, this, _lazyLoadChildren, e => e.Sales_Invoice = this, e =>
                    {
                        var x = e.Sales_Invoice;
                        e.Sales_Invoice = null;
                        new UpdateSetVisitor(true, new[]{"InvoiceID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _InvoiceID.Load(visitor.GetInt32());
            SendIdChanged();
            _CustomerID.Load(visitor.GetInt32());
            _BillToCustomerID.Load(visitor.GetInt32());
            _OrderID.Load(visitor.GetInt32());
            _DeliveryMethodID.Load(visitor.GetInt32());
            _ContactPersonID.Load(visitor.GetInt32());
            _AccountsPersonID.Load(visitor.GetInt32());
            _SalespersonPersonID.Load(visitor.GetInt32());
            _PackedByPersonID.Load(visitor.GetInt32());
            _InvoiceDate.Load(visitor.GetDateTime());
            _CustomerPurchaseOrderNumber.Load(visitor.GetValue<System.String>());
            _IsCreditNote.Load(visitor.GetBoolean());
            _CreditNoteReason.Load(visitor.GetValue<System.String>());
            _Comments.Load(visitor.GetValue<System.String>());
            _DeliveryInstructions.Load(visitor.GetValue<System.String>());
            _InternalComments.Load(visitor.GetValue<System.String>());
            _TotalDryItems.Load(visitor.GetInt32());
            _TotalChillerItems.Load(visitor.GetInt32());
            _DeliveryRun.Load(visitor.GetValue<System.String>());
            _RunPosition.Load(visitor.GetValue<System.String>());
            _ReturnedDeliveryData.Load(visitor.GetValue<System.String>());
            _ConfirmedDeliveryTime.Load(visitor.GetDateTime());
            _ConfirmedReceivedBy.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _InvoiceID.Welcome(visitor, "InvoiceID", "Int NOT NULL", false);
            _CustomerID.Welcome(visitor, "CustomerID", "Int NOT NULL", false);
            _BillToCustomerID.Welcome(visitor, "BillToCustomerID", "Int NOT NULL", false);
            _OrderID.Welcome(visitor, "OrderID", "Int", false);
            _DeliveryMethodID.Welcome(visitor, "DeliveryMethodID", "Int NOT NULL", false);
            _ContactPersonID.Welcome(visitor, "ContactPersonID", "Int NOT NULL", false);
            _AccountsPersonID.Welcome(visitor, "AccountsPersonID", "Int NOT NULL", false);
            _SalespersonPersonID.Welcome(visitor, "SalespersonPersonID", "Int NOT NULL", false);
            _PackedByPersonID.Welcome(visitor, "PackedByPersonID", "Int NOT NULL", false);
            _InvoiceDate.Welcome(visitor, "InvoiceDate", "Date NOT NULL", false);
            _CustomerPurchaseOrderNumber.Welcome(visitor, "CustomerPurchaseOrderNumber", "NVarChar(20)", false);
            _IsCreditNote.Welcome(visitor, "IsCreditNote", "Bit NOT NULL", false);
            _CreditNoteReason.Welcome(visitor, "CreditNoteReason", "NVarChar(MAX)", false);
            _Comments.Welcome(visitor, "Comments", "NVarChar(MAX)", false);
            _DeliveryInstructions.Welcome(visitor, "DeliveryInstructions", "NVarChar(MAX)", false);
            _InternalComments.Welcome(visitor, "InternalComments", "NVarChar(MAX)", false);
            _TotalDryItems.Welcome(visitor, "TotalDryItems", "Int NOT NULL", false);
            _TotalChillerItems.Welcome(visitor, "TotalChillerItems", "Int NOT NULL", false);
            _DeliveryRun.Welcome(visitor, "DeliveryRun", "NVarChar(5)", false);
            _RunPosition.Welcome(visitor, "RunPosition", "NVarChar(5)", false);
            _ReturnedDeliveryData.Welcome(visitor, "ReturnedDeliveryData", "NVarChar(MAX)", false);
            _ConfirmedDeliveryTime.Welcome(visitor, "ConfirmedDeliveryTime", "DateTime2(7)", false);
            _ConfirmedReceivedBy.Welcome(visitor, "ConfirmedReceivedBy", "NVarChar(4000)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Sales_CustomerTransactions);
            visitor.ProcessAssociation(this, _Sales_InvoiceLines);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _LastEditedByApplication_People);
            visitor.ProcessAssociation(this, _Sales_Customer);
            visitor.ProcessAssociation(this, _ContactPerson);
            visitor.ProcessAssociation(this, _Customer);
            visitor.ProcessAssociation(this, _Application_DeliveryMethod);
            visitor.ProcessAssociation(this, _Sales_Order);
            visitor.ProcessAssociation(this, _PackedByPerson);
            visitor.ProcessAssociation(this, _SalespersonPerson);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Sales_InvoiceQueryGetterExtensions
    {
        public static Sales_InvoiceTableQuery<Sales_Invoice> Sales_Invoices(this IDb db)
        {
            var query = new Sales_InvoiceTableQuery<Sales_Invoice>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_InvoiceQuery<K, T> : Query<K, T, Sales_Invoice, Sales_InvoiceWrapper, Sales_InvoiceQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_InvoiceQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_InvoiceWrapper GetWrapper()
        {
            return Sales_InvoiceWrapper.Instance;
        }

        public Sales_CustomerTransactionQuery<Sales_InvoiceQuery<K, T>, T> JoinSales_CustomerTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerTransactionQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerTransactions] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), (p, ids) => ((Sales_CustomerTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Invoice)o).Sales_CustomerTransactions.Attach(v.Cast<Sales_CustomerTransaction>()), p => (long)((Sales_CustomerTransaction)p).InvoiceID, attach);
        }

        public Sales_InvoiceLineQuery<Sales_InvoiceQuery<K, T>, T> JoinSales_InvoiceLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceLineQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceLineTableQuery<Sales_InvoiceLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[InvoiceLines] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), (p, ids) => ((Sales_InvoiceLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Invoice)o).Sales_InvoiceLines.Attach(v.Cast<Sales_InvoiceLine>()), p => (long)((Sales_InvoiceLine)p).InvoiceID, attach);
        }

        public Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[AccountsPersonID] = {1}.[PersonID]"), o => ((Sales_Invoice)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T> JoinLastEditedByApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_Invoice)o)?.LastEditedByApplication_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).LastEditedByApplication_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_InvoiceQuery<K, T>, T> JoinSales_Customer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[BillToCustomerID] = {1}.[CustomerID]"), o => ((Sales_Invoice)o)?.Sales_Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).Sales_Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T> JoinContactPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[ContactPersonID] = {1}.[PersonID]"), o => ((Sales_Invoice)o)?.ContactPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).ContactPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_InvoiceQuery<K, T>, T> JoinCustomer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), o => ((Sales_Invoice)o)?.Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Application_DeliveryMethodQuery<Sales_InvoiceQuery<K, T>, T> JoinApplication_DeliveryMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_DeliveryMethodQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[DeliveryMethods] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), o => ((Sales_Invoice)o)?.Application_DeliveryMethod, (e, fv, ppe) =>
            {
                var child = (Application_DeliveryMethod)ppe(QueryHelpers.Fill<Application_DeliveryMethod>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).Application_DeliveryMethod = child;
                }

                return child;
            }

            , typeof (Application_DeliveryMethod), preloadEntities);
        }

        public Sales_OrderQuery<Sales_InvoiceQuery<K, T>, T> JoinSales_Order(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_OrderQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[OrderID] = {1}.[OrderID]"), o => ((Sales_Invoice)o)?.Sales_Order, (e, fv, ppe) =>
            {
                var child = (Sales_Order)ppe(QueryHelpers.Fill<Sales_Order>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).Sales_Order = child;
                }

                return child;
            }

            , typeof (Sales_Order), preloadEntities);
        }

        public Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T> JoinPackedByPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[PackedByPersonID] = {1}.[PersonID]"), o => ((Sales_Invoice)o)?.PackedByPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).PackedByPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T> JoinSalespersonPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[SalespersonPersonID] = {1}.[PersonID]"), o => ((Sales_Invoice)o)?.SalespersonPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Invoice)e).SalespersonPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockItemTransactionQuery<Sales_InvoiceQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Sales_InvoiceQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Invoice)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).InvoiceID, attach);
        }
    }

    public class Sales_InvoiceTableQuery<T> : Sales_InvoiceQuery<Sales_InvoiceTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_InvoiceTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_InvoiceHelper : QueryHelper<Sales_Invoice>, IHelper<Sales_Invoice>
    {
        string[] columnsInSelectStatement = new[]{"{0}.InvoiceID", "{0}.CustomerID", "{0}.BillToCustomerID", "{0}.OrderID", "{0}.DeliveryMethodID", "{0}.ContactPersonID", "{0}.AccountsPersonID", "{0}.SalespersonPersonID", "{0}.PackedByPersonID", "{0}.InvoiceDate", "{0}.CustomerPurchaseOrderNumber", "{0}.IsCreditNote", "{0}.CreditNoteReason", "{0}.Comments", "{0}.DeliveryInstructions", "{0}.InternalComments", "{0}.TotalDryItems", "{0}.TotalChillerItems", "{0}.DeliveryRun", "{0}.RunPosition", "{0}.ReturnedDeliveryData", "{0}.ConfirmedDeliveryTime", "{0}.ConfirmedReceivedBy", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.InvoiceID", "{0}.CustomerID", "{0}.BillToCustomerID", "{0}.OrderID", "{0}.DeliveryMethodID", "{0}.ContactPersonID", "{0}.AccountsPersonID", "{0}.SalespersonPersonID", "{0}.PackedByPersonID", "{0}.InvoiceDate", "{0}.CustomerPurchaseOrderNumber", "{0}.IsCreditNote", "{0}.CreditNoteReason", "{0}.Comments", "{0}.DeliveryInstructions", "{0}.InternalComments", "{0}.TotalDryItems", "{0}.TotalChillerItems", "{0}.DeliveryRun", "{0}.RunPosition", "{0}.ReturnedDeliveryData", "{0}.ConfirmedDeliveryTime", "{0}.ConfirmedReceivedBy", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_Invoice ([InvoiceID] Int NOT NULL,[CustomerID] Int NOT NULL,[BillToCustomerID] Int NOT NULL,[OrderID] Int,[DeliveryMethodID] Int NOT NULL,[ContactPersonID] Int NOT NULL,[AccountsPersonID] Int NOT NULL,[SalespersonPersonID] Int NOT NULL,[PackedByPersonID] Int NOT NULL,[InvoiceDate] Date NOT NULL,[CustomerPurchaseOrderNumber] NVarChar(20),[IsCreditNote] Bit NOT NULL,[CreditNoteReason] NVarChar(MAX),[Comments] NVarChar(MAX),[DeliveryInstructions] NVarChar(MAX),[InternalComments] NVarChar(MAX),[TotalDryItems] Int NOT NULL,[TotalChillerItems] Int NOT NULL,[DeliveryRun] NVarChar(5),[RunPosition] NVarChar(5),[ReturnedDeliveryData] NVarChar(MAX),[ConfirmedDeliveryTime] DateTime2(7),[ConfirmedReceivedBy] NVarChar(4000),[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[Invoices]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_CustomerTransaction) || other == typeof (Sales_InvoiceLine) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Sales].[Invoices] ([{TableName = \"Sales].[Invoices\";}].[InvoiceID], [{TableName = \"Sales].[Invoices\";}].[CustomerID], [{TableName = \"Sales].[Invoices\";}].[BillToCustomerID], [{TableName = \"Sales].[Invoices\";}].[OrderID], [{TableName = \"Sales].[Invoices\";}].[DeliveryMethodID], [{TableName = \"Sales].[Invoices\";}].[ContactPersonID], [{TableName = \"Sales].[Invoices\";}].[AccountsPersonID], [{TableName = \"Sales].[Invoices\";}].[SalespersonPersonID], [{TableName = \"Sales].[Invoices\";}].[PackedByPersonID], [{TableName = \"Sales].[Invoices\";}].[InvoiceDate], [{TableName = \"Sales].[Invoices\";}].[CustomerPurchaseOrderNumber], [{TableName = \"Sales].[Invoices\";}].[IsCreditNote], [{TableName = \"Sales].[Invoices\";}].[CreditNoteReason], [{TableName = \"Sales].[Invoices\";}].[Comments], [{TableName = \"Sales].[Invoices\";}].[DeliveryInstructions], [{TableName = \"Sales].[Invoices\";}].[InternalComments], [{TableName = \"Sales].[Invoices\";}].[TotalDryItems], [{TableName = \"Sales].[Invoices\";}].[TotalChillerItems], [{TableName = \"Sales].[Invoices\";}].[DeliveryRun], [{TableName = \"Sales].[Invoices\";}].[RunPosition], [{TableName = \"Sales].[Invoices\";}].[ReturnedDeliveryData], [{TableName = \"Sales].[Invoices\";}].[ConfirmedDeliveryTime], [{TableName = \"Sales].[Invoices\";}].[ConfirmedReceivedBy], [{TableName = \"Sales].[Invoices\";}].[LastEditedBy], [{TableName = \"Sales].[Invoices\";}].[LastEditedWhen]) VALUES ([@InvoiceID],[@CustomerID],[@BillToCustomerID],[@OrderID],[@DeliveryMethodID],[@ContactPersonID],[@AccountsPersonID],[@SalespersonPersonID],[@PackedByPersonID],[@InvoiceDate],[@CustomerPurchaseOrderNumber],[@IsCreditNote],[@CreditNoteReason],[@Comments],[@DeliveryInstructions],[@InternalComments],[@TotalDryItems],[@TotalChillerItems],[@DeliveryRun],[@RunPosition],[@ReturnedDeliveryData],[@ConfirmedDeliveryTime],[@ConfirmedReceivedBy],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_Invoice _Sales_Invoice)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@InvoiceID", _Sales_Invoice.InvoiceID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Sales_Invoice.CustomerID);
            sqlCommand.Parameters.AddWithValue("@BillToCustomerID", _Sales_Invoice.BillToCustomerID);
            sqlCommand.Parameters.AddWithValue("@OrderID", _Sales_Invoice.OrderID);
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodID", _Sales_Invoice.DeliveryMethodID);
            sqlCommand.Parameters.AddWithValue("@ContactPersonID", _Sales_Invoice.ContactPersonID);
            sqlCommand.Parameters.AddWithValue("@AccountsPersonID", _Sales_Invoice.AccountsPersonID);
            sqlCommand.Parameters.AddWithValue("@SalespersonPersonID", _Sales_Invoice.SalespersonPersonID);
            sqlCommand.Parameters.AddWithValue("@PackedByPersonID", _Sales_Invoice.PackedByPersonID);
            sqlCommand.Parameters.AddWithValue("@InvoiceDate", _Sales_Invoice.InvoiceDate);
            sqlCommand.Parameters.AddWithValue("@CustomerPurchaseOrderNumber", _Sales_Invoice.CustomerPurchaseOrderNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsCreditNote", _Sales_Invoice.IsCreditNote);
            sqlCommand.Parameters.AddWithValue("@CreditNoteReason", _Sales_Invoice.CreditNoteReason ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Comments", _Sales_Invoice.Comments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryInstructions", _Sales_Invoice.DeliveryInstructions ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@InternalComments", _Sales_Invoice.InternalComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@TotalDryItems", _Sales_Invoice.TotalDryItems);
            sqlCommand.Parameters.AddWithValue("@TotalChillerItems", _Sales_Invoice.TotalChillerItems);
            sqlCommand.Parameters.AddWithValue("@DeliveryRun", _Sales_Invoice.DeliveryRun ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@RunPosition", _Sales_Invoice.RunPosition ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ReturnedDeliveryData", _Sales_Invoice.ReturnedDeliveryData ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ConfirmedDeliveryTime", _Sales_Invoice.ConfirmedDeliveryTime);
            sqlCommand.Parameters.AddWithValue("@ConfirmedReceivedBy", _Sales_Invoice.ConfirmedReceivedBy ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_Invoice.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_Invoice.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_Invoice _Sales_Invoice)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_Invoice.InvoiceID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_InvoiceWrapper _wrapper = Sales_InvoiceWrapper.Instance;
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
    public class Sales_InvoiceWrapper : QueryWrapper<Sales_Invoice>
    {
        public readonly QueryElMemberId<Sales_Customer> CustomerID = new QueryElMemberId<Sales_Customer>("CustomerID");
        public readonly QueryElMemberId<Sales_Customer> BillToCustomerID = new QueryElMemberId<Sales_Customer>("BillToCustomerID");
        public readonly QueryElMemberId<Sales_Order> OrderID = new QueryElMemberId<Sales_Order>("OrderID");
        public readonly QueryElMemberId<Application_DeliveryMethod> DeliveryMethodID = new QueryElMemberId<Application_DeliveryMethod>("DeliveryMethodID");
        public readonly QueryElMemberId<Application_People> ContactPersonID = new QueryElMemberId<Application_People>("ContactPersonID");
        public readonly QueryElMemberId<Application_People> AccountsPersonID = new QueryElMemberId<Application_People>("AccountsPersonID");
        public readonly QueryElMemberId<Application_People> SalespersonPersonID = new QueryElMemberId<Application_People>("SalespersonPersonID");
        public readonly QueryElMemberId<Application_People> PackedByPersonID = new QueryElMemberId<Application_People>("PackedByPersonID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> InvoiceDate = new QueryElMemberStruct<System.DateTime>("InvoiceDate");
        public readonly QueryElMember<System.String> CustomerPurchaseOrderNumber = new QueryElMember<System.String>("CustomerPurchaseOrderNumber");
        public readonly QueryElMemberStruct<System.Boolean> IsCreditNote = new QueryElMemberStruct<System.Boolean>("IsCreditNote");
        public readonly QueryElMember<System.String> CreditNoteReason = new QueryElMember<System.String>("CreditNoteReason");
        public readonly QueryElMember<System.String> Comments = new QueryElMember<System.String>("Comments");
        public readonly QueryElMember<System.String> DeliveryInstructions = new QueryElMember<System.String>("DeliveryInstructions");
        public readonly QueryElMember<System.String> InternalComments = new QueryElMember<System.String>("InternalComments");
        public readonly QueryElMemberStruct<System.Int32> TotalDryItems = new QueryElMemberStruct<System.Int32>("TotalDryItems");
        public readonly QueryElMemberStruct<System.Int32> TotalChillerItems = new QueryElMemberStruct<System.Int32>("TotalChillerItems");
        public readonly QueryElMember<System.String> DeliveryRun = new QueryElMember<System.String>("DeliveryRun");
        public readonly QueryElMember<System.String> RunPosition = new QueryElMember<System.String>("RunPosition");
        public readonly QueryElMember<System.String> ReturnedDeliveryData = new QueryElMember<System.String>("ReturnedDeliveryData");
        public readonly QueryElMemberStruct<System.DateTime> ConfirmedDeliveryTime = new QueryElMemberStruct<System.DateTime>("ConfirmedDeliveryTime");
        public readonly QueryElMember<System.String> ConfirmedReceivedBy = new QueryElMember<System.String>("ConfirmedReceivedBy");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_InvoiceWrapper Instance = new Sales_InvoiceWrapper();
        private Sales_InvoiceWrapper(): base ("[Sales].[Invoices]", "Sales_Invoice")
        {
        }
    }
}