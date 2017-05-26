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
    public partial class Purchasing_SupplierCategory : DbEntity, IId
    {
        private DbValue<System.Int32> _SupplierCategoryID = new DbValue<System.Int32>();
        private DbValue<System.String> _SupplierCategoryName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers;
        public int Id => SupplierCategoryID;
        long ILongId.Id => SupplierCategoryID;
        [Validate]
        public System.Int32 SupplierCategoryID
        {
            get
            {
                return _SupplierCategoryID.Entity;
            }

            set
            {
                _SupplierCategoryID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String SupplierCategoryName
        {
            get
            {
                return _SupplierCategoryName.Entity;
            }

            set
            {
                _SupplierCategoryName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Purchasing_SupplierCategories.Add(this);
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

                AssignDbEntity<Application_People, Purchasing_SupplierCategory>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Purchasing_SupplierCategories, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Purchasing_Supplier> Purchasing_Suppliers
        {
            get
            {
                if (_Purchasing_Suppliers == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_Suppliers = new DbEntitySetCached<Purchasing_SupplierCategory, Purchasing_Supplier>(() => _SupplierCategoryID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _SupplierCategoryID.Entity}, new[]{"[SupplierCategoryID]"}, (member, root) => member.Purchasing_SupplierCategory = root as Purchasing_SupplierCategory, this, _lazyLoadChildren, e => e.Purchasing_SupplierCategory = this, e =>
                    {
                        var x = e.Purchasing_SupplierCategory;
                        e.Purchasing_SupplierCategory = null;
                        new UpdateSetVisitor(true, new[]{"SupplierCategoryID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _SupplierCategoryID.Load(visitor.GetInt32());
            SendIdChanged();
            _SupplierCategoryName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _SupplierCategoryID.Welcome(visitor, "SupplierCategoryID", "Int NOT NULL", false);
            _SupplierCategoryName.Welcome(visitor, "SupplierCategoryName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers);
        }
    }

    public static class Db_Purchasing_SupplierCategoryQueryGetterExtensions
    {
        public static Purchasing_SupplierCategoryTableQuery<Purchasing_SupplierCategory> Purchasing_SupplierCategories(this IDb db)
        {
            var query = new Purchasing_SupplierCategoryTableQuery<Purchasing_SupplierCategory>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Purchasing_SupplierCategoryQuery<K, T> : Query<K, T, Purchasing_SupplierCategory, Purchasing_SupplierCategoryWrapper, Purchasing_SupplierCategoryQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Purchasing_SupplierCategoryQuery(IDb db): base (db)
        {
        }

        protected sealed override Purchasing_SupplierCategoryWrapper GetWrapper()
        {
            return Purchasing_SupplierCategoryWrapper.Instance;
        }

        public Application_PeopleQuery<Purchasing_SupplierCategoryQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Purchasing_SupplierCategoryQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Purchasing_SupplierCategory)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Purchasing_SupplierCategory)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Purchasing_SupplierQuery<Purchasing_SupplierCategoryQuery<K, T>, T> JoinPurchasing_Suppliers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Purchasing_SupplierCategoryQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[SupplierCategoryID] = {1}.[SupplierCategoryID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Purchasing_SupplierCategory)o).Purchasing_Suppliers.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).SupplierCategoryID, attach);
        }
    }

    public class Purchasing_SupplierCategoryTableQuery<T> : Purchasing_SupplierCategoryQuery<Purchasing_SupplierCategoryTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Purchasing_SupplierCategoryTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Purchasing_SupplierCategoryHelper : QueryHelper<Purchasing_SupplierCategory>, IHelper<Purchasing_SupplierCategory>
    {
        string[] columnsInSelectStatement = new[]{"{0}.SupplierCategoryID", "{0}.SupplierCategoryName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.SupplierCategoryID", "{0}.SupplierCategoryName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Purchasing_SupplierCategory ([SupplierCategoryID] Int NOT NULL,[SupplierCategoryName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Purchasing].[SupplierCategories]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_Supplier);
        }

        private const string insertCommand = "INSERT INTO [Purchasing].[SupplierCategories] ([{TableName = \"Purchasing].[SupplierCategories\";}].[SupplierCategoryID], [{TableName = \"Purchasing].[SupplierCategories\";}].[SupplierCategoryName], [{TableName = \"Purchasing].[SupplierCategories\";}].[LastEditedBy], [{TableName = \"Purchasing].[SupplierCategories\";}].[ValidFrom], [{TableName = \"Purchasing].[SupplierCategories\";}].[ValidTo]) VALUES ([@SupplierCategoryID],[@SupplierCategoryName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Purchasing_SupplierCategory _Purchasing_SupplierCategory)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@SupplierCategoryID", _Purchasing_SupplierCategory.SupplierCategoryID);
            sqlCommand.Parameters.AddWithValue("@SupplierCategoryName", _Purchasing_SupplierCategory.SupplierCategoryName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Purchasing_SupplierCategory.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Purchasing_SupplierCategory.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Purchasing_SupplierCategory.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Purchasing_SupplierCategory _Purchasing_SupplierCategory)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Purchasing_SupplierCategory.SupplierCategoryID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Purchasing_SupplierCategoryWrapper _wrapper = Purchasing_SupplierCategoryWrapper.Instance;
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
    public class Purchasing_SupplierCategoryWrapper : QueryWrapper<Purchasing_SupplierCategory>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> SupplierCategoryName = new QueryElMember<System.String>("SupplierCategoryName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Purchasing_SupplierCategoryWrapper Instance = new Purchasing_SupplierCategoryWrapper();
        private Purchasing_SupplierCategoryWrapper(): base ("[Purchasing].[SupplierCategories]", "Purchasing_SupplierCategory")
        {
        }
    }
}