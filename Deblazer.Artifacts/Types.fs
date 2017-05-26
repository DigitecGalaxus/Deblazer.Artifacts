[<AutoOpen>]
module Types
    open FSharp.Data
    open Microsoft.CodeAnalysis.CSharp
    open System
    open Regexes
    open System.Data.Linq
    
    type sf = SyntaxFactory
    type sk = SyntaxKind
    type dc = XmlProvider<"../DataClassesSchema.dbml">
    
    type SyntaxFactory with
        static member getCommaTokens count = 
            [| 0 .. count-2 |] |> Array.map (fun x -> sf.Token(sk.CommaToken)) 
    
    type cardinality = One=0 | Many=1
    
    type SqlQualifiedTable = {
        TableName: string;
    } with
        member this.WithSquareBrackets = sqlSquareBrackets this.TableName
    
    type association = {
        Name:string;
        Member:string;
        Type: string;
        ThisKey:string;
        OtherKey:string;
        /// Only set on One2One Associations
        OtherSideAssociation: Option<association>;
        IsForeignKey: bool;       
        Cardinality: cardinality;
        OtherTableName: SqlQualifiedTable;
    } with
        member this.Storage = getStorage this.Member
        member this.ThisKeyStorage = getStorage this.ThisKey
        member this.OtherKeyStorage = getStorage this.OtherKey
        member this.IsMany = this.Cardinality = cardinality.Many   
    
    type column = {
        Name:string;
        Type:string;
        DbType:string;
        CanBeNull:bool;
        IsDbGenerated: Option<bool>;
        IsPrimaryKey: Option<bool>;
        IsVersion: Option<bool>;
    } with
        member this.Storage = getStorage this.Name
        member this.Member =
            String.Format("{0}", this.Name)
        member this.MaxLength =
            match this.DbType with
            | MaxLengthRegex str -> 
                if (String.Equals(str, "MAX")) 
                then Int32.MaxValue 
                else Convert.ToInt32(str)
            | _ -> 0

        member this.CompileType =
            match this.Type with
            | "System.Xml.Linq.XElement" -> typeof<Xml.Linq.XElement>
            | "System.Data.Linq.Binary" -> typeof<System.Data.Linq.Binary>
            | _ -> Type.GetType this.Type

        member this.IsNullableType =
            match this.CompileType with
            | _ when this.CompileType = typedefof<string> -> true
            | _ when this.CompileType.IsGenericType && this.CompileType.GetGenericTypeDefinition() = typedefof<Nullable<_>> -> true
            | _ when this.CompileType = typedefof<Binary> -> true
            | _ -> false
    
    [<NoComparison>]
    type ForeignKey = {Column:column; Association:association; }

    let otherSideAssociation (a:association) (list: association[]) =
         list |> Array.tryFind (fun x -> x.Name = a.Name && x.Member <> a.Member)
    
    type table = {
        Name: SqlQualifiedTable;
        Member: string;
        TypeName: string;
        Associations:association[];
        Columns:column[];
    } with 
        member this.Storage = getStorage this.TypeName
        member this.PrimaryKeyColumn = 
            this.Columns |> Array.tryFind (fun column -> column.IsPrimaryKey.IsSome && column.IsPrimaryKey.Value)
            
        member this.HasPrimaryKey = this.PrimaryKeyColumn.IsSome
        
        member this.EditableColumns =
            this.Columns |> Array.filter (fun column -> column.IsDbGenerated.IsNone && column.IsVersion.IsNone)
             
        member this.BaseIIdType =
            match this.PrimaryKeyColumn with
            | Some pk ->  
                match pk.CompileType with
                | t when t = typeof<int64> -> "ILongId"
                | t when t = typeof<int32> -> "IId"
                | _ -> raise (Exception("Only int64 and int32 are allowed as IId."))
            | None -> raise (Exception("Only Primary Key Tables are supported."))
        member this.ColumnsWithoutPrimaryKey =
            this.Columns |> Array.filter (fun column -> column.IsPrimaryKey.IsNone)
        member this.NonForeignKeyColumns = 
            this.ColumnsWithoutPrimaryKey |> Array.filter (function column -> this.Associations |> (Array.exists (fun association -> association.ThisKey = column.Name) >> not))            
        member this.ForeignKeyColumns =
            this.ColumnsWithoutPrimaryKey
                |> Array.map (fun column ->
                    this.Associations
                        |> Array.tryPick (fun association ->
                            if association.ThisKey = column.Name
                            then
                                Some({
                                        Column = column;
                                        Association = association;
                                        
                                     })
                            else None))
                |> Array.filter (fun fk -> fk.IsSome)
                |> Array.map (fun fk -> fk.Value)
    type database = {
        Name:string;
        EntityNamespace:string;
        ConextNamespace:string;
        Tables:table[];
    } 
    
    
    let getOtherSide (current:association) (allTableAssociations:association[]) = 
        allTableAssociations |> Array.tryFind (fun x -> x.Name = current.Name && x.Member <> current.Member)
    
    let otherTableName (association: association) (allTables:Map<string, SqlQualifiedTable>) =
        let x = allTables.[association.Type].TableName 
        allTables.[association.Type]
        
    let getCardinality (a: dc.Association) =
        match a.Cardinality with
            | Some x when x = "Many" -> cardinality.Many
            | None ->
                match a.IsForeignKey.IsNone with
                | true -> cardinality.Many
                | false -> cardinality.One 
            | _ -> cardinality.One    
        
    let parseAssoications (associations:dc.Association[]) (tables:Map<string, SqlQualifiedTable>) =
        let flatList = 
            associations 
            |> Array.map (fun x ->
                {
                    Name = x.Name;
                    Member = x.Member;
                    Type = x.Type;
                    ThisKey = x.ThisKey
                    OtherKey = x.OtherKey;
                    Cardinality = getCardinality x
                    IsForeignKey = x.Cardinality.IsSome || x.IsForeignKey.IsNone;
                    OtherSideAssociation = None;
                    OtherTableName = { TableName = "" };
                    
                })
        flatList |> Array.map (fun x -> { x with 
                                            OtherSideAssociation = getOtherSide x flatList 
                                            OtherTableName = otherTableName x tables })      
                                            
    let parseColumns (columns:dc.Column[]) =
        columns
        |> Array.map (fun c -> 
            {
                Name = c.Name;
                Type = c.Type;
                DbType = c.DbType;
                CanBeNull = c.CanBeNull;
                IsDbGenerated = c.IsDbGenerated;
                IsPrimaryKey = c.IsPrimaryKey;
                IsVersion = c.IsVersion;
            }
        )
   
    
    let parseTables (tables:dc.Table[]) = 
        let tableNames = tables |> Array.map (fun x -> x.Type.Name, { TableName = x.Name} ) |> Map.ofArray
        tables
        |> Array.map (fun table -> 
            {
                Name = { TableName = table.Name };
                Member = table.Member;
                TypeName = table.Type.Name;
                Associations = parseAssoications table.Type.Associations tableNames
                Columns = parseColumns table.Type.Columns
            }) 
    
    let parseTypeProvider (xmlDatabase:dc.Database) =
        {
            Name = xmlDatabase.Name;
            EntityNamespace = xmlDatabase.EntityNamespace;
            ConextNamespace = xmlDatabase.ContextNamespace;
            Tables = parseTables xmlDatabase.Tables            
        }
    