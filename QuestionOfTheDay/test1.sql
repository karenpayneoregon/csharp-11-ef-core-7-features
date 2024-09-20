--- .\SQLEXPRESS
--- BirthDaysDatabase

SELECT CAST(FORMAT(GETDATE(), 'yyyyMMdd') AS INTEGER);

SELECT TOP (1) CAST(FORMAT(BirthDate, 'yyyyMMdd') AS INTEGER)
  FROM dbo.BirthDays
 ORDER BY BirthDate;

SELECT Id,
       FirstName,
       LastName,
       BirthDate,
       (CAST(FORMAT(GETDATE(), 'yyyyMMdd') AS INTEGER) - CAST(FORMAT(BirthDate, 'yyyyMMdd') AS INTEGER)) / 10000
  FROM dbo.BirthDays;