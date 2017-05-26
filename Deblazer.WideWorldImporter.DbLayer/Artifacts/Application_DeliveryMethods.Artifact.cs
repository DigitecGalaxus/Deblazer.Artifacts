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
    public partial class Application_DeliveryMethod : DbEntity, IId
    {
        private DbValue<System.Int32> _DeliveryMethodID = new DbValue<System.Int32>();
        private DbValue<System.String> _DeliveryMethodName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Purchasing_PurchaseOrder> _Purchasing_PurchaseOrders;
        private IDbEntitySet<Purchasing_Supplier> _Purchasing_Suppliers;
        private IDbEntitySet<Sales_Customer> _Sales_Customers;
        private IDbEntitySet<Sales_Invoice> _Sales_Invoices;
        public int Id => DeliveryMethodID;
        long ILongId.Id => DeliveryMethodID;
        [Validate]
        public System.Int32 DeliveryMethodID
        {
            get
            {
                return _DeliveryMethodID.Entity;
            }

            set
            {
                _DeliveryMethodID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String DeliveryMethodName
        {
            get
            {
                return _DeliveryMethodName.Entity;
            }

            set
            {
                _DeliveryMethodName.Entity = value;
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
                Action<Application_People> beforeRightsCheckAction = e => e.Application_DeliveryMethods.Add(this);
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

                AssignDbEntity<Application_People, Application_DeliveryMethod>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Application_DeliveryMethods, null, LastEditedByChanged);
            }
        }

        void LastEditedByChanged(object sender, EventArgs eventArgs)
        {
            if (sender is Application_People)
                _LastEditedBy.Entity = (int)((Application_People)sender).Id;
        }

        [Validate]
        public IDbEntitySet<Purchasing_PurchaseOrder> Purchasing_PurchaseOrders
        {
            get
            {
                if (_Purchasing_PurchaseOrders == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrders = new DbEntitySetCached<Application_DeliveryMethod, Purchasing_PurchaseOrder>(() => _DeliveryMethodID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrders = new DbEntitySet<Purchasing_PurchaseOrder>(_db, false, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, new[]{"[DeliveryMethodID]"}, (member, root) => member.Application_DeliveryMethod = root as Application_DeliveryMethod, this, _lazyLoadChildren, e => e.Application_DeliveryMethod = this, e =>
                    {
                        var x = e.Application_DeliveryMethod;
                        e.Application_DeliveryMethod = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryMethodID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrders;
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
                        _Purchasing_Suppliers = new DbEntitySetCached<Application_DeliveryMethod, Purchasing_Supplier>(() => _DeliveryMethodID.Entity);
                    }
                }
                else
                    _Purchasing_Suppliers = new DbEntitySet<Purchasing_Supplier>(_db, false, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, new[]{"[DeliveryMethodID]"}, (member, root) => member.Application_DeliveryMethod = root as Application_DeliveryMethod, this, _lazyLoadChildren, e => e.Application_DeliveryMethod = this, e =>
                    {
                        var x = e.Application_DeliveryMethod;
                        e.Application_DeliveryMethod = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryMethodID"}, false).Process(x);
                    }

                    );
                return _Purchasing_Suppliers;
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
                        _Sales_Customers = new DbEntitySetCached<Application_DeliveryMethod, Sales_Customer>(() => _DeliveryMethodID.Entity);
                    }
                }
                else
                    _Sales_Customers = new DbEntitySet<Sales_Customer>(_db, false, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, new[]{"[DeliveryMethodID]"}, (member, root) => member.Application_DeliveryMethod = root as Application_DeliveryMethod, this, _lazyLoadChildren, e => e.Application_DeliveryMethod = this, e =>
                    {
                        var x = e.Application_DeliveryMethod;
                        e.Application_DeliveryMethod = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryMethodID"}, false).Process(x);
                    }

                    );
                return _Sales_Customers;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_Invoice> Sales_Invoices
        {
            get
            {
                if (_Sales_Invoices == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_Invoices = new DbEntitySetCached<Application_DeliveryMethod, Sales_Invoice>(() => _DeliveryMethodID.Entity);
                    }
                }
                else
                    _Sales_Invoices = new DbEntitySet<Sales_Invoice>(_db, false, new Func<long ? >[]{() => _DeliveryMethodID.Entity}, new[]{"[DeliveryMethodID]"}, (member, root) => member.Application_DeliveryMethod = root as Application_DeliveryMethod, this, _lazyLoadChildren, e => e.Application_DeliveryMethod = this, e =>
                    {
                        var x = e.Application_DeliveryMethod;
                        e.Application_DeliveryMethod = null;
                        new UpdateSetVisitor(true, new[]{"DeliveryMethodID"}, false).Process(x);
                    }

                    );
                return _Sales_Invoices;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _DeliveryMethodID.Load(visitor.GetInt32());
            SendIdChanged();
            _DeliveryMethodName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _DeliveryMethodID.Welcome(visitor, "DeliveryMethodID", "Int NOT NULL", false);
            _DeliveryMethodName.Welcome(visitor, "DeliveryMethodName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrders);
            visitor.ProcessAssociation(this, _Purchasing_Suppliers);
            visitor.ProcessAssociation(this, _Sales_Customers);
            visitor.ProcessAssociation(this, _Sales_Invoices);
        }
    }

    public static class Db_Application_DeliveryMethodQueryGetterExtensions
    {
        public static Application_DeliveryMethodTableQuery<Application_DeliveryMethod> Application_DeliveryMethods(this IDb db)
        {
            var query = new Application_DeliveryMethodTableQuery<Application_DeliveryMethod>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Application_DeliveryMethodQuery<K, T> : Query<K, T, Application_DeliveryMethod, Application_DeliveryMethodWrapper, Application_DeliveryMethodQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Application_DeliveryMethodQuery(IDb db): base (db)
        {
        }

        protected sealed override Application_DeliveryMethodWrapper GetWrapper()
        {
            return Application_DeliveryMethodWrapper.Instance;
        }

        public Application_PeopleQuery<Application_DeliveryMethodQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Application_DeliveryMethodQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Application_DeliveryMethod)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Application_DeliveryMethod)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Purchasing_PurchaseOrderQuery<Application_DeliveryMethodQuery<K, T>, T> JoinPurchasing_PurchaseOrders(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderQuery<Application_DeliveryMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderTableQuery<Purchasing_PurchaseOrder>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrders] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), (p, ids) => ((Purchasing_PurchaseOrderWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_DeliveryMethod)o).Purchasing_PurchaseOrders.Attach(v.Cast<Purchasing_PurchaseOrder>()), p => (long)((Purchasing_PurchaseOrder)p).DeliveryMethodID, attach);
        }

        public Purchasing_SupplierQuery<Application_DeliveryMethodQuery<K, T>, T> JoinPurchasing_Suppliers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_SupplierQuery<Application_DeliveryMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_SupplierTableQuery<Purchasing_Supplier>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[Suppliers] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), (p, ids) => ((Purchasing_SupplierWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_DeliveryMethod)o).Purchasing_Suppliers.Attach(v.Cast<Purchasing_Supplier>()), p => (long)((Purchasing_Supplier)p).DeliveryMethodID, attach);
        }

        public Sales_CustomerQuery<Application_DeliveryMethodQuery<K, T>, T> JoinSales_Customers(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_CustomerQuery<Application_DeliveryMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_CustomerTableQuery<Sales_Customer>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Customers] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), (p, ids) => ((Sales_CustomerWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_DeliveryMethod)o).Sales_Customers.Attach(v.Cast<Sales_Customer>()), p => (long)((Sales_Customer)p).DeliveryMethodID, attach);
        }

        public Sales_InvoiceQuery<Application_DeliveryMethodQuery<K, T>, T> JoinSales_Invoices(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceQuery<Application_DeliveryMethodQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceTableQuery<Sales_Invoice>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[Invoices] AS {1} {0} ON", "{2}.[DeliveryMethodID] = {1}.[DeliveryMethodID]"), (p, ids) => ((Sales_InvoiceWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Application_DeliveryMethod)o).Sales_Invoices.Attach(v.Cast<Sales_Invoice>()), p => (long)((Sales_Invoice)p).DeliveryMethodID, attach);
        }
    }

    public class Application_DeliveryMethodTableQuery<T> : Application_DeliveryMethodQuery<Application_DeliveryMethodTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Application_DeliveryMethodTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Application_DeliveryMethodHelper : QueryHelper<Application_DeliveryMethod>, IHelper<Application_DeliveryMethod>
    {
        string[] columnsInSelectStatement = new[]{"{0}.DeliveryMethodID", "{0}.DeliveryMethodName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.DeliveryMethodID", "{0}.DeliveryMethodName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Application_DeliveryMethod ([DeliveryMethodID] Int NOT NULL,[DeliveryMethodName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Application].[DeliveryMethods]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_PurchaseOrder) || other == typeof (Purchasing_Supplier) || other == typeof (Sales_Customer) || other == typeof (Sales_Invoice);
        }

        private const string insertCommand = "INSERT INTO [Application].[DeliveryMethods] ([{TableName = \"Application].[DeliveryMethods\";}].[DeliveryMethodID], [{TableName = \"Application].[DeliveryMethods\";}].[DeliveryMethodName], [{TableName = \"Application].[DeliveryMethods\";}].[LastEditedBy], [{TableName = \"Application].[DeliveryMethods\";}].[ValidFrom], [{TableName = \"Application].[DeliveryMethods\";}].[ValidTo]) VALUES ([@DeliveryMethodID],[@DeliveryMethodName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Application_DeliveryMethod _Application_DeliveryMethod)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodID", _Application_DeliveryMethod.DeliveryMethodID);
            sqlCommand.Parameters.AddWithValue("@DeliveryMethodName", _Application_DeliveryMethod.DeliveryMethodName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Application_DeliveryMethod.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Application_DeliveryMethod.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Application_DeliveryMethod.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Application_DeliveryMethod _Application_DeliveryMethod)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Application_DeliveryMethod.DeliveryMethodID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Application_DeliveryMethodWrapper _wrapper = Application_DeliveryMethodWrapper.Instance;
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
    public class Application_DeliveryMethodWrapper : QueryWrapper<Application_DeliveryMethod>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> DeliveryMethodName = new QueryElMember<System.String>("DeliveryMethodName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Application_DeliveryMethodWrapper Instance = new Application_DeliveryMethodWrapper();
        private Application_DeliveryMethodWrapper(): base ("[Application].[DeliveryMethods]", "Application_DeliveryMethod")
        {
        }
    }
}