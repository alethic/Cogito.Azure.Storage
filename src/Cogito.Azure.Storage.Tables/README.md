# Cogito.Azure.Storage.Tables

A configured client factory for Azure Table Storage.

## Why

Tables ship as their own SDK with their own client, but the account and credential are the same ones
the rest of your storage code uses. This factory takes them from the same options.

## Install

```shell
dotnet add package Cogito.Azure.Storage.Tables
```

## Use

```csharp
var tables = cloudTableClientFactory.Create();
var table = tables.GetTableReference("orders");
```

## License

MIT.
