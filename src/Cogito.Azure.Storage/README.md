# Cogito.Azure.Storage

Configured client factories for Azure Storage blobs, queues and file shares.

## Why

The storage SDK clients each want a connection string or an account URI plus a credential. Building
them where they are used scatters that configuration and makes moving from connection strings to
managed identity a change in many places rather than one.

## Install

```shell
dotnet add package Cogito.Azure.Storage
```

## Use

```csharp
var blobs = blobServiceClientFactory.Create();
var container = blobs.GetBlobContainerClient("imports");
```

`BlobServiceClientFactory`, `QueueServiceClientFactory` and `ShareServiceClientFactory` build their
clients from `AzureStorageOptions` and the ambient credential, so switching the account or the
identity is a configuration change.

## License

MIT.
