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
    public partial class Sales_BuyingGroup : DbEntity, IId
    {
        private DbValue<System.Int32> _BuyingGroupID = new DbValue<System.Int32>();
        private DbValue<System.String> _BuyingGroupName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Sales_Customer> _Sales_Customers;
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        public int Id => BuyingGroupID;
        long ILongId.Id => BuyingGroupID;
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

        [StringColumn(50, false)]
        [Validate]
        public System.String BuyingGroupName
        {
            get
            {
                return _BuyingGroupName.Entity;
            }

            set
            {
                _BuyingGroupName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Sales_BuyingGroups.Add(this);
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

                AssignDbEntity<Application_People, Sales_BuyingGroup>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Sales_BuyingGroups, null, LastEditedByChanged);
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
                        _Sales_Customers = new DbEntitySetCached<Sales_BuyingGroup, Sales_Customer>(() => _BuyingGroupID.Entity);
                    }
                }
                else
                    _Sales_Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _BuyingGroupID.Entity}, new[]{"[BuyingGroupID]"}, (member, root) => member.Sales_BuyingGroup = root as Sales_BuyingGroup, this, _lazyLoadChildren, e => e.Sales_BuyingGroup = this, e =>
                    {
                        var x = e.Sales_BuyingGroup;
                        e.Sales_BuyingGroup = null;
                        new UpdateSetVisitor(true, new[]{"BuyingGroupID"}, false).Process(x);
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
                        _Sales_SpecialDeals = new DbEntitySetCached<Sales_BuyingGroup, Sales_SpecialDeal>(() => _BuyingGroupID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _BuyingGroupID.Entity}, new[]{"[BuyingGroupID]"}, (member, root) => member.Sales_BuyingGroup = root as Sales_BuyingGroup, this, _lazyLoadChildren, e => e.Sales_BuyingGroup = this, e =>
                    {
                        var x = e.Sales_BuyingGroup;
                        e.Sales_BuyingGroup = null;
                        new UpdateSetVisitor(true, new[]{"BuyingGroupID"}, false).Process(x);
                    }

                    );
                return _Sales_SpecialDeals;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _BuyingGroupID.Load(visitor.GetInt32());
            SendIdChanged();
            _BuyingGroupName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _BuyingGroupID.Welcome(visitor, "BuyingGroupID", "Int NOT NULL", false);
            _BuyingGroupName.Welcome(visitor, "BuyingGroupName", "NVarChar(50) NOT NULL", false);
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

    public static class Db_Sales_BuyingGroupQueryGetterExtensions
    {
        public static Sales_BuyingGroupTableQuery<Sales_BuyingGroup> Sales_BuyingGroups(this IDb db)
        {
            var query = new Sales_BuyingGroupTableQuery<Sales_BuyingGroup>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Sales_BuyingGroupQuery<K, T> : Query<K, T, Sales_BuyingGroup, Sales_BuyingGroupWrapper, Sales_BuyingGroupQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Sales_BuyingGroupQuery(IDb db): base (db)
        {
        }

        protected sealed override Sales_BuyingGroupWrapper GetWrapper()
        {
            return Sales_BuyingGroupWrapper.Instance;
        }

        public Application_PeopleQuery<Sales_BuyingGroupQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Sales_BuyingGroupQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Sales_BuyingGroup)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Sales_BuyingGroup)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Sales_CustomerQuery<Sales_BuyingGroupQuery<K, T>, T> JoinSales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Sales_BuyingGroupQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[BuyingGroupID] = {1}.[BuyingGroupID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_BuyingGroup)o).Sales_Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).BuyingGroupID, attach);
        }

        public Sales_SpecialDealQuery<Sales_BuyingGroupQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Sales_BuyingGroupQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[BuyingGroupID] = {1}.[BuyingGroupID]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Sales_BuyingGroup)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).BuyingGroupID, attach);
        }
    }

    public class Sales_BuyingGroupTableQuery<T> : Sales_BuyingGroupQuery<Sales_BuyingGroupTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Sales_BuyingGroupTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Sales_BuyingGroupHelper : QueryHelper<Sales_BuyingGroup>, IHelper<Sales_BuyingGroup>
    {
        string[] columnsInSelectStatement = new[]{"{0}.BuyingGroupID", "{0}.BuyingGroupName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.BuyingGroupID", "{0}.BuyingGroupName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Sales_BuyingGroup ([BuyingGroupID] Int NOT NULL,[BuyingGroupName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Sales].[BuyingGroups]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_Customer) || other == typeof (Sales_SpecialDeal);
        }

        private const string insertCommand = "INSERT INTO [Sales].[BuyingGroups] ([{TableName = \"Sales].[BuyingGroups\";}].[BuyingGroupID], [{TableName = \"Sales].[BuyingGroups\";}].[BuyingGroupName], [{TableName = \"Sales].[BuyingGroups\";}].[LastEditedBy], [{TableName = \"Sales].[BuyingGroups\";}].[ValidFrom], [{TableName = \"Sales].[BuyingGroups\";}].[ValidTo]) VALUES ([@BuyingGroupID],[@BuyingGroupName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Sales_BuyingGroup _Sales_BuyingGroup)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@BuyingGroupID", _Sales_BuyingGroup.BuyingGroupID);
            sqlCommand.Parameters.AddWithValue("@BuyingGroupName", _Sales_BuyingGroup.BuyingGroupName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Sales_BuyingGroup.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Sales_BuyingGroup.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Sales_BuyingGroup.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Sales_BuyingGroup _Sales_BuyingGroup)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Sales_BuyingGroup.BuyingGroupID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Sales_BuyingGroupWrapper _wrapper = Sales_BuyingGroupWrapper.Instance;
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
    public class Sales_BuyingGroupWrapper : QueryWrapper<Sales_BuyingGroup>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> BuyingGroupName = new QueryElMember<System.String>("BuyingGroupName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Sales_BuyingGroupWrapper Instance = new Sales_BuyingGroupWrapper();
        private Sales_BuyingGroupWrapper(): base ("[Sales].[BuyingGroups]", "Sales_BuyingGroup")
        {
        }
    }
}