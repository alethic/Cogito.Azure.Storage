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
            if (options.Value.ConnectionString != null)
                return new ShareServiceClient(options.Value.ConnectionString);

            var uri = options.Value.ShareServiceUri;
            if (uri == null && options.Value.AccountName != null)
                uri = new Uri($"https://{options.Value.AccountName}.file.core.windows.net/");
            if (uri == null)
                throw new InvalidOperationException("Could not determine Share Service URI.");

            if (options.Value.AccountKey != null && options.Value.AccountName != null)
                return new ShareServiceClient(uri, new StorageSharedKeyCredential(options.Value.AccountName, options.Value.AccountKey));

            throw new InvalidOperationException("Cannot retrieve Share Service Client, no connection method specified.");
        }

    }

}
