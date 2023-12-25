# About

A startup library to place EF Core Interceptors into. Currently only has AuditInterceptor, same as in AuditInterceptorSampleApp. So for the reader to use this library, copy into your Visual Studio solution, add it as a refernce your your project.


Add it to Services in Program.cs (replace Context with your DbContext)

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContextPool<Context>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .AddInterceptors(new AuditInterceptor()));
```