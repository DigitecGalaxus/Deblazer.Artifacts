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
    public partial class Application_City : DbEntity, IId
    {
        private DbValue<System.Int32> _CityID = new DbValue<System.Int32>();
        private DbValue<System.String> _CityName = new DbValue<System.String>();
        private DbValue<System.Int32> _StateProvinceID = new DbValue<System.Int32>();
        private DbValue<System.Int64> _LatestRecordedPopulation = new DbValue<System.Int64>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntityRef<Application_StateProvince> _Application_StateProvince;
        private IDbEntitySet<Application_SystemParameter> _Application_SystemParameters;
        private IDbEntitySet<Application_SystemParameter> _Cities;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers_PostalCityID_Application_Cities;
        private IDbEntitySet<Sales_Customer> _Sales_Customers;
        private IDbEntitySet<Sales_Customer> _Sales_Customers_PostalCityID_Application_Cities;
        public int Id => CityID;
        long ILongId.Id => CityID;
        [Validate]
        public System.Int32 CityID
        {
            get
            {
                return _CityID.Entity;
            }

            set
            {
                _CityID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String CityName
        {
            get
            {
                return _CityName.Entity;
            }

            set
            {
                _CityName.Entity = value;
            }
        }

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
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Application_Cities.Add(this);
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

                AssignDbEntity<Application_People, Application_City>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_Cities, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public Application_StateProvince Application_StateProvince
        {
            get
            {
                Action<Application_StateProvince> beforeRightsCheckAction = e => e.Application_Cities.Add(this);
                if (_Application_StateProvince != null)
                {
                    return _Application_StateProvince.GetEntity(beforeRightsCheckAction);
                }

                _Application_StateProvince = GetDbEntityRef(true, new[]{"[StateProvinceID]"}, new Func<long ? >[]{() => _StateProvinceID.Entity}, beforeRightsCheckAction);
                return (Application_StateProvince != null) ? _Application_StateProvince.GetEntity(beforeRightsCheckAction) : null;
            }

            set
            {
                if (_Application_StateProvince == null)
                {
                    _Application_StateProvince = new DbEntityRef<Application_StateProvince>(_db, true, new[]{"[StateProvinceID]"}, new Func<long ? >[]{() => _StateProvinceID.Entity}, _lazyLoadChildren, _getChildrenFromCache);
                }

                AssignDbEntity<Application_StateProvince, Application_City>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.StateProvinceID}, _Application_StateProvince, new long ? []{_StateProvinceID.Entity}, new Action<long ? >[]{x => StateProvinceID = (int ? )x ?? default (int)}, x => x.Application_Cities, null, StateProvinceIDChanged);
            }
        }

        void StateProvinceIDChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_StateProvince)
                _StateProvinceID.Entity = (int)((Application_StateProvince)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Application_SystemParameter> Application_SystemParameters
        {
            get
            {
                if (_Application_SystemParameters == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Application_SystemParameters = new DbEntitySetCached<Application_City, Application_SystemParameter>(() => _CityID.Entity);
                    }
                }
                else
                    _Application_SystemParameters = new DbEntitySet<Application_SystemParameter>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[DeliveryCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryCityID"}, false).Process(x);
                    }

                    );
                return _Application_SystemParameters;
            }
        }

        [Validate]
        public IDbEntitySet<Application_SystemParameter> Cities
        {
            get
            {
                if (_Cities == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Cities = new DbEntitySetCached<Application_City, Application_SystemParameter>(() => _CityID.Entity);
                    }
                }
                else
                    _Cities = new DbEntitySet<Application_SystemParameter>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[PostalCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"PostalCityID"}, false).Process(x);
                    }

                    );
                return _Cities;
            }
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
                        _Purchasing_Suppliers = new DbEntitySetCached<Application_City, Purchasing_Supplier>(() => _CityID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[DeliveryCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryCityID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers;
            }
        }

        [Validate]
        public IDbEntitySet<Purchasing_Supplier> Purchasing_Suppliers_PostalCityID_Application_Cities
        {
            get
            {
                if (_Purchasing_Suppliers_PostalCityID_Application_Cities == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_Suppliers_PostalCityID_Application_Cities = new DbEntitySetCached<Application_City, Purchasing_Supplier>(() => _CityID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers_PostalCityID_Application_Cities = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[PostalCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"PostalCityID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers_PostalCityID_Application_Cities;
            }
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
                        _Sales_Customers = new DbEntitySetCached<Application_City, Sales_Customer>(() => _CityID.Entity);
                    }
                }
                else
                    _Sales_Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[DeliveryCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryCityID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Customer> Sales_Customers_PostalCityID_Application_Cities
        {
            get
            {
                if (_Sales_Customers_PostalCityID_Application_Cities == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Customers_PostalCityID_Application_Cities = new DbEntitySetCached<Application_City, Sales_Customer>(() => _CityID.Entity);
                    }
                }
                else
                    _Sales_Customers_PostalCityID_Application_Cities = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _CityID.Entity}, new[]{"[PostalCityID]"}, (member, root) => member.Application_City = root as Application_City, this, _lazyLoadChildren, e => e.Application_City = this, e =>
                    {
                        var x = e.Application_City;
                        e.Application_City = null;
                        new UpdateSetVisitor(true, new[]{"PostalCityID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers_PostalCityID_Application_Cities;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _CityID.Load(visitor.GetInt32());
            SendIdChanged();
            _CityName.Load(visitor.GetValue<System.String>());
            _StateProvinceID.Load(visitor.GetInt32());
            _LatestRecordedPopulation.Load(visitor.GetValue<System.Int64>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _CityID.Welcome(visitor, "CityID", "Int NOT NULL", false);
            _CityName.Welcome(visitor, "CityName", "NVarChar(50) NOT NULL", false);
            _StateProvinceID.Welcome(visitor, "StateProvinceID", "Int NOT NULL", false);
            _LatestRecordedPopulation.Welcome(visitor, "LatestRecordedPopulation", "BigInt", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Application_StateProvince);
            visitor.ProcessAssociation(this, _Application_SystemParameters);
            visitor.ProcessAssociation(this, _Cities);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers_PostalCityID_Application_Cities);
            visitor.ProcessAssociation(this, _Sales_Customers);
            visitor.ProcessAssociation(this, _Sales_Customers_PostalCityID_Application_Cities);
        }
    }

    public static class Db_Application_CityQueryGetterExtensions
    {
        public static Application_CityTableQuery<Application_City> Application_Cities(this IDb db)
        {
            var query = new Application_CityTableQuery<Application_City>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_CityQuery<K, T> : Query<K, T, Application_City, Application_CityWrapper, Application_CityQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_CityQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_CityWrapper GetWrapper()
        {
            return Application_CityWrapper.Instance;
        }

        public Application_PeopleQuery<Application_CityQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_CityQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_City)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_City)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Application_StateProvinceQuery<Application_CityQuery<K, T>, T> JoinApplication_StateProvince(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_StateProvinceQuery<Application_CityQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[StateProvinces] AS {1} {0} ON", "{2}.[StateProvinceID] = {1}.[StateProvinceID]"), o => ((Application_City)o)?.Application_StateProvince, (e, fv, ppe) =>
            {
                var child = (Application_StateProvince)ppe(QueryHelpers.Fill<Application_StateProvince>(null, fv));
                if (e != null)
                {
                    ((Application_City)e).Application_StateProvince = child;
                }

                return child;
            }

            , typeof (Application_StateProvince), preloadEntities);
        }

        public Application_SystemParameterQuery<Application_CityQuery<K, T>, T> JoinApplication_SystemParameters(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_SystemParameterQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_SystemParameterTableQuery<Application_SystemParameter>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[SystemParameters] AS {1} {0} ON", "{2}.[CityID] = {1}.[DeliveryCityID]"), (p, ids) => ((Application_SystemParameterWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Application_SystemParameters.Attach(v.Cast<Application_SystemParameter>()), p => (long)((Application_SystemParameter)p).DeliveryCityID, attach);
        }

        public Application_SystemParameterQuery<Application_CityQuery<K, T>, T> JoinCities(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Application_SystemParameterQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Application_SystemParameterTableQuery<Application_SystemParameter>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[SystemParameters] AS {1} {0} ON", "{2}.[CityID] = {1}.[PostalCityID]"), (p, ids) => ((Application_SystemParameterWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Cities.Attach(v.Cast<Application_SystemParameter>()), p => (long)((Application_SystemParameter)p).PostalCityID, attach);
        }

        public Purchasing_SupplierQuery<Application_CityQuery<K, T>, T> JoinPurchasing_Suppliers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[CityID] = {1}.[DeliveryCityID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Purchasing_Suppliers.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).DeliveryCityID, attach);
        }

        public Purchasing_SupplierQuery<Application_CityQuery<K, T>, T> JoinPurchasing_Suppliers_PostalCityID_Application_Cities(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[CityID] = {1}.[PostalCityID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Purchasing_Suppliers_PostalCityID_Application_Cities.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).PostalCityID, attach);
        }

        public Sales_CustomerQuery<Application_CityQuery<K, T>, T> JoinSales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CityID] = {1}.[DeliveryCityID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Sales_Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).DeliveryCityID, attach);
        }

        public Sales_CustomerQuery<Application_CityQuery<K, T>, T> JoinSales_Customers_PostalCityID_Application_Cities(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_CityQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[CityID] = {1}.[PostalCityID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_City)o).Sales_Customers_PostalCityID_Application_Cities.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).PostalCityID, attach);
        }
    }

    public class Application_CityTableQuery<T> : Application_CityQuery<Application_CityTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_CityTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_CityHelper : QueryHelper<Application_City>, IHelper<Application_City>
    {
        string[] columnsInSelectStatement = new[]{"{0}.CityID", "{0}.CityName", "{0}.StateProvinceID", "{0}.LatestRecordedPopulation", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.CityID", "{0}.CityName", "{0}.StateProvinceID", "{0}.LatestRecordedPopulation", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_City ([CityID] Int NOT NULL,[CityName] NVarChar(50) NOT NULL,[StateProvinceID] Int NOT NULL,[LatestRecordedPopulation] BigInt,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[Cities]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Application_SystemParameter) || other == typeof (Application_SystemParameter) || other == typeof (Purchasing_Supplier) || other == typeof (Purchasing_Supplier) || other == typeof (Sales_Customer) || other == typeof (Sales_Customer);
        }

        private const string insertCommand = "INSERT INTO [Application].[Cities] ([{TableName = \"Application].[Cities\";}].[CityID], [{TableName = \"Application].[Cities\";}].[CityName], [{TableName = \"Application].[Cities\";}].[StateProvinceID], [{TableName = \"Application].[Cities\";}].[LatestRecordedPopulation], [{TableName = \"Application].[Cities\";}].[LastEditedBy], [{TableName = \"Application].[Cities\";}].[ValidFrom], [{TableName = \"Application].[Cities\";}].[ValidTo]) VALUES ([@CityID],[@CityName],[@StateProvinceID],[@LatestRecordedPopulation],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_City _Application_City)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@CityID", _Application_City.CityID);
            sqlCommand.Parameters.AddWithValue("@CityName", _Application_City.CityName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", _Application_City.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@LatestRecordedPopulation", _Application_City.LatestRecordedPopulation);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_City.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_City.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_City.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_City _Application_City)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_City.CityID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_CityWrapper _wrapper = Application_CityWrapper.Instance;
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
    public class Application_CityWrapper : QueryWrapper<Application_City>
    {
        public readonly QueryElMemberId<Application_StateProvince> StateProvinceID = new QueryElMemberId<Application_StateProvince>("StateProvinceID");
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> CityName = new QueryElMember<System.String>("CityName");
        public readonly QueryElMemberStruct<System.Int64> LatestRecordedPopulation = new QueryElMemberStruct<System.Int64>("LatestRecordedPopulation");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_CityWrapper Instance = new Application_CityWrapper();
        private Application_CityWrapper(): base ("[Application].[Cities]", "Application_City")
        {
        }
    }
}