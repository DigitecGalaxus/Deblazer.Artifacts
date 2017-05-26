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
    public partial class Application_TransactionType : DbEntity, IId
    {
        private DbValue<System.Int32> _TransactionTypeID = new DbValue<System.Int32>();
        private DbValue<System.String> _TransactionTypeName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Purchasing_SupplierTransaction> _Purchasing_SupplierTransactions;
        private IDbEntitySet<Sales_CustomerTransaction> _Sales_CustomerTransactions;
        private IDbEntitySet<Warehouse_StockItemTransaction> _Warehouse_StockItemTransactions;
        public int Id => TransactionTypeID;
        long ILongId.Id => TransactionTypeID;
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

        [StringColumn(50, false)]
        [Validate]
        public System.String TransactionTypeName
        {
            get
            {
                return _TransactionTypeName.Entity;
            }

            set
            {
                _TransactionTypeName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Application_TransactionTypes.Add(this);
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

                AssignDbEntity<Application_People, Application_TransactionType>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_TransactionTypes, null, LastEditedByChanged);
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
                        _Purchasing_SupplierTransactions = new DbEntitySetCached<Application_TransactionType, Purchasing_SupplierTransaction>(() => _TransactionTypeID.Entity);
                    }
                }
                else
                    _Purchasing_SupplierTransactions = new DbEntitySet<Purchasing_SupplierTransaction>(_db, false, new Func<long ? >[]{() => _TransactionTypeID.Entity}, new[]{"[TransactionTypeID]"}, (member, root) => member.Application_TransactionType = root as Application_TransactionType, this, _lazyLoadChildren, e => e.Application_TransactionType = this, e =>
                    {
                        var x = e.Application_TransactionType;
                        e.Application_TransactionType = null;
                        new UpdateSetVisitor(true, new[]{"TransactionTypeID"}, false).Process(x);
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
                        _Sales_CustomerTransactions = new DbEntitySetCached<Application_TransactionType, Sales_CustomerTransaction>(() => _TransactionTypeID.Entity);
                    }
                }
                else
                    _Sales_CustomerTransactions = new DbEntitySet<Sales_CustomerTransaction>(_db, false, new Func<long ? >[]{() => _TransactionTypeID.Entity}, new[]{"[TransactionTypeID]"}, (member, root) => member.Application_TransactionType = root as Application_TransactionType, this, _lazyLoadChildren, e => e.Application_TransactionType = this, e =>
                    {
                        var x = e.Application_TransactionType;
                        e.Application_TransactionType = null;
                        new UpdateSetVisitor(true, new[]{"TransactionTypeID"}, false).Process(x);
                    }

                    );
                return _Sales_CustomerTransactions;
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
                        _Warehouse_StockItemTransactions = new DbEntitySetCached<Application_TransactionType, Warehouse_StockItemTransaction>(() => _TransactionTypeID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemTransactions = new DbEntitySet<Warehouse_StockItemTransaction>(_db, false, new Func<long ? >[]{() => _TransactionTypeID.Entity}, new[]{"[TransactionTypeID]"}, (member, root) => member.Application_TransactionType = root as Application_TransactionType, this, _lazyLoadChildren, e => e.Application_TransactionType = this, e =>
                    {
                        var x = e.Application_TransactionType;
                        e.Application_TransactionType = null;
                        new UpdateSetVisitor(true, new[]{"TransactionTypeID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemTransactions;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _TransactionTypeID.Load(visitor.GetInt32());
            SendIdChanged();
            _TransactionTypeName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _TransactionTypeID.Welcome(visitor, "TransactionTypeID", "Int NOT NULL", false);
            _TransactionTypeName.Welcome(visitor, "TransactionTypeName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Purchasing_SupplierTransactions);
            visitor.ProcessAssociation(this, _Sales_CustomerTransactions);
            visitor.ProcessAssociation(this, _Warehouse_StockItemTransactions);
        }
    }

    public static class Db_Application_TransactionTypeQueryGetterExtensions
    {
        public static Application_TransactionTypeTableQuery<Application_TransactionType> Application_TransactionTypes(this IDb db)
        {
            var query = new Application_TransactionTypeTableQuery<Application_TransactionType>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_TransactionTypeQuery<K, T> : Query<K, T, Application_TransactionType, Application_TransactionTypeWrapper, Application_TransactionTypeQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_TransactionTypeQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_TransactionTypeWrapper GetWrapper()
        {
            return Application_TransactionTypeWrapper.Instance;
        }

        public Application_PeopleQuery<Application_TransactionTypeQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_TransactionTypeQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_TransactionType)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_TransactionType)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Purchasing_SupplierTransactionQuery<Application_TransactionTypeQuery<K, T>, T> JoinPurchasing_SupplierTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierTransactionQuery<Application_TransactionTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTransactionTableQuery<Purchasing_SupplierTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[SupplierTransactions] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), (p, ids) => ((Purchasing_SupplierTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_TransactionType)o).Purchasing_SupplierTransactions.Attach(v.Cast<Purchasing_SupplierTransaction>()), p => (long)((Purchasing_SupplierTransaction)p).TransactionTypeID, attach);
        }

        public Sales_CustomerTransactionQuery<Application_TransactionTypeQuery<K, T>, T> JoinSales_CustomerTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerTransactionQuery<Application_TransactionTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTransactionTableQuery<Sales_CustomerTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[CustomerTransactions] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), (p, ids) => ((Sales_CustomerTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_TransactionType)o).Sales_CustomerTransactions.Attach(v.Cast<Sales_CustomerTransaction>()), p => (long)((Sales_CustomerTransaction)p).TransactionTypeID, attach);
        }

        public Warehouse_StockItemTransactionQuery<Application_TransactionTypeQuery<K, T>, T> JoinWarehouse_StockItemTransactions(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemTransactionQuery<Application_TransactionTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTransactionTableQuery<Warehouse_StockItemTransaction>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemTransactions] AS {1} {0} ON", "{2}.[TransactionTypeID] = {1}.[TransactionTypeID]"), (p, ids) => ((Warehouse_StockItemTransactionWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_TransactionType)o).Warehouse_StockItemTransactions.Attach(v.Cast<Warehouse_StockItemTransaction>()), p => (long)((Warehouse_StockItemTransaction)p).TransactionTypeID, attach);
        }
    }

    public class Application_TransactionTypeTableQuery<T> : Application_TransactionTypeQuery<Application_TransactionTypeTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_TransactionTypeTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_TransactionTypeHelper : QueryHelper<Application_TransactionType>, IHelper<Application_TransactionType>
    {
        string[] columnsInSelectStatement = new[]{"{0}.TransactionTypeID", "{0}.TransactionTypeName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.TransactionTypeID", "{0}.TransactionTypeName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_TransactionType ([TransactionTypeID] Int NOT NULL,[TransactionTypeName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[TransactionTypes]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_SupplierTransaction) || other == typeof (Sales_CustomerTransaction) || other == typeof (Warehouse_StockItemTransaction);
        }

        private const string insertCommand = "INSERT INTO [Application].[TransactionTypes] ([{TableName = \"Application].[TransactionTypes\";}].[TransactionTypeID], [{TableName = \"Application].[TransactionTypes\";}].[TransactionTypeName], [{TableName = \"Application].[TransactionTypes\";}].[LastEditedBy], [{TableName = \"Application].[TransactionTypes\";}].[ValidFrom], [{TableName = \"Application].[TransactionTypes\";}].[ValidTo]) VALUES ([@TransactionTypeID],[@TransactionTypeName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_TransactionType _Application_TransactionType)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@TransactionTypeID", _Application_TransactionType.TransactionTypeID);
            sqlCommand.Parameters.AddWithValue("@TransactionTypeName", _Application_TransactionType.TransactionTypeName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_TransactionType.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_TransactionType.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_TransactionType.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_TransactionType _Application_TransactionType)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_TransactionType.TransactionTypeID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_TransactionTypeWrapper _wrapper = Application_TransactionTypeWrapper.Instance;
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
    public class Application_TransactionTypeWrapper : QueryWrapper<Application_TransactionType>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> TransactionTypeName = new QueryElMember<System.String>("TransactionTypeName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_TransactionTypeWrapper Instance = new Application_TransactionTypeWrapper();
        private Application_TransactionTypeWrapper(): base ("[Application].[TransactionTypes]", "Application_TransactionType")
        {
        }
    }
}