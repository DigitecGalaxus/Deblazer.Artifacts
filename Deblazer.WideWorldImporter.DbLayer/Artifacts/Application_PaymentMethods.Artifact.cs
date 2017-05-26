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
    public partial class Application_PaymentMethod : DbEntity, IId
    {
        private DbValue<System.Int32> _PaymentMethodID = new DbValue<System.Int32>();
        private DbValue<System.String> _PaymentMethodName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Purchasing_SupplierTransaction> _Purchasing_SupplierTransactions;
        private IDbEntitySet<Sales_CustomerTransaction> _Sales_CustomerTransactions;
        public int Id => PaymentMethodID;
        long ILongId.Id => PaymentMethodID;
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

        [StringColumn(50, false)]
        [Validate]
        public System.String PaymentMethodName
        {
            get
            {
                return _PaymentMethodName.Entity;
            }

            set
            {
                _PaymentMethodName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Application_PaymentMethods.Add(this);
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

                AssignDbEntity<Application_People, Application_PaymentMethod>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_PaymentMethods, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
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
                        _Purchasing_SupplierTransactions = new DbEntitySetCached<Application_PaymentMethod, Purchasing_SupplierTransaction>(() => _PaymentMethodID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierTransactions = new DbEntitySet<Purchasing_SupplierTransaction>(_db, false, new Func<long ? >[]{() => _PaymentMethodID.Entity}, new[]{"[PaymentMethodID]"}, (member, root) => member.Application_PaymentMethod = root as Application_PaymentMethod, this, _lazyLoadChildren, e => e.Application_PaymentMethod = this, e =>
                    {
                        var x = e.Application_PaymentMethod;
                        e.Application_PaymentMethod = null;
                        new UpdateSetVisitor(true, new[]{"PaymentMethodID"}, false).Process(x);
                    }

                    );
                return _Purchasing_SupplierTransactions;
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
                        _Sales_CustomerTransactions = new DbEntitySetCached<Application_PaymentMethod, Sales_CustomerTransaction>(() => _PaymentMethodID.Entity);
                    }
                }
                else
                    _Sales_CustomerTransactions = new DbEntitySet<Sales_CustomerTransaction>(_db, false, new Func<long ? >[]{() => _PaymentMethodID.Entity}, new[]{"[PaymentMethodID]"}, (member, root) => member.Application_PaymentMethod = root as Application_PaymentMethod, this, _lazyLoadChildren, e => e.Application_PaymentMethod = this, e =>
                    {
                        var x = e.Application_PaymentMethod;
                        e.Application_PaymentMethod = null;
                        new UpdateSetVisitor(true, new[]{"PaymentMethodID"}, false).Process(x);
                    }

                    );
                return _Sales_CustomerTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _PaymentMethodID.Load(visitor.GetInt32());
            SendIdChanged();
            _PaymentMethodName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _PaymentMethodID.Welcome(visitor, "PaymentMethodID", "Int NOT NULL", false);
            _PaymentMethodName.Welcome(visitor, "PaymentMethodName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Purchasing_SupplierTransactions);
            visitor.ProcessAssociation(this, _Sales_CustomerTransactions);
        }
    }

    public static class Db_Application_PaymentMethodQueryGetterExtensions
    {
        public static Application_PaymentMethodTableQuery<Application_PaymentMethod> Application_PaymentMethods(this IDb db)
        {
            var query = new Application_PaymentMethodTableQuery<Application_PaymentMethod>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_PaymentMethodQuery<K, T> : Query<K, T, Application_PaymentMethod, Application_PaymentMethodWrapper, Application_PaymentMethodQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_PaymentMethodQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_PaymentMethodWrapper GetWrapper()
        {
            return Application_PaymentMethodWrapper.Instance;
        }

        public Application_PeopleQuery<Application_PaymentMethodQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_PaymentMethodQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_PaymentMethod)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_PaymentMethod)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Purchasing_SupplierTransactionQuery<Application_PaymentMethodQuery<K, T>, T> JoinPurchasing_SupplierTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierTransactionQuery<Application_PaymentMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierTransactions] AS {1} {0} ON", "{2}.[PaymentMethodID] = {1}.[PaymentMethodID]"), (p, ids) => ((Purchasing_SupplierTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_PaymentMethod)o).Purchasing_SupplierTransactions.Attach(v.Cast<Purchasing_SupplierTransaction>()), p => (long)((Purchasing_SupplierTransaction)p).PaymentMethodID, attach);
        }

        public Sales_CustomerTransactionQuery<Application_PaymentMethodQuery<K, T>, T> JoinSales_CustomerTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerTransactionQuery<Application_PaymentMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerTransactions] AS {1} {0} ON", "{2}.[PaymentMethodID] = {1}.[PaymentMethodID]"), (p, ids) => ((Sales_CustomerTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_PaymentMethod)o).Sales_CustomerTransactions.Attach(v.Cast<Sales_CustomerTransaction>()), p => (long)((Sales_CustomerTransaction)p).PaymentMethodID, attach);
        }
    }

    public class Application_PaymentMethodTableQuery<T> : Application_PaymentMethodQuery<Application_PaymentMethodTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_PaymentMethodTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_PaymentMethodHelper : QueryHelper<Application_PaymentMethod>, IHelper<Application_PaymentMethod>
    {
        string[] columnsInSelectStatement = new[]{"{0}.PaymentMethodID", "{0}.PaymentMethodName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.PaymentMethodID", "{0}.PaymentMethodName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_PaymentMethod ([PaymentMethodID] Int NOT NULL,[PaymentMethodName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[PaymentMethods]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_SupplierTransaction) || other == typeof (Sales_CustomerTransaction);
        }

        private const string insertCommand = "INSERT INTO [Application].[PaymentMethods] ([{TableName = \"Application].[PaymentMethods\";}].[PaymentMethodID], [{TableName = \"Application].[PaymentMethods\";}].[PaymentMethodName], [{TableName = \"Application].[PaymentMethods\";}].[LastEditedBy], [{TableName = \"Application].[PaymentMethods\";}].[ValidFrom], [{TableName = \"Application].[PaymentMethods\";}].[ValidTo]) VALUES ([@PaymentMethodID],[@PaymentMethodName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_PaymentMethod _Application_PaymentMethod)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@PaymentMethodID", _Application_PaymentMethod.PaymentMethodID);
            sqlCommand.Parameters.AddWithValue("@PaymentMethodName", _Application_PaymentMethod.PaymentMethodName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_PaymentMethod.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_PaymentMethod.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_PaymentMethod.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_PaymentMethod _Application_PaymentMethod)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_PaymentMethod.PaymentMethodID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_PaymentMethodWrapper _wrapper = Application_PaymentMethodWrapper.Instance;
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
    public class Application_PaymentMethodWrapper : QueryWrapper<Application_PaymentMethod>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> PaymentMethodName = new QueryElMember<System.String>("PaymentMethodName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_PaymentMethodWrapper Instance = new Application_PaymentMethodWrapper();
        private Application_PaymentMethodWrapper(): base ("[Application].[PaymentMethods]", "Application_PaymentMethod")
        {
        }
    }
}