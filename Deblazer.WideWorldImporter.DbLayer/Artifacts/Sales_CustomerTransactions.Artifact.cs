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
    public partial class Sales_CustomerTransaction : DbEntity, IId
    {
        private DbValue<System.Int32> _CustomerTransactionID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _CustomerID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _TransactionTypeID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _InvoiceID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _PaymentMethodID = new DbValue<System.Int32>();
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
        private IDbEntityRef<Sales_Customer> _Sales_Customer;
        private IDbEntityRef<Sales_Invoice> _Sales_Invoice;
        private IDbEntityRef<Application_PaymentMethod> _Application_PaymentMethod;
        private IDbEntityRef<Application_TransactionType> _Application_TransactionType;
        public int Id => CustomerTransactionID;
        long ILongId.Id => CustomerTransactionID;
        [Validate]
        public System.Int32 CustomerTransactionID
        {
            get
            {
                return _CustomerTransactionID.Entity;
            }

            set
            {
                _CustomerTransactionID.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_CustomerTransactions.Add(this);
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

                AssignDbEntity<Application_People, Sales_CustomerTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_CustomerTransactions, null, LastEditedByChanged);
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
                Action<Sales_Customer> beforeRightsCheckAction = e => e.Sales_CustomerTransactions.Add(this);
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

                AssignDbEntity<Sales_Customer, Sales_CustomerTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CustomerID}, _Sales_Customer, new long ? []{_CustomerID.Entity}, new Action<long ? >[]{x => CustomerID = (int ? )x ?? default (int)}, x => x.Sales_CustomerTransactions, null, CustomerIDChanged);
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
                Action<Sales_Invoice> beforeRightsCheckAction = e => e.Sales_CustomerTransactions.Add(this);
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

                AssignDbEntity<Sales_Invoice, Sales_CustomerTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.InvoiceID}, _Sales_Invoice, new long ? []{_InvoiceID.Entity}, new Action<long ? >[]{x => InvoiceID = (int ? )x ?? default (int)}, x => x.Sales_CustomerTransactions, null, InvoiceIDChanged);
            }
        }

        void InvoiceIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Sales_Invoice)
                _InvoiceID.Entity = (int)((Sales_Invoice)sender).Id;
        }

        [Validate]
        public Application_PaymentMethod Application_PaymentMethod
        {
            get
            {
                Action<Application_PaymentMethod> beforeRightsCheckAction = e => e.Sales_CustomerTransactions.Add(this);
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

                AssignDbEntity<Application_PaymentMethod, Sales_CustomerTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PaymentMethodID}, _Application_PaymentMethod, new long ? []{_PaymentMethodID.Entity}, new Action<long ? >[]{x => PaymentMethodID = (int ? )x ?? default (int)}, x => x.Sales_CustomerTransactions, null, PaymentMethodIDChanged);
            }
        }

        void PaymentMethodIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_PaymentMethod)
                _PaymentMethodID.Entity = (int)((Application_PaymentMethod)sender).Id;
        }

        [Validate]
        public Application_TransactionType Application_TransactionType
        {
            get
            {
                Action<Application_TransactionType> beforeRightsCheckAction = e => e.Sales_CustomerTransactions.Add(this);
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

                AssignDbEntity<Application_TransactionType, Sales_CustomerTransaction>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.TransactionTypeID}, _Application_TransactionType, new long ? []{_TransactionTypeID.Entity}, new Action<long ? >[]{x => TransactionTypeID = (int ? )x ?? default (int)}, x => x.Sales_CustomerTransactions, null, TransactionTypeIDChanged);
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
            _CustomerTransactionID.Load(visitor.GetInt32());
            SendIdChanged();
            _CustomerID.Load(visitor.GetInt32());
            _TransactionTypeID.Load(visitor.GetInt32());
            _InvoiceID.Load(visitor.GetInt32());
            _PaymentMethodID.Load(visitor.GetInt32());
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
            _CustomerTransactionID.Welcome(visitor, "CustomerTransactionID", "Int NOT NULL", false);
            _CustomerID.Welcome(visitor, "CustomerID", "Int NOT NULL", false);
            _TransactionTypeID.Welcome(visitor, "TransactionTypeID", "Int NOT NULL", false);
            _InvoiceID.Welcome(visitor, "InvoiceID", "Int", false);
            _PaymentMethodID.Welcome(visitor, "PaymentMethodID", "Int", false);
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
            visitor.ProcessAssociation(this, _Sales_Customer);
            visitor.ProcessAssociation(this, _Sales_Invoice);
            visitor.ProcessAssociation(this, _Application_PaymentMethod);
            visitor.ProcessAssociation(this, _Application_TransactionType);
        }
    }

    public static class Db_Sales_CustomerTransactionQueryGetterExtensions
    {
        public static Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction> Sales_CustomerTransactions(this IDb db)
        {
            var query = new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_CustomerTransactionQuery<K, T> : Query<K, T, Sales_CustomerTransaction, Sales_CustomerTransactionWrapper, Sales_CustomerTransactionQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_CustomerTransactionQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_CustomerTransactionWrapper GetWrapper()
        {
            return Sales_CustomerTransactionWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_CustomerTransactionQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_CustomerTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_CustomerTransaction)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerTransaction)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_CustomerTransactionQuery<K, T>, T> JoinSales_Customer(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_CustomerTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerID] = {1}.[CustomerID]"), o => ((Sales_CustomerTransaction)o)?.Sales_Customer, (e, fv, ppe) =>
            {
                var child = (Sales_Customer)ppe(QueryHelpers.Fill<Sales_Customer>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerTransaction)e).Sales_Customer = child;
                }

                return child;
            }

            , typeof (Sales_Customer), preloadEntities);
        }

        public Sales_InvoiceQuery<Sales_CustomerTransactionQuery<K, T>, T> JoinSales_Invoice(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Sales_CustomerTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[InvoiceID] = {1}.[InvoiceID]"), o => ((Sales_CustomerTransaction)o)?.Sales_Invoice, (e, fv, ppe) =>
            {
                var child = (Sales_Invoice)ppe(QueryHelpers.Fill<Sales_Invoice>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerTransaction)e).Sales_Invoice = child;
                }

                return child;
            }

            , typeof (Sales_Invoice), preloadEntities);
        }

        public Application_PaymentMethodQuery<Sales_CustomerTransactionQuery<K, T>, T> JoinApplication_PaymentMethod(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PaymentMethodQuery<Sales_CustomerTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[PaymentMethods] AS {1} {0} ON", "{2}.[PaymentMethodID] = {1}.[PaymentMethodID]"), o => ((Sales_CustomerTransaction)o)?.Application_PaymentMethod, (e, fv, ppe) =>
            {
                var child = (Application_PaymentMethod)ppe(QueryHelpers.Fill<Application_PaymentMethod>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerTransaction)e).Application_PaymentMethod = child;
                }

                return child;
            }

            , typeof (Application_PaymentMethod), preloadEntities);
        }

        public Application_TransactionTypeQuery<Sales_CustomerTransactionQuery<K, T>, T> JoinApplication_TransactionType(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_TransactionTypeQuery<Sales_CustomerTransactionQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[TransactionTypes] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), o => ((Sales_CustomerTransaction)o)?.Application_TransactionType, (e, fv, ppe) =>
            {
                var child = (Application_TransactionType)ppe(QueryHelpers.Fill<Application_TransactionType>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerTransaction)e).Application_TransactionType = child;
                }

                return child;
            }

            , typeof (Application_TransactionType), preloadEntities);
        }
    }

    public class Sales_CustomerTransactionTableQuery<T> : Sales_CustomerTransactionQuery<Sales_CustomerTransactionTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_CustomerTransactionTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_CustomerTransactionHelper : QueryHelper<Sales_CustomerTransaction>, IHelper<Sales_CustomerTransaction>
    {
        string[] columnsInSelectStatement = new[]{"{0}.CustomerTransactionID", "{0}.CustomerID", "{0}.TransactionTypeID", "{0}.InvoiceID", "{0}.PaymentMethodID", "{0}.TransactionDate", "{0}.AmountExcludingTax", "{0}.TaxAmount", "{0}.TransactionAmount", "{0}.OutstandingBalance", "{0}.FinalizationDate", "{0}.IsFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.CustomerTransactionID", "{0}.CustomerID", "{0}.TransactionTypeID", "{0}.InvoiceID", "{0}.PaymentMethodID", "{0}.TransactionDate", "{0}.AmountExcludingTax", "{0}.TaxAmount", "{0}.TransactionAmount", "{0}.OutstandingBalance", "{0}.FinalizationDate", "{0}.IsFinalized", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_CustomerTransaction ([CustomerTransactionID] Int NOT NULL,[CustomerID] Int NOT NULL,[TransactionTypeID] Int NOT NULL,[InvoiceID] Int,[PaymentMethodID] Int,[TransactionDate] Date NOT NULL,[AmountExcludingTax] Decimal(18,2) NOT NULL,[TaxAmount] Decimal(18,2) NOT NULL,[TransactionAmount] Decimal(18,2) NOT NULL,[OutstandingBalance] Decimal(18,2) NOT NULL,[FinalizationDate] Date,[IsFinalized] Bit,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[CustomerTransactions]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Sales].[CustomerTransactions] ([{TableName = \"Sales].[CustomerTransactions\";}].[CustomerTransactionID], [{TableName = \"Sales].[CustomerTransactions\";}].[CustomerID], [{TableName = \"Sales].[CustomerTransactions\";}].[TransactionTypeID], [{TableName = \"Sales].[CustomerTransactions\";}].[InvoiceID], [{TableName = \"Sales].[CustomerTransactions\";}].[PaymentMethodID], [{TableName = \"Sales].[CustomerTransactions\";}].[TransactionDate], [{TableName = \"Sales].[CustomerTransactions\";}].[AmountExcludingTax], [{TableName = \"Sales].[CustomerTransactions\";}].[TaxAmount], [{TableName = \"Sales].[CustomerTransactions\";}].[TransactionAmount], [{TableName = \"Sales].[CustomerTransactions\";}].[OutstandingBalance], [{TableName = \"Sales].[CustomerTransactions\";}].[FinalizationDate], [{TableName = \"Sales].[CustomerTransactions\";}].[IsFinalized], [{TableName = \"Sales].[CustomerTransactions\";}].[LastEditedBy], [{TableName = \"Sales].[CustomerTransactions\";}].[LastEditedWhen]) VALUES ([@CustomerTransactionID],[@CustomerID],[@TransactionTypeID],[@InvoiceID],[@PaymentMethodID],[@TransactionDate],[@AmountExcludingTax],[@TaxAmount],[@TransactionAmount],[@OutstandingBalance],[@FinalizationDate],[@IsFinalized],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_CustomerTransaction _Sales_CustomerTransaction)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@CustomerTransactionID", _Sales_CustomerTransaction.CustomerTransactionID);
            sqlCommand.Parameters.AddWithValue("@CustomerID", _Sales_CustomerTransaction.CustomerID);
            sqlCommand.Parameters.AddWithValue("@TransactionTypeID", _Sales_CustomerTransaction.TransactionTypeID);
            sqlCommand.Parameters.AddWithValue("@InvoiceID", _Sales_CustomerTransaction.InvoiceID);
            sqlCommand.Parameters.AddWithValue("@PaymentMethodID", _Sales_CustomerTransaction.PaymentMethodID);
            sqlCommand.Parameters.AddWithValue("@TransactionDate", _Sales_CustomerTransaction.TransactionDate);
            sqlCommand.Parameters.AddWithValue("@AmountExcludingTax", _Sales_CustomerTransaction.AmountExcludingTax);
            sqlCommand.Parameters.AddWithValue("@TaxAmount", _Sales_CustomerTransaction.TaxAmount);
            sqlCommand.Parameters.AddWithValue("@TransactionAmount", _Sales_CustomerTransaction.TransactionAmount);
            sqlCommand.Parameters.AddWithValue("@OutstandingBalance", _Sales_CustomerTransaction.OutstandingBalance);
            sqlCommand.Parameters.AddWithValue("@FinalizationDate", _Sales_CustomerTransaction.FinalizationDate);
            sqlCommand.Parameters.AddWithValue("@IsFinalized", _Sales_CustomerTransaction.IsFinalized);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_CustomerTransaction.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Sales_CustomerTransaction.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_CustomerTransaction _Sales_CustomerTransaction)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_CustomerTransaction.CustomerTransactionID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_CustomerTransactionWrapper _wrapper = Sales_CustomerTransactionWrapper.Instance;
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
    public class Sales_CustomerTransactionWrapper : QueryWrapper<Sales_CustomerTransaction>
    {
        public readonly QueryElMemberId<Sales_Customer> CustomerID = new QueryElMemberId<Sales_Customer>("CustomerID");
        public readonly QueryElMemberId<Application_TransactionType> TransactionTypeID = new QueryElMemberId<Application_TransactionType>("TransactionTypeID");
        public readonly QueryElMemberId<Sales_Invoice> InvoiceID = new QueryElMemberId<Sales_Invoice>("InvoiceID");
        public readonly QueryElMemberId<Application_PaymentMethod> PaymentMethodID = new QueryElMemberId<Application_PaymentMethod>("PaymentMethodID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> TransactionDate = new QueryElMemberStruct<System.DateTime>("TransactionDate");
        public readonly QueryElMemberStruct<System.Decimal> AmountExcludingTax = new QueryElMemberStruct<System.Decimal>("AmountExcludingTax");
        public readonly QueryElMemberStruct<System.Decimal> TaxAmount = new QueryElMemberStruct<System.Decimal>("TaxAmount");
        public readonly QueryElMemberStruct<System.Decimal> TransactionAmount = new QueryElMemberStruct<System.Decimal>("TransactionAmount");
        public readonly QueryElMemberStruct<System.Decimal> OutstandingBalance = new QueryElMemberStruct<System.Decimal>("OutstandingBalance");
        public readonly QueryElMemberStruct<System.DateTime> FinalizationDate = new QueryElMemberStruct<System.DateTime>("FinalizationDate");
        public readonly QueryElMemberStruct<System.Boolean> IsFinalized = new QueryElMemberStruct<System.Boolean>("IsFinalized");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Sales_CustomerTransactionWrapper Instance = new Sales_CustomerTransactionWrapper();
        private Sales_CustomerTransactionWrapper(): base ("[Sales].[CustomerTransactions]", "Sales_CustomerTransaction")
        {
        }
    }
}