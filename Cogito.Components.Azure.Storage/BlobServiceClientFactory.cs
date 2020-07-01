using System;

using Azure.Storage.Blobs;

using Cogito.Autofac;
using Cogito.Components.Azure.Identity;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Storage
{

    /// <summary>
    /// Provides instances of an Azure Storage blob client.
    /// </summary>
    [RegisterAs(typeof(BlobServiceClientFactory))]
    [RegisterSingleInstance]
    public class BlobServiceClientFactory
    {

        readonly IOptions<AzureStorageOptions> options;
        readonly AzureIdentityCredential credential;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="credential"></param>
        public BlobServiceClientFactory(IOptions<AzureStorageOptions> options, AzureIdentityCredential credential)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        /// <summary>
        /// Creates a new blob service client.
        /// </summary>
        /// <returns></returns>
        public BlobServiceClient CreateBlobServiceClient()
        {
            if (options.Value.ServiceUri != null)
                return new BlobServiceClient(options.Value.ServiceUri, credential);

            if (options.Value.ConnectionString != null)
                return new BlobServiceClient(options.Value.ConnectionString);

            throw new InvalidOperationException("Cannot retrieve Blob Service Client, no connection method specified.");
        }

    }

}
