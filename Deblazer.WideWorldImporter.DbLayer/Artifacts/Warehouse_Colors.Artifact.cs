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
    public partial class Warehouse_Color : DbEntity, IId
    {
        private DbValue<System.Int32> _ColorID = new DbValue<System.Int32>();
        private DbValue<System.String> _ColorName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Warehouse_StockItem> _Warehouse_StockItems;
        public int Id => ColorID;
        long ILongId.Id => ColorID;
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

        [StringColumn(20, false)]
        [Validate]
        public System.String ColorName
        {
            get
            {
                return _ColorName.Entity;
            }

            set
            {
                _ColorName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_Colors.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_Color>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_Colors, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItem> Warehouse_StockItems
        {
            get
            {
                if (_Warehouse_StockItems == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Warehouse_StockItems = new DbEntitySetCached<Warehouse_Color, Warehouse_StockItem>(() => _ColorID.Entity);
                    }
                }
                else
                    _Warehouse_StockItems = new DbEntitySet<Warehouse_StockItem>(_db, false, new Func<long ? >[]{() => _ColorID.Entity}, new[]{"[ColorID]"}, (member, root) => member.Warehouse_Color = root as Warehouse_Color, this, _lazyLoadChildren, e => e.Warehouse_Color = this, e =>
                    {
                        var x = e.Warehouse_Color;
                        e.Warehouse_Color = null;
                        new UpdateSetVisitor(true, new[]{"ColorID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItems;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _ColorID.Load(visitor.GetInt32());
            SendIdChanged();
            _ColorName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _ColorID.Welcome(visitor, "ColorID", "Int NOT NULL", false);
            _ColorName.Welcome(visitor, "ColorName", "NVarChar(20) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_StockItems);
        }
    }

    public static class Db_Warehouse_ColorQueryGetterExtensions
    {
        public static Warehouse_ColorTableQuery<Warehouse_Color> Warehouse_Colors(this IDb db)
        {
            var query = new Warehouse_ColorTableQuery<Warehouse_Color>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_ColorQuery<K, T> : Query<K, T, Warehouse_Color, Warehouse_ColorWrapper, Warehouse_ColorQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_ColorQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_ColorWrapper GetWrapper()
        {
            return Warehouse_ColorWrapper.Instance;
        }

        public Application_PeopleQuery<Warehouse_ColorQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_ColorQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_Color)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_Color)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockItemQuery<Warehouse_ColorQuery<K, T>, T> JoinWarehouse_StockItems(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_ColorQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTableQuery<Warehouse_StockItem>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[ColorID] = {1}.[ColorID]"), (p, ids) => ((Warehouse_StockItemWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_Color)o).Warehouse_StockItems.Attach(v.Cast<Warehouse_StockItem>()), p => (long)((Warehouse_StockItem)p).ColorID, attach);
        }
    }

    public class Warehouse_ColorTableQuery<T> : Warehouse_ColorQuery<Warehouse_ColorTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_ColorTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_ColorHelper : QueryHelper<Warehouse_Color>, IHelper<Warehouse_Color>
    {
        string[] columnsInSelectStatement = new[]{"{0}.ColorID", "{0}.ColorName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.ColorID", "{0}.ColorName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_Color ([ColorID] Int NOT NULL,[ColorName] NVarChar(20) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[Colors]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Warehouse_StockItem);
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[Colors] ([{TableName = \"Warehouse].[Colors\";}].[ColorID], [{TableName = \"Warehouse].[Colors\";}].[ColorName], [{TableName = \"Warehouse].[Colors\";}].[LastEditedBy], [{TableName = \"Warehouse].[Colors\";}].[ValidFrom], [{TableName = \"Warehouse].[Colors\";}].[ValidTo]) VALUES ([@ColorID],[@ColorName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_Color _Warehouse_Color)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@ColorID", _Warehouse_Color.ColorID);
            sqlCommand.Parameters.AddWithValue("@ColorName", _Warehouse_Color.ColorName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_Color.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Warehouse_Color.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Warehouse_Color.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_Color _Warehouse_Color)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_Color.ColorID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_ColorWrapper _wrapper = Warehouse_ColorWrapper.Instance;
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
    public class Warehouse_ColorWrapper : QueryWrapper<Warehouse_Color>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> ColorName = new QueryElMember<System.String>("ColorName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Warehouse_ColorWrapper Instance = new Warehouse_ColorWrapper();
        private Warehouse_ColorWrapper(): base ("[Warehouse].[Colors]", "Warehouse_Color")
        {
        }
    }
}