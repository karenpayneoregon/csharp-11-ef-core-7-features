# Breaking change for connections

Suppose your connection string was setup as shown below prior to EF Core 7, this will fail with EF Core 7.

```
Data Source=.\\SQLEXPRESS;Initial Catalog=EF.Connection;Integrated Security=True;
```

We need to add `Encrypt=False` as done in all projects in this solution.

From Microsoft `Encrypt defaults to true for SQL Server connections`

> **Warning**
> This is a severe breaking change in the Microsoft.Data.SqlClient package. There is nothing that can be done in EF Core to revert or mitigate this change.

## See also 

- https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/breaking-changes#encrypt-defaults-to-true-for-sql-server-connections
- https://www.nuget.org/packages/Microsoft.Data.SqlClient/
