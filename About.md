These two projects show how to control creating and populating database tables for testing controlled by code in the project PayneServiceLibrary, which reads settings from the parent project’s appsettings.json file.

```json
{
  "ConnectionStrings": {
    "MainConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HasDataExample;Integrated Security=True;Encrypt=False",
    "SecondaryConnection": "..."
  },
  "EntityConfiguration": {
    "CreateNew": true
  }
}
```

Setting `CreateNew` to true to create and populate the database specified in `ConnectionStrings.MainConnection`

Project `ConventionalRead` is for writing an article.