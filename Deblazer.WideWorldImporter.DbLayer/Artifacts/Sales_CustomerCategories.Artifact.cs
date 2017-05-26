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
    public partial class Sales_CustomerCategory : DbEntity, IId
    {
        private DbValue<System.Int32> _CustomerCategoryID = new DbValue<System.Int32>();
        private DbValue<System.String> _CustomerCategoryName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Sales_Customer> _Sales_Customers;
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        public int Id => CustomerCategoryID;
        long ILongId.Id => CustomerCategoryID;
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

        [StringColumn(50, false)]
        [Validate]
        public System.String CustomerCategoryName
        {
            get
            {
                return _CustomerCategoryName.Entity;
            }

            set
            {
                _CustomerCategoryName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_CustomerCategories.Add(this);
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

                AssignDbEntity<Application_People, Sales_CustomerCategory>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_CustomerCategories, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
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
                        _Sales_Customers = new DbEntitySetCached<Sales_CustomerCategory, Sales_Customer>(() => _CustomerCategoryID.Entity);
                    }
                }
                else
                    _Sales_Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _CustomerCategoryID.Entity}, new[]{"[CustomerCategoryID]"}, (member, root) => member.Sales_CustomerCategory = root as Sales_CustomerCategory, this, _lazyLoadChildren, e => e.Sales_CustomerCategory = this, e =>
                    {
                        var x = e.Sales_CustomerCategory;
                        e.Sales_CustomerCategory = null;
                        new UpdateSetVisitor(true, new[]{"CustomerCategoryID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers;
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
                        _Sales_SpecialDeals = new DbEntitySetCached<Sales_CustomerCategory, Sales_SpecialDeal>(() => _CustomerCategoryID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _CustomerCategoryID.Entity}, new[]{"[CustomerCategoryID]"}, (member, root) => member.Sales_CustomerCategory = root as Sales_CustomerCategory, this, _lazyLoadChildren, e => e.Sales_CustomerCategory = this, e =>
                    {
                        var x = e.Sales_CustomerCategory;
                        e.Sales_CustomerCategory = null;
                        new UpdateSetVisitor(true, new[]{"CustomerCategoryID"}, false).Process(x);
                    }

                    );
                return _Sales_SpecialDeals;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _CustomerCategoryID.Load(visitor.GetInt32());
            SendIdChanged();
            _CustomerCategoryName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _CustomerCategoryID.Welcome(visitor, "CustomerCategoryID", "Int NOT NULL", false);
            _CustomerCategoryName.Welcome(visitor, "CustomerCategoryName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Sales_Customers);
            visitor.ProcessAssociation(this, _Sales_SpecialDeals);
        }
    }

    public static class Db_Sales_CustomerCategoryQueryGetterExtensions
    {
        public static Sales_CustomerCategoryTableQuery<Sales_CustomerCategory> Sales_CustomerCategories(this IDb db)
        {
            var query = new Sales_CustomerCategoryTableQuery<Sales_CustomerCategory>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_CustomerCategoryQuery<K, T> : Query<K, T, Sales_CustomerCategory, Sales_CustomerCategoryWrapper, Sales_CustomerCategoryQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_CustomerCategoryQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_CustomerCategoryWrapper GetWrapper()
        {
            return Sales_CustomerCategoryWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_CustomerCategoryQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_CustomerCategoryQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_CustomerCategory)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_CustomerCategory)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_CustomerCategoryQuery<K, T>, T> JoinSales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_CustomerCategoryQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CustomerCategoryID] = {1}.[CustomerCategoryID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_CustomerCategory)o).Sales_Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).CustomerCategoryID, attach);
        }

        public Sales_SpecialDealQuery<Sales_CustomerCategoryQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Sales_CustomerCategoryQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[CustomerCategoryID] = {1}.[CustomerCategoryID]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_CustomerCategory)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).CustomerCategoryID, attach);
        }
    }

    public class Sales_CustomerCategoryTableQuery<T> : Sales_CustomerCategoryQuery<Sales_CustomerCategoryTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_CustomerCategoryTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_CustomerCategoryHelper : QueryHelper<Sales_CustomerCategory>, IHelper<Sales_CustomerCategory>
    {
        string[] columnsInSelectStatement = new[]{"{0}.CustomerCategoryID", "{0}.CustomerCategoryName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.CustomerCategoryID", "{0}.CustomerCategoryName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_CustomerCategory ([CustomerCategoryID] Int NOT NULL,[CustomerCategoryName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[CustomerCategories]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_Customer) || other == typeof (Sales_SpecialDeal);
        }

        private const string insertCommand = "INSERT INTO [Sales].[CustomerCategories] ([{TableName = \"Sales].[CustomerCategories\";}].[CustomerCategoryID], [{TableName = \"Sales].[CustomerCategories\";}].[CustomerCategoryName], [{TableName = \"Sales].[CustomerCategories\";}].[LastEditedBy], [{TableName = \"Sales].[CustomerCategories\";}].[ValidFrom], [{TableName = \"Sales].[CustomerCategories\";}].[ValidTo]) VALUES ([@CustomerCategoryID],[@CustomerCategoryName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_CustomerCategory _Sales_CustomerCategory)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@CustomerCategoryID", _Sales_CustomerCategory.CustomerCategoryID);
            sqlCommand.Parameters.AddWithValue("@CustomerCategoryName", _Sales_CustomerCategory.CustomerCategoryName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_CustomerCategory.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Sales_CustomerCategory.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Sales_CustomerCategory.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_CustomerCategory _Sales_CustomerCategory)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_CustomerCategory.CustomerCategoryID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_CustomerCategoryWrapper _wrapper = Sales_CustomerCategoryWrapper.Instance;
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
    public class Sales_CustomerCategoryWrapper : QueryWrapper<Sales_CustomerCategory>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> CustomerCategoryName = new QueryElMember<System.String>("CustomerCategoryName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Sales_CustomerCategoryWrapper Instance = new Sales_CustomerCategoryWrapper();
        private Sales_CustomerCategoryWrapper(): base ("[Sales].[CustomerCategories]", "Sales_CustomerCategory")
        {
        }
    }
}