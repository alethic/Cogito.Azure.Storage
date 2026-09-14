# Cogito.Azure.Storage.Tables.Autofac

Registers the Azure Table Storage client factory in an Autofac container.

## Install

```shell
dotnet add package Cogito.Azure.Storage.Tables.Autofac
```

## Use

```csharp
builder.RegisterAllAssemblyModules();
```

`CloudTableClientFactory` then resolves, configured from `AzureStorageOptions`.

## License

MIT.
