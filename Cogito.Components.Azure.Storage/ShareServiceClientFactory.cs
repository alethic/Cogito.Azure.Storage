using System;

using Azure.Storage;
using Azure.Storage.Files.Shares;

using Cogito.Autofac;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Storage
{

    /// <summary>
    /// Provides instances of an Azure Storage share service client.
    /// </summary>
    [RegisterAs(typeof(ShareServiceClientFactory))]
    [RegisterSingleInstance]
    public class ShareServiceClientFactory
    {

        readonly IOptions<AzureStorageOptions> options;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        public ShareServiceClientFactory(IOptions<AzureStorageOptions> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Creates a new queue service client.
        /// </summary>
        /// <returns></returns>
        public ShareServiceClient CreateShareServiceClient()
        {
            if (options.Value.ServiceUri != null)
                return new ShareServiceClient(options.Value.ServiceUri, new StorageSharedKeyCredential(options.Value.AccountName, options.Value.AccountKey));

            if (options.Value.ConnectionString != null)
                return new ShareServiceClient(options.Value.ConnectionString);

            throw new InvalidOperationException("Cannot retrieve Share Service Client, no connection method specified or missing credentials.");
        }

    }

}
