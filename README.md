# Entity Framework Core

Entity Framework Core using MySQL and SQL Server.

## Project Creation

The project was created using the .Net CLI. The following command will create the project:

```
dotnet new console
```

## Nuget Packages

There are several packages that are used in this project. The following packages are installed:

* ConsoleTables
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.EntityFrameworkCore.Tools.DotNet
* Microsoft.EntityFrameworkCore.SqlServer
* Pomelo.EntityFrameworkCore.MySql
* Pomelo.EntityFrameworkCore.MySql.Design

To add the `ConsoleTables` package, use the following command in the `Terminal`:

```
dotnet add package ConsoleTables
```

Repeat for the remaining packages.

>**Note:** The packages `Microsoft.EntityFrameworkCore.Tools` and `Microsoft.EntityFrameworkCore.Tools.DotNet` need to be changed from `PackageReference` to `DotNetCliToolReference` in the project file.

## Scaffolding

In this project we used code first with an empty database. If you are using an existing database, customize the following command:

```
dotnet ef dbcontext scaffold "server=localhost;userid=root;pwd=rootpw;port=3306;database=MoviesApp;sslmode=none;" Pomelo.EntityFrameworkCore.MySql -o Entities
```

* Replace `localhost` with the MySQL server name
* Replace `root` with the username
* Replace `rootpw` with the password for the database user
* Replace `MoviesApp` with the database, or schema name
* The text `Pomelo.EntityFrameworkCore.MySql` designates the scaffolding assembly to use
* `Entities` specifies the output directory

## Migrations

Migrations are an integral part of `Entity Framework Core`. In order to perform a mmigration, use the following steps:

1. Make changes to entities
2. If adding an entity, add the collection to the context.
    
    For example, use the following code to add a collection of `Person` entities to the context:
    
    ```csharp
    public virtual DbSet<Person> People { get; set; }
    ```

3. To create a migration named `Initial`, use the following command:

    ```
    dotnet ef migrations add Initial
    ```

4. To script the changes, use the `script` parameter:

    ```
    dotnet ef migrations script
    ```

5. If you want to apply the migration to the database, use the following command:

    ```
    dotnet ef database update
    ```


## Resources

Below are resources for further learning.

* [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/#pivot=efcore)
* [MySQL Downloads](https://dev.mysql.com/downloads/mysql/)
* [MySQL Documentation](https://dev.mysql.com/doc/)
* [nuget](https://www.nuget.org/)
* [edX Course - Data Access in C# and .NET Core](https://www.edx.org/course/data-access-c-net-core-microsoft-dev258x)