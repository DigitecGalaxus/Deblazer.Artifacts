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
    public partial class Warehouse_PackageType : DbEntity, IId
    {
        private DbValue<System.Int32> _PackageTypeID = new DbValue<System.Int32>();
        private DbValue<System.String> _PackageTypeName = new DbValue<System.String>();
        private DbValue<System.Int32> _LastEditedBy = new DbValue<System.Int32>();
        private DbValue<System.DateTime> _ValidFrom = new DbValue<System.DateTime>();
        private DbValue<System.DateTime> _ValidTo = new DbValue<System.DateTime>();
        private IDbEntitySet<Purchasing_PurchaseOrderLine> _Purchasing_PurchaseOrderLines;
        private IDbEntitySet<Sales_InvoiceLine> _Sales_InvoiceLines;
        private IDbEntitySet<Sales_OrderLine> _Sales_OrderLines;
        private IDbEntityRef<Application_People> _Application_People;
        private IDbEntitySet<Warehouse_StockItem> _Warehouse_StockItems;
        private IDbEntitySet<Warehouse_StockItem> _PackageTypes;
        public int Id => PackageTypeID;
        long ILongId.Id => PackageTypeID;
        [Validate]
        public System.Int32 PackageTypeID
        {
            get
            {
                return _PackageTypeID.Entity;
            }

            set
            {
                _PackageTypeID.Entity = value;
            }
        }

        [StringColumn(50, false)]
        [Validate]
        public System.String PackageTypeName
        {
            get
            {
                return _PackageTypeName.Entity;
            }

            set
            {
                _PackageTypeName.Entity = value;
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
        public IDbEntitySet<Purchasing_PurchaseOrderLine> Purchasing_PurchaseOrderLines
        {
            get
            {
                if (_Purchasing_PurchaseOrderLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Purchasing_PurchaseOrderLines = new DbEntitySetCached<Warehouse_PackageType, Purchasing_PurchaseOrderLine>(() => _PackageTypeID.Entity);
                    }
                }
                else
                    _Purchasing_PurchaseOrderLines = new DbEntitySet<Purchasing_PurchaseOrderLine>(_db, false, new Func<long ? >[]{() => _PackageTypeID.Entity}, new[]{"[PackageTypeID]"}, (member, root) => member.Warehouse_PackageType = root as Warehouse_PackageType, this, _lazyLoadChildren, e => e.Warehouse_PackageType = this, e =>
                    {
                        var x = e.Warehouse_PackageType;
                        e.Warehouse_PackageType = null;
                        new UpdateSetVisitor(true, new[]{"PackageTypeID"}, false).Process(x);
                    }

                    );
                return _Purchasing_PurchaseOrderLines;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_InvoiceLine> Sales_InvoiceLines
        {
            get
            {
                if (_Sales_InvoiceLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_InvoiceLines = new DbEntitySetCached<Warehouse_PackageType, Sales_InvoiceLine>(() => _PackageTypeID.Entity);
                    }
                }
                else
                    _Sales_InvoiceLines = new DbEntitySet<Sales_InvoiceLine>(_db, false, new Func<long ? >[]{() => _PackageTypeID.Entity}, new[]{"[PackageTypeID]"}, (member, root) => member.Warehouse_PackageType = root as Warehouse_PackageType, this, _lazyLoadChildren, e => e.Warehouse_PackageType = this, e =>
                    {
                        var x = e.Warehouse_PackageType;
                        e.Warehouse_PackageType = null;
                        new UpdateSetVisitor(true, new[]{"PackageTypeID"}, false).Process(x);
                    }

                    );
                return _Sales_InvoiceLines;
            }
        }

        [Validate]
        public IDbEntitySet<Sales_OrderLine> Sales_OrderLines
        {
            get
            {
                if (_Sales_OrderLines == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _Sales_OrderLines = new DbEntitySetCached<Warehouse_PackageType, Sales_OrderLine>(() => _PackageTypeID.Entity);
                    }
                }
                else
                    _Sales_OrderLines = new DbEntitySet<Sales_OrderLine>(_db, false, new Func<long ? >[]{() => _PackageTypeID.Entity}, new[]{"[PackageTypeID]"}, (member, root) => member.Warehouse_PackageType = root as Warehouse_PackageType, this, _lazyLoadChildren, e => e.Warehouse_PackageType = this, e =>
                    {
                        var x = e.Warehouse_PackageType;
                        e.Warehouse_PackageType = null;
                        new UpdateSetVisitor(true, new[]{"PackageTypeID"}, false).Process(x);
                    }

                    );
                return _Sales_OrderLines;
            }
        }

        [Validate]
        public Application_People Application_People
        {
            get
            {
                Action<Application_People> beforeRightsCheckAction = e => e.Warehouse_PackageTypes.Add(this);
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

                AssignDbEntity<Application_People, Warehouse_PackageType>(value, value == null ? new long ? [0] : new long ? []{(long ? )value.PersonID}, _Application_People, new long ? []{_LastEditedBy.Entity}, new Action<long ? >[]{x => LastEditedBy = (int ? )x ?? default (int)}, x => x.Warehouse_PackageTypes, null, LastEditedByChanged);
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
                        _Warehouse_StockItems = new DbEntitySetCached<Warehouse_PackageType, Warehouse_StockItem>(() => _PackageTypeID.Entity);
                    }
                }
                else
                    _Warehouse_StockItems = new DbEntitySet<Warehouse_StockItem>(_db, false, new Func<long ? >[]{() => _PackageTypeID.Entity}, new[]{"[OuterPackageID]"}, (member, root) => member.Warehouse_PackageType = root as Warehouse_PackageType, this, _lazyLoadChildren, e => e.Warehouse_PackageType = this, e =>
                    {
                        var x = e.Warehouse_PackageType;
                        e.Warehouse_PackageType = null;
                        new UpdateSetVisitor(true, new[]{"OuterPackageID"}, false).Process(x);
                    }

                    );
                return _Warehouse_StockItems;
            }
        }

        [Validate]
        public IDbEntitySet<Warehouse_StockItem> PackageTypes
        {
            get
            {
                if (_PackageTypes == null)
                {
                    if (_getChildrenFromCache)
                    {
                        _PackageTypes = new DbEntitySetCached<Warehouse_PackageType, Warehouse_StockItem>(() => _PackageTypeID.Entity);
                    }
                }
                else
                    _PackageTypes = new DbEntitySet<Warehouse_StockItem>(_db, false, new Func<long ? >[]{() => _PackageTypeID.Entity}, new[]{"[UnitPackageID]"}, (member, root) => member.Warehouse_PackageType = root as Warehouse_PackageType, this, _lazyLoadChildren, e => e.Warehouse_PackageType = this, e =>
                    {
                        var x = e.Warehouse_PackageType;
                        e.Warehouse_PackageType = null;
                        new UpdateSetVisitor(true, new[]{"UnitPackageID"}, false).Process(x);
                    }

                    );
                return _PackageTypes;
            }
        }

        protected override void ModifyInternalState(FillVisitor visitor)
        {
            SendIdChanging();
            _PackageTypeID.Load(visitor.GetInt32());
            SendIdChanged();
            _PackageTypeName.Load(visitor.GetValue<System.String>());
            _LastEditedBy.Load(visitor.GetInt32());
            _ValidFrom.Load(visitor.GetDateTime());
            _ValidTo.Load(visitor.GetDateTime());
            this._db = visitor.Db;
            isLoaded = true;
        }

        protected sealed override void CheckProperties(IUpdateVisitor visitor)
        {
            _PackageTypeID.Welcome(visitor, "PackageTypeID", "Int NOT NULL", false);
            _PackageTypeName.Welcome(visitor, "PackageTypeName", "NVarChar(50) NOT NULL", false);
            _LastEditedBy.Welcome(visitor, "LastEditedBy", "Int NOT NULL", false);
            _ValidFrom.Welcome(visitor, "ValidFrom", "DateTime2(7) NOT NULL", false);
            _ValidTo.Welcome(visitor, "ValidTo", "DateTime2(7) NOT NULL", false);
        }

        protected override void HandleChildren(DbEntityVisitorBase visitor)
        {
            visitor.ProcessAssociation(this, _Purchasing_PurchaseOrderLines);
            visitor.ProcessAssociation(this, _Sales_InvoiceLines);
            visitor.ProcessAssociation(this, _Sales_OrderLines);
            visitor.ProcessAssociation(this, _Application_People);
            visitor.ProcessAssociation(this, _Warehouse_StockItems);
            visitor.ProcessAssociation(this, _PackageTypes);
        }
    }

    public static class Db_Warehouse_PackageTypeQueryGetterExtensions
    {
        public static Warehouse_PackageTypeTableQuery<Warehouse_PackageType> Warehouse_PackageTypes(this IDb db)
        {
            var query = new Warehouse_PackageTypeTableQuery<Warehouse_PackageType>(db as IDb);
            return query;
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Queries
{
    public class Warehouse_PackageTypeQuery<K, T> : Query<K, T, Warehouse_PackageType, Warehouse_PackageTypeWrapper, Warehouse_PackageTypeQuery<K, T>> where K : QueryBase where T : DbEntity, ILongId
    {
        public Warehouse_PackageTypeQuery(IDb db): base (db)
        {
        }

        protected sealed override Warehouse_PackageTypeWrapper GetWrapper()
        {
            return Warehouse_PackageTypeWrapper.Instance;
        }

        public Purchasing_PurchaseOrderLineQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinPurchasing_PurchaseOrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Purchasing_PurchaseOrderLineQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Purchasing_PurchaseOrderLineTableQuery<Purchasing_PurchaseOrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Purchasing].[PurchaseOrderLines] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), (p, ids) => ((Purchasing_PurchaseOrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_PackageType)o).Purchasing_PurchaseOrderLines.Attach(v.Cast<Purchasing_PurchaseOrderLine>()), p => (long)((Purchasing_PurchaseOrderLine)p).PackageTypeID, attach);
        }

        public Sales_InvoiceLineQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinSales_InvoiceLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_InvoiceLineQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_InvoiceLineTableQuery<Sales_InvoiceLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[InvoiceLines] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), (p, ids) => ((Sales_InvoiceLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_PackageType)o).Sales_InvoiceLines.Attach(v.Cast<Sales_InvoiceLine>()), p => (long)((Sales_InvoiceLine)p).PackageTypeID, attach);
        }

        public Sales_OrderLineQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinSales_OrderLines(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Sales_OrderLineQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Sales_OrderLineTableQuery<Sales_OrderLine>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Sales].[OrderLines] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[PackageTypeID]"), (p, ids) => ((Sales_OrderLineWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_PackageType)o).Sales_OrderLines.Attach(v.Cast<Sales_OrderLine>()), p => (long)((Sales_OrderLine)p).PackageTypeID, attach);
        }

        public Application_PeopleQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinApplication_People(JoinType joinType = JoinType.Inner, bool preloadEntities = false)
        {
            var joinedQuery = new Application_PeopleQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return Join(joinedQuery, string.Concat(joinType.GetJoinString(), " [Application].[People] AS {1} {0} ON", "{2}.[LastEditedBy] = {1}.[PersonID]"), o => ((Warehouse_PackageType)o)?.Application_People, (e, fv, ppe) =>
            {
                var child = (Application_People)ppe(QueryHelpers.Fill<Application_People>(null, fv));
                if (e != null)
                {
                    ((Warehouse_PackageType)e).Application_People = child;
                }

                return child;
            }

            , typeof (Application_People), preloadEntities);
        }

        public Warehouse_StockItemQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinWarehouse_StockItems(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTableQuery<Warehouse_StockItem>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[OuterPackageID]"), (p, ids) => ((Warehouse_StockItemWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_PackageType)o).Warehouse_StockItems.Attach(v.Cast<Warehouse_StockItem>()), p => (long)((Warehouse_StockItem)p).OuterPackageID, attach);
        }

        public Warehouse_StockItemQuery<Warehouse_PackageTypeQuery<K, T>, T> JoinPackageTypes(JoinType joinType = JoinType.Inner, bool attach = false)
        {
            var joinedQuery = new Warehouse_StockItemQuery<Warehouse_PackageTypeQuery<K, T>, T>(Db);
            return JoinSet(() => new Warehouse_StockItemTableQuery<Warehouse_StockItem>(Db), joinedQuery, string.Concat(joinType.GetJoinString(), " [Warehouse].[StockItems] AS {1} {0} ON", "{2}.[PackageTypeID] = {1}.[UnitPackageID]"), (p, ids) => ((Warehouse_StockItemWrapper)p).Id.In(ids.Select(id => (System.Int32)id)), (o, v) => ((Warehouse_PackageType)o).PackageTypes.Attach(v.Cast<Warehouse_StockItem>()), p => (long)((Warehouse_StockItem)p).UnitPackageID, attach);
        }
    }

    public class Warehouse_PackageTypeTableQuery<T> : Warehouse_PackageTypeQuery<Warehouse_PackageTypeTableQuery<T>, T> where T : DbEntity, ILongId
    {
        public Warehouse_PackageTypeTableQuery(IDb db): base (db)
        {
        }
    }
}

namespace Deblazer.WideWorldImporter.DbLayer.Helpers
{
    public class Warehouse_PackageTypeHelper : QueryHelper<Warehouse_PackageType>, IHelper<Warehouse_PackageType>
    {
        string[] columnsInSelectStatement = new[]{"{0}.PackageTypeID", "{0}.PackageTypeName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInSelectStatement => columnsInSelectStatement;
        string[] columnsInInsertStatement = new[]{"{0}.PackageTypeID", "{0}.PackageTypeName", "{0}.LastEditedBy", "{0}.ValidFrom", "{0}.ValidTo"};
        public sealed override string[] ColumnsInInsertStatement => columnsInInsertStatement;
        private static readonly string createTempTableCommand = "CREATE TABLE #Warehouse_PackageType ([PackageTypeID] Int NOT NULL,[PackageTypeName] NVarChar(50) NOT NULL,[LastEditedBy] Int NOT NULL,[ValidFrom] DateTime2(7) NOT NULL,[ValidTo] DateTime2(7) NOT NULL, [RowIndexForSqlBulkCopy] INT NOT NULL)";
        public sealed override string CreateTempTableCommand => createTempTableCommand;
        public sealed override string FullTableName => "[Warehouse].[PackageTypes]";
        public sealed override bool IsForeignKeyTo(Type other)
        {
            return other == typeof (Purchasing_PurchaseOrderLine) || other == typeof (Sales_InvoiceLine) || other == typeof (Sales_OrderLine) || other == typeof (Warehouse_StockItem) || other == typeof (Warehouse_StockItem);
        }

        private const string insertCommand = "INSERT INTO [Warehouse].[PackageTypes] ([{TableName = \"Warehouse].[PackageTypes\";}].[PackageTypeID], [{TableName = \"Warehouse].[PackageTypes\";}].[PackageTypeName], [{TableName = \"Warehouse].[PackageTypes\";}].[LastEditedBy], [{TableName = \"Warehouse].[PackageTypes\";}].[ValidFrom], [{TableName = \"Warehouse].[PackageTypes\";}].[ValidTo]) VALUES ([@PackageTypeID],[@PackageTypeName],[@LastEditedBy],[@ValidFrom],[@ValidTo]); SELECT SCOPE_IDENTITY()";
        public sealed override void FillInsertCommand(SqlCommand sqlCommand, Warehouse_PackageType _Warehouse_PackageType)
        {
            sqlCommand.CommandText = insertCommand;
            sqlCommand.Parameters.AddWithValue("@PackageTypeID", _Warehouse_PackageType.PackageTypeID);
            sqlCommand.Parameters.AddWithValue("@PackageTypeName", _Warehouse_PackageType.PackageTypeName ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@LastEditedBy", _Warehouse_PackageType.LastEditedBy);
            sqlCommand.Parameters.AddWithValue("@ValidFrom", _Warehouse_PackageType.ValidFrom);
            sqlCommand.Parameters.AddWithValue("@ValidTo", _Warehouse_PackageType.ValidTo);
        }

        public sealed override void ExecuteInsertCommand(SqlCommand sqlCommand, Warehouse_PackageType _Warehouse_PackageType)
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                sqlDataReader.Read();
                _Warehouse_PackageType.PackageTypeID = Convert.ToInt32(sqlDataReader.GetValue(0));
            }
        }

        private static Warehouse_PackageTypeWrapper _wrapper = Warehouse_PackageTypeWrapper.Instance;
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
    public class Warehouse_PackageTypeWrapper : QueryWrapper<Warehouse_PackageType>
    {
        public readonly QueryElMemberId<Application_People> LastEditedBy = new QueryElMemberId<Application_People>("LastEditedBy");
        public readonly QueryElMember<System.String> PackageTypeName = new QueryElMember<System.String>("PackageTypeName");
        public readonly QueryElMemberStruct<System.DateTime> ValidFrom = new QueryElMemberStruct<System.DateTime>("ValidFrom");
        public readonly QueryElMemberStruct<System.DateTime> ValidTo = new QueryElMemberStruct<System.DateTime>("ValidTo");
        public static readonly Warehouse_PackageTypeWrapper Instance = new Warehouse_PackageTypeWrapper();
        private Warehouse_PackageTypeWrapper(): base ("[Warehouse].[PackageTypes]", "Warehouse_PackageType")
        {
        }
    }
}