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
            if (options.Value.ConnectionString != null)
                return CloudStorageAccount.Parse(options.Value.ConnectionString).CreateCloudTableClient();

            var uri = options.Value.TableServiceUri;
            if (uri == null && options.Value.AccountName != null)
                uri = new Uri($"https://{options.Value.AccountName}.table.core.windows.net/");
            if (uri == null)
                throw new InvalidOperationException("Could not determine Table Service URI.");

            if (options.Value.AccountKey != null && options.Value.AccountName != null)
                return new CloudTableClient(uri, new StorageCredentials(options.Value.AccountName, options.Value.AccountKey));

            throw new InvalidOperationException("Cannot retrieve Table Service Client, no connection method specified.");
        }

    }

}
