# Deblazer Artifacts
This project is used to generate the artifact classes for the C# Deblazer ORM [<insert link to repo here>](https://gogole.ch) used by   [Digitec Galaxus](https://github.com/DigitecGalaxus)

Roslyn is used to generate the artifact classes from a DBML File generate by the SqlMetal.exe

## Getting Started
Download the latest release from [<insert latest release url here>](https://gogole.ch)

### Usuage
1. [Download SQL Metal](https://msdn.microsoft.com/en-us/library/bb386987(v=vs.110).aspx)
2. Generate DBML File:
```sh
sqlmetal.exe /conn:"Data Source=MySQlServer;Initial Catalog=MyDatabase;Integrated Security=True;" /timeout:0 /dbml:"DataClasses.dbml" /namespace:devinite.Meta.DbLayer /language:csharp /pluralize
```
3. Generate Artifacts
```sh
deblazer generate DataClasses.dbml -dbml <Path to DBML File> -o <OutputPath>
```

4. Add the files to a .csproj
5. Add References for `System.ComponentModel.DataAnnotations` and `System.Data.Linq`
6. Create a "Db" Class for accessing your artifacts
```cs
using Dg.Deblazer.Write;

namespace Deblazer.WideWorldImporter.DbLayer
{
    public class Db : WriteDb
    {
	    public Db(string connectionString) : base(connectionString, allowLoadingBinaryData: true)
	    {}
	}
}
```
7. Create a query
```cs
var topTenPeople = db.Application_Peoples()
    .TakeDb(takeCount)
    .ToList();
```

## Development
The tooling uses f# as primary Language targeting the .NET 4.6.1 Framework. .NET core is not yet possible because of the usuage of an XML Type-Provider.

## Continuous Integration
Badges coming soon

