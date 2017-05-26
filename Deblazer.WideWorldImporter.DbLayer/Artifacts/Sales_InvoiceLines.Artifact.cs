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
    public partial class Sales_InvoiceLine : DbEntity, IId
    {
        private DbValue<System.Int32> _InvoiceLineID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _InvoiceID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.String> _Description = new DbValue<System.String>();
        private DbValue<System.Int32> _PackageTypeID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _Quantity = new DbValue<System.Int32>();
        private DbValue<System.Decimal> _UnitPrice = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TaxRate = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TaxAmount = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _LineProfit = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _ExtendedPrice = new DbValue<System.Decimal>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Sales_Invoice> _Sales_Invoice;
        private IDbEntityRef<Warehouse_PackageType> _Warehouse_PackageType;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => InvoiceLineID;
        long ILongId.Id => InvoiceLineID;
        [Validate]
        public System.Int32 InvoiceLineID
        {
            get
            {
                return _InvoiceLineID.Entity;
            }

            set
            {
                _InvoiceLineID.Entity = value;
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
        public System.Int32 Quantity
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
        public System.Decimal TaxAmount
        {
            get
            {
                return _TaxAmount.Entity;
            }

            set
            {
                _TaxAmount.Entity = value;
            }
        }

        [Validate]
        public System.Decimal LineProfit
        {
            get
            {
                return _LineProfit.Entity;
            }

            set
            {
                _LineProfit.Entity = value;
            }
        }

        [Validate]
        public System.Decimal ExtendedPrice
        {
            get
            {
                return _ExtendedPrice.Entity;
            }

            set
            {
                _ExtendedPrice.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_InvoiceLines.Add(this);
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

                AssignDbEntity<Application_People, Sales_InvoiceLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_InvoiceLines, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Sales_Invoice Sales_Invoice
        {
            get
            {
                Action<Sales_Invoice> beforeRightsCheckAction = e => e.Sales_InvoiceLines.Add(this);
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

                AssignDbEntity<Sales_Invoice, Sales_InvoiceLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.InvoiceID}, _Sales_Invoice, new long ? []{_InvoiceID.Entity}, new Action<long ? >[]{x => InvoiceID = (int ? )x ?? default (int)}, x => x.Sales_InvoiceLines, null, InvoiceIDChanged);
            }
        }

        void InvoiceIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Invoice)
                _InvoiceID.Entity = (int)((Sales_Invoice)sender).Id;
        }

        [Validate]
        public Warehouse_PackageType Warehouse_PackageType
        {
            get
            {
                Action<Warehouse_PackageType> beforeRightsCheckAction = e => e.Sales_InvoiceLines.Add(this);
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

                AssignDbEntity<Warehouse_PackageType, Sales_InvoiceLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PackageTypeID}, _Warehouse_PackageType, new long ? []{_PackageTypeID.Entity}, new Action<long ? >[]{x => PackageTypeID = (int ? )x ?? default (int)}, x => x.Sales_InvoiceLines, null, PackageTypeIDChanged);
            }
        }

        void PackageTypeIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_PackageType)
                _PackageTypeID.Entity = (int)((Warehouse_PackageType)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Sales_InvoiceLines.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Sales_InvoiceLine>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Sales_InvoiceLines, null, StockItemIDChanged);
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
            _InvoiceLineID.Load(visitor.GetInt32());
            SendIdChanged();
            _InvoiceID.Load(visitor.GetInt32());
            _StockItemID.Load(visitor.GetInt32());
            _Description.Load(visitor.GetValue<System.String>());
            _PackageTypeID.Load(visitor.GetInt32());
            _Quantity.Load(visitor.GetInt32());
            _UnitPrice.Load(visitor.GetDecimal());
            _TaxRate.Load(visitor.GetDecimal());
            _TaxAmount.Load(visitor.GetDecimal());
            _LineProfit.Load(visitor.GetDecimal());
            _ExtendedPrice.Load(visitor.GetDecimal());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _InvoiceLineID.Welcome(visitor, "InvoiceLineID", "Int NOT NULL", false);
            _InvoiceID.Welcome(visitor, "InvoiceID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _Description.Welcome(visitor, "Description", "NVarChar(100) NOT NULL", false);
            _PackageTypeID.Welcome(visitor, "PackageTypeID", "Int NOT NULL", false);
            _Quantity.Welcome(visitor, "Quantity", "Int NOT NULL", false);
            _UnitPrice.Welcome(visitor, "UnitPrice", "Decimal(18,2)", false);
            _TaxRate.Welcome(visitor, "TaxRate", "Decimal(18,3) NOT NULL", false);
            _TaxAmount.Welcome(visitor, "TaxAmount", "Decimal(18,2) NOT NULL", false);
            _LineProfit.Welcome(visitor, "LineProfit", "Decimal(18,2) NOT NULL", false);
            _ExtendedPrice.Welcome(visitor, "ExtendedPrice", "Decimal(18,2) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Sales_Invoice);
            visitor.ProcessAssociation(this, _Warehouse_PackageType);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Sales_InvoiceLineQueryGetterExtensions
    {
        public static Sales_InvoiceLineTableQuery<Sales_InvoiceLine> Sales_InvoiceLines(this IDb db)
        {
            var query = new Sales_InvoiceLineTableQuery<Sales_InvoiceLine>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_InvoiceLineQuery<K, T> : Query<K, T, Sales_InvoiceLine, Sales_InvoiceLineWrapper, Sales_InvoiceLineQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_InvoiceLineQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_InvoiceLineWrapper GetWrapper()
        {
            return Sales_InvoiceLineWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_InvoiceLineQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_InvoiceLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_InvoiceLine)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_InvoiceLine)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_InvoiceQuery<Sales_InvoiceLineQuery<K, T>, T> JoinSales_Invoice(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Sales_InvoiceLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), o => ((Sales_InvoiceLine)o)?.Sales_Invoice, (e, fv, ppe) =>
            {
                var child = (Sales_Invoice)ppe(QueryHelpers.Fill<Sales_Invoice>(null, fv));
                if (e != null)
                {
                    ((Sales_InvoiceLine)e).Sales_Invoice = child;
                }

                return child;
            }

            , typeof (Sales_Invoice), preloadEntities);
        }

        public Warehouse_PackageTypeQuery<Sales_InvoiceLineQuery<K, T>, T> JoinWarehouse_PackageType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_PackageTypeQuery<Sales_InvoiceLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[PackageTypes] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), o => ((Sales_InvoiceLine)o)?.Warehouse_PackageType, (e, fv, ppe) =>
            {
                var child = (Warehouse_PackageType)ppe(QueryHelpers.Fill<Warehouse_PackageType>(null, fv));
                if (e != null)
                {
                    ((Sales_InvoiceLine)e).Warehouse_PackageType = child;
                }

                return child;
            }

            , typeof (Warehouse_PackageType), preloadEntities);
        }

        public Warehouse_StockItemQuery<Sales_InvoiceLineQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Sales_InvoiceLineQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Sales_InvoiceLine)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Sales_InvoiceLine)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Sales_InvoiceLineTableQuery<T> : Sales_InvoiceLineQuery<Sales_InvoiceLineTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_InvoiceLineTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_InvoiceLineHelper : QueryHelper<Sales_InvoiceLine>, IHelper<Sales_InvoiceLine>
    {
        string[] columnsInSelectStatement = new[]{"{0}.InvoiceLineID", "{0}.InvoiceID", "{0}.StockItemID", "{0}.Description", "{0}.PackageTypeID", "{0}.Quantity", "{0}.UnitPrice", "{0}.TaxRate", "{0}.TaxAmount", "{0}.LineProfit", "{0}.ExtendedPrice", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.InvoiceLineID", "{0}.InvoiceID", "{0}.StockItemID", "{0}.Description", "{0}.PackageTypeID", "{0}.Quantity", "{0}.UnitPrice", "{0}.TaxRate", "{0}.TaxAmount", "{0}.LineProfit", "{0}.ExtendedPrice", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_InvoiceLine ([InvoiceLineID] Int NOT NULL,[InvoiceID] Int NOT NULL,[StockItemID] Int NOT NULL,[Description] NVarChar(100) NOT NULL,[PackageTypeID] Int NOT NULL,[Quantity] Int NOT NULL,[UnitPrice] Decimal(18,2),[TaxRate] Decimal(18,3) NOT NULL,[TaxAmount] Decimal(18,2) NOT NULL,[LineProfit] Decimal(18,2) NOT NULL,[ExtendedPrice] Decimal(18,2) NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[InvoiceLines]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Sales].[InvoiceLines] ([{TableName = \"Sales].[InvoiceLines\";}].[InvoiceLineID], [{TableName = \"Sales].[InvoiceLines\";}].[InvoiceID], [{TableName = \"Sales].[InvoiceLines\";}].[StockItemID], [{TableName = \"Sales].[InvoiceLines\";}].[Description], [{TableName = \"Sales].[InvoiceLines\";}].[PackageTypeID], [{TableName = \"Sales].[InvoiceLines\";}].[Quantity], [{TableName = \"Sales].[InvoiceLines\";}].[UnitPrice], [{TableName = \"Sales].[InvoiceLines\";}].[TaxRate], [{TableName = \"Sales].[InvoiceLines\";}].[TaxAmount], [{TableName = \"Sales].[InvoiceLines\";}].[LineProfit], [{TableName = \"Sales].[InvoiceLines\";}].[ExtendedPrice], [{TableName = \"Sales].[InvoiceLines\";}].[LastEditedBy], [{TableName = \"Sales].[InvoiceLines\";}].[LastEditedWhen]) VALUES ([@InvoiceLineID],[@InvoiceID],[@StockItemID],[@Description],[@PackageTypeID],[@Quantity],[@UnitPrice],[@TaxRate],[@TaxAmount],[@LineProfit],[@ExtendedPrice],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_InvoiceLine _Sales_InvoiceLine)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@InvoiceLineID", _Sales_InvoiceLine.InvoiceLineID);
            sqlCommand.Parameters.AddWithValue("@InvoiceID", _Sales_InvoiceLine.InvoiceID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Sales_InvoiceLine.StockItemID);
            sqlCommand.Parameters.AddWithValue("@Description", _Sales_InvoiceLine.Description ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PackageTypeID", _Sales_InvoiceLine.PackageTypeID);
            sqlCommand.Parameters.AddWithValue("@Quantity", _Sales_InvoiceLine.Quantity);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", _Sales_InvoiceLine.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@TaxRate", _Sales_InvoiceLine.TaxRate);
            sqlCommand.Parameters.AddWithValue("@TaxAmount", _Sales_InvoiceLine.TaxAmount);
            sqlCommand.Parameters.AddWithValue("@LineProfit", _Sales_InvoiceLine.LineProfit);
            sqlCommand.Parameters.AddWithValue("@ExtendedPrice", _Sales_InvoiceLine.ExtendedPrice);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_InvoiceLine.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_InvoiceLine.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_InvoiceLine _Sales_InvoiceLine)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_InvoiceLine.InvoiceLineID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_InvoiceLineWrapper _wrapper = Sales_InvoiceLineWrapper.Instance;
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
    public class Sales_InvoiceLineWrapper : QueryWrapper<Sales_InvoiceLine>
    {
        public readonly QueryElMemberId<Sales_Invoice> InvoiceID = new QueryElMemberId<Sales_Invoice>("InvoiceID");
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Warehouse_PackageType> PackageTypeID = new QueryElMemberId<Warehouse_PackageType>("PackageTypeID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> Description = new QueryElMember<System.String>("Description");
        public readonly QueryElMemberStruct<System.Int32> Quantity = new QueryElMemberStruct<System.Int32>("Quantity");
        public readonly QueryElMemberStruct<System.Decimal> UnitPrice = new QueryElMemberStruct<System.Decimal>("UnitPrice");
        public readonly QueryElMemberStruct<System.Decimal> TaxRate = new QueryElMemberStruct<System.Decimal>("TaxRate");
        public readonly QueryElMemberStruct<System.Decimal> TaxAmount = new QueryElMemberStruct<System.Decimal>("TaxAmount");
        public readonly QueryElMemberStruct<System.Decimal> LineProfit = new QueryElMemberStruct<System.Decimal>("LineProfit");
        public readonly QueryElMemberStruct<System.Decimal> ExtendedPrice = new QueryElMemberStruct<System.Decimal>("ExtendedPrice");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_InvoiceLineWrapper Instance = new Sales_InvoiceLineWrapper();
        private Sales_InvoiceLineWrapper(): base ("[Sales].[InvoiceLines]", "Sales_InvoiceLine")
        {
        }
    }
}