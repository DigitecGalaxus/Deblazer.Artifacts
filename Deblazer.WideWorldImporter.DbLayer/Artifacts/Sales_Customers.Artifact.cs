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
    public partial class Sales_Customer : DbEntity, IId
    {
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.String> _CustomerName = new DbValue<System.String>();
        private DbValue<System.Int32> _BillToCustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerCategoryID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _BuyingGroupID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PrimaryContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _AlternateContactPersonID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _DeliveryMethodID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _DeliveryCityID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PostalCityID = new DbValue<System.Int32>();
        private DbValue<System.Decimal> _CreditLimit = new DbValue<System.Decimal>();
        private DbValue<System.DateTime> _AccountOpenedDate = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _StandardDiscountPercentage = new DbValue<System.Decimal>();
        private DbValue<System.Boolean> _IsStatementSent = new DbValue<System.Boolean>();
        private DbValue<System.Boolean> _IsOnCreditHold = new DbValue<System.Boolean>();
        private DbValue<System.Int32> _PaymentDays = new DbValue<System.Int32>();
        private DbValue<System.String> _PhoneNumber = new DbValue<System.String>();
        private DbValue<System.String> _FaxNumber = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryRun = new DbValue<System.String>();
        private DbValue<System.String> _RunPosition = new DbValue<System.String>();
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
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_People> _LastEditedByApplication_People;
        private IDbEntityRef<Sales_Customer> _BillToCustomer;
        private IDbEntitySet<Sales_Customer> _Customers;
        private IDbEntityRef<Sales_BuyingGroup> _Sales_BuyingGroup;
        private IDbEntityRef<Sales_CustomerCategory> _Sales_CustomerCategory;
        private IDbEntityRef<Application_City> _Application_City;
        private IDbEntityRef<Application_DeliveryMethod> _Application_DeliveryMethod;
        private IDbEntityRef<Application_City> _PostalCity;
        private IDbEntityRef<Application_People> _PrimaryContactPerson;
        private IDbEntitySet<Sales_CustomerTransaction> _Sales_CustomerTransactions;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices_CustomerID_Sales_Customers;
        private IDbEntitySet<Sales_Order> _Sales_Orders;
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => CustomerID;
        long ILongId.Id => CustomerID;
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

        [StringColumn(100, false)]
        [Validate]
        public System.String CustomerName
        {
            get
            {
                return _CustomerName.Entity;
            }

            set
            {
                _CustomerName.Entity = value;
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

        [Validate]
        public System.Decimal CreditLimit
        {
            get
            {
                return _CreditLimit.Entity;
            }

            set
            {
                _CreditLimit.Entity = value;
            }
        }

        [Validate]
        public System.DateTime AccountOpenedDate
        {
            get
            {
                return _AccountOpenedDate.Entity;
            }

            set
            {
                _AccountOpenedDate.Entity = value;
            }
        }

        [Validate]
        public System.Decimal StandardDiscountPercentage
        {
            get
            {
                return _StandardDiscountPercentage.Entity;
            }

            set
            {
                _StandardDiscountPercentage.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsStatementSent
        {
            get
            {
                return _IsStatementSent.Entity;
            }

            set
            {
                _IsStatementSent.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsOnCreditHold
        {
            get
            {
                return _IsOnCreditHold.Entity;
            }

            set
            {
                _IsOnCreditHold.Entity = value;
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
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_People, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_AlternateContactPersonID.Entity}, new Action<long ? >[]{x => AlternateContactPersonID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, AlternateContactPersonIDChanged);
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_People, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _LastEditedByApplication_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Customer BillToCustomer
        {
            get
            {
                Action<Sales_Customer> beforeRightsCheckAction = e => e.BillToCustomer = this;
                if (_BillToCustomer != null)
                {
                    return _BillToCustomer.GetEntity(beforeRightsCheckAction);
                }

                _BillToCustomer = GetDbEntityRef(true, new[]{"[BillToCustomerID]"}, new Func<long ? >[]{() => _BillToCustomerID.Entity}, beforeRightsCheckAction);
                return (BillToCustomer != null) ? _BillToCustomer.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_BillToCustomer == null)
                {
                    _BillToCustomer = new DbEntityRef<Sales_Customer>(_db, true, new[]{"[BillToCustomerID]"}, new Func<long ? >[]{() => _BillToCustomerID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Sales_Customer, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _BillToCustomer, new long ? []{_BillToCustomerID.Entity}, new Action<long ? >[]{x => BillToCustomerID = (int ? )x ?? default (int)}, x => x.Customers, null, BillToCustomerIDChanged);
            }
        }

        void BillToCustomerIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Customer)
                _BillToCustomerID.Entity = (int)((Sales_Customer)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Sales_Customer> Customers
        {
            get
            {
                if (_Customers == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Customers = new DbEntitySetCached<Sales_Customer, Sales_Customer>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[BillToCustomerID]"}, (member, root) => member.BillToCustomer = root as Sales_Customer, this, _lazyLoadChildren, e => e.BillToCustomer = this, e =>
                    {
                        var x = e.BillToCustomer;
                        e.BillToCustomer = null;
                        new UpdateSetVisitor(true, new[]{"BillToCustomerID"}, false).Process(x);
                    }

                    );
                return _Customers;
            }
        }

        [Validate]
        public Sales_BuyingGroup Sales_BuyingGroup
        {
            get
            {
                Action<Sales_BuyingGroup> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Sales_BuyingGroup, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.BuyingGroupID}, _Sales_BuyingGroup, new long ? []{_BuyingGroupID.Entity}, new Action<long ? >[]{x => BuyingGroupID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, BuyingGroupIDChanged);
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
                Action<Sales_CustomerCategory> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Sales_CustomerCategory, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerCategoryID}, _Sales_CustomerCategory, new long ? []{_CustomerCategoryID.Entity}, new Action<long ? >[]{x => CustomerCategoryID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, CustomerCategoryIDChanged);
            }
        }

        void CustomerCategoryIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_CustomerCategory)
                _CustomerCategoryID.Entity = (int)((Sales_CustomerCategory)sender).Id;
        }

        [Validate]
        public Application_City Application_City
        {
            get
            {
                Action<Application_City> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_City, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _Application_City, new long ? []{_DeliveryCityID.Entity}, new Action<long ? >[]{x => DeliveryCityID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, DeliveryCityIDChanged);
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
                Action<Application_DeliveryMethod> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_DeliveryMethod, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.DeliveryMethodID}, _Application_DeliveryMethod, new long ? []{_DeliveryMethodID.Entity}, new Action<long ? >[]{x => DeliveryMethodID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, DeliveryMethodIDChanged);
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
                Action<Application_City> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_City, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _PostalCity, new long ? []{_PostalCityID.Entity}, new Action<long ? >[]{x => PostalCityID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, PostalCityIDChanged);
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_Customers.Add(this);
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

                AssignDbEntity<Application_People, Sales_Customer>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _PrimaryContactPerson, new long ? []{_PrimaryContactPersonID.Entity}, new Action<long ? >[]{x => PrimaryContactPersonID = (int ? )x ?? default (int)}, x => x.Sales_Customers, null, PrimaryContactPersonIDChanged);
            }
        }

        void PrimaryContactPersonIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _PrimaryContactPersonID.Entity = (int)((Application_People)sender).Id;
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
                        _Sales_CustomerTransactions = new DbEntitySetCached<Sales_Customer, Sales_CustomerTransaction>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Sales_CustomerTransactions = new DbEntitySet<Sales_CustomerTransaction>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[CustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"CustomerID"}, false).Process(x);
                    }

                    );
                return _Sales_CustomerTransactions;
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
                        _Sales_Invoices = new DbEntitySetCached<Sales_Customer, Sales_Invoice>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Sales_Invoices = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[BillToCustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"BillToCustomerID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices_CustomerID_Sales_Customers
        {
            get
            {
                if (_Sales_Invoices_CustomerID_Sales_Customers == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices_CustomerID_Sales_Customers = new DbEntitySetCached<Sales_Customer, Sales_Invoice>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Sales_Invoices_CustomerID_Sales_Customers = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[CustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"CustomerID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices_CustomerID_Sales_Customers;
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
                        _Sales_Orders = new DbEntitySetCached<Sales_Customer, Sales_Order>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Sales_Orders = new DbEntitySet<Sales_Order>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[CustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"CustomerID"}, false).Process(x);
                    }

                    );
                return _Sales_Orders;
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
                        _Sales_SpecialDeals = new DbEntitySetCached<Sales_Customer, Sales_SpecialDeal>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[CustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"CustomerID"}, false).Process(x);
                    }

                    );
                return _Sales_SpecialDeals;
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Sales_Customer, Warehouse_StockItemTransaction>(() => _CustomerID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _CustomerID.Entity}, new[]{"[CustomerID]"}, (member, root) => member.Sales_Customer = root as Sales_Customer, this, _lazyLoadChildren, e => e.Sales_Customer = this, e =>
                    {
                        var x = e.Sales_Customer;
                        e.Sales_Customer = null;
                        new UpdateSetVisitor(true, new[]{"CustomerID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _CustomerID.Load(visitor.GetInt32());
            SendIdChanged();
            _CustomerName.Load(visitor.GetValue<System.String>());
            _BillToCustomerID.Load(visitor.GetInt32());
            _CustomerCategoryID.Load(visitor.GetInt32());
            _BuyingGroupID.Load(visitor.GetInt32());
            _PrimaryContactPersonID.Load(visitor.GetInt32());
            _AlternateContactPersonID.Load(visitor.GetInt32());
            _DeliveryMethodID.Load(visitor.GetInt32());
            _DeliveryCityID.Load(visitor.GetInt32());
            _PostalCityID.Load(visitor.GetInt32());
            _CreditLimit.Load(visitor.GetDecimal());
            _AccountOpenedDate.Load(visitor.GetDateTime());
            _StandardDiscountPercentage.Load(visitor.GetDecimal());
            _IsStatementSent.Load(visitor.GetBoolean());
            _IsOnCreditHold.Load(visitor.GetBoolean());
            _PaymentDays.Load(visitor.GetInt32());
            _PhoneNumber.Load(visitor.GetValue<System.String>());
            _FaxNumber.Load(visitor.GetValue<System.String>());
            _DeliveryRun.Load(visitor.GetValue<System.String>());
            _RunPosition.Load(visitor.GetValue<System.String>());
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
            _CustomerID.Welcome(visitor, "CustomerID", "Int NOT NULL", false);
            _CustomerName.Welcome(visitor, "CustomerName", "NVarChar(100) NOT NULL", false);
            _BillToCustomerID.Welcome(visitor, "BillToCustomerID", "Int NOT NULL", false);
            _CustomerCategoryID.Welcome(visitor, "CustomerCategoryID", "Int NOT NULL", false);
            _BuyingGroupID.Welcome(visitor, "BuyingGroupID", "Int", false);
            _PrimaryContactPersonID.Welcome(visitor, "PrimaryContactPersonID", "Int NOT NULL", false);
            _AlternateContactPersonID.Welcome(visitor, "AlternateContactPersonID", "Int", false);
            _DeliveryMethodID.Welcome(visitor, "DeliveryMethodID", "Int NOT NULL", false);
            _DeliveryCityID.Welcome(visitor, "DeliveryCityID", "Int NOT NULL", false);
            _PostalCityID.Welcome(visitor, "PostalCityID", "Int NOT NULL", false);
            _CreditLimit.Welcome(visitor, "CreditLimit", "Decimal(18,2)", false);
            _AccountOpenedDate.Welcome(visitor, "AccountOpenedDate", "Date NOT NULL", false);
            _StandardDiscountPercentage.Welcome(visitor, "StandardDiscountPercentage", "Decimal(18,3) NOT NULL", false);
            _IsStatementSent.Welcome(visitor, "IsStatementSent", "Bit NOT NULL", false);
            _IsOnCreditHold.Welcome(visitor, "IsOnCreditHold", "Bit NOT NULL", false);
            _PaymentDays.Welcome(visitor, "PaymentDays", "Int NOT NULL", false);
            _PhoneNumber.Welcome(visitor, "PhoneNumber", "NVarChar(20) NOT NULL", false);
            _FaxNumber.Welcome(visitor, "FaxNumber", "NVarChar(20) NOT NULL", false);
            _DeliveryRun.Welcome(visitor, "DeliveryRun", "NVarChar(5)", false);
            _RunPosition.Welcome(visitor, "RunPosition", "NVarChar(5)", false);
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
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _LastEditedByApplication_People);
            visitor.ProcessAssociation(this, _BillToCustomer);
            visitor.ProcessAssociation(this, _Customers);
            visitor.ProcessAssociation(this, _Sales_BuyingGroup);
            visitor.ProcessAssociation(this, _Sales_CustomerCategory);
            visitor.ProcessAssociation(this, _Application_City);
            visitor.ProcessAssociation(this, _Application_DeliveryMethod);
            visitor.ProcessAssociation(this, _PostalCity);
            visitor.ProcessAssociation(this, _PrimaryContactPerson);
            visitor.ProcessAssociation(this, _Sales_CustomerTransactions);
            visitor.ProcessAssociation(this, _Sales_Invoices);
            visitor.ProcessAssociation(this, _Sales_Invoices_CustomerID_Sales_Customers);
            visitor.ProcessAssociation(this, _Sales_Orders);
            visitor.ProcessAssociation(this, _Sales_SpecialDeals);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Sales_CustomerQueryGetterExtensions
    {
        public static Sales_CustomerTableQuery<Sales_Customer> Sales_Customers(this IDb db)
        {
            var query = new Sales_CustomerTableQuery<Sales_Customer>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_CustomerQuery<K, T> : Query<K, T, Sales_Customer, Sales_CustomerWrapper, Sales_CustomerQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_CustomerQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_CustomerWrapper GetWrapper()
        {
            return Sales_CustomerWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_CustomerQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[AlternateContactPersonID] = {1}.[PersonID]"), o => ((Sales_Customer)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PeopleQuery<Sales_CustomerQuery<K, T>, T> JoinLastEditedByApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_Customer)o)?.LastEditedByApplication_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).LastEditedByApplication_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_CustomerQuery<K, T>, T> JoinBillToCustomer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[BillToCustomerID] = {1}.[CustomerID]"), o => ((Sales_Customer)o)?.BillToCustomer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).BillToCustomer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_CustomerQuery<K, T>, T> JoinCustomers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[BillToCustomerID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).BillToCustomerID, attach);
        }

        public Sales_BuyingGroupQuery<Sales_CustomerQuery<K, T>, T> JoinSales_BuyingGroup(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_BuyingGroupQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[BuyingGroups] AS {1} {0} ON", "{2}.[BuyingGroupID] = {1}.[BuyingGroupID]"), o => ((Sales_Customer)o)?.Sales_BuyingGroup, (e, fv, ppe) =>
            {
                var child = (Sales_BuyingGroup)ppe(QueryHelpers.Fill<Sales_BuyingGroup>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).Sales_BuyingGroup = child;
                }

                return child;
            }

            , typeof (Sales_BuyingGroup), preloadEntities);
        }

        public Sales_CustomerCategoryQuery<Sales_CustomerQuery<K, T>, T> JoinSales_CustomerCategory(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerCategoryQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerCategories] AS {1} {0} ON", "{2}.[CustomerCategoryID] = {1}.[CustomerCategoryID]"), o => ((Sales_Customer)o)?.Sales_CustomerCategory, (e, fv, ppe) =>
            {
                var child = (Sales_CustomerCategory)ppe(QueryHelpers.Fill<Sales_CustomerCategory>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).Sales_CustomerCategory = child;
                }

                return child;
            }

            , typeof (Sales_CustomerCategory), preloadEntities);
        }

        public Application_CityQuery<Sales_CustomerQuery<K, T>, T> JoinApplication_City(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[DeliveryCityID] = {1}.[CityID]"), o => ((Sales_Customer)o)?.Application_City, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).Application_City = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }

        public Application_DeliveryMethodQuery<Sales_CustomerQuery<K, T>, T> JoinApplication_DeliveryMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_DeliveryMethodQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[DeliveryMethods] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), o => ((Sales_Customer)o)?.Application_DeliveryMethod, (e, fv, ppe) =>
            {
                var child = (Application_DeliveryMethod)ppe(QueryHelpers.Fill<Application_DeliveryMethod>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).Application_DeliveryMethod = child;
                }

                return child;
            }

            , typeof (Application_DeliveryMethod), preloadEntities);
        }

        public Application_CityQuery<Sales_CustomerQuery<K, T>, T> JoinPostalCity(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[PostalCityID] = {1}.[CityID]"), o => ((Sales_Customer)o)?.PostalCity, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).PostalCity = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }

        public Application_PeopleQuery<Sales_CustomerQuery<K, T>, T> JoinPrimaryContactPerson(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[PrimaryContactPersonID] = {1}.[PersonID]"), o => ((Sales_Customer)o)?.PrimaryContactPerson, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_Customer)e).PrimaryContactPerson = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerTransactionQuery<Sales_CustomerQuery<K, T>, T> JoinSales_CustomerTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerTransactionQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerTransactions] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), (p, ids) => ((Sales_CustomerTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Sales_CustomerTransactions.Attach(v.Cast<Sales_CustomerTransaction>()), p => (long)((Sales_CustomerTransaction)p).CustomerID, attach);
        }

        public Sales_InvoiceQuery<Sales_CustomerQuery<K, T>, T> JoinSales_Invoices(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[BillToCustomerID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Sales_Invoices.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).BillToCustomerID, attach);
        }

        public Sales_InvoiceQuery<Sales_CustomerQuery<K, T>, T> JoinSales_Invoices_CustomerID_Sales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Sales_Invoices_CustomerID_Sales_Customers.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).CustomerID, attach);
        }

        public Sales_OrderQuery<Sales_CustomerQuery<K, T>, T> JoinSales_Orders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderTableQuery<Sales_Order>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Orders] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), (p, ids) => ((Sales_OrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Sales_Orders.Attach(v.Cast<Sales_Order>()), p => (long)((Sales_Order)p).CustomerID, attach);
        }

        public Sales_SpecialDealQuery<Sales_CustomerQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).CustomerID, attach);
        }

        public Warehouse_StockItemTransactionQuery<Sales_CustomerQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Sales_CustomerQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_Customer)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).CustomerID, attach);
        }
    }

    public class Sales_CustomerTableQuery<T> : Sales_CustomerQuery<Sales_CustomerTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_CustomerTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_CustomerHelper : QueryHelper<Sales_Customer>, IHelper<Sales_Customer>
    {
        string[] columnsInSelectStatement = new[]{"{0}.CustomerID", "{0}.CustomerName", "{0}.BillToCustomerID", "{0}.CustomerCategoryID", "{0}.BuyingGroupID", "{0}.PrimaryContactPersonID", "{0}.AlternateContactPersonID", "{0}.DeliveryMethodID", "{0}.DeliveryCityID", "{0}.PostalCityID", "{0}.CreditLimit", "{0}.AccountOpenedDate", "{0}.StandardDiscountPercentage", "{0}.IsStatementSent", "{0}.IsOnCreditHold", "{0}.PaymentDays", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.DeliveryRun", "{0}.RunPosition", "{0}.WebsiteURL", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalPostalCode", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.CustomerID", "{0}.CustomerName", "{0}.BillToCustomerID", "{0}.CustomerCategoryID", "{0}.BuyingGroupID", "{0}.PrimaryContactPersonID", "{0}.AlternateContactPersonID", "{0}.DeliveryMethodID", "{0}.DeliveryCityID", "{0}.PostalCityID", "{0}.CreditLimit", "{0}.AccountOpenedDate", "{0}.StandardDiscountPercentage", "{0}.IsStatementSent", "{0}.IsOnCreditHold", "{0}.PaymentDays", "{0}.PhoneNumber", "{0}.FaxNumber", "{0}.DeliveryRun", "{0}.RunPosition", "{0}.WebsiteURL", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalPostalCode", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_Customer ([CustomerID] Int NOT NULL,[CustomerName] NVarChar(100) NOT NULL,[BillToCustomerID] Int NOT NULL,[CustomerCategoryID] Int NOT NULL,[BuyingGroupID] Int,[PrimaryContactPersonID] Int NOT NULL,[AlternateContactPersonID] Int,[DeliveryMethodID] Int NOT NULL,[DeliveryCityID] Int NOT NULL,[PostalCityID] Int NOT NULL,[CreditLimit] Decimal(18,2),[AccountOpenedDate] Date NOT NULL,[StandardDiscountPercentage] Decimal(18,3) NOT NULL,[IsStatementSent] Bit NOT NULL,[IsOnCreditHold] Bit NOT NULL,[PaymentDays] Int NOT NULL,[PhoneNumber] NVarChar(20) NOT NULL,[FaxNumber] NVarChar(20) NOT NULL,[DeliveryRun] NVarChar(5),[RunPosition] NVarChar(5),[WebsiteURL] NVarChar(256) NOT NULL,[DeliveryAddressLine1] NVarChar(60) NOT NULL,[DeliveryAddressLine2] NVarChar(60),[DeliveryPostalCode] NVarChar(10) NOT NULL,[PostalAddressLine1] NVarChar(60) NOT NULL,[PostalAddressLine2] NVarChar(60),[PostalPostalCode] NVarChar(10) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[Customers]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_Customer) || other == typeof (Sales_CustomerTransaction) || other == typeof (Sales_Invoice) || other == typeof (Sales_Invoice) || other == typeof (Sales_Order) || other == typeof (Sales_SpecialDeal) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Sales].[Customers] ([{TableName = \"Sales].[Customers\";}].[CustomerID], [{TableName = \"Sales].[Customers\";}].[CustomerName], [{TableName = \"Sales].[Customers\";}].[BillToCustomerID], [{TableName = \"Sales].[Customers\";}].[CustomerCategoryID], [{TableName = \"Sales].[Customers\";}].[BuyingGroupID], [{TableName = \"Sales].[Customers\";}].[PrimaryContactPersonID], [{TableName = \"Sales].[Customers\";}].[AlternateContactPersonID], [{TableName = \"Sales].[Customers\";}].[DeliveryMethodID], [{TableName = \"Sales].[Customers\";}].[DeliveryCityID], [{TableName = \"Sales].[Customers\";}].[PostalCityID], [{TableName = \"Sales].[Customers\";}].[CreditLimit], [{TableName = \"Sales].[Customers\";}].[AccountOpenedDate], [{TableName = \"Sales].[Customers\";}].[StandardDiscountPercentage], [{TableName = \"Sales].[Customers\";}].[IsStatementSent], [{TableName = \"Sales].[Customers\";}].[IsOnCreditHold], [{TableName = \"Sales].[Customers\";}].[PaymentDays], [{TableName = \"Sales].[Customers\";}].[PhoneNumber], [{TableName = \"Sales].[Customers\";}].[FaxNumber], [{TableName = \"Sales].[Customers\";}].[DeliveryRun], [{TableName = \"Sales].[Customers\";}].[RunPosition], [{TableName = \"Sales].[Customers\";}].[WebsiteURL], [{TableName = \"Sales].[Customers\";}].[DeliveryAddressLine1], [{TableName = \"Sales].[Customers\";}].[DeliveryAddressLine2], [{TableName = \"Sales].[Customers\";}].[DeliveryPostalCode], [{TableName = \"Sales].[Customers\";}].[PostalAddressLine1], [{TableName = \"Sales].[Customers\";}].[PostalAddressLine2], [{TableName = \"Sales].[Customers\";}].[PostalPostalCode], [{TableName = \"Sales].[Customers\";}].[LastEditedBy], [{TableName = \"Sales].[Customers\";}].[ValidFrom], [{TableName = \"Sales].[Customers\";}].[ValidTo]) VALUES ([@CustomerID],[@CustomerName],[@BillToCustomerID],[@CustomerCategoryID],[@BuyingGroupID],[@PrimaryContactPersonID],[@AlternateContactPersonID],[@DeliveryMethodID],[@DeliveryCityID],[@PostalCityID],[@CreditLimit],[@AccountOpenedDate],[@StandardDiscountPercentage],[@IsStatementSent],[@IsOnCreditHold],[@PaymentDays],[@PhoneNumber],[@FaxNumber],[@DeliveryRun],[@RunPosition],[@WebsiteURL],[@DeliveryAddressLine1],[@DeliveryAddressLine2],[@DeliveryPostalCode],[@PostalAddressLine1],[@PostalAddressLine2],[@PostalPostalCode],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_Customer _Sales_Customer)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Sales_Customer.CustomerID);
            sqlCommand.Parameters.AddWithValue("@CustomerName", _Sales_Customer.CustomerName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@BillToCustomerID", _Sales_Customer.BillToCustomerID);
            sqlCommand.Parameters.AddWithValue("@CustomerCategoryID", _Sales_Customer.CustomerCategoryID);
            sqlCommand.Parameters.AddWithValue("@BuyingGroupID", _Sales_Customer.BuyingGroupID);
            sqlCommand.Parameters.AddWithValue("@PrimaryContactPersonID", _Sales_Customer.PrimaryContactPersonID);
            sqlCommand.Parameters.AddWithValue("@AlternateContactPersonID", _Sales_Customer.AlternateContactPersonID);
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodID", _Sales_Customer.DeliveryMethodID);
            sqlCommand.Parameters.AddWithValue("@DeliveryCityID", _Sales_Customer.DeliveryCityID);
            sqlCommand.Parameters.AddWithValue("@PostalCityID", _Sales_Customer.PostalCityID);
            sqlCommand.Parameters.AddWithValue("@CreditLimit", _Sales_Customer.CreditLimit);
            sqlCommand.Parameters.AddWithValue("@AccountOpenedDate", _Sales_Customer.AccountOpenedDate);
            sqlCommand.Parameters.AddWithValue("@StandardDiscountPercentage", _Sales_Customer.StandardDiscountPercentage);
            sqlCommand.Parameters.AddWithValue("@IsStatementSent", _Sales_Customer.IsStatementSent);
            sqlCommand.Parameters.AddWithValue("@IsOnCreditHold", _Sales_Customer.IsOnCreditHold);
            sqlCommand.Parameters.AddWithValue("@PaymentDays", _Sales_Customer.PaymentDays);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", _Sales_Customer.PhoneNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@FaxNumber", _Sales_Customer.FaxNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryRun", _Sales_Customer.DeliveryRun ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@RunPosition", _Sales_Customer.RunPosition ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@WebsiteURL", _Sales_Customer.WebsiteURL ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine1", _Sales_Customer.DeliveryAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine2", _Sales_Customer.DeliveryAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryPostalCode", _Sales_Customer.DeliveryPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine1", _Sales_Customer.PostalAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine2", _Sales_Customer.PostalAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalPostalCode", _Sales_Customer.PostalPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_Customer.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Sales_Customer.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Sales_Customer.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_Customer _Sales_Customer)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_Customer.CustomerID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_CustomerWrapper _wrapper = Sales_CustomerWrapper.Instance;
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
    public class Sales_CustomerWrapper : QueryWrapper<Sales_Customer>
    {
        public readonly QueryElMemberId<Sales_Customer> BillToCustomerID = new QueryElMemberId<Sales_Customer>("BillToCustomerID");
        public readonly QueryElMemberId<Sales_CustomerCategory> CustomerCategoryID = new QueryElMemberId<Sales_CustomerCategory>("CustomerCategoryID");
        public readonly QueryElMemberId<Sales_BuyingGroup> BuyingGroupID = new QueryElMemberId<Sales_BuyingGroup>("BuyingGroupID");
        public readonly QueryElMemberId<Application_People> PrimaryContactPersonID = new QueryElMemberId<Application_People>("PrimaryContactPersonID");
        public readonly QueryElMemberId<Application_People> AlternateContactPersonID = new QueryElMemberId<Application_People>("AlternateContactPersonID");
        public readonly QueryElMemberId<Application_DeliveryMethod> DeliveryMethodID = new QueryElMemberId<Application_DeliveryMethod>("DeliveryMethodID");
        public readonly QueryElMemberId<Application_City> DeliveryCityID = new QueryElMemberId<Application_City>("DeliveryCityID");
        public readonly QueryElMemberId<Application_City> PostalCityID = new QueryElMemberId<Application_City>("PostalCityID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> CustomerName = new QueryElMember<System.String>("CustomerName");
        public readonly QueryElMemberStruct<System.Decimal> CreditLimit = new QueryElMemberStruct<System.Decimal>("CreditLimit");
        public readonly QueryElMemberStruct<System.DateTime> AccountOpenedDate = new QueryElMemberStruct<System.DateTime>("AccountOpenedDate");
        public readonly QueryElMemberStruct<System.Decimal> StandardDiscountPercentage = new QueryElMemberStruct<System.Decimal>("StandardDiscountPercentage");
        public readonly QueryElMemberStruct<System.Boolean> IsStatementSent = new QueryElMemberStruct<System.Boolean>("IsStatementSent");
        public readonly QueryElMemberStruct<System.Boolean> IsOnCreditHold = new QueryElMemberStruct<System.Boolean>("IsOnCreditHold");
        public readonly QueryElMemberStruct<System.Int32> PaymentDays = new QueryElMemberStruct<System.Int32>("PaymentDays");
        public readonly QueryElMember<System.String> PhoneNumber = new QueryElMember<System.String>("PhoneNumber");
        public readonly QueryElMember<System.String> FaxNumber = new QueryElMember<System.String>("FaxNumber");
        public readonly QueryElMember<System.String> DeliveryRun = new QueryElMember<System.String>("DeliveryRun");
        public readonly QueryElMember<System.String> RunPosition = new QueryElMember<System.String>("RunPosition");
        public readonly QueryElMember<System.String> WebsiteURL = new QueryElMember<System.String>("WebsiteURL");
        public readonly QueryElMember<System.String> DeliveryAddressLine1 = new QueryElMember<System.String>("DeliveryAddressLine1");
        public readonly QueryElMember<System.String> DeliveryAddressLine2 = new QueryElMember<System.String>("DeliveryAddressLine2");
        public readonly QueryElMember<System.String> DeliveryPostalCode = new QueryElMember<System.String>("DeliveryPostalCode");
        public readonly QueryElMember<System.String> PostalAddressLine1 = new QueryElMember<System.String>("PostalAddressLine1");
        public readonly QueryElMember<System.String> PostalAddressLine2 = new QueryElMember<System.String>("PostalAddressLine2");
        public readonly QueryElMember<System.String> PostalPostalCode = new QueryElMember<System.String>("PostalPostalCode");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Sales_CustomerWrapper Instance = new Sales_CustomerWrapper();
        private Sales_CustomerWrapper(): base ("[Sales].[Customers]", "Sales_Customer")
        {
        }
    }
}