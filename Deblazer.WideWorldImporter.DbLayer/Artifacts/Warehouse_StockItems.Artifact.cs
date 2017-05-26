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
    public partial class Warehouse_StockItem : DbEntity, IId
    {
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.String> _StockItemName = new DbValue<System.String>();
        private DbValue<System.Int32> _SupplierID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _ColorID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _UnitPackageID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _OuterPackageID = new DbValue<System.Int32>();
        private DbValue<System.String> _Brand = new DbValue<System.String>();
        private DbValue<System.String> _Size = new DbValue<System.String>();
        private DbValue<System.Int32> _LeadTimeDays = new DbValue<System.Int32>();
        private DbValue<System.Int32> _QuantityPerOuter = new DbValue<System.Int32>();
        private DbValue<System.Boolean> _IsChillerStock = new DbValue<System.Boolean>();
        private DbValue<System.String> _Barcode = new DbValue<System.String>();
        private DbValue<System.Decimal> _TaxRate = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _UnitPrice = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _RecommendedRetailPrice = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TypicalWeightPerUnit = new DbValue<System.Decimal>();
        private DbValue<System.String> _MarketingComments = new DbValue<System.String>();
        private DbValue<System.String> _InternalComments = new DbValue<System.String>();
        private DbValue<System.Data.Linq.Binary> _Photo = new DbValue<System.Data.Linq.Binary>();
        private DbValue<System.String> _CustomFields = new DbValue<System.String>();
        private DbValue<System.String> _Tags = new DbValue<System.String>();
        private DbValue<System.String> _SearchDetails = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Purchasing_PurchaseOrderLine> _Purchasing_PurchaseOrderLines;
        private IDbEntitySet<Sales_InvoiceLine> _Sales_InvoiceLines;
        private IDbEntitySet<Sales_OrderLine> _Sales_OrderLines;
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Warehouse_Color> _Warehouse_Color;
        private IDbEntityRef<Warehouse_PackageType> _Warehouse_PackageType;
        private IDbEntityRef<Purchasing_Supplier> _Purchasing_Supplier;
        private IDbEntityRef<Warehouse_PackageType> _UnitPackage;
        private IDbEntitySet<Warehouse_StockItemStockGroup> _Warehouse_StockItemStockGroups;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        private IDbEntityRef<Warehouse_StockItemHolding> _Warehouse_StockItemHolding;
        public int Id => StockItemID;
        long ILongId.Id => StockItemID;
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
        public System.String StockItemName
        {
            get
            {
                return _StockItemName.Entity;
            }

            set
            {
                _StockItemName.Entity = value;
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
        public System.Int32 ColorID
        {
            get
            {
                return _ColorID.Entity;
            }

            set
            {
                _ColorID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 UnitPackageID
        {
            get
            {
                return _UnitPackageID.Entity;
            }

            set
            {
                _UnitPackageID.Entity = value;
            }
        }

        [Validate]
        public System.Int32 OuterPackageID
        {
            get
            {
                return _OuterPackageID.Entity;
            }

            set
            {
                _OuterPackageID.Entity = value;
            }
        }

        [StringColumn(50, true)]
        [Validate]
        public System.String Brand
        {
            get
            {
                return _Brand.Entity;
            }

            set
            {
                _Brand.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String Size
        {
            get
            {
                return _Size.Entity;
            }

            set
            {
                _Size.Entity = value;
            }
        }

        [Validate]
        public System.Int32 LeadTimeDays
        {
            get
            {
                return _LeadTimeDays.Entity;
            }

            set
            {
                _LeadTimeDays.Entity = value;
            }
        }

        [Validate]
        public System.Int32 QuantityPerOuter
        {
            get
            {
                return _QuantityPerOuter.Entity;
            }

            set
            {
                _QuantityPerOuter.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsChillerStock
        {
            get
            {
                return _IsChillerStock.Entity;
            }

            set
            {
                _IsChillerStock.Entity = value;
            }
        }

        [StringColumn(50, true)]
        [Validate]
        public System.String Barcode
        {
            get
            {
                return _Barcode.Entity;
            }

            set
            {
                _Barcode.Entity = value;
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
        public System.Decimal RecommendedRetailPrice
        {
            get
            {
                return _RecommendedRetailPrice.Entity;
            }

            set
            {
                _RecommendedRetailPrice.Entity = value;
            }
        }

        [Validate]
        public System.Decimal TypicalWeightPerUnit
        {
            get
            {
                return _TypicalWeightPerUnit.Entity;
            }

            set
            {
                _TypicalWeightPerUnit.Entity = value;
            }
        }

        [StringColumn(2147483647, true)]
        [Validate]
        public System.String MarketingComments
        {
            get
            {
                return _MarketingComments.Entity;
            }

            set
            {
                _MarketingComments.Entity = value;
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
        public System.String Tags
        {
            get
            {
                return _Tags.Entity;
            }

            set
            {
                _Tags.Entity = value;
            }
        }

        [StringColumn(2147483647, false)]
        [Validate]
        public System.String SearchDetails
        {
            get
            {
                return _SearchDetails.Entity;
            }

            set
            {
                _SearchDetails.Entity = value;
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
        public IDbEntitySet<Purchasing_PurchaseOrderLine> Purchasing_PurchaseOrderLines
        {
            get
            {
                if (_Purchasing_PurchaseOrderLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrderLines = new DbEntitySetCached<Warehouse_StockItem, Purchasing_PurchaseOrderLine>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrderLines = new DbEntitySet<Purchasing_PurchaseOrderLine>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrderLines;
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
                        _Sales_InvoiceLines = new DbEntitySetCached<Warehouse_StockItem, Sales_InvoiceLine>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Sales_InvoiceLines = new DbEntitySet<Sales_InvoiceLine>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
                    }

                    );
                return _Sales_InvoiceLines;
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
                        _Sales_OrderLines = new DbEntitySetCached<Warehouse_StockItem, Sales_OrderLine>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Sales_OrderLines = new DbEntitySet<Sales_OrderLine>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
                    }

                    );
                return _Sales_OrderLines;
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
                        _Sales_SpecialDeals = new DbEntitySetCached<Warehouse_StockItem, Sales_SpecialDeal>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
                    }

                    );
                return _Sales_SpecialDeals;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_StockItems.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_StockItems, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Warehouse_Color Warehouse_Color
        {
            get
            {
                Action<Warehouse_Color> beforeRightsCheckAction = e => e.Warehouse_StockItems.Add(this);
                if (_Warehouse_Color != null)
                {
                    return _Warehouse_Color.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_Color = GetDbEntityRef(true, new[]{"[ColorID]"}, new Func<long ? >[]{() => _ColorID.Entity}, beforeRightsCheckAction);
                return (Warehouse_Color != null) ? _Warehouse_Color.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_Color == null)
                {
                    _Warehouse_Color = new DbEntityRef<Warehouse_Color>(_db, true, new[]{"[ColorID]"}, new Func<long ? >[]{() => _ColorID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_Color, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.ColorID}, _Warehouse_Color, new long ? []{_ColorID.Entity}, new Action<long ? >[]{x => ColorID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItems, null, ColorIDChanged);
            }
        }

        void ColorIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_Color)
                _ColorID.Entity = (int)((Warehouse_Color)sender).Id;
        }

        [Validate]
        public Warehouse_PackageType Warehouse_PackageType
        {
            get
            {
                Action<Warehouse_PackageType> beforeRightsCheckAction = e => e.Warehouse_StockItems.Add(this);
                if (_Warehouse_PackageType != null)
                {
                    return _Warehouse_PackageType.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_PackageType = GetDbEntityRef(true, new[]{"[OuterPackageID]"}, new Func<long ? >[]{() => _OuterPackageID.Entity}, beforeRightsCheckAction);
                return (Warehouse_PackageType != null) ? _Warehouse_PackageType.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_PackageType == null)
                {
                    _Warehouse_PackageType = new DbEntityRef<Warehouse_PackageType>(_db, true, new[]{"[OuterPackageID]"}, new Func<long ? >[]{() => _OuterPackageID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_PackageType, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PackageTypeID}, _Warehouse_PackageType, new long ? []{_OuterPackageID.Entity}, new Action<long ? >[]{x => OuterPackageID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItems, null, OuterPackageIDChanged);
            }
        }

        void OuterPackageIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_PackageType)
                _OuterPackageID.Entity = (int)((Warehouse_PackageType)sender).Id;
        }

        [Validate]
        public Purchasing_Supplier Purchasing_Supplier
        {
            get
            {
                Action<Purchasing_Supplier> beforeRightsCheckAction = e => e.Warehouse_StockItems.Add(this);
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

                AssignDbEntity<Purchasing_Supplier, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.SupplierID}, _Purchasing_Supplier, new long ? []{_SupplierID.Entity}, new Action<long ? >[]{x => SupplierID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItems, null, SupplierIDChanged);
            }
        }

        void SupplierIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_Supplier)
                _SupplierID.Entity = (int)((Purchasing_Supplier)sender).Id;
        }

        [Validate]
        public Warehouse_PackageType UnitPackage
        {
            get
            {
                Action<Warehouse_PackageType> beforeRightsCheckAction = e => e.Warehouse_StockItems.Add(this);
                if (_UnitPackage != null)
                {
                    return _UnitPackage.GetEntity(beforeRightsCheckAction);
                }

                _UnitPackage = GetDbEntityRef(true, new[]{"[UnitPackageID]"}, new Func<long ? >[]{() => _UnitPackageID.Entity}, beforeRightsCheckAction);
                return (UnitPackage != null) ? _UnitPackage.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_UnitPackage == null)
                {
                    _UnitPackage = new DbEntityRef<Warehouse_PackageType>(_db, true, new[]{"[UnitPackageID]"}, new Func<long ? >[]{() => _UnitPackageID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_PackageType, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PackageTypeID}, _UnitPackage, new long ? []{_UnitPackageID.Entity}, new Action<long ? >[]{x => UnitPackageID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItems, null, UnitPackageIDChanged);
            }
        }

        void UnitPackageIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_PackageType)
                _UnitPackageID.Entity = (int)((Warehouse_PackageType)sender).Id;
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
                        _Warehouse_StockItemStockGroups = new DbEntitySetCached<Warehouse_StockItem, Warehouse_StockItemStockGroup>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemStockGroups = new DbEntitySet<Warehouse_StockItemStockGroup>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Warehouse_StockItem, Warehouse_StockItemTransaction>(() => _StockItemID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _StockItemID.Entity}, new[]{"[StockItemID]"}, (member, root) => member.Warehouse_StockItem = root as Warehouse_StockItem, this, _lazyLoadChildren, e => e.Warehouse_StockItem = this, e =>
                    {
                        var x = e.Warehouse_StockItem;
                        e.Warehouse_StockItem = null;
                        new UpdateSetVisitor(true, new[]{"StockItemID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        [Validate]
        public Warehouse_StockItemHolding Warehouse_StockItemHolding
        {
            get
            {
                Action<Warehouse_StockItemHolding> beforeRightsCheckAction = e => e.Warehouse_StockItem = this;
                if (_Warehouse_StockItemHolding != null)
                {
                    return _Warehouse_StockItemHolding.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_StockItemHolding = GetDbEntityRef(true, new[]{"[StockItemID]"}, new Func<long ? >[]{() => _StockItemID.Entity}, beforeRightsCheckAction);
                return (Warehouse_StockItemHolding != null) ? _Warehouse_StockItemHolding.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_StockItemHolding == null)
                {
                    _Warehouse_StockItemHolding = new DbEntityRef<Warehouse_StockItemHolding>(_db, true, new[]{"[StockItemID]"}, new Func<long ? >[]{() => _StockItemID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_StockItemHolding, Warehouse_StockItem>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItemHolding, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, null, (x, y) => x.Warehouse_StockItem = y, StockItemIDChanged);
            }
        }

        void StockItemIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_StockItemHolding)
                _StockItemID.Entity = (int)((Warehouse_StockItemHolding)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _StockItemID.Load(visitor.GetInt32());
            SendIdChanged();
            _StockItemName.Load(visitor.GetValue<System.String>());
            _SupplierID.Load(visitor.GetInt32());
            _ColorID.Load(visitor.GetInt32());
            _UnitPackageID.Load(visitor.GetInt32());
            _OuterPackageID.Load(visitor.GetInt32());
            _Brand.Load(visitor.GetValue<System.String>());
            _Size.Load(visitor.GetValue<System.String>());
            _LeadTimeDays.Load(visitor.GetInt32());
            _QuantityPerOuter.Load(visitor.GetInt32());
            _IsChillerStock.Load(visitor.GetBoolean());
            _Barcode.Load(visitor.GetValue<System.String>());
            _TaxRate.Load(visitor.GetDecimal());
            _UnitPrice.Load(visitor.GetDecimal());
            _RecommendedRetailPrice.Load(visitor.GetDecimal());
            _TypicalWeightPerUnit.Load(visitor.GetDecimal());
            _MarketingComments.Load(visitor.GetValue<System.String>());
            _InternalComments.Load(visitor.GetValue<System.String>());
            _Photo.Load(visitor.GetBinary());
            _CustomFields.Load(visitor.GetValue<System.String>());
            _Tags.Load(visitor.GetValue<System.String>());
            _SearchDetails.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _StockItemName.Welcome(visitor, "StockItemName", "NVarChar(100) NOT NULL", false);
            _SupplierID.Welcome(visitor, "SupplierID", "Int NOT NULL", false);
            _ColorID.Welcome(visitor, "ColorID", "Int", false);
            _UnitPackageID.Welcome(visitor, "UnitPackageID", "Int NOT NULL", false);
            _OuterPackageID.Welcome(visitor, "OuterPackageID", "Int NOT NULL", false);
            _Brand.Welcome(visitor, "Brand", "NVarChar(50)", false);
            _Size.Welcome(visitor, "Size", "NVarChar(20)", false);
            _LeadTimeDays.Welcome(visitor, "LeadTimeDays", "Int NOT NULL", false);
            _QuantityPerOuter.Welcome(visitor, "QuantityPerOuter", "Int NOT NULL", false);
            _IsChillerStock.Welcome(visitor, "IsChillerStock", "Bit NOT NULL", false);
            _Barcode.Welcome(visitor, "Barcode", "NVarChar(50)", false);
            _TaxRate.Welcome(visitor, "TaxRate", "Decimal(18,3) NOT NULL", false);
            _UnitPrice.Welcome(visitor, "UnitPrice", "Decimal(18,2) NOT NULL", false);
            _RecommendedRetailPrice.Welcome(visitor, "RecommendedRetailPrice", "Decimal(18,2)", false);
            _TypicalWeightPerUnit.Welcome(visitor, "TypicalWeightPerUnit", "Decimal(18,3) NOT NULL", false);
            _MarketingComments.Welcome(visitor, "MarketingComments", "NVarChar(MAX)", false);
            _InternalComments.Welcome(visitor, "InternalComments", "NVarChar(MAX)", false);
            _Photo.Welcome(visitor, "Photo", "VarBinary(MAX)", false);
            _CustomFields.Welcome(visitor, "CustomFields", "NVarChar(MAX)", false);
            _Tags.Welcome(visitor, "Tags", "NVarChar(MAX)", false);
            _SearchDetails.Welcome(visitor, "SearchDetails", "NVarChar(MAX) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrderLines);
            visitor.ProcessAssociation(this, _Sales_InvoiceLines);
            visitor.ProcessAssociation(this, _Sales_OrderLines);
            visitor.ProcessAssociation(this, _Sales_SpecialDeals);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_Color);
            visitor.ProcessAssociation(this, _Warehouse_PackageType);
            visitor.ProcessAssociation(this, _Purchasing_Supplier);
            visitor.ProcessAssociation(this, _UnitPackage);
            visitor.ProcessAssociation(this, _Warehouse_StockItemStockGroups);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
            visitor.ProcessAssociation(this, _Warehouse_StockItemHolding);
        }
    }

    public static class Db_Warehouse_StockItemQueryGetterExtensions
    {
        public static Warehouse_StockItemTableQuery<Warehouse_StockItem> Warehouse_StockItems(this IDb db)
        {
            var query = new Warehouse_StockItemTableQuery<Warehouse_StockItem>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_StockItemQuery<K, T> : Query<K, T, Warehouse_StockItem, Warehouse_StockItemWrapper, Warehouse_StockItemQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_StockItemQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_StockItemWrapper GetWrapper()
        {
            return Warehouse_StockItemWrapper.Instance;
        }

        public Purchasing_PurchaseOrderLineQuery<Warehouse_StockItemQuery<K, T>, T> JoinPurchasing_PurchaseOrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderLineQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrderLines] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Purchasing_PurchaseOrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Purchasing_PurchaseOrderLines.Attach(v.Cast<Purchasing_PurchaseOrderLine>()), p => (long)((Purchasing_PurchaseOrderLine)p).StockItemID, attach);
        }

        public Sales_InvoiceLineQuery<Warehouse_StockItemQuery<K, T>, T> JoinSales_InvoiceLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceLineQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceLineTableQuery<Sales_InvoiceLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[InvoiceLines] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Sales_InvoiceLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Sales_InvoiceLines.Attach(v.Cast<Sales_InvoiceLine>()), p => (long)((Sales_InvoiceLine)p).StockItemID, attach);
        }

        public Sales_OrderLineQuery<Warehouse_StockItemQuery<K, T>, T> JoinSales_OrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderLineQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderLineTableQuery<Sales_OrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[OrderLines] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Sales_OrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Sales_OrderLines.Attach(v.Cast<Sales_OrderLine>()), p => (long)((Sales_OrderLine)p).StockItemID, attach);
        }

        public Sales_SpecialDealQuery<Warehouse_StockItemQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).StockItemID, attach);
        }

        public Application_PeopleQuery<Warehouse_StockItemQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_StockItem)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_ColorQuery<Warehouse_StockItemQuery<K, T>, T> JoinWarehouse_Color(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_ColorQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[Colors] AS {1} {0} ON", "{2}.[ColorID] = {1}.[ColorID]"), o => ((Warehouse_StockItem)o)?.Warehouse_Color, (e, fv, ppe) =>
            {
                var child = (Warehouse_Color)ppe(QueryHelpers.Fill<Warehouse_Color>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).Warehouse_Color = child;
                }

                return child;
            }

            , typeof (Warehouse_Color), preloadEntities);
        }

        public Warehouse_PackageTypeQuery<Warehouse_StockItemQuery<K, T>, T> JoinWarehouse_PackageType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[OuterPackageID] = {1}.[PackageTypeID]"), o => ((Warehouse_StockItem)o)?.Warehouse_PackageType, (e, fv, ppe) =>
            {
                var child = (Warehouse_PackageType)ppe(QueryHelpers.Fill<Warehouse_PackageType>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).Warehouse_PackageType = child;
                }

                return child;
            }

            , typeof (Warehouse_PackageType), preloadEntities);
        }

        public Purchasing_SupplierQuery<Warehouse_StockItemQuery<K, T>, T> JoinPurchasing_Supplier(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), o => ((Warehouse_StockItem)o)?.Purchasing_Supplier, (e, fv, ppe) =>
            {
                var child = (Purchasing_Supplier)ppe(QueryHelpers.Fill<Purchasing_Supplier>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).Purchasing_Supplier = child;
                }

                return child;
            }

            , typeof (Purchasing_Supplier), preloadEntities);
        }

        public Warehouse_PackageTypeQuery<Warehouse_StockItemQuery<K, T>, T> JoinUnitPackage(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[UnitPackageID] = {1}.[PackageTypeID]"), o => ((Warehouse_StockItem)o)?.UnitPackage, (e, fv, ppe) =>
            {
                var child = (Warehouse_PackageType)ppe(QueryHelpers.Fill<Warehouse_PackageType>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).UnitPackage = child;
                }

                return child;
            }

            , typeof (Warehouse_PackageType), preloadEntities);
        }

        public Warehouse_StockItemStockGroupQuery<Warehouse_StockItemQuery<K, T>, T> JoinWarehouse_StockItemStockGroups(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemStockGroupQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemStockGroupTableQuery<Warehouse_StockItemStockGroup>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemStockGroups] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Warehouse_StockItemStockGroupWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Warehouse_StockItemStockGroups.Attach(v.Cast<Warehouse_StockItemStockGroup>()), p => (long)((Warehouse_StockItemStockGroup)p).StockItemID, attach);
        }

        public Warehouse_StockItemTransactionQuery<Warehouse_StockItemQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockItem)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).StockItemID, attach);
        }

        public Warehouse_StockItemHoldingQuery<Warehouse_StockItemQuery<K, T>, T> JoinWarehouse_StockItemHolding(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemHoldingQuery<Warehouse_StockItemQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemHoldings] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Warehouse_StockItem)o)?.Warehouse_StockItemHolding, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItemHolding)ppe(QueryHelpers.Fill<Warehouse_StockItemHolding>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItem)e).Warehouse_StockItemHolding = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItemHolding), preloadEntities);
        }
    }

    public class Warehouse_StockItemTableQuery<T> : Warehouse_StockItemQuery<Warehouse_StockItemTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_StockItemTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_StockItemHelper : QueryHelper<Warehouse_StockItem>, IHelper<Warehouse_StockItem>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StockItemID", "{0}.StockItemName", "{0}.SupplierID", "{0}.ColorID", "{0}.UnitPackageID", "{0}.OuterPackageID", "{0}.Brand", "{0}.Size", "{0}.LeadTimeDays", "{0}.QuantityPerOuter", "{0}.IsChillerStock", "{0}.Barcode", "{0}.TaxRate", "{0}.UnitPrice", "{0}.RecommendedRetailPrice", "{0}.TypicalWeightPerUnit", "{0}.MarketingComments", "{0}.InternalComments", "{0}.Photo", "{0}.CustomFields", "{0}.Tags", "{0}.SearchDetails", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StockItemID", "{0}.StockItemName", "{0}.SupplierID", "{0}.ColorID", "{0}.UnitPackageID", "{0}.OuterPackageID", "{0}.Brand", "{0}.Size", "{0}.LeadTimeDays", "{0}.QuantityPerOuter", "{0}.IsChillerStock", "{0}.Barcode", "{0}.TaxRate", "{0}.UnitPrice", "{0}.RecommendedRetailPrice", "{0}.TypicalWeightPerUnit", "{0}.MarketingComments", "{0}.InternalComments", "{0}.Photo", "{0}.CustomFields", "{0}.Tags", "{0}.SearchDetails", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_StockItem ([StockItemID] Int NOT NULL,[StockItemName] NVarChar(100) NOT NULL,[SupplierID] Int NOT NULL,[ColorID] Int,[UnitPackageID] Int NOT NULL,[OuterPackageID] Int NOT NULL,[Brand] NVarChar(50),[Size] NVarChar(20),[LeadTimeDays] Int NOT NULL,[QuantityPerOuter] Int NOT NULL,[IsChillerStock] Bit NOT NULL,[Barcode] NVarChar(50),[TaxRate] Decimal(18,3) NOT NULL,[UnitPrice] Decimal(18,2) NOT NULL,[RecommendedRetailPrice] Decimal(18,2),[TypicalWeightPerUnit] Decimal(18,3) NOT NULL,[MarketingComments] NVarChar(MAX),[InternalComments] NVarChar(MAX),[Photo] VarBinary(MAX),[CustomFields] NVarChar(MAX),[Tags] NVarChar(MAX),[SearchDetails] NVarChar(MAX) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[StockItems]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_PurchaseOrderLine) || other == typeof (Sales_InvoiceLine) || other == typeof (Sales_OrderLine) || other == typeof (Sales_SpecialDeal) || other == typeof (Warehouse_StockItemStockGroup) || other == typeof (Warehouse_StockItemTransaction) || other == typeof (Warehouse_StockItemHolding);
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[StockItems] ([{TableName = \"Warehouse].[StockItems\";}].[StockItemID], [{TableName = \"Warehouse].[StockItems\";}].[StockItemName], [{TableName = \"Warehouse].[StockItems\";}].[SupplierID], [{TableName = \"Warehouse].[StockItems\";}].[ColorID], [{TableName = \"Warehouse].[StockItems\";}].[UnitPackageID], [{TableName = \"Warehouse].[StockItems\";}].[OuterPackageID], [{TableName = \"Warehouse].[StockItems\";}].[Brand], [{TableName = \"Warehouse].[StockItems\";}].[Size], [{TableName = \"Warehouse].[StockItems\";}].[LeadTimeDays], [{TableName = \"Warehouse].[StockItems\";}].[QuantityPerOuter], [{TableName = \"Warehouse].[StockItems\";}].[IsChillerStock], [{TableName = \"Warehouse].[StockItems\";}].[Barcode], [{TableName = \"Warehouse].[StockItems\";}].[TaxRate], [{TableName = \"Warehouse].[StockItems\";}].[UnitPrice], [{TableName = \"Warehouse].[StockItems\";}].[RecommendedRetailPrice], [{TableName = \"Warehouse].[StockItems\";}].[TypicalWeightPerUnit], [{TableName = \"Warehouse].[StockItems\";}].[MarketingComments], [{TableName = \"Warehouse].[StockItems\";}].[InternalComments], [{TableName = \"Warehouse].[StockItems\";}].[Photo], [{TableName = \"Warehouse].[StockItems\";}].[CustomFields], [{TableName = \"Warehouse].[StockItems\";}].[Tags], [{TableName = \"Warehouse].[StockItems\";}].[SearchDetails], [{TableName = \"Warehouse].[StockItems\";}].[LastEditedBy], [{TableName = \"Warehouse].[StockItems\";}].[ValidFrom], [{TableName = \"Warehouse].[StockItems\";}].[ValidTo]) VALUES ([@StockItemID],[@StockItemName],[@SupplierID],[@ColorID],[@UnitPackageID],[@OuterPackageID],[@Brand],[@Size],[@LeadTimeDays],[@QuantityPerOuter],[@IsChillerStock],[@Barcode],[@TaxRate],[@UnitPrice],[@RecommendedRetailPrice],[@TypicalWeightPerUnit],[@MarketingComments],[@InternalComments],[@Photo],[@CustomFields],[@Tags],[@SearchDetails],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_StockItem _Warehouse_StockItem)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Warehouse_StockItem.StockItemID);
            sqlCommand.Parameters.AddWithValue("@StockItemName", _Warehouse_StockItem.StockItemName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@SupplierID", _Warehouse_StockItem.SupplierID);
            sqlCommand.Parameters.AddWithValue("@ColorID", _Warehouse_StockItem.ColorID);
            sqlCommand.Parameters.AddWithValue("@UnitPackageID", _Warehouse_StockItem.UnitPackageID);
            sqlCommand.Parameters.AddWithValue("@OuterPackageID", _Warehouse_StockItem.OuterPackageID);
            sqlCommand.Parameters.AddWithValue("@Brand", _Warehouse_StockItem.Brand ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Size", _Warehouse_StockItem.Size ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LeadTimeDays", _Warehouse_StockItem.LeadTimeDays);
            sqlCommand.Parameters.AddWithValue("@QuantityPerOuter", _Warehouse_StockItem.QuantityPerOuter);
            sqlCommand.Parameters.AddWithValue("@IsChillerStock", _Warehouse_StockItem.IsChillerStock);
            sqlCommand.Parameters.AddWithValue("@Barcode", _Warehouse_StockItem.Barcode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@TaxRate", _Warehouse_StockItem.TaxRate);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", _Warehouse_StockItem.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@RecommendedRetailPrice", _Warehouse_StockItem.RecommendedRetailPrice);
            sqlCommand.Parameters.AddWithValue("@TypicalWeightPerUnit", _Warehouse_StockItem.TypicalWeightPerUnit);
            sqlCommand.Parameters.AddWithValue("@MarketingComments", _Warehouse_StockItem.MarketingComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@InternalComments", _Warehouse_StockItem.InternalComments ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Photo", _Warehouse_StockItem.Photo ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@CustomFields", _Warehouse_StockItem.CustomFields ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Tags", _Warehouse_StockItem.Tags ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@SearchDetails", _Warehouse_StockItem.SearchDetails ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_StockItem.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Warehouse_StockItem.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Warehouse_StockItem.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_StockItem _Warehouse_StockItem)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_StockItem.StockItemID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_StockItemWrapper _wrapper = Warehouse_StockItemWrapper.Instance;
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
    public class Warehouse_StockItemWrapper : QueryWrapper<Warehouse_StockItem>
    {
        public readonly QueryElMemberId<Purchasing_Supplier> SupplierID = new QueryElMemberId<Purchasing_Supplier>("SupplierID");
        public readonly QueryElMemberId<Warehouse_Color> ColorID = new QueryElMemberId<Warehouse_Color>("ColorID");
        public readonly QueryElMemberId<Warehouse_PackageType> UnitPackageID = new QueryElMemberId<Warehouse_PackageType>("UnitPackageID");
        public readonly QueryElMemberId<Warehouse_PackageType> OuterPackageID = new QueryElMemberId<Warehouse_PackageType>("OuterPackageID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> StockItemName = new QueryElMember<System.String>("StockItemName");
        public readonly QueryElMember<System.String> Brand = new QueryElMember<System.String>("Brand");
        public readonly QueryElMember<System.String> Size = new QueryElMember<System.String>("Size");
        public readonly QueryElMemberStruct<System.Int32> LeadTimeDays = new QueryElMemberStruct<System.Int32>("LeadTimeDays");
        public readonly QueryElMemberStruct<System.Int32> QuantityPerOuter = new QueryElMemberStruct<System.Int32>("QuantityPerOuter");
        public readonly QueryElMemberStruct<System.Boolean> IsChillerStock = new QueryElMemberStruct<System.Boolean>("IsChillerStock");
        public readonly QueryElMember<System.String> Barcode = new QueryElMember<System.String>("Barcode");
        public readonly QueryElMemberStruct<System.Decimal> TaxRate = new QueryElMemberStruct<System.Decimal>("TaxRate");
        public readonly QueryElMemberStruct<System.Decimal> UnitPrice = new QueryElMemberStruct<System.Decimal>("UnitPrice");
        public readonly QueryElMemberStruct<System.Decimal> RecommendedRetailPrice = new QueryElMemberStruct<System.Decimal>("RecommendedRetailPrice");
        public readonly QueryElMemberStruct<System.Decimal> TypicalWeightPerUnit = new QueryElMemberStruct<System.Decimal>("TypicalWeightPerUnit");
        public readonly QueryElMember<System.String> MarketingComments = new QueryElMember<System.String>("MarketingComments");
        public readonly QueryElMember<System.String> InternalComments = new QueryElMember<System.String>("InternalComments");
        public readonly QueryElMember<System.Data.Linq.Binary> Photo = new QueryElMember<System.Data.Linq.Binary>("Photo");
        public readonly QueryElMember<System.String> CustomFields = new QueryElMember<System.String>("CustomFields");
        public readonly QueryElMember<System.String> Tags = new QueryElMember<System.String>("Tags");
        public readonly QueryElMember<System.String> SearchDetails = new QueryElMember<System.String>("SearchDetails");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Warehouse_StockItemWrapper Instance = new Warehouse_StockItemWrapper();
        private Warehouse_StockItemWrapper(): base ("[Warehouse].[StockItems]", "Warehouse_StockItem")
        {
        }
    }
}