using System;

using Cogito.Autofac;

using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Storage.Tables
{

    /// <summary>
    /// Provides instances of an Azure Storage table client.
    /// </summary>
    [RegisterAs(typeof(CloudTableClientFactory))]
    [RegisterSingleInstance]
    public class CloudTableClientFactory
    {

        readonly IOptions<AzureStorageOptions> options;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        public CloudTableClientFactory(IOptions<AzureStorageOptions> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Creates a new blob service client.
        /// </summary>
        /// <returns></returns>
        public CloudTableClient CreateCloudTableClient()
        {
            if (options.Value.ServiceUri != null)
                if (options.Value.AccountName != null)
                    return new CloudTableClient(options.Value.ServiceUri, new StorageCredentials(options.Value.AccountName, options.Value.AccountKey));

            if (options.Value.AccountName != null)
                return new CloudStorageAccount(new StorageCredentials(options.Value.AccountName, options.Value.AccountKey), true).CreateCloudTableClient();

            if (options.Value.ConnectionString != null)
                return CloudStorageAccount.Parse(options.Value.ConnectionString).CreateCloudTableClient();

            throw new InvalidOperationException("Cannot retrieve Cloud Table Client, no connection method specified.");
        }

    }

}
