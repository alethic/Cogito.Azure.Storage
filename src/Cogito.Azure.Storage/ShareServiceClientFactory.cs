using System;

using Azure.Core;
using Azure.Storage;
using Azure.Storage.Files.Shares;

using Microsoft.Extensions.Options;

namespace Cogito.Azure.Storage
{

    /// <summary>
    /// Provides instances of an Azure Storage share service client.
    /// </summary>
    public class ShareServiceClientFactory
    {

        readonly IOptions<AzureStorageOptions> options;
        readonly TokenCredential? credential;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="credential"></param>
        public ShareServiceClientFactory(IOptions<AzureStorageOptions> options, TokenCredential? credential)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        /// <summary>
        /// Creates a new queue service client.
        /// </summary>
        /// <returns></returns>
        public ShareServiceClient CreateShareServiceClient()
        {
            if (string.IsNullOrEmpty(options.Value.ConnectionString) == false)
                return new ShareServiceClient(options.Value.ConnectionString);

            var uri = options.Value.ShareServiceUri;
            if (uri == null && string.IsNullOrEmpty(options.Value.AccountName) == false)
                uri = new Uri($"https://{options.Value.AccountName}.file.core.windows.net/");
            if (uri == null)
                throw new InvalidOperationException("Could not determine Share Service URI.");

            if (string.IsNullOrEmpty(options.Value.AccountKey) || options.Value.UseDefaultCredential)
                return new ShareServiceClient(uri, credential);

            if (string.IsNullOrEmpty(options.Value.AccountKey) == false && string.IsNullOrEmpty(options.Value.AccountName) == false)
                return new ShareServiceClient(uri, new StorageSharedKeyCredential(options.Value.AccountName, options.Value.AccountKey));

            throw new InvalidOperationException("Cannot retrieve Share Service Client, no connection method specified.");
        }

    }

}
