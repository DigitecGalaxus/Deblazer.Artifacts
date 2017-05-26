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
    public partial class Application_SystemParameter : DbEntity, IId
    {
        private DbValue<System.Int32> _SystemParameterID = new DbValue<System.Int32>();
        private DbValue<System.String> _DeliveryAddressLine1 = new DbValue<System.String>();
        private DbValue<System.String> _DeliveryAddressLine2 = new DbValue<System.String>();
        private DbValue<System.Int32> _DeliveryCityID = new DbValue<System.Int32>();
        private DbValue<System.String> _DeliveryPostalCode = new DbValue<System.String>();
        private DbValue<System.String> _PostalAddressLine1 = new DbValue<System.String>();
        private DbValue<System.String> _PostalAddressLine2 = new DbValue<System.String>();
        private DbValue<System.Int32> _PostalCityID = new DbValue<System.Int32>();
        private DbValue<System.String> _PostalPostalCode = new DbValue<System.String>();
        private DbValue<System.String> _ApplicationSettings = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _LastEditedWhen = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_City> _Application_City;
        private IDbEntityRef<Application_City> _PostalCity;
        public int Id => SystemParameterID;
        long ILongId.Id => SystemParameterID;
        [Validate]
        public System.Int32 SystemParameterID
        {
            get
            {
                return _SystemParameterID.Entity;
            }

            set
            {
                _SystemParameterID.Entity = value;
            }
        }

        [StringColumn(60, false)]
        [Validate]
        public System.String DeliveryAddressLine1
        {
            get
            {
                return _DeliveryAddressLine1.Entity;
            }

            set
            {
                _DeliveryAddressLine1.Entity = value;
            }
        }

        [StringColumn(60, true)]
        [Validate]
        public System.String DeliveryAddressLine2
        {
            get
            {
                return _DeliveryAddressLine2.Entity;
            }

            set
            {
                _DeliveryAddressLine2.Entity = value;
            }
        }

        [Validate]
        public System.Int32 DeliveryCityID
        {
            get
            {
                return _DeliveryCityID.Entity;
            }

            set
            {
                _DeliveryCityID.Entity = value;
            }
        }

        [StringColumn(10, false)]
        [Validate]
        public System.String DeliveryPostalCode
        {
            get
            {
                return _DeliveryPostalCode.Entity;
            }

            set
            {
                _DeliveryPostalCode.Entity = value;
            }
        }

        [StringColumn(60, false)]
        [Validate]
        public System.String PostalAddressLine1
        {
            get
            {
                return _PostalAddressLine1.Entity;
            }

            set
            {
                _PostalAddressLine1.Entity = value;
            }
        }

        [StringColumn(60, true)]
        [Validate]
        public System.String PostalAddressLine2
        {
            get
            {
                return _PostalAddressLine2.Entity;
            }

            set
            {
                _PostalAddressLine2.Entity = value;
            }
        }

        [Validate]
        public System.Int32 PostalCityID
        {
            get
            {
                return _PostalCityID.Entity;
            }

            set
            {
                _PostalCityID.Entity = value;
            }
        }

        [StringColumn(10, false)]
        [Validate]
        public System.String PostalPostalCode
        {
            get
            {
                return _PostalPostalCode.Entity;
            }

            set
            {
                _PostalPostalCode.Entity = value;
            }
        }

        [StringColumn(2147483647, false)]
        [Validate]
        public System.String ApplicationSettings
        {
            get
            {
                return _ApplicationSettings.Entity;
            }

            set
            {
                _ApplicationSettings.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Application_SystemParameters.Add(this);
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

                AssignDbEntity<Application_People, Application_SystemParameter>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_SystemParameters, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_City Application_City
        {
            get
            {
                Action<Application_City> beforeRightsCheckAction = e => e.Application_SystemParameters.Add(this);
                if (_Application_City != null)
                {
                    return _Application_City.GetEntity(beforeRightsCheckAction);
                }

                _Application_City = GetDbEntityRef(true, new[]{"[DeliveryCityID]"}, new Func<long ? >[]{() => _DeliveryCityID.Entity}, beforeRightsCheckAction);
                return (Application_City != null) ? _Application_City.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_City == null)
                {
                    _Application_City = new DbEntityRef<Application_City>(_db, true, new[]{"[DeliveryCityID]"}, new Func<long ? >[]{() => _DeliveryCityID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_City, Application_SystemParameter>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _Application_City, new long ? []{_DeliveryCityID.Entity}, new Action<long ? >[]{x => DeliveryCityID = (int ? )x ?? default (int)}, x => x.Application_SystemParameters, null, DeliveryCityIDChanged);
            }
        }

        void DeliveryCityIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_City)
                _DeliveryCityID.Entity = (int)((Application_City)sender).Id;
        }

        [Validate]
        public Application_City PostalCity
        {
            get
            {
                Action<Application_City> beforeRightsCheckAction = e => e.Application_SystemParameters.Add(this);
                if (_PostalCity != null)
                {
                    return _PostalCity.GetEntity(beforeRightsCheckAction);
                }

                _PostalCity = GetDbEntityRef(true, new[]{"[PostalCityID]"}, new Func<long ? >[]{() => _PostalCityID.Entity}, beforeRightsCheckAction);
                return (PostalCity != null) ? _PostalCity.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_PostalCity == null)
                {
                    _PostalCity = new DbEntityRef<Application_City>(_db, true, new[]{"[PostalCityID]"}, new Func<long ? >[]{() => _PostalCityID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_City, Application_SystemParameter>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.CityID}, _PostalCity, new long ? []{_PostalCityID.Entity}, new Action<long ? >[]{x => PostalCityID = (int ? )x ?? default (int)}, x => x.Application_SystemParameters, null, PostalCityIDChanged);
            }
        }

        void PostalCityIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_City)
                _PostalCityID.Entity = (int)((Application_City)sender).Id;
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _SystemParameterID.Load(visitor.GetInt32());
            SendIdChanged();
            _DeliveryAddressLine1.Load(visitor.GetValue<System.String>());
            _DeliveryAddressLine2.Load(visitor.GetValue<System.String>());
            _DeliveryCityID.Load(visitor.GetInt32());
            _DeliveryPostalCode.Load(visitor.GetValue<System.String>());
            _PostalAddressLine1.Load(visitor.GetValue<System.String>());
            _PostalAddressLine2.Load(visitor.GetValue<System.String>());
            _PostalCityID.Load(visitor.GetInt32());
            _PostalPostalCode.Load(visitor.GetValue<System.String>());
            _ApplicationSettings.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _LastEditedWhen.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _SystemParameterID.Welcome(visitor, "SystemParameterID", "Int NOT NULL", false);
            _DeliveryAddressLine1.Welcome(visitor, "DeliveryAddressLine1", "NVarChar(60) NOT NULL", false);
            _DeliveryAddressLine2.Welcome(visitor, "DeliveryAddressLine2", "NVarChar(60)", false);
            _DeliveryCityID.Welcome(visitor, "DeliveryCityID", "Int NOT NULL", false);
            _DeliveryPostalCode.Welcome(visitor, "DeliveryPostalCode", "NVarChar(10) NOT NULL", false);
            _PostalAddressLine1.Welcome(visitor, "PostalAddressLine1", "NVarChar(60) NOT NULL", false);
            _PostalAddressLine2.Welcome(visitor, "PostalAddressLine2", "NVarChar(60)", false);
            _PostalCityID.Welcome(visitor, "PostalCityID", "Int NOT NULL", false);
            _PostalPostalCode.Welcome(visitor, "PostalPostalCode", "NVarChar(10) NOT NULL", false);
            _ApplicationSettings.Welcome(visitor, "ApplicationSettings", "NVarChar(MAX) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _LastEditedWhen.Welcome(visitor, "LastEditedWhen", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Application_City);
            visitor.ProcessAssociation(this, _PostalCity);
        }
    }

    public static class Db_Application_SystemParameterQueryGetterExtensions
    {
        public static Application_SystemParameterTableQuery<Application_SystemParameter> Application_SystemParameters(this IDb db)
        {
            var query = new Application_SystemParameterTableQuery<Application_SystemParameter>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_SystemParameterQuery<K, T> : Query<K, T, Application_SystemParameter, Application_SystemParameterWrapper, Application_SystemParameterQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_SystemParameterQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_SystemParameterWrapper GetWrapper()
        {
            return Application_SystemParameterWrapper.Instance;
        }

        public Application_PeopleQuery<Application_SystemParameterQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_SystemParameterQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_SystemParameter)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_SystemParameter)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_CityQuery<Application_SystemParameterQuery<K, T>, T> JoinApplication_City(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Application_SystemParameterQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[DeliveryCityID] = {1}.[CityID]"), o => ((Application_SystemParameter)o)?.Application_City, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Application_SystemParameter)e).Application_City = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }

        public Application_CityQuery<Application_SystemParameterQuery<K, T>, T> JoinPostalCity(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_CityQuery<Application_SystemParameterQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[Cities] AS {1} {0} ON", "{2}.[PostalCityID] = {1}.[CityID]"), o => ((Application_SystemParameter)o)?.PostalCity, (e, fv, ppe) =>
            {
                var child = (Application_City)ppe(QueryHelpers.Fill<Application_City>(null, fv));
                if (e != null)
                {
                    ((Application_SystemParameter)e).PostalCity = child;
                }

                return child;
            }

            , typeof (Application_City), preloadEntities);
        }
    }

    public class Application_SystemParameterTableQuery<T> : Application_SystemParameterQuery<Application_SystemParameterTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_SystemParameterTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_SystemParameterHelper : QueryHelper<Application_SystemParameter>, IHelper<Application_SystemParameter>
    {
        string[] columnsInSelectStatement = new[]{"{0}.SystemParameterID", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryCityID", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalCityID", "{0}.PostalPostalCode", "{0}.ApplicationSettings", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.SystemParameterID", "{0}.DeliveryAddressLine1", "{0}.DeliveryAddressLine2", "{0}.DeliveryCityID", "{0}.DeliveryPostalCode", "{0}.PostalAddressLine1", "{0}.PostalAddressLine2", "{0}.PostalCityID", "{0}.PostalPostalCode", "{0}.ApplicationSettings", "{0}.LastEditedBy", "{0}.LastEditedWhen"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_SystemParameter ([SystemParameterID] Int NOT NULL,[DeliveryAddressLine1] NVarChar(60) NOT NULL,[DeliveryAddressLine2] NVarChar(60),[DeliveryCityID] Int NOT NULL,[DeliveryPostalCode] NVarChar(10) NOT NULL,[PostalAddressLine1] NVarChar(60) NOT NULL,[PostalAddressLine2] NVarChar(60),[PostalCityID] Int NOT NULL,[PostalPostalCode] NVarChar(10) NOT NULL,[ApplicationSettings] NVarChar(MAX) NOT NULL,[LastEditedBy] Int NOT NULL,[LastEditedWhen] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[SystemParameters]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return false;
        }

        private const string insertCommand = "INSERT INTO [Application].[SystemParameters] ([{TableName = \"Application].[SystemParameters\";}].[SystemParameterID], [{TableName = \"Application].[SystemParameters\";}].[DeliveryAddressLine1], [{TableName = \"Application].[SystemParameters\";}].[DeliveryAddressLine2], [{TableName = \"Application].[SystemParameters\";}].[DeliveryCityID], [{TableName = \"Application].[SystemParameters\";}].[DeliveryPostalCode], [{TableName = \"Application].[SystemParameters\";}].[PostalAddressLine1], [{TableName = \"Application].[SystemParameters\";}].[PostalAddressLine2], [{TableName = \"Application].[SystemParameters\";}].[PostalCityID], [{TableName = \"Application].[SystemParameters\";}].[PostalPostalCode], [{TableName = \"Application].[SystemParameters\";}].[ApplicationSettings], [{TableName = \"Application].[SystemParameters\";}].[LastEditedBy], [{TableName = \"Application].[SystemParameters\";}].[LastEditedWhen]) VALUES ([@SystemParameterID],[@DeliveryAddressLine1],[@DeliveryAddressLine2],[@DeliveryCityID],[@DeliveryPostalCode],[@PostalAddressLine1],[@PostalAddressLine2],[@PostalCityID],[@PostalPostalCode],[@ApplicationSettings],[@LastEditedBy],[@LastEditedWhen]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_SystemParameter _Application_SystemParameter)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@SystemParameterID", _Application_SystemParameter.SystemParameterID);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine1", _Application_SystemParameter.DeliveryAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryAddressLine2", _Application_SystemParameter.DeliveryAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DeliveryCityID", _Application_SystemParameter.DeliveryCityID);
            sqlCommand.Parameters.AddWithValue("@DeliveryPostalCode", _Application_SystemParameter.DeliveryPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine1", _Application_SystemParameter.PostalAddressLine1 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalAddressLine2", _Application_SystemParameter.PostalAddressLine2 ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@PostalCityID", _Application_SystemParameter.PostalCityID);
            sqlCommand.Parameters.AddWithValue("@PostalPostalCode", _Application_SystemParameter.PostalPostalCode ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@ApplicationSettings", _Application_SystemParameter.ApplicationSettings ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_SystemParameter.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@LastEditedWhen", _Application_SystemParameter.LastEditedWhen);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_SystemParameter _Application_SystemParameter)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_SystemParameter.SystemParameterID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_SystemParameterWrapper _wrapper = Application_SystemParameterWrapper.Instance;
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
    public class Application_SystemParameterWrapper : QueryWrapper<Application_SystemParameter>
    {
        public readonly QueryElMemberId<Application_City> DeliveryCityID = new QueryElMemberId<Application_City>("DeliveryCityID");
        public readonly QueryElMemberId<Application_City> PostalCityID = new QueryElMemberId<Application_City>("PostalCityID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> DeliveryAddressLine1 = new QueryElMember<System.String>("DeliveryAddressLine1");
        public readonly QueryElMember<System.String> DeliveryAddressLine2 = new QueryElMember<System.String>("DeliveryAddressLine2");
        public readonly QueryElMember<System.String> DeliveryPostalCode = new QueryElMember<System.String>("DeliveryPostalCode");
        public readonly QueryElMember<System.String> PostalAddressLine1 = new QueryElMember<System.String>("PostalAddressLine1");
        public readonly QueryElMember<System.String> PostalAddressLine2 = new QueryElMember<System.String>("PostalAddressLine2");
        public readonly QueryElMember<System.String> PostalPostalCode = new QueryElMember<System.String>("PostalPostalCode");
        public readonly QueryElMember<System.String> ApplicationSettings = new QueryElMember<System.String>("ApplicationSettings");
        public readonly QueryElMemberStruct<System.DateTime> LastEditedWhen = new QueryElMemberStruct<System.DateTime>("LastEditedWhen");
        public static readonly Application_SystemParameterWrapper Instance = new Application_SystemParameterWrapper();
        private Application_SystemParameterWrapper(): base ("[Application].[SystemParameters]", "Application_SystemParameter")
        {
        }
    }
}