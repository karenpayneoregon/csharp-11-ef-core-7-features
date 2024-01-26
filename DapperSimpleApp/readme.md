# About

This code sample is for novice developers using Framework 4.8 that are interested in working with SQL-Server using a data provider, in this case using Dapper.

All data operations are in the form which is okay for learning when first starting out while the next step is to move data operations need to be in a separate class outside of a form. With that the challenge and to learn is take all data operations out of the form into a separate class.

## Setup

1. Under localDb, create a database named `InsertExamples`
1. Run the script under Scripts folder
1. Build and run the project

First button asserts a connection can be made, second button gets all data and the last button demo's using a parameter to get the current record from the database table.

Why a button to check a connection, well either do that for the first time or add a try/catch in the loading of all data and of course consider abstracting data operations to a class and have try/catch statements for all data operations

## Uses a DataGridView

Used to keep things simple, a developer can use form controls instead bound to data with TextBox, ComboBox etc.

## Proper validation

Using [FluentValidation](https://www.nuget.org/packages/FluentValidation) done simple in child form.

## Edits, deletes, additions



I never cared to add records in a DataGridView, always used a modal dialog in most cases so here its done in a dialog.

See code in SampleValidationForm to see the basics to validate before an add new record.
