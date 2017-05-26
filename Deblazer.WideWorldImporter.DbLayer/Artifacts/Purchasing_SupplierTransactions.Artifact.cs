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
    public partial class Purchasing_SupplierTransaction : DbEntity, IId
    {
        private DbValue<System.Int32> _SupplierTransactionID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _SupplierID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _TransactionTypeID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PurchaseOrderID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PaymentMethodID = new DbValue<System.Int32>();
        private DbValue<System.String> _SupplierInvoiceNumber = new DbValue<System.String>();
        private DbValue<System.DateTime> _TransactionDate = new DbValue<System.DateTime>();
        private DbValue<System.Decimal> _AmountExcludingTax = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TaxAmount = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _TransactionAmount = new DbValue<System.Decimal>();
        private DbValue<System.Decimal> _OutstandingBalance = new DbValue<System.Decimal>();
        private DbValue<System.DateTime> _FinalizationDate = new DbValue<System.DateTime>();
        private DbValue<System.Boolean> _IsFinalized = new DbValue<System.Boolean>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_PaymentMethod> _Application_PaymentMethod;
        private IDbEntityRef<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrder;
        private IDbEntityRef<Purchasing_Supplier> _Purchasing_Supplier;
        private IDbEntityRef<Application_TransactionType> _Application_TransactionType;
        public int Id => SupplierTransactionID;
        long ILongId.Id => SupplierTransactionID;
        [Validate]
        public System.Int32 SupplierTransactionID
        {
            get
            {
                return _SupplierTransactionID.Entity;
            }

            set
            {
                _SupplierTransactionID.Entity = value;
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
        public System.Int32 PaymentMethodID
        {
            get
            {
                return _PaymentMethodID.Entity;
            }

            set
            {
                _PaymentMethodID.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String SupplierInvoiceNumber
        {
            get
            {
                return _SupplierInvoiceNumber.Entity;
            }

            set
            {
                _SupplierInvoiceNumber.Entity = value;
            }
        }

        [Validate]
        public System.DateTime TransactionDate
        {
            get
            {
                return _TransactionDate.Entity;
            }

            set
            {
                _TransactionDate.Entity = value;
            }
        }

        [Validate]
        public System.Decimal AmountExcludingTax
        {
            get
            {
                return _AmountExcludingTax.Entity;
            }

            set
            {
                _AmountExcludingTax.Entity = value;
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
        public System.Decimal TransactionAmount
        {
            get
            {
                return _TransactionAmount.Entity;
            }

            set
            {
                _TransactionAmount.Entity = value;
            }
        }

        [Validate]
        public System.Decimal OutstandingBalance
        {
            get
            {
                return _OutstandingBalance.Entity;
            }

            set
            {
                _OutstandingBalance.Entity = value;
            }
        }

        [Validate]
        public System.DateTime FinalizationDate
        {
            get
            {
                return _FinalizationDate.Entity;
            }

            set
            {
                _FinalizationDate.Entity = value;
            }
        }

        [Validate]
        public System.Boolean IsFinalized
        {
            get
            {
                return _IsFinalized.Entity;
            }

            set
            {
                _IsFinalized.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_SupplierTransactions.Add(this);
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

                AssignDbEntity<Application_People, Purchasing_SupplierTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierTransactions, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_PaymentMethod Application_PaymentMethod
        {
            get
            {
                Action<Application_PaymentMethod> beforeRightsCheckAction = e => e.Purchasing_SupplierTransactions.Add(this);
                if (_Application_PaymentMethod != null)
                {
                    return _Application_PaymentMethod.GetEntity(beforeRightsCheckAction);
                }

                _Application_PaymentMethod = GetDbEntityRef(true, new[]{"[PaymentMethodID]"}, new Func<long ? >[]{() => _PaymentMethodID.Entity}, beforeRightsCheckAction);
                return (Application_PaymentMethod != null) ? _Application_PaymentMethod.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_PaymentMethod == null)
                {
                    _Application_PaymentMethod = new DbEntityRef<Application_PaymentMethod>(_db, true, new[]{"[PaymentMethodID]"}, new Func<long ? >[]{() => _PaymentMethodID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_PaymentMethod, Purchasing_SupplierTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PaymentMethodID}, _Application_PaymentMethod, new long ? []{_PaymentMethodID.Entity}, new Action<long ? >[]{x => PaymentMethodID = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierTransactions, null, PaymentMethodIDChanged);
            }
        }

        void PaymentMethodIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_PaymentMethod)
                _PaymentMethodID.Entity = (int)((Application_PaymentMethod)sender).Id;
        }

        [Validate]
        public Purchasing_PurchaseOrder Purchasing_PurchaseOrder
        {
            get
            {
                Action<Purchasing_PurchaseOrder> beforeRightsCheckAction = e => e.Purchasing_SupplierTransactions.Add(this);
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

                AssignDbEntity<Purchasing_PurchaseOrder, Purchasing_SupplierTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PurchaseOrderID}, _Purchasing_PurchaseOrder, new long ? []{_PurchaseOrderID.Entity}, new Action<long ? >[]{x => PurchaseOrderID = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierTransactions, null, PurchaseOrderIDChanged);
            }
        }

        void PurchaseOrderIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Purchasing_PurchaseOrder)
                _PurchaseOrderID.Entity = (int)((Purchasing_PurchaseOrder)sender).Id;
        }

        [Validate]
        public Purchasing_Supplier Purchasing_Supplier
        {
            get
            {
                Action<Purchasing_Supplier> beforeRightsCheckAction = e => e.Purchasing_SupplierTransactions.Add(this);
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

                AssignDbEntity<Purchasing_Supplier, Purchasing_SupplierTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.SupplierID}, _Purchasing_Supplier, new long ? []{_SupplierID.Entity}, new Action<long ? >[]{x => SupplierID = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierTransactions, null, SupplierIDChanged);
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
                Action<Application_TransactionType> beforeRightsCheckAction = e => e.Purchasing_SupplierTransactions.Add(this);
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

                AssignDbEntity<Application_TransactionType, Purchasing_SupplierTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.TransactionTypeID}, _Application_TransactionType, new long ? []{_TransactionTypeID.Entity}, new Action<long ? >[]{x => TransactionTypeID = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierTransactions, null, TransactionTypeIDChanged);
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
            _SupplierTransactionID.Load(visitor.GetInt32());
            SendIdChanged();
            _SupplierID.Load(visitor.GetInt32());
            _TransactionTypeID.Load(visitor.GetInt32());
            _PurchaseOrderID.Load(visitor.GetInt32());
            _PaymentMethodID.Load(visitor.GetInt32());
            _SupplierInvoiceNumber.Load(visitor.GetValue<System.String>());
            _TransactionDate.Load(visitor.GetDateTime());
            _AmountExcludingTax.Load(visitor.GetDecimal());
            _TaxAmount.Load(visitor.GetDecimal());
            _TransactionAmount.Load(visitor.GetDecimal());
            _OutstandingBalance.Load(visitor.GetDecimal());
            _FinalizationDate.Load(visitor.GetDateTime());
            _IsFinalized.Load(visitor.GetBoolean());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _SupplierTransactionID.Welcome(visitor, "SupplierTransactionID", "Int NOT NULL", false);
            _SupplierID.Welcome(visitor, "SupplierID", "Int NOT NULL", false);
            _TransactionTypeID.Welcome(visitor, "TransactionTypeID", "Int NOT NULL", false);
            _PurchaseOrderID.Welcome(visitor, "PurchaseOrderID", "Int", false);
            _PaymentMethodID.Welcome(visitor, "PaymentMethodID", "Int", false);
            _SupplierInvoiceNumber.Welcome(visitor, "SupplierInvoiceNumber", "NVarChar(20)", false);
            _TransactionDate.Welcome(visitor, "TransactionDate", "Date NOT NULL", false);
            _AmountExcludingTax.Welcome(visitor, "AmountExcludingTax", "Decimal(18,2) NOT NULL", false);
            _TaxAmount.Welcome(visitor, "TaxAmount", "Decimal(18,2) NOT NULL", false);
            _TransactionAmount.Welcome(visitor, "TransactionAmount", "Decimal(18,2) NOT NULL", false);
            _OutstandingBalance.Welcome(visitor, "OutstandingBalance", "Decimal(18,2) NOT NULL", false);
            _FinalizationDate.Welcome(visitor, "FinalizationDate", "Date", false);
            _IsFinalized.Welcome(visitor, "IsFinalized", "Bit", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Application_PaymentMethod);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrder);
            visitor.ProcessAssociation(this, _Purchasing_Supplier);
            visitor.ProcessAssociation(this, _Application_TransactionType);
        }
    }

    public static class Db_Purchasing_SupplierTransactionQueryGetterExtensions
    {
        public static Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction> Purchasing_SupplierTransactions(this IDb db)
        {
            var query = new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Purchasing_SupplierTransactionQuery<K, T> : Query<K, T, Purchasing_SupplierTransaction, Purchasing_SupplierTransactionWrapper, Purchasing_SupplierTransactionQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Purchasing_SupplierTransactionQuery(IDb db): base (db)
        {
        }

        protected sealed override Purchasing_SupplierTransactionWrapper GetWrapper()
        {
            return Purchasing_SupplierTransactionWrapper.Instance;
        }

        public Application_PeopleQuery<Purchasing_SupplierTransactionQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_SupplierTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Purchasing_SupplierTransaction)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierTransaction)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_PaymentMethodQuery<Purchasing_SupplierTransactionQuery<K, T>, T> JoinApplication_PaymentMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PaymentMethodQuery<Purchasing_SupplierTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[PaymentMethods] AS {1} {0} ON", "{2}.[PaymentMethodID] = {1}.[PaymentMethodID]"), o => ((Purchasing_SupplierTransaction)o)?.Application_PaymentMethod, (e, fv, ppe) =>
            {
                var child = (Application_PaymentMethod)ppe(QueryHelpers.Fill<Application_PaymentMethod>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierTransaction)e).Application_PaymentMethod = child;
                }

                return child;
            }

            , typeof (Application_PaymentMethod), preloadEntities);
        }

        public Purchasing_PurchaseOrderQuery<Purchasing_SupplierTransactionQuery<K, T>, T> JoinPurchasing_PurchaseOrder(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Purchasing_SupplierTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[PurchaseOrderID] = {1}.[PurchaseOrderID]"), o => ((Purchasing_SupplierTransaction)o)?.Purchasing_PurchaseOrder, (e, fv, ppe) =>
            {
                var child = (Purchasing_PurchaseOrder)ppe(QueryHelpers.Fill<Purchasing_PurchaseOrder>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierTransaction)e).Purchasing_PurchaseOrder = child;
                }

                return child;
            }

            , typeof (Purchasing_PurchaseOrder), preloadEntities);
        }

        public Purchasing_SupplierQuery<Purchasing_SupplierTransactionQuery<K, T>, T> JoinPurchasing_Supplier(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Purchasing_SupplierTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[SupplierID] = {1}.[SupplierID]"), o => ((Purchasing_SupplierTransaction)o)?.Purchasing_Supplier, (e, fv, ppe) =>
            {
                var child = (Purchasing_Supplier)ppe(QueryHelpers.Fill<Purchasing_Supplier>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierTransaction)e).Purchasing_Supplier = child;
                }

                return child;
            }

            , typeof (Purchasing_Supplier), preloadEntities);
        }

        public Application_TransactionTypeQuery<Purchasing_SupplierTransactionQuery<K, T>, T> JoinApplication_TransactionType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_TransactionTypeQuery<Purchasing_SupplierTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[TransactionTypes] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), o => ((Purchasing_SupplierTransaction)o)?.Application_TransactionType, (e, fv, ppe) =>
            {
                var child = (Application_TransactionType)ppe(QueryHelpers.Fill<Application_TransactionType>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierTransaction)e).Application_TransactionType = child;
                }

                return child;
            }

            , typeof (Application_TransactionType), preloadEntities);
        }
    }

    public class Purchasing_SupplierTransactionTableQuery<T> : Purchasing_SupplierTransactionQuery<Purchasing_SupplierTransactionTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Purchasing_SupplierTransactionTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Purchasing_SupplierTransactionHelper : QueryHelper<Purchasing_SupplierTransaction>, IHelper<Purchasing_SupplierTransaction>
    {
        string[] columnsInSelectStatement = new[]{"{0}.SupplierTransactionID", "{0}.SupplierID", "{0}.TransactionTypeID", "{0}.PurchaseOrderID", "{0}.PaymentMethodID", "{0}.SupplierInvoiceNumber", "{0}.TransactionDate", "{0}.AmountExcludingTax", "{0}.TaxAmount", "{0}.TransactionAmount", "{0}.OutstandingBalance", "{0}.FinalizationDate", "{0}.IsFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.SupplierTransactionID", "{0}.SupplierID", "{0}.TransactionTypeID", "{0}.PurchaseOrderID", "{0}.PaymentMethodID", "{0}.SupplierInvoiceNumber", "{0}.TransactionDate", "{0}.AmountExcludingTax", "{0}.TaxAmount", "{0}.TransactionAmount", "{0}.OutstandingBalance", "{0}.FinalizationDate", "{0}.IsFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Purchasing_SupplierTransaction ([SupplierTransactionID] Int NOT NULL,[SupplierID] Int NOT NULL,[TransactionTypeID] Int NOT NULL,[PurchaseOrderID] Int,[PaymentMethodID] Int,[SupplierInvoiceNumber] NVarChar(20),[TransactionDate] Date NOT NULL,[AmountExcludingTax] Decimal(18,2) NOT NULL,[TaxAmount] Decimal(18,2) NOT NULL,[TransactionAmount] Decimal(18,2) NOT NULL,[OutstandingBalance] Decimal(18,2) NOT NULL,[FinalizationDate] Date,[IsFinalized] Bit,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Purchasing].[SupplierTransactions]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Purchasing].[SupplierTransactions] ([{TableName = \"Purchasing].[SupplierTransactions\";}].[SupplierTransactionID], [{TableName = \"Purchasing].[SupplierTransactions\";}].[SupplierID], [{TableName = \"Purchasing].[SupplierTransactions\";}].[TransactionTypeID], [{TableName = \"Purchasing].[SupplierTransactions\";}].[PurchaseOrderID], [{TableName = \"Purchasing].[SupplierTransactions\";}].[PaymentMethodID], [{TableName = \"Purchasing].[SupplierTransactions\";}].[SupplierInvoiceNumber], [{TableName = \"Purchasing].[SupplierTransactions\";}].[TransactionDate], [{TableName = \"Purchasing].[SupplierTransactions\";}].[AmountExcludingTax], [{TableName = \"Purchasing].[SupplierTransactions\";}].[TaxAmount], [{TableName = \"Purchasing].[SupplierTransactions\";}].[TransactionAmount], [{TableName = \"Purchasing].[SupplierTransactions\";}].[OutstandingBalance], [{TableName = \"Purchasing].[SupplierTransactions\";}].[FinalizationDate], [{TableName = \"Purchasing].[SupplierTransactions\";}].[IsFinalized], [{TableName = \"Purchasing].[SupplierTransactions\";}].[LastEditedBy], [{TableName = \"Purchasing].[SupplierTransactions\";}].[LastEditedWhen]) VALUES ([@SupplierTransactionID],[@SupplierID],[@TransactionTypeID],[@PurchaseOrderID],[@PaymentMethodID],[@SupplierInvoiceNumber],[@TransactionDate],[@AmountExcludingTax],[@TaxAmount],[@TransactionAmount],[@OutstandingBalance],[@FinalizationDate],[@IsFinalized],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Purchasing_SupplierTransaction _Purchasing_SupplierTransaction)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@SupplierTransactionID", _Purchasing_SupplierTransaction.SupplierTransactionID);
            sqlCommand.Parameters.AddWithValue("@SupplierID", _Purchasing_SupplierTransaction.SupplierID);
            sqlCommand.Parameters.AddWithValue("@TransactionTypeID", _Purchasing_SupplierTransaction.TransactionTypeID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", _Purchasing_SupplierTransaction.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@PaymentMethodID", _Purchasing_SupplierTransaction.PaymentMethodID);
            sqlCommand.Parameters.AddWithValue("@SupplierInvoiceNumber", _Purchasing_SupplierTransaction.SupplierInvoiceNumber ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@TransactionDate", _Purchasing_SupplierTransaction.TransactionDate);
            sqlCommand.Parameters.AddWithValue("@AmountExcludingTax", _Purchasing_SupplierTransaction.AmountExcludingTax);
            sqlCommand.Parameters.AddWithValue("@TaxAmount", _Purchasing_SupplierTransaction.TaxAmount);
            sqlCommand.Parameters.AddWithValue("@TransactionAmount", _Purchasing_SupplierTransaction.TransactionAmount);
            sqlCommand.Parameters.AddWithValue("@OutstandingBalance", _Purchasing_SupplierTransaction.OutstandingBalance);
            sqlCommand.Parameters.AddWithValue("@FinalizationDate", _Purchasing_SupplierTransaction.FinalizationDate);
            sqlCommand.Parameters.AddWithValue("@IsFinalized", _Purchasing_SupplierTransaction.IsFinalized);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Purchasing_SupplierTransaction.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Purchasing_SupplierTransaction.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Purchasing_SupplierTransaction _Purchasing_SupplierTransaction)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Purchasing_SupplierTransaction.SupplierTransactionID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Purchasing_SupplierTransactionWrapper _wrapper = Purchasing_SupplierTransactionWrapper.Instance;
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
    public class Purchasing_SupplierTransactionWrapper : QueryWrapper<Purchasing_SupplierTransaction>
    {
        public readonly QueryElMemberId<Purchasing_Supplier> SupplierID = new QueryElMemberId<Purchasing_Supplier>("SupplierID");
        public readonly QueryElMemberId<Application_TransactionType> TransactionTypeID = new QueryElMemberId<Application_TransactionType>("TransactionTypeID");
        public readonly QueryElMemberId<Purchasing_PurchaseOrder> PurchaseOrderID = new QueryElMemberId<Purchasing_PurchaseOrder>("PurchaseOrderID");
        public readonly QueryElMemberId<Application_PaymentMethod> PaymentMethodID = new QueryElMemberId<Application_PaymentMethod>("PaymentMethodID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> SupplierInvoiceNumber = new QueryElMember<System.String>("SupplierInvoiceNumber");
        public readonly QueryElMemberStruct<System.DateTime> TransactionDate = new QueryElMemberStruct<System.DateTime>("TransactionDate");
        public readonly QueryElMemberStruct<System.Decimal> AmountExcludingTax = new QueryElMemberStruct<System.Decimal>("AmountExcludingTax");
        public readonly QueryElMemberStruct<System.Decimal> TaxAmount = new QueryElMemberStruct<System.Decimal>("TaxAmount");
        public readonly QueryElMemberStruct<System.Decimal> TransactionAmount = new QueryElMemberStruct<System.Decimal>("TransactionAmount");
        public readonly QueryElMemberStruct<System.Decimal> OutstandingBalance = new QueryElMemberStruct<System.Decimal>("OutstandingBalance");
        public readonly QueryElMemberStruct<System.DateTime> FinalizationDate = new QueryElMemberStruct<System.DateTime>("FinalizationDate");
        public readonly QueryElMemberStruct<System.Boolean> IsFinalized = new QueryElMemberStruct<System.Boolean>("IsFinalized");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Purchasing_SupplierTransactionWrapper Instance = new Purchasing_SupplierTransactionWrapper();
        private Purchasing_SupplierTransactionWrapper(): base ("[Purchasing].[SupplierTransactions]", "Purchasing_SupplierTransaction")
        {
        }
    }
}