# Cogito.Azure.Storage.Autofac

Registers the Azure Storage client factories in an Autofac container.

## Install

```shell
dotnet add package Cogito.Azure.Storage.Autofac
```

## Use

```csharp
builder.RegisterAllAssemblyModules();
```

The blob, queue and file-share client factories then resolve, configured from `AzureStorageOptions`
and using the container's `TokenCredential`.

## License

MIT.
