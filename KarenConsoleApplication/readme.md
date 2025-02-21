# Peter Ritchie - ConsoleApplicationBuilder

[GitHub repository](https://github.com/peteraritchie/ConsoleApplicationBuilder)

## About this project

This project uses the above dotnet tool to set up a console project for dependency injection.	

 In the main entry point, a value is read from appsettings.json to see if logging to the console should be used; as delivered, logging is turned off. Next, our DbContext is configured, followed by configuring the data class.

 In the Run method, a database query returns some data using EF Core to the console window.

 ### Setup

 - See instructions in the [GitHub repository](https://github.com/peteraritchie/ConsoleApplicationBuilder).
 - Set up the database using the SQL script in the folder Data scripts.
