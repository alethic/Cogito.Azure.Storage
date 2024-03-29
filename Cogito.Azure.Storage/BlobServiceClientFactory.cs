﻿using System;

using Azure.Storage;
using Azure.Storage.Blobs;

using Cogito.Azure.Identity;

using Microsoft.Extensions.Options;

namespace Cogito.Azure.Storage
{

    /// <summary>
    /// Provides instances of an Azure Storage blob client.
    /// </summary>
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
            if (string.IsNullOrEmpty(options.Value.ConnectionString) == false)
                return new BlobServiceClient(options.Value.ConnectionString);

            var uri = options.Value.BlobServiceUri;
            if (uri == null && string.IsNullOrEmpty(options.Value.AccountName) == false)
                uri = new Uri($"https://{options.Value.AccountName}.blob.core.windows.net/");
            if (uri == null)
                throw new InvalidOperationException("Could not determine Blob Service URI.");

            if (string.IsNullOrEmpty(options.Value.AccountKey) || options.Value.UseDefaultCredential)
                return new BlobServiceClient(uri, credential);

            if (string.IsNullOrEmpty(options.Value.AccountKey) == false && string.IsNullOrEmpty(options.Value.AccountName) == false)
                return new BlobServiceClient(uri, new StorageSharedKeyCredential(options.Value.AccountName, options.Value.AccountKey));

            throw new InvalidOperationException("Cannot retrieve Blob Service Client, no connection method specified.");
        }

    }

}
