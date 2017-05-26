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
    public partial class Purchasing_Supplier : DbEntity, IId
    {
        private DbValue<System.Int32> _SupplierID = new DbValue<System.Int32>();
        private DbValue<System.String> _SupplierName = new DbValue<System.String>();
        private DbValue<System.Int32> _SupplierCategoryID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PrimaryContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _AlternateContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _DeliveryMethodID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _DeliveryCityID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PostalCityID = new DbValue<System.Int32>();
        private DbValue<System.String> _SupplierReference = new DbValue<System.String>();
        private DbValue<System.String> _BankAccountName = new DbValue<System.String>();
        private DbValue<System.String> _BankAccountBranch = new DbValue<System.String>();
        private DbValue<System.String> _BankAccountCode = new DbValue<System.String>();
        private DbValue<System.String> _BankAccountNumber = new DbValue<System.String>();
        private DbValue<System.String> _BankInternationalCode = new DbValue<System.String>();
        private DbValue<System.Int32> _PaymentDays = new DbValue<System.Int32>();
        private DbValue<System.String> _InternalComments = new DbValue<System.String>();
        private DbValue<System.String> _PhoneNumber = new DbValue<System.String>();
        private DbValue<System.String> _FaxNumber = new DbValue<System.String>();
        private DbValue<System.String> _WebsiteURL = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryAddressLine1 = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryAddressLine2 = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryPostalCode = new DbValue<System.String>();
        private DbValue<System.String> _PostalAddressLine1 = new DbValue<System.String>();
        private DbValue<System.String> _PostalAddressLine2 = new DbValue<System.String>();
        private DbValue<System.String> _PostalPostalCode = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrders;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_People> _LastEditedByApplication_People;
        private IDbEntityRef<Application_City> _Application_City;
        private IDbEntityRef<Application_DeliveryMethod> _Application_DeliveryMethod;
        private IDbEntityRef<Application_City> _PostalCity;
        private IDbEntityRef<Application_People> _PrimaryContactPerson;
        private IDbEntityRef<Purchasing_SupplierCategory> _Purchasing_SupplierCategory;
        private IDbEntitySet<Purchasing_SupplierTransaction> _Purchasing_SupplierTransactions;
        private IDbEntitySet<Warehouse_StockItem> _Warehouse_StockItems;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => SupplierID;
        long ILongId.Id => SupplierID;
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

        [StringColumn(100, false)]
        [Validate]
        public System.String SupplierName
        {
            get
            {
                return _SupplierName.Entity;
            }

            set
            {
                _SupplierName.Entity = value;
            }
        }

        [Validate]
        public System.Int32 SupplierCategoryID
        {
            get
            {
                return _SupplierCategoryID.Entity;
            }

            set
            {
                _SupplierCategoryID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PrimaryContactPersonID
        {
            get
            {
                return _PrimaryContactPersonID.Entity;
            }

            set
            {
                _PrimaryContactPersonID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 AlternateContactPersonID
        {
            get
            {
                return _AlternateContactPersonID.Entity;
            }

            set
            {
                _AlternateContactPersonID.Entity = value;
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
        public System.Int32 DeliveryCityID
        {
            get
            {
                return _DeliveryCityID.Entity;
            }

            set
            {
                _DeliveryCityID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PostalCityID
        {
            get
            {
                return _PostalCityID.Entity;
            }

            set
            {
                _PostalCityID.Entity = value;
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

        [StringColumn(50, true)]
        [Validate]
        public System.String BankAccountName
        {
            get
            {
                return _BankAccountName.Entity;
            }

            set
            {
                _BankAccountName.Entity = value;
            }
        }

        [StringColumn(50, true)]
        [Validate]
        public System.String BankAccountBranch
        {
            get
            {
                return _BankAccountBranch.Entity;
            }

            set
            {
                _BankAccountBranch.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String BankAccountCode
        {
            get
            {
                return _BankAccountCode.Entity;
            }

            set
            {
                _BankAccountCode.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String BankAccountNumber
        {
            get
            {
                return _BankAccountNumber.Entity;
            }

            set
            {
                _BankAccountNumber.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String BankInternationalCode
        {
            get
            {
                return _BankInternationalCode.Entity;
            }

            set
            {
                _BankInternationalCode.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PaymentDays
        {
            get
            {
                return _PaymentDays.Entity;
            }

            set
            {
                _PaymentDays.Entity = value;
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

        [StringColumn(20, false)]
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

        [StringColumn(20, false)]
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

        [StringColumn(256, false)]
        [Validate]
        public System.String WebsiteURL
        {
            get
            {
                return _WebsiteURL.Entity;
            }

            set
            {
                _WebsiteURL.Entity = value;
            }
        }

        [StringColumn(60, false)]
        [Validate]
        public System.String DeliveryAddressLine1
        {
            get
            {
                return _DeliveryAddressLine1.Entity;
            }

            set
            {
                _DeliveryAddressLine1.Entity = value;
            }
        }

        [StringColumn(60, true)]
        [Validate]
        public System.String DeliveryAddressLine2
        {
            get
            {
                return _DeliveryAddressLine2.Entity;
            }

            set
            {
                _DeliveryAddressLine2.Entity = value;
            }
        }

        [StringColumn(10, false)]
        [Validate]
        public System.String DeliveryPostalCode
        {
            get
            {
                return _DeliveryPostalCode.Entity;
            }

            set
            {
                _DeliveryPostalCode.Entity = value;
            }
        }

        [StringColumn(60, false)]
        [Validate]
        public System.String PostalAddressLine1
        {
            get
            {
                return _PostalAddressLine1.Entity;
            }

            set
            {
                _PostalAddressLine1.Entity = value;
            }
        }

        [StringColumn(60, true)]
        [Validate]
        public System.String PostalAddressLine2
        {
            get
            {
                return _PostalAddressLine2.Entity;
            }

            set
            {
                _PostalAddressLine2.Entity = value;
            }
        }

        [StringColumn(10, false)]
        [Validate]
        public System.String PostalPostalCode
        {
            get
            {
                return _PostalPostalCode.Entity;
            }

            set
            {
                _PostalPostalCode.Entity = value;
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
        public IDbEntitySet<Purchasing_PurchaseOrder> Purchasing_PurchaseOrders
        {
            get
            {
                if (_Purchasing_PurchaseOrders == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrders = new DbEntitySetCached<Purchasing_Supplier, Purchasing_PurchaseOrder>(() => _SupplierID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrders = new DbEntitySet<Purchasing_PurchaseOrder>(_db, false, new Func<long ? >[]{() => _SupplierID.Entity}, new[]{"[SupplierID]"}, (member, root) => member.Purchasing_Supplier = root as Purchasing_Supplier, this, _lazyLoadChildren, e => e.Purchasing_Supplier = this, e =>
                    {
                        var x = e.Purchasing_Supplier;
                        e.Purchasing_Supplier = null;
                        new UpdateSetVisitor(true, new[]{"SupplierID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrders;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
                if (_Application_People != null)
                {
                    return _Application_People.GetEntity(beforeRightsCheckAction);
                }

                _Application_People = GetDbEntityRef(true, new[]{"[AlternateContactPersonID]"}, new Func<long ? >[]{() => _AlternateContactPersonID.Entity}, beforeRightsCheckAction);
                return (Application_People != null) ? _Application_People.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_People == null)
                {
                    _Application_People = new DbEntityRef<Application_People>(_db, true, new[]{"[AlternateContactPersonID]"}, new Func<long ? >[]{() => _AlternateContactPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_AlternateContactPersonID.Entity}, new Action<long ? >[]{x => AlternateContactPersonID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, AlternateContactPersonIDChanged);
            }
        }

        void AlternateContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _AlternateContactPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_People LastEditedByApplication_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
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

                AssignDbEntity<Application_People, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _LastEditedByApplication_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_City Application_City
        {
            get
            {
                Action<Application_City> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
                if (_Application_City != null)
                {
                    return _Application_City.GetEntity(beforeRightsCheckAction);
                }

                _Application_City = GetDbEntityRef(true, new[]{"[DeliveryCityID]"}, new Func<long ? >[]{() => _DeliveryCityID.Entity}, beforeRightsCheckAction);
                return (Application_City != null) ? _Application_City.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_City == null)
                {
                    _Application_City = new DbEntityRef<Application_City>(_db, true, new[]{"[DeliveryCityID]"}, new Func<long ? >[]{() => _DeliveryCityID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_City, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _Application_City, new long ? []{_DeliveryCityID.Entity}, new Action<long ? >[]{x => DeliveryCityID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, DeliveryCityIDChanged);
            }
        }

        void DeliveryCityIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_City)
                _DeliveryCityID.Entity = (int)((Application_City)sender).Id;
        }

        [Validate]
        public Application_DeliveryMethod Application_DeliveryMethod
        {
            get
            {
                Action<Application_DeliveryMethod> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
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

                AssignDbEntity<Application_DeliveryMethod, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.DeliveryMethodID}, _Application_DeliveryMethod, new long ? []{_DeliveryMethodID.Entity}, new Action<long ? >[]{x => DeliveryMethodID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, DeliveryMethodIDChanged);
            }
        }

        void DeliveryMethodIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_DeliveryMethod)
                _DeliveryMethodID.Entity = (int)((Application_DeliveryMethod)sender).Id;
        }

        [Validate]
        public Application_City PostalCity
        {
            get
            {
                Action<Application_City> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
                if (_PostalCity != null)
                {
                    return _PostalCity.GetEntity(beforeRightsCheckAction);
                }

                _PostalCity = GetDbEntityRef(true, new[]{"[PostalCityID]"}, new Func<long ? >[]{() => _PostalCityID.Entity}, beforeRightsCheckAction);
                return (PostalCity != null) ? _PostalCity.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_PostalCity == null)
                {
                    _PostalCity = new DbEntityRef<Application_City>(_db, true, new[]{"[PostalCityID]"}, new Func<long ? >[]{() => _PostalCityID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_City, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _PostalCity, new long ? []{_PostalCityID.Entity}, new Action<long ? >[]{x => PostalCityID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, PostalCityIDChanged);
            }
        }

        void PostalCityIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_City)
                _PostalCityID.Entity = (int)((Application_City)sender).Id;
        }

        [Validate]
        public Application_People PrimaryContactPerson
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
                if (_PrimaryContactPerson != null)
                {
                    return _PrimaryContactPerson.GetEntity(beforeRightsCheckAction);
                }

                _PrimaryContactPerson = GetDbEntityRef(true, new[]{"[PrimaryContactPersonID]"}, new Func<long ? >[]{() => _PrimaryContactPersonID.Entity}, beforeRightsCheckAction);
                return (PrimaryContactPerson != null) ? _PrimaryContactPerson.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_PrimaryContactPerson == null)
                {
                    _PrimaryContactPerson = new DbEntityRef<Application_People>(_db, true, new[]{"[PrimaryContactPersonID]"}, new Func<long ? >[]{() => _PrimaryContactPersonID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_People, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _PrimaryContactPerson, new long ? []{_PrimaryContactPersonID.Entity}, new Action<long ? >[]{x => PrimaryContactPersonID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, PrimaryContactPersonIDChanged);
            }
        }

        void PrimaryContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _PrimaryContactPersonID.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Purchasing_SupplierCategory Purchasing_SupplierCategory
        {
            get
            {
                Action<Purchasing_SupplierCategory> beforeRightsCheckAction = e => e.Purchasing_Suppliers.Add(this);
                if (_Purchasing_SupplierCategory != null)
                {
                    return _Purchasing_SupplierCategory.GetEntity(beforeRightsCheckAction);
                }

                _Purchasing_SupplierCategory = GetDbEntityRef(true, new[]{"[SupplierCategoryID]"}, new Func<long ? >[]{() => _SupplierCategoryID.Entity}, beforeRightsCheckAction);
                return (Purchasing_SupplierCategory != null) ? _Purchasing_SupplierCategory.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Purchasing_SupplierCategory == null)
                {
                    _Purchasing_SupplierCategory = new DbEntityRef<Purchasing_SupplierCategory>(_db, true, new[]{"[SupplierCategoryID]"}, new Func<long ? >[]{() => _SupplierCategoryID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Purchasing_SupplierCategory, Purchasing_Supplier>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.SupplierCategoryID}, _Purchasing_SupplierCategory, new long ? []{_SupplierCategoryID.Entity}, new Action<long ? >[]{x => SupplierCategoryID = (int ? )x ?? default (int)}, x => x.Purchasing_Suppliers, null, SupplierCategoryIDChanged);
            }
        }

        void SupplierCategoryIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_SupplierCategory)
                _SupplierCategoryID.Entity = (int)((Purchasing_SupplierCategory)sender).Id;
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
                        _Purchasing_SupplierTransactions = new DbEntitySetCached<Purchasing_Supplier, Purchasing_SupplierTransaction>(() => _SupplierID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierTransactions = new DbEntitySet<Purchasing_SupplierTransaction>(_db, false, new Func<long ? >[]{() => _SupplierID.Entity}, new[]{"[SupplierID]"}, (member, root) => member.Purchasing_Supplier = root as Purchasing_Supplier, this, _lazyLoadChildren, e => e.Purchasing_Supplier = this, e =>
                    {
                        var x = e.Purchasing_Supplier;
                        e.Purchasing_Supplier = null;
                        new UpdateSetVisitor(true, new[]{"SupplierID"}, false).Process(x);
                    }

                    );
                return _Purchasing_SupplierTransactions;
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
                        _Warehouse_StockItems = new DbEntitySetCached<Purchasing_Supplier, Warehouse_StockItem>(() => _SupplierID.Entity);
                    }
                }
                else
                    _Warehouse_StockItems = new DbEntitySet<Warehouse_StockItem>(_db, false, new Func<long ? >[]{() => _SupplierID.Entity}, new[]{"[SupplierID]"}, (member, root) => member.Purchasing_Supplier = root as Purchasing_Supplier, this, _lazyLoadChildren, e => e.Purchasing_Supplier = this, e =>
                    {
                        var x = e.Purchasing_Supplier;
                        e.Purchasing_Supplier = null;
                        new UpdateSetVisitor(true, new[]{"SupplierID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItems;
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Purchasing_Supplier, Warehouse_StockItemTransaction>(() => _SupplierID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _SupplierID.Entity}, new[]{"[SupplierID]"}, (member, root) => member.Purchasing_Supplier = root as Purchasing_Supplier, this, _lazyLoadChildren, e => e.Purchasing_Supplier = this, e =>
                    {
                        var x = e.Purchasing_Supplier;
                        e.Purchasing_Supplier = null;
                        new UpdateSetVisitor(true, new[]{"SupplierID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _SupplierID.Load(visitor.GetInt32());
            SendIdChanged();
            _SupplierName.Load(visitor.GetValue<System.String>());
            _SupplierCategoryID.Load(visitor.GetInt32());
            _PrimaryContactPersonID.Load(visitor.GetInt32());
            _AlternateContactPersonID.Load(visitor.GetInt32());
            _DeliveryMethodID.Load(visitor.GetInt32());
            _DeliveryCityID.Load(visitor.GetInt32());
            _PostalCityID.Load(visitor.GetInt32());
            _SupplierReference.Load(visitor.GetValue<System.String>());
            _BankAccountName.Load(visitor.GetValue<System.String>());
            _BankAccountBranch.Load(visitor.GetValue<System.String>());
            _BankAccountCode.Load(visitor.GetValue<System.String>());
            _BankAccountNumber.Load(visitor.GetValue<System.String>());
            _BankInternationalCode.Load(visitor.GetValue<System.String>());
            _PaymentDays.Load(visitor.GetInt32());
            _InternalComments.Load(visitor.GetValue<System.String>());
            _PhoneNumber.Load(visitor.GetValue<System.String>());
            _FaxNumber.Load(visitor.GetValue<System.String>());
            _WebsiteURL.Load(visitor.GetValue<System.String>());
            _DeliveryAddressLine1.Load(visitor.GetValue<System.String>());
            _DeliveryAddressLine2.Load(visitor.GetValue<System.String>());
            _DeliveryPostalCode.Load(visitor.GetValue<System.String>());
            _PostalAddressLine1.Load(visitor.GetValue<System.String>());
            _PostalAddressLine2.Load(visitor.GetValue<System.String>());
            _PostalPostalCode.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _SupplierID.Welcome(visitor, "SupplierID", "Int NOT NULL", false);
            _SupplierName.Welcome(visitor, "SupplierName", "NVarChar(100) NOT NULL", false);
            _SupplierCategoryID.Welcome(visitor, "SupplierCategoryID", "Int NOT NULL", false);
            _PrimaryContactPersonID.Welcome(visitor, "PrimaryContactPersonID", "Int NOT NULL", false);
            _AlternateContactPersonID.Welcome(visitor, "AlternateContactPersonID", "Int NOT NULL", false);
            _DeliveryMethodID.Welcome(visitor, "DeliveryMethodID", "Int", false);
            _DeliveryCityID.Welcome(visitor, "DeliveryCityID", "Int NOT NULL", false);
            _PostalCityID.Welcome(visitor, "PostalCityID", "Int NOT NULL", false);
            _SupplierReference.Welcome(visitor, "SupplierReference", "NVarChar(20)", false);
            _BankAccountName.Welcome(visitor, "BankAccountName", "NVarChar(50)", false);
            _BankAccountBranch.Welcome(visitor, "BankAccountBranch", "NVarChar(50)", false);
            _BankAccountCode.Welcome(visitor, "BankAccountCode", "NVarChar(20)", false);
            _BankAccountNumber.Welcome(visitor, "BankAccountNumber", "NVarChar(20)", false);
            _BankInternationalCode.Welcome(visitor, "BankInternationalCode", "NVarChar(20)", false);
            _PaymentDays.Welcome(visitor, "PaymentDays", "Int NOT NULL", false);
            _InternalComments.Welcome(visitor, "InternalComments", "NVarChar(MAX)", false);
            _PhoneNumber.Welcome(visitor, "PhoneNumber", "NVarChar(20) NOT NULL", false);
            _FaxNumber.Welcome(visitor, "FaxNumber", "NVarChar(20) NOT NULL", false);
            _WebsiteURL.Welcome(visitor, "WebsiteURL", "NVarChar(256) NOT NULL", false);
            _DeliveryAddressLine1.Welcome(visitor, "DeliveryAddressLine1", "NVarChar(60) NOT NULL", false);
            _DeliveryAddressLine2.Welcome(visitor, "DeliveryAddressLine2", "NVarChar(60)", false);
            _DeliveryPostalCode.Welcome(visitor, "DeliveryPostalCode", "NVarChar(10) NOT NULL", false);
            _PostalAddressLine1.Welcome(visitor, "PostalAddressLine1", "NVarChar(60) NOT NULL", false);
            _PostalAddressLine2.Welcome(visitor, "PostalAddressLine2", "NVarChar(60)", false);
            _PostalPostalCode.Welcome(visitor, "PostalPostalCode", "NVarChar(10) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrders);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _LastEditedByApplication_People);
            visitor.ProcessAssociation(this, _Application_City);
            visitor.ProcessAssociation(this, _Application_DeliveryMethod);
            visitor.ProcessAssociation(this, _PostalCity);
            visitor.ProcessAssociation(this, _PrimaryContactPerson);
            visitor.ProcessAssociation(this, _Purchasing_SupplierCategory);
            visitor.ProcessAssociation(this, _Purchasing_SupplierTransactions);
            visitor.ProcessAssociation(this, _Warehouse_StockItems);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Purchasing_SupplierQueryGetterExtensions
    {
        public static Purchasing_SupplierTableQuery<Purchasing_Supplier> Purchasing_Suppliers(this IDb db)
        {
            var query = new Purchasing_SupplierTableQuery<Purchasing_Supplier>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Purchasing_SupplierQuery<K, T> : Query<K, T, Purchasing_Supplier, Purchasing_SupplierWrapper, Purchasing_SupplierQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Purchasing_SupplierQuery(IDb db): base (db)
        {
        }

        protected sealed override Purchasing_SupplierWrapper GetWrapper()
        {
            return Purchasing_SupplierWrapper.Instance;
        }

        public Purchasing_PurchaseOrderQuery<Purchasing_SupplierQuery<K, T>, T> JoinPurchasing_PurchaseOrders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), (p, ids) => ((Purchasing_PurchaseOrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_Supplier)o).Purchasing_PurchaseOrders.Attach(v.Cast<Purchasing_PurchaseOrder>()), p => (long)((Purchasing_PurchaseOrder)p).SupplierID, attach);
        }

        public Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[AlternateContactPersonID] = {1}.[PersonID]"), o => ((Purchasing_Supplier)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T> JoinLastEditedByApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Purchasing_Supplier)o)?.LastEditedByApplication_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).LastEditedByApplication_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_CityQuery<Purchasing_SupplierQuery<K, T>, T> JoinApplication_City(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[DeliveryCityID] = {1}.[CityID]"), o => ((Purchasing_Supplier)o)?.Application_City, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).Application_City = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }

        public Application_DeliveryMethodQuery<Purchasing_SupplierQuery<K, T>, T> JoinApplication_DeliveryMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_DeliveryMethodQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[DeliveryMethods] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), o => ((Purchasing_Supplier)o)?.Application_DeliveryMethod, (e, fv, ppe) =>
            {
                var child = (Application_DeliveryMethod)ppe(QueryHelpers.Fill<Application_DeliveryMethod>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).Application_DeliveryMethod = child;
                }

                return child;
            }

            , typeof (Application_DeliveryMethod), preloadEntities);
        }

        public Application_CityQuery<Purchasing_SupplierQuery<K, T>, T> JoinPostalCity(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[PostalCityID] = {1}.[CityID]"), o => ((Purchasing_Supplier)o)?.PostalCity, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).PostalCity = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }

        public Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T> JoinPrimaryContactPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[PrimaryContactPersonID] = {1}.[PersonID]"), o => ((Purchasing_Supplier)o)?.PrimaryContactPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).PrimaryContactPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Purchasing_SupplierCategoryQuery<Purchasing_SupplierQuery<K, T>, T> JoinPurchasing_SupplierCategory(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_SupplierCategoryQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierCategories] AS {1} {0} ON", "{2}.[SupplierCategoryID] = {1}.[SupplierCategoryID]"), o => ((Purchasing_Supplier)o)?.Purchasing_SupplierCategory, (e, fv, ppe) =>
            {
                var child = (Purchasing_SupplierCategory)ppe(QueryHelpers.Fill<Purchasing_SupplierCategory>(null, fv));
                if (e != null)
                {
                    ((Purchasing_Supplier)e).Purchasing_SupplierCategory = child;
                }

                return child;
            }

            , typeof (Purchasing_SupplierCategory), preloadEntities);
        }

        public Purchasing_SupplierTransactionQuery<Purchasing_SupplierQuery<K, T>, T> JoinPurchasing_SupplierTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierTransactionQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierTransactions] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), (p, ids) => ((Purchasing_SupplierTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_Supplier)o).Purchasing_SupplierTransactions.Attach(v.Cast<Purchasing_SupplierTransaction>()), p => (long)((Purchasing_SupplierTransaction)p).SupplierID, attach);
        }

        public Warehouse_StockItemQuery<Purchasing_SupplierQuery<K, T>, T> JoinWarehouse_StockItems(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTableQuery<Warehouse_StockItem>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), (p, ids) => ((Warehouse_StockItemWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_Supplier)o).Warehouse_StockItems.Attach(v.Cast<Warehouse_StockItem>()), p => (long)((Warehouse_StockItem)p).SupplierID, attach);
        }

        public Warehouse_StockItemTransactionQuery<Purchasing_SupplierQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Purchasing_SupplierQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_Supplier)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).SupplierID, attach);
        }
    }

    public class Purchasing_SupplierTableQuery<T> : Purchasing_SupplierQuery<Purchasing_SupplierTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Purchasing_SupplierTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Purchasing_SupplierHelper : QueryHelper<Purchasing_Supplier>, IHelper<Purchasing_Supplier>
    {
        string[] columnsInSelectStatement = new[]{"{0}.SupplierID", "{0}.SupplierName", "{0}.SupplierCategoryID", "{0}.PrimaryContactPersonID", "{0}.AlternateContactPersonID", "{0}.DeliveryMethodID", "{0}.DeliveryCityID", "{0}.PostalCityID", "{0}.SupplierReference", "{0}.BankAccountName", "{0}.BankAccountBranch", "{0}.BankAccountCode", "{0}.BankAccountNumber", "{0}.BankInternationalCode", "{0}.PaymentDays", "{0}.InternalComments", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.WebsiteURL", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalPostalCode", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.SupplierID", "{0}.SupplierName", "{0}.SupplierCategoryID", "{0}.PrimaryContactPersonID", "{0}.AlternateContactPersonID", "{0}.DeliveryMethodID", "{0}.DeliveryCityID", "{0}.PostalCityID", "{0}.SupplierReference", "{0}.BankAccountName", "{0}.BankAccountBranch", "{0}.BankAccountCode", "{0}.BankAccountNumber", "{0}.BankInternationalCode", "{0}.PaymentDays", "{0}.InternalComments", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.WebsiteURL", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalPostalCode", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Purchasing_Supplier ([SupplierID] Int NOT NULL,[SupplierName] NVarChar(100) NOT NULL,[SupplierCategoryID] Int NOT NULL,[PrimaryContactPersonID] Int NOT NULL,[AlternateContactPersonID] Int NOT NULL,[DeliveryMethodID] Int,[DeliveryCityID] Int NOT NULL,[PostalCityID] Int NOT NULL,[SupplierReference] NVarChar(20),[BankAccountName] NVarChar(50),[BankAccountBranch] NVarChar(50),[BankAccountCode] NVarChar(20),[BankAccountNumber] NVarChar(20),[BankInternationalCode] NVarChar(20),[PaymentDays] Int NOT NULL,[InternalComments] NVarChar(MAX),[PhoneNumber] NVarChar(20) NOT NULL,[FaxNumber] NVarChar(20) NOT NULL,[WebsiteURL] NVarChar(256) NOT NULL,[DeliveryAddressLine1] NVarChar(60) NOT NULL,[DeliveryAddressLine2] NVarChar(60),[DeliveryPostalCode] NVarChar(10) NOT NULL,[PostalAddressLine1] NVarChar(60) NOT NULL,[PostalAddressLine2] NVarChar(60),[PostalPostalCode] NVarChar(10) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Purchasing].[Suppliers]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_PurchaseOrder) || other == typeof (Purchasing_SupplierTransaction) || other == typeof (Warehouse_StockItem) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Purchasing].[Suppliers] ([{TableName = \"Purchasing].[Suppliers\";}].[SupplierID], [{TableName = \"Purchasing].[Suppliers\";}].[SupplierName], [{TableName = \"Purchasing].[Suppliers\";}].[SupplierCategoryID], [{TableName = \"Purchasing].[Suppliers\";}].[PrimaryContactPersonID], [{TableName = \"Purchasing].[Suppliers\";}].[AlternateContactPersonID], [{TableName = \"Purchasing].[Suppliers\";}].[DeliveryMethodID], [{TableName = \"Purchasing].[Suppliers\";}].[DeliveryCityID], [{TableName = \"Purchasing].[Suppliers\";}].[PostalCityID], [{TableName = \"Purchasing].[Suppliers\";}].[SupplierReference], [{TableName = \"Purchasing].[Suppliers\";}].[BankAccountName], [{TableName = \"Purchasing].[Suppliers\";}].[BankAccountBranch], [{TableName = \"Purchasing].[Suppliers\";}].[BankAccountCode], [{TableName = \"Purchasing].[Suppliers\";}].[BankAccountNumber], [{TableName = \"Purchasing].[Suppliers\";}].[BankInternationalCode], [{TableName = \"Purchasing].[Suppliers\";}].[PaymentDays], [{TableName = \"Purchasing].[Suppliers\";}].[InternalComments], [{TableName = \"Purchasing].[Suppliers\";}].[PhoneNumber], [{TableName = \"Purchasing].[Suppliers\";}].[FaxNumber], [{TableName = \"Purchasing].[Suppliers\";}].[WebsiteURL], [{TableName = \"Purchasing].[Suppliers\";}].[DeliveryAddressLine1], [{TableName = \"Purchasing].[Suppliers\";}].[DeliveryAddressLine2], [{TableName = \"Purchasing].[Suppliers\";}].[DeliveryPostalCode], [{TableName = \"Purchasing].[Suppliers\";}].[PostalAddressLine1], [{TableName = \"Purchasing].[Suppliers\";}].[PostalAddressLine2], [{TableName = \"Purchasing].[Suppliers\";}].[PostalPostalCode], [{TableName = \"Purchasing].[Suppliers\";}].[LastEditedBy], [{TableName = \"Purchasing].[Suppliers\";}].[ValidFrom], [{TableName = \"Purchasing].[Suppliers\";}].[ValidTo]) VALUES ([@SupplierID],[@SupplierName],[@SupplierCategoryID],[@PrimaryContactPersonID],[@AlternateContactPersonID],[@DeliveryMethodID],[@DeliveryCityID],[@PostalCityID],[@SupplierReference],[@BankAccountName],[@BankAccountBranch],[@BankAccountCode],[@BankAccountNumber],[@BankInternationalCode],[@PaymentDays],[@InternalComments],[@PhoneNumber],[@FaxNumber],[@WebsiteURL],[@DeliveryAddressLine1],[@DeliveryAddressLine2],[@DeliveryPostalCode],[@PostalAddressLine1],[@PostalAddressLine2],[@PostalPostalCode],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Purchasing_Supplier _Purchasing_Supplier)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@SupplierID", _Purchasing_Supplier.SupplierID);
            sqlCommand.Parameters.AddWithValue("@SupplierName", _Purchasing_Supplier.SupplierName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@SupplierCategoryID", _Purchasing_Supplier.SupplierCategoryID);
            sqlCommand.Parameters.AddWithValue("@PrimaryContactPersonID", _Purchasing_Supplier.PrimaryContactPersonID);
            sqlCommand.Parameters.AddWithValue("@AlternateContactPersonID", _Purchasing_Supplier.AlternateContactPersonID);
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodID", _Purchasing_Supplier.DeliveryMethodID);
            sqlCommand.Parameters.AddWithValue("@DeliveryCityID", _Purchasing_Supplier.DeliveryCityID);
            sqlCommand.Parameters.AddWithValue("@PostalCityID", _Purchasing_Supplier.PostalCityID);
            sqlCommand.Parameters.AddWithValue("@SupplierReference", _Purchasing_Supplier.SupplierReference ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BankAccountName", _Purchasing_Supplier.BankAccountName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BankAccountBranch", _Purchasing_Supplier.BankAccountBranch ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BankAccountCode", _Purchasing_Supplier.BankAccountCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BankAccountNumber", _Purchasing_Supplier.BankAccountNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BankInternationalCode", _Purchasing_Supplier.BankInternationalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PaymentDays", _Purchasing_Supplier.PaymentDays);
            sqlCommand.Parameters.AddWithValue("@InternalComments", _Purchasing_Supplier.InternalComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", _Purchasing_Supplier.PhoneNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@FaxNumber", _Purchasing_Supplier.FaxNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@WebsiteURL", _Purchasing_Supplier.WebsiteURL ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine1", _Purchasing_Supplier.DeliveryAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine2", _Purchasing_Supplier.DeliveryAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryPostalCode", _Purchasing_Supplier.DeliveryPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine1", _Purchasing_Supplier.PostalAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine2", _Purchasing_Supplier.PostalAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalPostalCode", _Purchasing_Supplier.PostalPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Purchasing_Supplier.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Purchasing_Supplier.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Purchasing_Supplier.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Purchasing_Supplier _Purchasing_Supplier)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Purchasing_Supplier.SupplierID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Purchasing_SupplierWrapper _wrapper = Purchasing_SupplierWrapper.Instance;
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
    public class Purchasing_SupplierWrapper : QueryWrapper<Purchasing_Supplier>
    {
        public readonly QueryElMemberId<Purchasing_SupplierCategory> SupplierCategoryID = new QueryElMemberId<Purchasing_SupplierCategory>("SupplierCategoryID");
        public readonly QueryElMemberId<Application_People> PrimaryContactPersonID = new QueryElMemberId<Application_People>("PrimaryContactPersonID");
        public readonly QueryElMemberId<Application_People> AlternateContactPersonID = new QueryElMemberId<Application_People>("AlternateContactPersonID");
        public readonly QueryElMemberId<Application_DeliveryMethod> DeliveryMethodID = new QueryElMemberId<Application_DeliveryMethod>("DeliveryMethodID");
        public readonly QueryElMemberId<Application_City> DeliveryCityID = new QueryElMemberId<Application_City>("DeliveryCityID");
        public readonly QueryElMemberId<Application_City> PostalCityID = new QueryElMemberId<Application_City>("PostalCityID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> SupplierName = new QueryElMember<System.String>("SupplierName");
        public readonly QueryElMember<System.String> SupplierReference = new QueryElMember<System.String>("SupplierReference");
        public readonly QueryElMember<System.String> BankAccountName = new QueryElMember<System.String>("BankAccountName");
        public readonly QueryElMember<System.String> BankAccountBranch = new QueryElMember<System.String>("BankAccountBranch");
        public readonly QueryElMember<System.String> BankAccountCode = new QueryElMember<System.String>("BankAccountCode");
        public readonly QueryElMember<System.String> BankAccountNumber = new QueryElMember<System.String>("BankAccountNumber");
        public readonly QueryElMember<System.String> BankInternationalCode = new QueryElMember<System.String>("BankInternationalCode");
        public readonly QueryElMemberStruct<System.Int32> PaymentDays = new QueryElMemberStruct<System.Int32>("PaymentDays");
        public readonly QueryElMember<System.String> InternalComments = new QueryElMember<System.String>("InternalComments");
        public readonly QueryElMember<System.String> PhoneNumber = new QueryElMember<System.String>("PhoneNumber");
        public readonly QueryElMember<System.String> FaxNumber = new QueryElMember<System.String>("FaxNumber");
        public readonly QueryElMember<System.String> WebsiteURL = new QueryElMember<System.String>("WebsiteURL");
        public readonly QueryElMember<System.String> DeliveryAddressLine1 = new QueryElMember<System.String>("DeliveryAddressLine1");
        public readonly QueryElMember<System.String> DeliveryAddressLine2 = new QueryElMember<System.String>("DeliveryAddressLine2");
        public readonly QueryElMember<System.String> DeliveryPostalCode = new QueryElMember<System.String>("DeliveryPostalCode");
        public readonly QueryElMember<System.String> PostalAddressLine1 = new QueryElMember<System.String>("PostalAddressLine1");
        public readonly QueryElMember<System.String> PostalAddressLine2 = new QueryElMember<System.String>("PostalAddressLine2");
        public readonly QueryElMember<System.String> PostalPostalCode = new QueryElMember<System.String>("PostalPostalCode");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Purchasing_SupplierWrapper Instance = new Purchasing_SupplierWrapper();
        private Purchasing_SupplierWrapper(): base ("[Purchasing].[Suppliers]", "Purchasing_Supplier")
        {
        }
    }
}