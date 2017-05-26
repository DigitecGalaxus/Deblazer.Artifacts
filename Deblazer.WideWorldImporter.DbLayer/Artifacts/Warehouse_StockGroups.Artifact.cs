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
    public partial class Warehouse_StockGroup : DbEntity, IId
    {
        private DbValue<System.Int32> _StockGroupID = new DbValue<System.Int32>();
        private DbValue<System.String> _StockGroupName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Sales_SpecialDeal> _Sales_SpecialDeals;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Warehouse_StockItemStockGroup> _Warehouse_StockItemStockGroups;
        public int Id => StockGroupID;
        long ILongId.Id => StockGroupID;
        [Validate]
        public System.Int32 StockGroupID
        {
            get
            {
                return _StockGroupID.Entity;
            }

            set
            {
                _StockGroupID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String StockGroupName
        {
            get
            {
                return _StockGroupName.Entity;
            }

            set
            {
                _StockGroupName.Entity = value;
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
        public IDbEntitySet<Sales_SpecialDeal> Sales_SpecialDeals
        {
            get
            {
                if (_Sales_SpecialDeals == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_SpecialDeals = new DbEntitySetCached<Warehouse_StockGroup, Sales_SpecialDeal>(() => _StockGroupID.Entity);
                    }
                }
                else
                    _Sales_SpecialDeals = new DbEntitySet<Sales_SpecialDeal>(_db, false, new Func<long ? >[]{() => _StockGroupID.Entity}, new[]{"[StockGroupID]"}, (member, root) => member.Warehouse_StockGroup = root as Warehouse_StockGroup, this, _lazyLoadChildren, e => e.Warehouse_StockGroup = this, e =>
                    {
                        var x = e.Warehouse_StockGroup;
                        e.Warehouse_StockGroup = null;
                        new UpdateSetVisitor(true, new[]{"StockGroupID"}, false).Process(x);
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
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_StockGroups.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_StockGroup>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_StockGroups, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
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
                        _Warehouse_StockItemStockGroups = new DbEntitySetCached<Warehouse_StockGroup, Warehouse_StockItemStockGroup>(() => _StockGroupID.Entity);
                    }
                }
                else
                    _Warehouse_StockItemStockGroups = new DbEntitySet<Warehouse_StockItemStockGroup>(_db, false, new Func<long ? >[]{() => _StockGroupID.Entity}, new[]{"[StockGroupID]"}, (member, root) => member.Warehouse_StockGroup = root as Warehouse_StockGroup, this, _lazyLoadChildren, e => e.Warehouse_StockGroup = this, e =>
                    {
                        var x = e.Warehouse_StockGroup;
                        e.Warehouse_StockGroup = null;
                        new UpdateSetVisitor(true, new[]{"StockGroupID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItemStockGroups;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _StockGroupID.Load(visitor.GetInt32());
            SendIdChanged();
            _StockGroupName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StockGroupID.Welcome(visitor, "StockGroupID", "Int NOT NULL", false);
            _StockGroupName.Welcome(visitor, "StockGroupName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Sales_SpecialDeals);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_StockItemStockGroups);
        }
    }

    public static class Db_Warehouse_StockGroupQueryGetterExtensions
    {
        public static Warehouse_StockGroupTableQuery<Warehouse_StockGroup> Warehouse_StockGroups(this IDb db)
        {
            var query = new Warehouse_StockGroupTableQuery<Warehouse_StockGroup>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_StockGroupQuery<K, T> : Query<K, T, Warehouse_StockGroup, Warehouse_StockGroupWrapper, Warehouse_StockGroupQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_StockGroupQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_StockGroupWrapper GetWrapper()
        {
            return Warehouse_StockGroupWrapper.Instance;
        }

        public Sales_SpecialDealQuery<Warehouse_StockGroupQuery<K, T>, T> JoinSales_SpecialDeals(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_SpecialDealQuery<Warehouse_StockGroupQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_SpecialDealTableQuery<Sales_SpecialDeal>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[SpecialDeals] AS {1} {0} ON", "{2}.[StockGroupID] = {1}.[StockGroupID]"), (p, ids) => ((Sales_SpecialDealWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockGroup)o).Sales_SpecialDeals.Attach(v.Cast<Sales_SpecialDeal>()), p => (long)((Sales_SpecialDeal)p).StockGroupID, attach);
        }

        public Application_PeopleQuery<Warehouse_StockGroupQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_StockGroupQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_StockGroup)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockGroup)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockItemStockGroupQuery<Warehouse_StockGroupQuery<K, T>, T> JoinWarehouse_StockItemStockGroups(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemStockGroupQuery<Warehouse_StockGroupQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemStockGroupTableQuery<Warehouse_StockItemStockGroup>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItemStockGroups] AS {1} {0} ON", "{2}.[StockGroupID] = {1}.[StockGroupID]"), (p, ids) => ((Warehouse_StockItemStockGroupWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_StockGroup)o).Warehouse_StockItemStockGroups.Attach(v.Cast<Warehouse_StockItemStockGroup>()), p => (long)((Warehouse_StockItemStockGroup)p).StockGroupID, attach);
        }
    }

    public class Warehouse_StockGroupTableQuery<T> : Warehouse_StockGroupQuery<Warehouse_StockGroupTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_StockGroupTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_StockGroupHelper : QueryHelper<Warehouse_StockGroup>, IHelper<Warehouse_StockGroup>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StockGroupID", "{0}.StockGroupName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StockGroupID", "{0}.StockGroupName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_StockGroup ([StockGroupID] Int NOT NULL,[StockGroupName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[StockGroups]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Sales_SpecialDeal) || other == typeof (Warehouse_StockItemStockGroup);
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[StockGroups] ([{TableName = \"Warehouse].[StockGroups\";}].[StockGroupID], [{TableName = \"Warehouse].[StockGroups\";}].[StockGroupName], [{TableName = \"Warehouse].[StockGroups\";}].[LastEditedBy], [{TableName = \"Warehouse].[StockGroups\";}].[ValidFrom], [{TableName = \"Warehouse].[StockGroups\";}].[ValidTo]) VALUES ([@StockGroupID],[@StockGroupName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_StockGroup _Warehouse_StockGroup)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StockGroupID", _Warehouse_StockGroup.StockGroupID);
            sqlCommand.Parameters.AddWithValue("@StockGroupName", _Warehouse_StockGroup.StockGroupName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_StockGroup.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Warehouse_StockGroup.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Warehouse_StockGroup.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_StockGroup _Warehouse_StockGroup)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_StockGroup.StockGroupID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_StockGroupWrapper _wrapper = Warehouse_StockGroupWrapper.Instance;
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
    public class Warehouse_StockGroupWrapper : QueryWrapper<Warehouse_StockGroup>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> StockGroupName = new QueryElMember<System.String>("StockGroupName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Warehouse_StockGroupWrapper Instance = new Warehouse_StockGroupWrapper();
        private Warehouse_StockGroupWrapper(): base ("[Warehouse].[StockGroups]", "Warehouse_StockGroup")
        {
        }
    }
}