# First project for EF Core 8

:curly_loop: Focus on DateOnly, could had done a simple example database but figured why not use NorthWind database where Orders table DateTime columns could be Date.

Changed from NorthWind2022 Orders table

```sql
ALTER TABLE dbo.Orders ALTER COLUMN OrderDate DATE NOT NULL;
ALTER TABLE dbo.Orders ALTER COLUMN RequiredDate DATE NOT NULL;
ALTER TABLE dbo.Orders ALTER COLUMN ShippedDate DATE NOT NULL;
ALTER TABLE dbo.Orders ALTER COLUMN DeliveredDate DATE NOT NULL;
```

## Requires

- VS2022 17.18.0 or higher
- Create database and populate via Scripts folder

## EF Core

Resides in NorthWind2023Library class project

## Logs

EF Core operations are logged to a file under the application folder.

---
[What's New in EF Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)