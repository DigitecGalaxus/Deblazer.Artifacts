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
    public partial class Application_StateProvince : DbEntity, IId
    {
        private DbValue<System.Int32> _StateProvinceID = new DbValue<System.Int32>();
        private DbValue<System.String> _StateProvinceCode = new DbValue<System.String>();
        private DbValue<System.String> _StateProvinceName = new DbValue<System.String>();
        private DbValue<System.Int32> _CountryID = new DbValue<System.Int32>();
        private DbValue<System.String> _SalesTerritory = new DbValue<System.String>();
        private DbValue<System.Int64> _LatestRecordedPopulation = new DbValue<System.Int64>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Application_City> _Application_Cities;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_Country> _Application_Country;
        public int Id => StateProvinceID;
        long ILongId.Id => StateProvinceID;
        [Validate]
        public System.Int32 StateProvinceID
        {
            get
            {
                return _StateProvinceID.Entity;
            }

            set
            {
                _StateProvinceID.Entity = value;
            }
        }

        [StringColumn(5, false)]
        [Validate]
        public System.String StateProvinceCode
        {
            get
            {
                return _StateProvinceCode.Entity;
            }

            set
            {
                _StateProvinceCode.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String StateProvinceName
        {
            get
            {
                return _StateProvinceName.Entity;
            }

            set
            {
                _StateProvinceName.Entity = value;
            }
        }

        [Validate]
        public System.Int32 CountryID
        {
            get
            {
                return _CountryID.Entity;
            }

            set
            {
                _CountryID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String SalesTerritory
        {
            get
            {
                return _SalesTerritory.Entity;
            }

            set
            {
                _SalesTerritory.Entity = value;
            }
        }

        [Validate]
        public System.Int64 LatestRecordedPopulation
        {
            get
            {
                return _LatestRecordedPopulation.Entity;
            }

            set
            {
                _LatestRecordedPopulation.Entity = value;
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
        public IDbEntitySet<Application_City> Application_Cities
        {
            get
            {
                if (_Application_Cities == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_Cities = new DbEntitySetCached<Application_StateProvince, Application_City>(() => _StateProvinceID.Entity);
                    }
                }
                else
                    _Application_Cities = new DbEntitySet<Application_City>(_db, false, new Func<long ? >[]{() => _StateProvinceID.Entity}, new[]{"[StateProvinceID]"}, (member, root) => member.Application_StateProvince = root as Application_StateProvince, this, _lazyLoadChildren, e => e.Application_StateProvince = this, e =>
                    {
                        var x = e.Application_StateProvince;
                        e.Application_StateProvince = null;
                        new UpdateSetVisitor(true, new[]{"StateProvinceID"}, false).Process(x);
                    }

                    );
                return _Application_Cities;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Application_StateProvinces.Add(this);
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

                AssignDbEntity<Application_People, Application_StateProvince>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_StateProvinces, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_Country Application_Country
        {
            get
            {
                Action<Application_Country> beforeRightsCheckAction = e => e.Application_StateProvinces.Add(this);
                if (_Application_Country != null)
                {
                    return _Application_Country.GetEntity(beforeRightsCheckAction);
                }

                _Application_Country = GetDbEntityRef(true, new[]{"[CountryID]"}, new Func<long ? >[]{() => _CountryID.Entity}, beforeRightsCheckAction);
                return (Application_Country != null) ? _Application_Country.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_Country == null)
                {
                    _Application_Country = new DbEntityRef<Application_Country>(_db, true, new[]{"[CountryID]"}, new Func<long ? >[]{() => _CountryID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_Country, Application_StateProvince>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CountryID}, _Application_Country, new long ? []{_CountryID.Entity}, new Action<long ? >[]{x => CountryID = (int ? )x ?? default (int)}, x => x.Application_StateProvinces, null, CountryIDChanged);
            }
        }

        void CountryIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_Country)
                _CountryID.Entity = (int)((Application_Country)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _StateProvinceID.Load(visitor.GetInt32());
            SendIdChanged();
            _StateProvinceCode.Load(visitor.GetValue<System.String>());
            _StateProvinceName.Load(visitor.GetValue<System.String>());
            _CountryID.Load(visitor.GetInt32());
            _SalesTerritory.Load(visitor.GetValue<System.String>());
            _LatestRecordedPopulation.Load(visitor.GetValue<System.Int64>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _StateProvinceID.Welcome(visitor, "StateProvinceID", "Int NOT NULL", false);
            _StateProvinceCode.Welcome(visitor, "StateProvinceCode", "NVarChar(5) NOT NULL", false);
            _StateProvinceName.Welcome(visitor, "StateProvinceName", "NVarChar(50) NOT NULL", false);
            _CountryID.Welcome(visitor, "CountryID", "Int NOT NULL", false);
            _SalesTerritory.Welcome(visitor, "SalesTerritory", "NVarChar(50) NOT NULL", false);
            _LatestRecordedPopulation.Welcome(visitor, "LatestRecordedPopulation", "BigInt", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_Cities);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Application_Country);
        }
    }

    public static class Db_Application_StateProvinceQueryGetterExtensions
    {
        public static Application_StateProvinceTableQuery<Application_StateProvince> Application_StateProvinces(this IDb db)
        {
            var query = new Application_StateProvinceTableQuery<Application_StateProvince>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_StateProvinceQuery<K, T> : Query<K, T, Application_StateProvince, Application_StateProvinceWrapper, Application_StateProvinceQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_StateProvinceQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_StateProvinceWrapper GetWrapper()
        {
            return Application_StateProvinceWrapper.Instance;
        }

        public Application_CityQuery<Application_StateProvinceQuery<K, T>, T> JoinApplication_Cities(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_CityQuery<Application_StateProvinceQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_CityTableQuery<Application_City>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[StateProvinceID] = {1}.[StateProvinceID]"), (p, ids) => ((Application_CityWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_StateProvince)o).Application_Cities.Attach(v.Cast<Application_City>()), p => (long)((Application_City)p).StateProvinceID, attach);
        }

        public Application_PeopleQuery<Application_StateProvinceQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_StateProvinceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_StateProvince)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_StateProvince)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_CountryQuery<Application_StateProvinceQuery<K, T>, T> JoinApplication_Country(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CountryQuery<Application_StateProvinceQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Countries] AS {1} {0} ON", "{2}.[CountryID] = {1}.[CountryID]"), o => ((Application_StateProvince)o)?.Application_Country, (e, fv, ppe) =>
            {
                var child = (Application_Country)ppe(QueryHelpers.Fill<Application_Country>(null, fv));
                if (e != null)
                {
                    ((Application_StateProvince)e).Application_Country = child;
                }

                return child;
            }

            , typeof (Application_Country), preloadEntities);
        }
    }

    public class Application_StateProvinceTableQuery<T> : Application_StateProvinceQuery<Application_StateProvinceTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_StateProvinceTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_StateProvinceHelper : QueryHelper<Application_StateProvince>, IHelper<Application_StateProvince>
    {
        string[] columnsInSelectStatement = new[]{"{0}.StateProvinceID", "{0}.StateProvinceCode", "{0}.StateProvinceName", "{0}.CountryID", "{0}.SalesTerritory", "{0}.LatestRecordedPopulation", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.StateProvinceID", "{0}.StateProvinceCode", "{0}.StateProvinceName", "{0}.CountryID", "{0}.SalesTerritory", "{0}.LatestRecordedPopulation", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_StateProvince ([StateProvinceID] Int NOT NULL,[StateProvinceCode] NVarChar(5) NOT NULL,[StateProvinceName] NVarChar(50) NOT NULL,[CountryID] Int NOT NULL,[SalesTerritory] NVarChar(50) NOT NULL,[LatestRecordedPopulation] BigInt,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[StateProvinces]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Application_City);
        }

        private const string insertCommand = "INSERT INTO [Application].[StateProvinces] ([{TableName = \"Application].[StateProvinces\";}].[StateProvinceID], [{TableName = \"Application].[StateProvinces\";}].[StateProvinceCode], [{TableName = \"Application].[StateProvinces\";}].[StateProvinceName], [{TableName = \"Application].[StateProvinces\";}].[CountryID], [{TableName = \"Application].[StateProvinces\";}].[SalesTerritory], [{TableName = \"Application].[StateProvinces\";}].[LatestRecordedPopulation], [{TableName = \"Application].[StateProvinces\";}].[LastEditedBy], [{TableName = \"Application].[StateProvinces\";}].[ValidFrom], [{TableName = \"Application].[StateProvinces\";}].[ValidTo]) VALUES ([@StateProvinceID],[@StateProvinceCode],[@StateProvinceName],[@CountryID],[@SalesTerritory],[@LatestRecordedPopulation],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_StateProvince _Application_StateProvince)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", _Application_StateProvince.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@StateProvinceCode", _Application_StateProvince.StateProvinceCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@StateProvinceName", _Application_StateProvince.StateProvinceName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@CountryID", _Application_StateProvince.CountryID);
            sqlCommand.Parameters.AddWithValue("@SalesTerritory", _Application_StateProvince.SalesTerritory ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LatestRecordedPopulation", _Application_StateProvince.LatestRecordedPopulation);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_StateProvince.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_StateProvince.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_StateProvince.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_StateProvince _Application_StateProvince)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_StateProvince.StateProvinceID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_StateProvinceWrapper _wrapper = Application_StateProvinceWrapper.Instance;
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
    public class Application_StateProvinceWrapper : QueryWrapper<Application_StateProvince>
    {
        public readonly QueryElMemberId<Application_Country> CountryID = new QueryElMemberId<Application_Country>("CountryID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> StateProvinceCode = new QueryElMember<System.String>("StateProvinceCode");
        public readonly QueryElMember<System.String> StateProvinceName = new QueryElMember<System.String>("StateProvinceName");
        public readonly QueryElMember<System.String> SalesTerritory = new QueryElMember<System.String>("SalesTerritory");
        public readonly QueryElMemberStruct<System.Int64> LatestRecordedPopulation = new QueryElMemberStruct<System.Int64>("LatestRecordedPopulation");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_StateProvinceWrapper Instance = new Application_StateProvinceWrapper();
        private Application_StateProvinceWrapper(): base ("[Application].[StateProvinces]", "Application_StateProvince")
        {
        }
    }
}