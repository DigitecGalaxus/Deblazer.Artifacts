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
    public partial class Application_Country : DbEntity, IId
    {
        private DbValue<System.Int32> _CountryID = new DbValue<System.Int32>();
        private DbValue<System.String> _CountryName = new DbValue<System.String>();
        private DbValue<System.String> _FormalName = new DbValue<System.String>();
        private DbValue<System.String> _IsoAlpha3Code = new DbValue<System.String>();
        private DbValue<System.Int32> _IsoNumericCode = new DbValue<System.Int32>();
        private DbValue<System.String> _CountryType = new DbValue<System.String>();
        private DbValue<System.Int64> _LatestRecordedPopulation = new DbValue<System.Int64>();
        private DbValue<System.String> _Continent = new DbValue<System.String>();
        private DbValue<System.String> _Region = new DbValue<System.String>();
        private DbValue<System.String> _Subregion = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Application_StateProvince> _Application_StateProvinces;
        public int Id => CountryID;
        long ILongId.Id => CountryID;
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

        [StringColumn(60, false)]
        [Validate]
        public System.String CountryName
        {
            get
            {
                return _CountryName.Entity;
            }

            set
            {
                _CountryName.Entity = value;
            }
        }

        [StringColumn(60, false)]
        [Validate]
        public System.String FormalName
        {
            get
            {
                return _FormalName.Entity;
            }

            set
            {
                _FormalName.Entity = value;
            }
        }

        [StringColumn(3, true)]
        [Validate]
        public System.String IsoAlpha3Code
        {
            get
            {
                return _IsoAlpha3Code.Entity;
            }

            set
            {
                _IsoAlpha3Code.Entity = value;
            }
        }

        [Validate]
        public System.Int32 IsoNumericCode
        {
            get
            {
                return _IsoNumericCode.Entity;
            }

            set
            {
                _IsoNumericCode.Entity = value;
            }
        }

        [StringColumn(20, true)]
        [Validate]
        public System.String CountryType
        {
            get
            {
                return _CountryType.Entity;
            }

            set
            {
                _CountryType.Entity = value;
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

        [StringColumn(30, false)]
        [Validate]
        public System.String Continent
        {
            get
            {
                return _Continent.Entity;
            }

            set
            {
                _Continent.Entity = value;
            }
        }

        [StringColumn(30, false)]
        [Validate]
        public System.String Region
        {
            get
            {
                return _Region.Entity;
            }

            set
            {
                _Region.Entity = value;
            }
        }

        [StringColumn(30, false)]
        [Validate]
        public System.String Subregion
        {
            get
            {
                return _Subregion.Entity;
            }

            set
            {
                _Subregion.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Application_Countries.Add(this);
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

                AssignDbEntity<Application_People, Application_Country>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_Countries, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Application_StateProvince> Application_StateProvinces
        {
            get
            {
                if (_Application_StateProvinces == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_StateProvinces = new DbEntitySetCached<Application_Country, Application_StateProvince>(() => _CountryID.Entity);
                    }
                }
                else
                    _Application_StateProvinces = new DbEntitySet<Application_StateProvince>(_db, false, new Func<long ? >[]{() => _CountryID.Entity}, new[]{"[CountryID]"}, (member, root) => member.Application_Country = root as Application_Country, this, _lazyLoadChildren, e => e.Application_Country = this, e =>
                    {
                        var x = e.Application_Country;
                        e.Application_Country = null;
                        new UpdateSetVisitor(true, new[]{"CountryID"}, false).Process(x);
                    }

                    );
                return _Application_StateProvinces;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _CountryID.Load(visitor.GetInt32());
            SendIdChanged();
            _CountryName.Load(visitor.GetValue<System.String>());
            _FormalName.Load(visitor.GetValue<System.String>());
            _IsoAlpha3Code.Load(visitor.GetValue<System.String>());
            _IsoNumericCode.Load(visitor.GetInt32());
            _CountryType.Load(visitor.GetValue<System.String>());
            _LatestRecordedPopulation.Load(visitor.GetValue<System.Int64>());
            _Continent.Load(visitor.GetValue<System.String>());
            _Region.Load(visitor.GetValue<System.String>());
            _Subregion.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _CountryID.Welcome(visitor, "CountryID", "Int NOT NULL", false);
            _CountryName.Welcome(visitor, "CountryName", "NVarChar(60) NOT NULL", false);
            _FormalName.Welcome(visitor, "FormalName", "NVarChar(60) NOT NULL", false);
            _IsoAlpha3Code.Welcome(visitor, "IsoAlpha3Code", "NVarChar(3)", false);
            _IsoNumericCode.Welcome(visitor, "IsoNumericCode", "Int", false);
            _CountryType.Welcome(visitor, "CountryType", "NVarChar(20)", false);
            _LatestRecordedPopulation.Welcome(visitor, "LatestRecordedPopulation", "BigInt", false);
            _Continent.Welcome(visitor, "Continent", "NVarChar(30) NOT NULL", false);
            _Region.Welcome(visitor, "Region", "NVarChar(30) NOT NULL", false);
            _Subregion.Welcome(visitor, "Subregion", "NVarChar(30) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Application_StateProvinces);
        }
    }

    public static class Db_Application_CountryQueryGetterExtensions
    {
        public static Application_CountryTableQuery<Application_Country> Application_Countries(this IDb db)
        {
            var query = new Application_CountryTableQuery<Application_Country>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_CountryQuery<K, T> : Query<K, T, Application_Country, Application_CountryWrapper, Application_CountryQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_CountryQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_CountryWrapper GetWrapper()
        {
            return Application_CountryWrapper.Instance;
        }

        public Application_PeopleQuery<Application_CountryQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_CountryQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_Country)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_Country)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_StateProvinceQuery<Application_CountryQuery<K, T>, T> JoinApplication_StateProvinces(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_StateProvinceQuery<Application_CountryQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_StateProvinceTableQuery<Application_StateProvince>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[StateProvinces] AS {1} {0} ON", "{2}.[CountryID] = {1}.[CountryID]"), (p, ids) => ((Application_StateProvinceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_Country)o).Application_StateProvinces.Attach(v.Cast<Application_StateProvince>()), p => (long)((Application_StateProvince)p).CountryID, attach);
        }
    }

    public class Application_CountryTableQuery<T> : Application_CountryQuery<Application_CountryTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_CountryTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_CountryHelper : QueryHelper<Application_Country>, IHelper<Application_Country>
    {
        string[] columnsInSelectStatement = new[]{"{0}.CountryID", "{0}.CountryName", "{0}.FormalName", "{0}.IsoAlpha3Code", "{0}.IsoNumericCode", "{0}.CountryType", "{0}.LatestRecordedPopulation", "{0}.Continent", "{0}.Region", "{0}.Subregion", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.CountryID", "{0}.CountryName", "{0}.FormalName", "{0}.IsoAlpha3Code", "{0}.IsoNumericCode", "{0}.CountryType", "{0}.LatestRecordedPopulation", "{0}.Continent", "{0}.Region", "{0}.Subregion", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_Country ([CountryID] Int NOT NULL,[CountryName] NVarChar(60) NOT NULL,[FormalName] NVarChar(60) NOT NULL,[IsoAlpha3Code] NVarChar(3),[IsoNumericCode] Int,[CountryType] NVarChar(20),[LatestRecordedPopulation] BigInt,[Continent] NVarChar(30) NOT NULL,[Region] NVarChar(30) NOT NULL,[Subregion] NVarChar(30) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[Countries]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Application_StateProvince);
        }

        private const string insertCommand = "INSERT INTO [Application].[Countries] ([{TableName = \"Application].[Countries\";}].[CountryID], [{TableName = \"Application].[Countries\";}].[CountryName], [{TableName = \"Application].[Countries\";}].[FormalName], [{TableName = \"Application].[Countries\";}].[IsoAlpha3Code], [{TableName = \"Application].[Countries\";}].[IsoNumericCode], [{TableName = \"Application].[Countries\";}].[CountryType], [{TableName = \"Application].[Countries\";}].[LatestRecordedPopulation], [{TableName = \"Application].[Countries\";}].[Continent], [{TableName = \"Application].[Countries\";}].[Region], [{TableName = \"Application].[Countries\";}].[Subregion], [{TableName = \"Application].[Countries\";}].[LastEditedBy], [{TableName = \"Application].[Countries\";}].[ValidFrom], [{TableName = \"Application].[Countries\";}].[ValidTo]) VALUES ([@CountryID],[@CountryName],[@FormalName],[@IsoAlpha3Code],[@IsoNumericCode],[@CountryType],[@LatestRecordedPopulation],[@Continent],[@Region],[@Subregion],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_Country _Application_Country)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@CountryID", _Application_Country.CountryID);
            sqlCommand.Parameters.AddWithValue("@CountryName", _Application_Country.CountryName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@FormalName", _Application_Country.FormalName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsoAlpha3Code", _Application_Country.IsoAlpha3Code ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@IsoNumericCode", _Application_Country.IsoNumericCode);
            sqlCommand.Parameters.AddWithValue("@CountryType", _Application_Country.CountryType ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LatestRecordedPopulation", _Application_Country.LatestRecordedPopulation);
            sqlCommand.Parameters.AddWithValue("@Continent", _Application_Country.Continent ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Region", _Application_Country.Region ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Subregion", _Application_Country.Subregion ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_Country.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_Country.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_Country.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_Country _Application_Country)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_Country.CountryID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_CountryWrapper _wrapper = Application_CountryWrapper.Instance;
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
    public class Application_CountryWrapper : QueryWrapper<Application_Country>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> CountryName = new QueryElMember<System.String>("CountryName");
        public readonly QueryElMember<System.String> FormalName = new QueryElMember<System.String>("FormalName");
        public readonly QueryElMember<System.String> IsoAlpha3Code = new QueryElMember<System.String>("IsoAlpha3Code");
        public readonly QueryElMemberStruct<System.Int32> IsoNumericCode = new QueryElMemberStruct<System.Int32>("IsoNumericCode");
        public readonly QueryElMember<System.String> CountryType = new QueryElMember<System.String>("CountryType");
        public readonly QueryElMemberStruct<System.Int64> LatestRecordedPopulation = new QueryElMemberStruct<System.Int64>("LatestRecordedPopulation");
        public readonly QueryElMember<System.String> Continent = new QueryElMember<System.String>("Continent");
        public readonly QueryElMember<System.String> Region = new QueryElMember<System.String>("Region");
        public readonly QueryElMember<System.String> Subregion = new QueryElMember<System.String>("Subregion");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_CountryWrapper Instance = new Application_CountryWrapper();
        private Application_CountryWrapper(): base ("[Application].[Countries]", "Application_Country")
        {
        }
    }
}