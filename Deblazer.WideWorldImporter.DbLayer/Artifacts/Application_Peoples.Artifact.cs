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
    public partial class Application_People : DbEntity, IId
    {
        private DbValue<System.Int32> _PersonID = new DbValue<System.Int32>();
        private DbValue<System.String> _FullName = new DbValue<System.String>();
        private DbValue<System.String> _PreferredName = new DbValue<System.String>();
        private DbValue<System.String> _SearchName = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsPermittedToLogon = new DbValue<System.Boolean>();
        private DbValue<System.String> _LogonName = new DbValue<System.String>();
        private DbValue<System.Boolean> _IsExternalLogonProvider = new DbValue<System.Boolean>();
        private DbValue<System.Data.Linq.Binary> _HashedPassword = new DbValue<System.Data.Linq.Binary>();
        private DbValue<System.Boolean> _IsSystemUser = new DbValue<System.Boolean>();
        private DbValue<System.Boolean> _IsEmployee = new DbValue<System.Boolean>();
        private DbValue<System.Boolean> _IsSalesperson = new DbValue<System.Boolean>();
        private DbValue<System.String> _UserPreferences = new DbValue<System.String>();
        private DbValue<System.String> _PhoneNumber = new DbValue<System.String>();
        private DbValue<System.String> _FaxNumber = new DbValue<System.String>();
        private DbValue<System.String> _EmailAddress = new DbValue<System.String>();
        private DbValue<System.Data.Linq.Binary> _Photo = new DbValue<System.Data.Linq.Binary>();
        private DbValue<System.String> _CustomFields = new DbValue<System.String>();
        private DbValue<System.String> _OtherLanguages = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Application_City> _Application_Cities;
        private IDbEntitySet<Application_Country> _Application_Countries;
        private IDbEntitySet<Application_DeliveryMethod> _Application_DeliveryMethods;
        private IDbEntitySet<Application_PaymentMethod> _Application_PaymentMethods;
        private IDbEntityRef<Application_People> _LastEditedByApplication_People;
        private IDbEntitySet<Application_People> _Persons;
        private IDbEntitySet<Application_StateProvince> _Application_StateProvinces;
        private IDbEntitySet<Application_SystemParameter> _Application_SystemParameters;
        private IDbEntitySet<Application_TransactionType> _Application_TransactionTypes;
        private IDbEntitySet<Purchasing_PurchaseOrderLine> _Purchasing_PurchaseOrderLines;
        private IDbEntitySet<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrders;
        private IDbEntitySet<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples;
        private IDbEntitySet<Purchasing_SupplierCategory> _Purchasing_SupplierCategories;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers_Application_Peoples;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples;
        private IDbEntitySet<Purchasing_SupplierTransaction> _Purchasing_SupplierTransactions;
        private IDbEntitySet<Sales_BuyingGroup> _Sales_BuyingGroups;
        private IDbEntitySet<Sales_CustomerCategory> _Sales_CustomerCategories;
        private IDbEntitySet<Sales_Customer> _Sales_Customers;
        private IDbEntitySet<Sales_Customer> _Sales_Customers_Application_Peoples;
        private IDbEntitySet<Sales_Customer> _Sales_Customers_PrimaryContactPersonID_Application_Peoples;
        private IDbEntitySet<Sales_CustomerTransaction> _Sales_CustomerTransactions;
        private IDbEntitySet<Sales_InvoiceLine> _Sales_InvoiceLines;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices_Application_Peoples;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices_ContactPersonID_Application_Peoples;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices_PackedByPersonID_Application_Peoples;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices_SalespersonPersonID_Application_Peoples;
        private IDbEntitySet<Sales_OrderLine> _Sales_OrderLines;
        private IDbEntitySet<Sales_Order> _Sales_Orders;
        private IDbEntitySet<Sales_Order> _Sales_Orders_ContactPersonID_Application_Peoples;
        private IDbEntitySet<Sales_Order> _Sales_Orders_PickedByPersonID_Application_Peoples;
        private IDbEntitySet<Sales_Order> _Sales_Orders_SalespersonPersonID_Application_Peoples;
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        private IDbEntitySet<Warehouse_Color> _Warehouse_Colors;
        private IDbEntitySet<Warehouse_PackageType> _Warehouse_PackageTypes;
        private IDbEntitySet<Warehouse_StockGroup> _Warehouse_StockGroups;
        private IDbEntitySet<Warehouse_StockItemHolding> _Warehouse_StockItemHoldings;
        private IDbEntitySet<Warehouse_StockItem> _Warehouse_StockItems;
        private IDbEntitySet<Warehouse_StockItemStockGroup> _Warehouse_StockItemStockGroups;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => PersonID;
        long ILongId.Id => PersonID;
        [Validate]
        public System.Int32 PersonID
        {
            get
            {
                return _PersonID.Entity;
            }

            set
            {
                _PersonID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String FullName
        {
            get
            {
                return _FullName.Entity;
            }

            set
            {
                _FullName.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String PreferredName
        {
            get
            {
                return _PreferredName.Entity;
            }

            set
            {
                _PreferredName.Entity = value;
            }
        }

        [StringColumn(101, false)]
        [Validate]
        public System.String SearchName
        {
            get
            {
                return _SearchName.Entity;
            }

            set
            {
                _SearchName.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsPermittedToLogon
        {
            get
            {
                return _IsPermittedToLogon.Entity;
            }

            set
            {
                _IsPermittedToLogon.Entity = value;
            }
        }

        [StringColumn(50, true)]
        [Validate]
        public System.String LogonName
        {
            get
            {
                return _LogonName.Entity;
            }

            set
            {
                _LogonName.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsExternalLogonProvider
        {
            get
            {
                return _IsExternalLogonProvider.Entity;
            }

            set
            {
                _IsExternalLogonProvider.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.Data.Linq.Binary HashedPassword
        {
            get
            {
                return _HashedPassword.Entity;
            }

            set
            {
                _HashedPassword.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsSystemUser
        {
            get
            {
                return _IsSystemUser.Entity;
            }

            set
            {
                _IsSystemUser.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsEmployee
        {
            get
            {
                return _IsEmployee.Entity;
            }

            set
            {
                _IsEmployee.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsSalesperson
        {
            get
            {
                return _IsSalesperson.Entity;
            }

            set
            {
                _IsSalesperson.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String UserPreferences
        {
            get
            {
                return _UserPreferences.Entity;
            }

            set
            {
                _UserPreferences.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String PhoneNumber
        {
            get
            {
                return _PhoneNumber.Entity;
            }

            set
            {
                _PhoneNumber.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String FaxNumber
        {
            get
            {
                return _FaxNumber.Entity;
            }

            set
            {
                _FaxNumber.Entity = value;
            }
        }

        [StringColumn(256, true)]
        [Validate]
        public System.String EmailAddress
        {
            get
            {
                return _EmailAddress.Entity;
            }

            set
            {
                _EmailAddress.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.Data.Linq.Binary Photo
        {
            get
            {
                return _Photo.Entity;
            }

            set
            {
                _Photo.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String CustomFields
        {
            get
            {
                return _CustomFields.Entity;
            }

            set
            {
                _CustomFields.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String OtherLanguages
        {
            get
            {
                return _OtherLanguages.Entity;
            }

            set
            {
                _OtherLanguages.Entity = value;
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

        [Validate]
        public IDbEntitySet<Application_City> Application_Cities
        {
            get
            {
                if (_Application_Cities == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_Cities = new DbEntitySetCached<Application_People, Application_City>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_Cities = new DbEntitySet<Application_City>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_Cities;
            }
        }

        [Validate]
        public IDbEntitySet<Application_Country> Application_Countries
        {
            get
            {
                if (_Application_Countries == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_Countries = new DbEntitySetCached<Application_People, Application_Country>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_Countries = new DbEntitySet<Application_Country>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_Countries;
            }
        }

        [Validate]
        public IDbEntitySet<Application_DeliveryMethod> Application_DeliveryMethods
        {
            get
            {
                if (_Application_DeliveryMethods == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_DeliveryMethods = new DbEntitySetCached<Application_People, Application_DeliveryMethod>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_DeliveryMethods = new DbEntitySet<Application_DeliveryMethod>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_DeliveryMethods;
            }
        }

        [Validate]
        public IDbEntitySet<Application_PaymentMethod> Application_PaymentMethods
        {
            get
            {
                if (_Application_PaymentMethods == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_PaymentMethods = new DbEntitySetCached<Application_People, Application_PaymentMethod>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_PaymentMethods = new DbEntitySet<Application_PaymentMethod>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_PaymentMethods;
            }
        }

        [Validate]
        public Application_People LastEditedByApplication_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.LastEditedByApplication_People = this;
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

                AssignDbEntity<Application_People, Application_People>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _LastEditedByApplication_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Persons, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Application_People> Persons
        {
            get
            {
                if (_Persons == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Persons = new DbEntitySetCached<Application_People, Application_People>(() => _PersonID.Entity);
                    }
                }
                else
                    _Persons = new DbEntitySet<Application_People>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.LastEditedByApplication_People = root as Application_People, this, _lazyLoadChildren, e => e.LastEditedByApplication_People = this, e =>
                    {
                        var x = e.LastEditedByApplication_People;
                        e.LastEditedByApplication_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Persons;
            }
        }

        [Validate]
        public IDbEntitySet<Application_StateProvince> Application_StateProvinces
        {
            get
            {
                if (_Application_StateProvinces == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_StateProvinces = new DbEntitySetCached<Application_People, Application_StateProvince>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_StateProvinces = new DbEntitySet<Application_StateProvince>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_StateProvinces;
            }
        }

        [Validate]
        public IDbEntitySet<Application_SystemParameter> Application_SystemParameters
        {
            get
            {
                if (_Application_SystemParameters == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_SystemParameters = new DbEntitySetCached<Application_People, Application_SystemParameter>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_SystemParameters = new DbEntitySet<Application_SystemParameter>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_SystemParameters;
            }
        }

        [Validate]
        public IDbEntitySet<Application_TransactionType> Application_TransactionTypes
        {
            get
            {
                if (_Application_TransactionTypes == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_TransactionTypes = new DbEntitySetCached<Application_People, Application_TransactionType>(() => _PersonID.Entity);
                    }
                }
                else
                    _Application_TransactionTypes = new DbEntitySet<Application_TransactionType>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Application_TransactionTypes;
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
                        _Purchasing_PurchaseOrderLines = new DbEntitySetCached<Application_People, Purchasing_PurchaseOrderLine>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrderLines = new DbEntitySet<Purchasing_PurchaseOrderLine>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrderLines;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_PurchaseOrder> Purchasing_PurchaseOrders
        {
            get
            {
                if (_Purchasing_PurchaseOrders == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrders = new DbEntitySetCached<Application_People, Purchasing_PurchaseOrder>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrders = new DbEntitySet<Purchasing_PurchaseOrder>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrders;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_PurchaseOrder> Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples
        {
            get
            {
                if (_Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Purchasing_PurchaseOrder>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples = new DbEntitySet<Purchasing_PurchaseOrder>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[ContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"ContactPersonID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_SupplierCategory> Purchasing_SupplierCategories
        {
            get
            {
                if (_Purchasing_SupplierCategories == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_SupplierCategories = new DbEntitySetCached<Application_People, Purchasing_SupplierCategory>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierCategories = new DbEntitySet<Purchasing_SupplierCategory>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Purchasing_SupplierCategories;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_Supplier> Purchasing_Suppliers
        {
            get
            {
                if (_Purchasing_Suppliers == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_Suppliers = new DbEntitySetCached<Application_People, Purchasing_Supplier>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[AlternateContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"AlternateContactPersonID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_Supplier> Purchasing_Suppliers_Application_Peoples
        {
            get
            {
                if (_Purchasing_Suppliers_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_Suppliers_Application_Peoples = new DbEntitySetCached<Application_People, Purchasing_Supplier>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers_Application_Peoples = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_Supplier> Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples
        {
            get
            {
                if (_Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Purchasing_Supplier>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[PrimaryContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"PrimaryContactPersonID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples;
            }
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
                        _Purchasing_SupplierTransactions = new DbEntitySetCached<Application_People, Purchasing_SupplierTransaction>(() => _PersonID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierTransactions = new DbEntitySet<Purchasing_SupplierTransaction>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Purchasing_SupplierTransactions;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_BuyingGroup> Sales_BuyingGroups
        {
            get
            {
                if (_Sales_BuyingGroups == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_BuyingGroups = new DbEntitySetCached<Application_People, Sales_BuyingGroup>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_BuyingGroups = new DbEntitySet<Sales_BuyingGroup>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_BuyingGroups;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_CustomerCategory> Sales_CustomerCategories
        {
            get
            {
                if (_Sales_CustomerCategories == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_CustomerCategories = new DbEntitySetCached<Application_People, Sales_CustomerCategory>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_CustomerCategories = new DbEntitySet<Sales_CustomerCategory>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_CustomerCategories;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Customer> Sales_Customers
        {
            get
            {
                if (_Sales_Customers == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Customers = new DbEntitySetCached<Application_People, Sales_Customer>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[AlternateContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"AlternateContactPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Customer> Sales_Customers_Application_Peoples
        {
            get
            {
                if (_Sales_Customers_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Customers_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Customer>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Customers_Application_Peoples = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_Customers_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Customer> Sales_Customers_PrimaryContactPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Customers_PrimaryContactPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Customers_PrimaryContactPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Customer>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Customers_PrimaryContactPersonID_Application_Peoples = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[PrimaryContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"PrimaryContactPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers_PrimaryContactPersonID_Application_Peoples;
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
                        _Sales_CustomerTransactions = new DbEntitySetCached<Application_People, Sales_CustomerTransaction>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_CustomerTransactions = new DbEntitySet<Sales_CustomerTransaction>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
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
                        _Sales_InvoiceLines = new DbEntitySetCached<Application_People, Sales_InvoiceLine>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_InvoiceLines = new DbEntitySet<Sales_InvoiceLine>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_InvoiceLines;
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
                        _Sales_Invoices = new DbEntitySetCached<Application_People, Sales_Invoice>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Invoices = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[AccountsPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"AccountsPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices_Application_Peoples
        {
            get
            {
                if (_Sales_Invoices_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Invoice>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Invoices_Application_Peoples = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices_ContactPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Invoices_ContactPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices_ContactPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Invoice>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Invoices_ContactPersonID_Application_Peoples = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[ContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"ContactPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices_ContactPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices_PackedByPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Invoices_PackedByPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices_PackedByPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Invoice>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Invoices_PackedByPersonID_Application_Peoples = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[PackedByPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"PackedByPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices_PackedByPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices_SalespersonPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Invoices_SalespersonPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices_SalespersonPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Invoice>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Invoices_SalespersonPersonID_Application_Peoples = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[SalespersonPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"SalespersonPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices_SalespersonPersonID_Application_Peoples;
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
                        _Sales_OrderLines = new DbEntitySetCached<Application_People, Sales_OrderLine>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_OrderLines = new DbEntitySet<Sales_OrderLine>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_OrderLines;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Order> Sales_Orders
        {
            get
            {
                if (_Sales_Orders == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Orders = new DbEntitySetCached<Application_People, Sales_Order>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Orders = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_Orders;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Order> Sales_Orders_ContactPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Orders_ContactPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Orders_ContactPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Order>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Orders_ContactPersonID_Application_Peoples = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[ContactPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"ContactPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Orders_ContactPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Order> Sales_Orders_PickedByPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Orders_PickedByPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Orders_PickedByPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Order>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Orders_PickedByPersonID_Application_Peoples = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[PickedByPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"PickedByPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Orders_PickedByPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Order> Sales_Orders_SalespersonPersonID_Application_Peoples
        {
            get
            {
                if (_Sales_Orders_SalespersonPersonID_Application_Peoples == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Orders_SalespersonPersonID_Application_Peoples = new DbEntitySetCached<Application_People, Sales_Order>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_Orders_SalespersonPersonID_Application_Peoples = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[SalespersonPersonID]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"SalespersonPersonID"}, false).Process(x);
                    }

                    );
                return _Sales_Orders_SalespersonPersonID_Application_Peoples;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_SpecialDeal> Sales_SpecialDeals
        {
            get
            {
                if (_Sales_SpecialDeals == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_SpecialDeals = new DbEntitySetCached<Application_People, Sales_SpecialDeal>(() => _PersonID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Sales_SpecialDeals;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_Color> Warehouse_Colors
        {
            get
            {
                if (_Warehouse_Colors == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_Colors = new DbEntitySetCached<Application_People, Warehouse_Color>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_Colors = new DbEntitySet<Warehouse_Color>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_Colors;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_PackageType> Warehouse_PackageTypes
        {
            get
            {
                if (_Warehouse_PackageTypes == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_PackageTypes = new DbEntitySetCached<Application_People, Warehouse_PackageType>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_PackageTypes = new DbEntitySet<Warehouse_PackageType>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_PackageTypes;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockGroup> Warehouse_StockGroups
        {
            get
            {
                if (_Warehouse_StockGroups == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockGroups = new DbEntitySetCached<Application_People, Warehouse_StockGroup>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_StockGroups = new DbEntitySet<Warehouse_StockGroup>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockGroups;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItemHolding> Warehouse_StockItemHoldings
        {
            get
            {
                if (_Warehouse_StockItemHoldings == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockItemHoldings = new DbEntitySetCached<Application_People, Warehouse_StockItemHolding>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemHoldings = new DbEntitySet<Warehouse_StockItemHolding>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemHoldings;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItem> Warehouse_StockItems
        {
            get
            {
                if (_Warehouse_StockItems == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockItems = new DbEntitySetCached<Application_People, Warehouse_StockItem>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_StockItems = new DbEntitySet<Warehouse_StockItem>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItems;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItemStockGroup> Warehouse_StockItemStockGroups
        {
            get
            {
                if (_Warehouse_StockItemStockGroups == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockItemStockGroups = new DbEntitySetCached<Application_People, Warehouse_StockItemStockGroup>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemStockGroups = new DbEntitySet<Warehouse_StockItemStockGroup>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemStockGroups;
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Application_People, Warehouse_StockItemTransaction>(() => _PersonID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _PersonID.Entity}, new[]{"[LastEditedBy]"}, (member, root) => member.Application_People = root as Application_People, this, _lazyLoadChildren, e => e.Application_People = this, e =>
                    {
                        var x = e.Application_People;
                        e.Application_People = null;
                        new UpdateSetVisitor(true, new[]{"LastEditedBy"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _PersonID.Load(visitor.GetInt32());
            SendIdChanged();
            _FullName.Load(visitor.GetValue<System.String>());
            _PreferredName.Load(visitor.GetValue<System.String>());
            _SearchName.Load(visitor.GetValue<System.String>());
            _IsPermittedToLogon.Load(visitor.GetBoolean());
            _LogonName.Load(visitor.GetValue<System.String>());
            _IsExternalLogonProvider.Load(visitor.GetBoolean());
            _HashedPassword.Load(visitor.GetBinary());
            _IsSystemUser.Load(visitor.GetBoolean());
            _IsEmployee.Load(visitor.GetBoolean());
            _IsSalesperson.Load(visitor.GetBoolean());
            _UserPreferences.Load(visitor.GetValue<System.String>());
            _PhoneNumber.Load(visitor.GetValue<System.String>());
            _FaxNumber.Load(visitor.GetValue<System.String>());
            _EmailAddress.Load(visitor.GetValue<System.String>());
            _Photo.Load(visitor.GetBinary());
            _CustomFields.Load(visitor.GetValue<System.String>());
            _OtherLanguages.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _PersonID.Welcome(visitor, "PersonID", "Int NOT NULL", false);
            _FullName.Welcome(visitor, "FullName", "NVarChar(50) NOT NULL", false);
            _PreferredName.Welcome(visitor, "PreferredName", "NVarChar(50) NOT NULL", false);
            _SearchName.Welcome(visitor, "SearchName", "NVarChar(101) NOT NULL", false);
            _IsPermittedToLogon.Welcome(visitor, "IsPermittedToLogon", "Bit NOT NULL", false);
            _LogonName.Welcome(visitor, "LogonName", "NVarChar(50)", false);
            _IsExternalLogonProvider.Welcome(visitor, "IsExternalLogonProvider", "Bit NOT NULL", false);
            _HashedPassword.Welcome(visitor, "HashedPassword", "VarBinary(MAX)", false);
            _IsSystemUser.Welcome(visitor, "IsSystemUser", "Bit NOT NULL", false);
            _IsEmployee.Welcome(visitor, "IsEmployee", "Bit NOT NULL", false);
            _IsSalesperson.Welcome(visitor, "IsSalesperson", "Bit NOT NULL", false);
            _UserPreferences.Welcome(visitor, "UserPreferences", "NVarChar(MAX)", false);
            _PhoneNumber.Welcome(visitor, "PhoneNumber", "NVarChar(20)", false);
            _FaxNumber.Welcome(visitor, "FaxNumber", "NVarChar(20)", false);
            _EmailAddress.Welcome(visitor, "EmailAddress", "NVarChar(256)", false);
            _Photo.Welcome(visitor, "Photo", "VarBinary(MAX)", false);
            _CustomFields.Welcome(visitor, "CustomFields", "NVarChar(MAX)", false);
            _OtherLanguages.Welcome(visitor, "OtherLanguages", "NVarChar(MAX)", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_Cities);
            visitor.ProcessAssociation(this, _Application_Countries);
            visitor.ProcessAssociation(this, _Application_DeliveryMethods);
            visitor.ProcessAssociation(this, _Application_PaymentMethods);
            visitor.ProcessAssociation(this, _LastEditedByApplication_People);
            visitor.ProcessAssociation(this, _Persons);
            visitor.ProcessAssociation(this, _Application_StateProvinces);
            visitor.ProcessAssociation(this, _Application_SystemParameters);
            visitor.ProcessAssociation(this, _Application_TransactionTypes);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrderLines);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrders);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Purchasing_SupplierCategories);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers_Application_Peoples);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Purchasing_SupplierTransactions);
            visitor.ProcessAssociation(this, _Sales_BuyingGroups);
            visitor.ProcessAssociation(this, _Sales_CustomerCategories);
            visitor.ProcessAssociation(this, _Sales_Customers);
            visitor.ProcessAssociation(this, _Sales_Customers_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Customers_PrimaryContactPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_CustomerTransactions);
            visitor.ProcessAssociation(this, _Sales_InvoiceLines);
            visitor.ProcessAssociation(this, _Sales_Invoices);
            visitor.ProcessAssociation(this, _Sales_Invoices_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Invoices_ContactPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Invoices_PackedByPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Invoices_SalespersonPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_OrderLines);
            visitor.ProcessAssociation(this, _Sales_Orders);
            visitor.ProcessAssociation(this, _Sales_Orders_ContactPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Orders_PickedByPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_Orders_SalespersonPersonID_Application_Peoples);
            visitor.ProcessAssociation(this, _Sales_SpecialDeals);
            visitor.ProcessAssociation(this, _Warehouse_Colors);
            visitor.ProcessAssociation(this, _Warehouse_PackageTypes);
            visitor.ProcessAssociation(this, _Warehouse_StockGroups);
            visitor.ProcessAssociation(this, _Warehouse_StockItemHoldings);
            visitor.ProcessAssociation(this, _Warehouse_StockItems);
            visitor.ProcessAssociation(this, _Warehouse_StockItemStockGroups);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Application_PeopleQueryGetterExtensions
    {
        public static Application_PeopleTableQuery<Application_People> Application_Peoples(this IDb db)
        {
            var query = new Application_PeopleTableQuery<Application_People>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_PeopleQuery<K, T> : Query<K, T, Application_People, Application_PeopleWrapper, Application_PeopleQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_PeopleQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_PeopleWrapper GetWrapper()
        {
            return Application_PeopleWrapper.Instance;
        }

        public Application_CityQuery<Application_PeopleQuery<K, T>, T> JoinApplication_Cities(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_CityQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_CityTableQuery<Application_City>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_CityWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_Cities.Attach(v.Cast<Application_City>()), p => (long)((Application_City)p).LastEditedBy, attach);
        }

        public Application_CountryQuery<Application_PeopleQuery<K, T>, T> JoinApplication_Countries(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_CountryQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_CountryTableQuery<Application_Country>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Countries] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_CountryWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_Countries.Attach(v.Cast<Application_Country>()), p => (long)((Application_Country)p).LastEditedBy, attach);
        }

        public Application_DeliveryMethodQuery<Application_PeopleQuery<K, T>, T> JoinApplication_DeliveryMethods(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_DeliveryMethodQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_DeliveryMethodTableQuery<Application_DeliveryMethod>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[DeliveryMethods] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_DeliveryMethodWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_DeliveryMethods.Attach(v.Cast<Application_DeliveryMethod>()), p => (long)((Application_DeliveryMethod)p).LastEditedBy, attach);
        }

        public Application_PaymentMethodQuery<Application_PeopleQuery<K, T>, T> JoinApplication_PaymentMethods(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_PaymentMethodQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_PaymentMethodTableQuery<Application_PaymentMethod>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[PaymentMethods] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_PaymentMethodWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_PaymentMethods.Attach(v.Cast<Application_PaymentMethod>()), p => (long)((Application_PaymentMethod)p).LastEditedBy, attach);
        }

        public Application_PeopleQuery<Application_PeopleQuery<K, T>, T> JoinLastEditedByApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_PeopleQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_People)o)?.LastEditedByApplication_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_People)e).LastEditedByApplication_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Application_PeopleQuery<K, T>, T> JoinPersons(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_PeopleTableQuery<Application_People>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_PeopleWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Persons.Attach(v.Cast<Application_People>()), p => (long)((Application_People)p).LastEditedBy, attach);
        }

        public Application_StateProvinceQuery<Application_PeopleQuery<K, T>, T> JoinApplication_StateProvinces(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_StateProvinceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_StateProvinceTableQuery<Application_StateProvince>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[StateProvinces] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_StateProvinceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_StateProvinces.Attach(v.Cast<Application_StateProvince>()), p => (long)((Application_StateProvince)p).LastEditedBy, attach);
        }

        public Application_SystemParameterQuery<Application_PeopleQuery<K, T>, T> JoinApplication_SystemParameters(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_SystemParameterQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_SystemParameterTableQuery<Application_SystemParameter>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[SystemParameters] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_SystemParameterWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_SystemParameters.Attach(v.Cast<Application_SystemParameter>()), p => (long)((Application_SystemParameter)p).LastEditedBy, attach);
        }

        public Application_TransactionTypeQuery<Application_PeopleQuery<K, T>, T> JoinApplication_TransactionTypes(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_TransactionTypeQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_TransactionTypeTableQuery<Application_TransactionType>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[TransactionTypes] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Application_TransactionTypeWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Application_TransactionTypes.Attach(v.Cast<Application_TransactionType>()), p => (long)((Application_TransactionType)p).LastEditedBy, attach);
        }

        public Purchasing_PurchaseOrderLineQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_PurchaseOrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderLineQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrderLines] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Purchasing_PurchaseOrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_PurchaseOrderLines.Attach(v.Cast<Purchasing_PurchaseOrderLine>()), p => (long)((Purchasing_PurchaseOrderLine)p).LastEditedBy, attach);
        }

        public Purchasing_PurchaseOrderQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_PurchaseOrders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Purchasing_PurchaseOrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_PurchaseOrders.Attach(v.Cast<Purchasing_PurchaseOrder>()), p => (long)((Purchasing_PurchaseOrder)p).LastEditedBy, attach);
        }

        public Purchasing_PurchaseOrderQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_PurchaseOrders_ContactPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[ContactPersonID]"), (p, ids) => ((Purchasing_PurchaseOrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_PurchaseOrders_ContactPersonID_Application_Peoples.Attach(v.Cast<Purchasing_PurchaseOrder>()), p => (long)((Purchasing_PurchaseOrder)p).ContactPersonID, attach);
        }

        public Purchasing_SupplierCategoryQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_SupplierCategories(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierCategoryQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierCategoryTableQuery<Purchasing_SupplierCategory>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierCategories] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Purchasing_SupplierCategoryWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_SupplierCategories.Attach(v.Cast<Purchasing_SupplierCategory>()), p => (long)((Purchasing_SupplierCategory)p).LastEditedBy, attach);
        }

        public Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_Suppliers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[AlternateContactPersonID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_Suppliers.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).AlternateContactPersonID, attach);
        }

        public Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_Suppliers_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_Suppliers_Application_Peoples.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).LastEditedBy, attach);
        }

        public Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_Suppliers_PrimaryContactPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[PrimaryContactPersonID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_Suppliers_PrimaryContactPersonID_Application_Peoples.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).PrimaryContactPersonID, attach);
        }

        public Purchasing_SupplierTransactionQuery<Application_PeopleQuery<K, T>, T> JoinPurchasing_SupplierTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierTransactionQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierTransactions] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Purchasing_SupplierTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Purchasing_SupplierTransactions.Attach(v.Cast<Purchasing_SupplierTransaction>()), p => (long)((Purchasing_SupplierTransaction)p).LastEditedBy, attach);
        }

        public Sales_BuyingGroupQuery<Application_PeopleQuery<K, T>, T> JoinSales_BuyingGroups(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_BuyingGroupQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_BuyingGroupTableQuery<Sales_BuyingGroup>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[BuyingGroups] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_BuyingGroupWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_BuyingGroups.Attach(v.Cast<Sales_BuyingGroup>()), p => (long)((Sales_BuyingGroup)p).LastEditedBy, attach);
        }

        public Sales_CustomerCategoryQuery<Application_PeopleQuery<K, T>, T> JoinSales_CustomerCategories(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerCategoryQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerCategoryTableQuery<Sales_CustomerCategory>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerCategories] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_CustomerCategoryWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_CustomerCategories.Attach(v.Cast<Sales_CustomerCategory>()), p => (long)((Sales_CustomerCategory)p).LastEditedBy, attach);
        }

        public Sales_CustomerQuery<Application_PeopleQuery<K, T>, T> JoinSales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[AlternateContactPersonID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).AlternateContactPersonID, attach);
        }

        public Sales_CustomerQuery<Application_PeopleQuery<K, T>, T> JoinSales_Customers_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Customers_Application_Peoples.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).LastEditedBy, attach);
        }

        public Sales_CustomerQuery<Application_PeopleQuery<K, T>, T> JoinSales_Customers_PrimaryContactPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[PersonID] = {1}.[PrimaryContactPersonID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Customers_PrimaryContactPersonID_Application_Peoples.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).PrimaryContactPersonID, attach);
        }

        public Sales_CustomerTransactionQuery<Application_PeopleQuery<K, T>, T> JoinSales_CustomerTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerTransactionQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerTransactions] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_CustomerTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_CustomerTransactions.Attach(v.Cast<Sales_CustomerTransaction>()), p => (long)((Sales_CustomerTransaction)p).LastEditedBy, attach);
        }

        public Sales_InvoiceLineQuery<Application_PeopleQuery<K, T>, T> JoinSales_InvoiceLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceLineQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceLineTableQuery<Sales_InvoiceLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[InvoiceLines] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_InvoiceLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_InvoiceLines.Attach(v.Cast<Sales_InvoiceLine>()), p => (long)((Sales_InvoiceLine)p).LastEditedBy, attach);
        }

        public Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T> JoinSales_Invoices(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[PersonID] = {1}.[AccountsPersonID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Invoices.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).AccountsPersonID, attach);
        }

        public Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T> JoinSales_Invoices_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Invoices_Application_Peoples.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).LastEditedBy, attach);
        }

        public Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T> JoinSales_Invoices_ContactPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[PersonID] = {1}.[ContactPersonID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Invoices_ContactPersonID_Application_Peoples.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).ContactPersonID, attach);
        }

        public Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T> JoinSales_Invoices_PackedByPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[PersonID] = {1}.[PackedByPersonID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Invoices_PackedByPersonID_Application_Peoples.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).PackedByPersonID, attach);
        }

        public Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T> JoinSales_Invoices_SalespersonPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[PersonID] = {1}.[SalespersonPersonID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Invoices_SalespersonPersonID_Application_Peoples.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).SalespersonPersonID, attach);
        }

        public Sales_OrderLineQuery<Application_PeopleQuery<K, T>, T> JoinSales_OrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderLineQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderLineTableQuery<Sales_OrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[OrderLines] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_OrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_OrderLines.Attach(v.Cast<Sales_OrderLine>()), p => (long)((Sales_OrderLine)p).LastEditedBy, attach);
        }

        public Sales_OrderQuery<Application_PeopleQuery<K, T>, T> JoinSales_Orders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Orders.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).LastEditedBy, attach);
        }

        public Sales_OrderQuery<Application_PeopleQuery<K, T>, T> JoinSales_Orders_ContactPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[ContactPersonID]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Orders_ContactPersonID_Application_Peoples.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).ContactPersonID, attach);
        }

        public Sales_OrderQuery<Application_PeopleQuery<K, T>, T> JoinSales_Orders_PickedByPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[PickedByPersonID]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Orders_PickedByPersonID_Application_Peoples.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).PickedByPersonID, attach);
        }

        public Sales_OrderQuery<Application_PeopleQuery<K, T>, T> JoinSales_Orders_SalespersonPersonID_Application_Peoples(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[PersonID] = {1}.[SalespersonPersonID]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_Orders_SalespersonPersonID_Application_Peoples.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).SalespersonPersonID, attach);
        }

        public Sales_SpecialDealQuery<Application_PeopleQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).LastEditedBy, attach);
        }

        public Warehouse_ColorQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_Colors(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_ColorQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_ColorTableQuery<Warehouse_Color>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[Colors] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_ColorWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_Colors.Attach(v.Cast<Warehouse_Color>()), p => (long)((Warehouse_Color)p).LastEditedBy, attach);
        }

        public Warehouse_PackageTypeQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_PackageTypes(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_PackageTypeTableQuery<Warehouse_PackageType>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_PackageTypeWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_PackageTypes.Attach(v.Cast<Warehouse_PackageType>()), p => (long)((Warehouse_PackageType)p).LastEditedBy, attach);
        }

        public Warehouse_StockGroupQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_StockGroups(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockGroupQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockGroupTableQuery<Warehouse_StockGroup>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockGroups] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_StockGroupWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_StockGroups.Attach(v.Cast<Warehouse_StockGroup>()), p => (long)((Warehouse_StockGroup)p).LastEditedBy, attach);
        }

        public Warehouse_StockItemHoldingQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_StockItemHoldings(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemHoldingQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemHoldingTableQuery<Warehouse_StockItemHolding>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemHoldings] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_StockItemHoldingWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_StockItemHoldings.Attach(v.Cast<Warehouse_StockItemHolding>()), p => (long)((Warehouse_StockItemHolding)p).LastEditedBy, attach);
        }

        public Warehouse_StockItemQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_StockItems(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTableQuery<Warehouse_StockItem>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_StockItemWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_StockItems.Attach(v.Cast<Warehouse_StockItem>()), p => (long)((Warehouse_StockItem)p).LastEditedBy, attach);
        }

        public Warehouse_StockItemStockGroupQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_StockItemStockGroups(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemStockGroupQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemStockGroupTableQuery<Warehouse_StockItemStockGroup>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemStockGroups] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_StockItemStockGroupWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_StockItemStockGroups.Attach(v.Cast<Warehouse_StockItemStockGroup>()), p => (long)((Warehouse_StockItemStockGroup)p).LastEditedBy, attach);
        }

        public Warehouse_StockItemTransactionQuery<Application_PeopleQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Application_PeopleQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[PersonID] = {1}.[LastEditedBy]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_People)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).LastEditedBy, attach);
        }
    }

    public class Application_PeopleTableQuery<T> : Application_PeopleQuery<Application_PeopleTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_PeopleTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_PeopleHelper : QueryHelper<Application_People>, IHelper<Application_People>
    {
        string[] columnsInSelectStatement = new[]{"{0}.PersonID", "{0}.FullName", "{0}.PreferredName", "{0}.SearchName", "{0}.IsPermittedToLogon", "{0}.LogonName", "{0}.IsExternalLogonProvider", "{0}.HashedPassword", "{0}.IsSystemUser", "{0}.IsEmployee", "{0}.IsSalesperson", "{0}.UserPreferences", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.EmailAddress", "{0}.Photo", "{0}.CustomFields", "{0}.OtherLanguages", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.PersonID", "{0}.FullName", "{0}.PreferredName", "{0}.SearchName", "{0}.IsPermittedToLogon", "{0}.LogonName", "{0}.IsExternalLogonProvider", "{0}.HashedPassword", "{0}.IsSystemUser", "{0}.IsEmployee", "{0}.IsSalesperson", "{0}.UserPreferences", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.EmailAddress", "{0}.Photo", "{0}.CustomFields", "{0}.OtherLanguages", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_People ([PersonID] Int NOT NULL,[FullName] NVarChar(50) NOT NULL,[PreferredName] NVarChar(50) NOT NULL,[SearchName] NVarChar(101) NOT NULL,[IsPermittedToLogon] Bit NOT NULL,[LogonName] NVarChar(50),[IsExternalLogonProvider] Bit NOT NULL,[HashedPassword] VarBinary(MAX),[IsSystemUser] Bit NOT NULL,[IsEmployee] Bit NOT NULL,[IsSalesperson] Bit NOT NULL,[UserPreferences] NVarChar(MAX),[PhoneNumber] NVarChar(20),[FaxNumber] NVarChar(20),[EmailAddress] NVarChar(256),[Photo] VarBinary(MAX),[CustomFields] NVarChar(MAX),[OtherLanguages] NVarChar(MAX),[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[People]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Application_City) || other == typeof (Application_Country) || other == typeof (Application_DeliveryMethod) || other == typeof (Application_PaymentMethod) || other == typeof (Application_People) || other == typeof (Application_StateProvince) || other == typeof (Application_SystemParameter) || other == typeof (Application_TransactionType) || other == typeof (Purchasing_PurchaseOrderLine) || other == typeof (Purchasing_PurchaseOrder) || other == typeof (Purchasing_PurchaseOrder) || other == typeof (Purchasing_SupplierCategory) || other == typeof (Purchasing_Supplier) || other == typeof (Purchasing_Supplier) || other == typeof (Purchasing_Supplier) || other == typeof (Purchasing_SupplierTransaction) || other == typeof (Sales_BuyingGroup) || other == typeof (Sales_CustomerCategory) || other == typeof (Sales_Customer) || other == typeof (Sales_Customer) || other == typeof (Sales_Customer) || other == typeof (Sales_CustomerTransaction) || other == typeof (Sales_InvoiceLine) || other == typeof (Sales_Invoice) || other == typeof (Sales_Invoice) || other == typeof (Sales_Invoice) || other == typeof (Sales_Invoice) || other == typeof (Sales_Invoice) || other == typeof (Sales_OrderLine) || other == typeof (Sales_Order) || other == typeof (Sales_Order) || other == typeof (Sales_Order) || other == typeof (Sales_Order) || other == typeof (Sales_SpecialDeal) || other == typeof (Warehouse_Color) || other == typeof (Warehouse_PackageType) || other == typeof (Warehouse_StockGroup) || other == typeof (Warehouse_StockItemHolding) || other == typeof (Warehouse_StockItem) || other == typeof (Warehouse_StockItemStockGroup) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Application].[People] ([{TableName = \"Application].[People\";}].[PersonID], [{TableName = \"Application].[People\";}].[FullName], [{TableName = \"Application].[People\";}].[PreferredName], [{TableName = \"Application].[People\";}].[SearchName], [{TableName = \"Application].[People\";}].[IsPermittedToLogon], [{TableName = \"Application].[People\";}].[LogonName], [{TableName = \"Application].[People\";}].[IsExternalLogonProvider], [{TableName = \"Application].[People\";}].[HashedPassword], [{TableName = \"Application].[People\";}].[IsSystemUser], [{TableName = \"Application].[People\";}].[IsEmployee], [{TableName = \"Application].[People\";}].[IsSalesperson], [{TableName = \"Application].[People\";}].[UserPreferences], [{TableName = \"Application].[People\";}].[PhoneNumber], [{TableName = \"Application].[People\";}].[FaxNumber], [{TableName = \"Application].[People\";}].[EmailAddress], [{TableName = \"Application].[People\";}].[Photo], [{TableName = \"Application].[People\";}].[CustomFields], [{TableName = \"Application].[People\";}].[OtherLanguages], [{TableName = \"Application].[People\";}].[LastEditedBy], [{TableName = \"Application].[People\";}].[ValidFrom], [{TableName = \"Application].[People\";}].[ValidTo]) VALUES ([@PersonID],[@FullName],[@PreferredName],[@SearchName],[@IsPermittedToLogon],[@LogonName],[@IsExternalLogonProvider],[@HashedPassword],[@IsSystemUser],[@IsEmployee],[@IsSalesperson],[@UserPreferences],[@PhoneNumber],[@FaxNumber],[@EmailAddress],[@Photo],[@CustomFields],[@OtherLanguages],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_People _Application_People)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@PersonID", _Application_People.PersonID);
            sqlCommand.Parameters.AddWithValue("@FullName", _Application_People.FullName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PreferredName", _Application_People.PreferredName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@SearchName", _Application_People.SearchName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsPermittedToLogon", _Application_People.IsPermittedToLogon);
            sqlCommand.Parameters.AddWithValue("@LogonName", _Application_People.LogonName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsExternalLogonProvider", _Application_People.IsExternalLogonProvider);
            sqlCommand.Parameters.AddWithValue("@HashedPassword", _Application_People.HashedPassword ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsSystemUser", _Application_People.IsSystemUser);
            sqlCommand.Parameters.AddWithValue("@IsEmployee", _Application_People.IsEmployee);
            sqlCommand.Parameters.AddWithValue("@IsSalesperson", _Application_People.IsSalesperson);
            sqlCommand.Parameters.AddWithValue("@UserPreferences", _Application_People.UserPreferences ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", _Application_People.PhoneNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@FaxNumber", _Application_People.FaxNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", _Application_People.EmailAddress ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Photo", _Application_People.Photo ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@CustomFields", _Application_People.CustomFields ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@OtherLanguages", _Application_People.OtherLanguages ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_People.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_People.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_People.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_People _Application_People)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_People.PersonID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_PeopleWrapper _wrapper = Application_PeopleWrapper.Instance;
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
    public class Application_PeopleWrapper : QueryWrapper<Application_People>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> FullName = new QueryElMember<System.String>("FullName");
        public readonly QueryElMember<System.String> PreferredName = new QueryElMember<System.String>("PreferredName");
        public readonly QueryElMember<System.String> SearchName = new QueryElMember<System.String>("SearchName");
        public readonly QueryElMemberStruct<System.Boolean> IsPermittedToLogon = new QueryElMemberStruct<System.Boolean>("IsPermittedToLogon");
        public readonly QueryElMember<System.String> LogonName = new QueryElMember<System.String>("LogonName");
        public readonly QueryElMemberStruct<System.Boolean> IsExternalLogonProvider = new QueryElMemberStruct<System.Boolean>("IsExternalLogonProvider");
        public readonly QueryElMember<System.Data.Linq.Binary> HashedPassword = new QueryElMember<System.Data.Linq.Binary>("HashedPassword");
        public readonly QueryElMemberStruct<System.Boolean> IsSystemUser = new QueryElMemberStruct<System.Boolean>("IsSystemUser");
        public readonly QueryElMemberStruct<System.Boolean> IsEmployee = new QueryElMemberStruct<System.Boolean>("IsEmployee");
        public readonly QueryElMemberStruct<System.Boolean> IsSalesperson = new QueryElMemberStruct<System.Boolean>("IsSalesperson");
        public readonly QueryElMember<System.String> UserPreferences = new QueryElMember<System.String>("UserPreferences");
        public readonly QueryElMember<System.String> PhoneNumber = new QueryElMember<System.String>("PhoneNumber");
        public readonly QueryElMember<System.String> FaxNumber = new QueryElMember<System.String>("FaxNumber");
        public readonly QueryElMember<System.String> EmailAddress = new QueryElMember<System.String>("EmailAddress");
        public readonly QueryElMember<System.Data.Linq.Binary> Photo = new QueryElMember<System.Data.Linq.Binary>("Photo");
        public readonly QueryElMember<System.String> CustomFields = new QueryElMember<System.String>("CustomFields");
        public readonly QueryElMember<System.String> OtherLanguages = new QueryElMember<System.String>("OtherLanguages");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_PeopleWrapper Instance = new Application_PeopleWrapper();
        private Application_PeopleWrapper(): base ("[Application].[People]", "Application_People")
        {
        }
    }
}