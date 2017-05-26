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
    public partial class Warehouse_StockItemStockGroup : DbEntity, IId
    {
        private DbValue<System.Int32> _StockItemStockGroupID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockItemID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _StockGroupID = new DbValue<System.Int32>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Warehouse_StockGroup> _Warehouse_StockGroup;
        private IDbEntityRef<Warehouse_StockItem> _Warehouse_StockItem;
        public int Id => StockItemStockGroupID;
        long ILongId.Id => StockItemStockGroupID;
        [Validate]
        public System.Int32 StockItemStockGroupID
        {
            get
            {
                return _StockItemStockGroupID.Entity;
            }

            set
            {
                _StockItemStockGroupID.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_StockItemStockGroups.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_StockItemStockGroup>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemStockGroups, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Warehouse_StockGroup Warehouse_StockGroup
        {
            get
            {
                Action<Warehouse_StockGroup> beforeRightsCheckAction = e => e.Warehouse_StockItemStockGroups.Add(this);
                if (_Warehouse_StockGroup != null)
                {
                    return _Warehouse_StockGroup.GetEntity(beforeRightsCheckAction);
                }

                _Warehouse_StockGroup = GetDbEntityRef(true, new[]{"[StockGroupID]"}, new Func<long ? >[]{() => _StockGroupID.Entity}, beforeRightsCheckAction);
                return (Warehouse_StockGroup != null) ? _Warehouse_StockGroup.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Warehouse_StockGroup == null)
                {
                    _Warehouse_StockGroup = new DbEntityRef<Warehouse_StockGroup>(_db, true, new[]{"[StockGroupID]"}, new Func<long ? >[]{() => _StockGroupID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Warehouse_StockGroup, Warehouse_StockItemStockGroup>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockGroupID}, _Warehouse_StockGroup, new long ? []{_StockGroupID.Entity}, new Action<long ? >[]{x => StockGroupID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemStockGroups, null, StockGroupIDChanged);
            }
        }

        void StockGroupIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Warehouse_StockGroup)
                _StockGroupID.Entity = (int)((Warehouse_StockGroup)sender).Id;
        }

        [Validate]
        public Warehouse_StockItem Warehouse_StockItem
        {
            get
            {
                Action<Warehouse_StockItem> beforeRightsCheckAction = e => e.Warehouse_StockItemStockGroups.Add(this);
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

                AssignDbEntity<Warehouse_StockItem, Warehouse_StockItemStockGroup>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StockItemID}, _Warehouse_StockItem, new long ? []{_StockItemID.Entity}, new Action<long ? >[]{x => StockItemID = (int ? )x ?? default (int)}, x => x.Warehouse_StockItemStockGroups, null, StockItemIDChanged);
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
            _StockItemStockGroupID.Load(visitor.GetInt32());
            SendIdChanged();
            _StockItemID.Load(visitor.GetInt32());
            _StockGroupID.Load(visitor.GetInt32());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StockItemStockGroupID.Welcome(visitor, "StockItemStockGroupID", "Int NOT NULL", false);
            _StockItemID.Welcome(visitor, "StockItemID", "Int NOT NULL", false);
            _StockGroupID.Welcome(visitor, "StockGroupID", "Int NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_StockGroup);
            visitor.ProcessAssociation(this, _Warehouse_StockItem);
        }
    }

    public static class Db_Warehouse_StockItemStockGroupQueryGetterExtensions
    {
        public static Warehouse_StockItemStockGroupTableQuery<Warehouse_StockItemStockGroup> Warehouse_StockItemStockGroups(this IDb db)
        {
            var query = new Warehouse_StockItemStockGroupTableQuery<Warehouse_StockItemStockGroup>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_StockItemStockGroupQuery<K, T> : Query<K, T, Warehouse_StockItemStockGroup, Warehouse_StockItemStockGroupWrapper, Warehouse_StockItemStockGroupQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_StockItemStockGroupQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_StockItemStockGroupWrapper GetWrapper()
        {
            return Warehouse_StockItemStockGroupWrapper.Instance;
        }

        public Application_PeopleQuery<Warehouse_StockItemStockGroupQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_StockItemStockGroupQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_StockItemStockGroup)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemStockGroup)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockGroupQuery<Warehouse_StockItemStockGroupQuery<K, T>, T> JoinWarehouse_StockGroup(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockGroupQuery<Warehouse_StockItemStockGroupQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockGroups] AS {1} {0} ON", "{2}.[StockGroupID] = {1}.[StockGroupID]"), o => ((Warehouse_StockItemStockGroup)o)?.Warehouse_StockGroup, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockGroup)ppe(QueryHelpers.Fill<Warehouse_StockGroup>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemStockGroup)e).Warehouse_StockGroup = child;
                }

                return child;
            }

            , typeof (Warehouse_StockGroup), preloadEntities);
        }

        public Warehouse_StockItemQuery<Warehouse_StockItemStockGroupQuery<K, T>, T> JoinWarehouse_StockItem(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_StockItemStockGroupQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[StockItemID] = {1}.[StockItemID]"), o => ((Warehouse_StockItemStockGroup)o)?.Warehouse_StockItem, (e, fv, ppe) =>
            {
                var child = (Warehouse_StockItem)ppe(QueryHelpers.Fill<Warehouse_StockItem>(null, fv));
                if (e != null)
                {
                    ((Warehouse_StockItemStockGroup)e).Warehouse_StockItem = child;
                }

                return child;
            }

            , typeof (Warehouse_StockItem), preloadEntities);
        }
    }

    public class Warehouse_StockItemStockGroupTableQuery<T> : Warehouse_StockItemStockGroupQuery<Warehouse_StockItemStockGroupTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_StockItemStockGroupTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_StockItemStockGroupHelper : QueryHelper<Warehouse_StockItemStockGroup>, IHelper<Warehouse_StockItemStockGroup>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StockItemStockGroupID", "{0}.StockItemID", "{0}.StockGroupID", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StockItemStockGroupID", "{0}.StockItemID", "{0}.StockGroupID", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_StockItemStockGroup ([StockItemStockGroupID] Int NOT NULL,[StockItemID] Int NOT NULL,[StockGroupID] Int NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[StockItemStockGroups]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[StockItemStockGroups] ([{TableName = \"Warehouse].[StockItemStockGroups\";}].[StockItemStockGroupID], [{TableName = \"Warehouse].[StockItemStockGroups\";}].[StockItemID], [{TableName = \"Warehouse].[StockItemStockGroups\";}].[StockGroupID], [{TableName = \"Warehouse].[StockItemStockGroups\";}].[LastEditedBy], [{TableName = \"Warehouse].[StockItemStockGroups\";}].[LastEditedWhen]) VALUES ([@StockItemStockGroupID],[@StockItemID],[@StockGroupID],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemStockGroup _Warehouse_StockItemStockGroup)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StockItemStockGroupID", _Warehouse_StockItemStockGroup.StockItemStockGroupID);
            sqlCommand.Parameters.AddWithValue("@StockItemID", _Warehouse_StockItemStockGroup.StockItemID);
            sqlCommand.Parameters.AddWithValue("@StockGroupID", _Warehouse_StockItemStockGroup.StockGroupID);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_StockItemStockGroup.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Warehouse_StockItemStockGroup.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_StockItemStockGroup _Warehouse_StockItemStockGroup)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_StockItemStockGroup.StockItemStockGroupID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_StockItemStockGroupWrapper _wrapper = Warehouse_StockItemStockGroupWrapper.Instance;
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
    public class Warehouse_StockItemStockGroupWrapper : QueryWrapper<Warehouse_StockItemStockGroup>
    {
        public readonly QueryElMemberId<Warehouse_StockItem> StockItemID = new QueryElMemberId<Warehouse_StockItem>("StockItemID");
        public readonly QueryElMemberId<Warehouse_StockGroup> StockGroupID = new QueryElMemberId<Warehouse_StockGroup>("StockGroupID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Warehouse_StockItemStockGroupWrapper Instance = new Warehouse_StockItemStockGroupWrapper();
        private Warehouse_StockItemStockGroupWrapper(): base ("[Warehouse].[StockItemStockGroups]", "Warehouse_StockItemStockGroup")
        {
        }
    }
}