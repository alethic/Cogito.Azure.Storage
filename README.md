# Cogito.Azure.Storage

[![Build](https://github.com/alethic/Cogito.Azure.Storage/actions/workflows/Cogito.Azure.Storage.yml/badge.svg)](https://github.com/alethic/Cogito.Azure.Storage/actions/workflows/Cogito.Azure.Storage.yml)

Configured client factories for Azure Storage blobs, queues, file shares and tables.

## Packages

**[Cogito.Azure.Storage](https://www.nuget.org/packages/Cogito.Azure.Storage)** — Configured client factories for Azure Storage blobs, queues and file shares.

**[Cogito.Azure.Storage.Autofac](https://www.nuget.org/packages/Cogito.Azure.Storage.Autofac)** — Registers the Azure Storage client factories in an Autofac container.

**[Cogito.Azure.Storage.Tables](https://www.nuget.org/packages/Cogito.Azure.Storage.Tables)** — A configured client factory for Azure Table Storage.

**[Cogito.Azure.Storage.Tables.Autofac](https://www.nuget.org/packages/Cogito.Azure.Storage.Tables.Autofac)** — Registers the Azure Table Storage client factory in an Autofac container.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.Azure.Storage.sln
dotnet msbuild -p:Configuration=Release Cogito.Azure.Storage.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
