using System;

using Azure.Storage;
using Azure.Storage.Queues;

using Cogito.Autofac;
using Cogito.Components.Azure.Identity;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Storage
{

    /// <summary>
    /// Provides instances of an Azure Storage queue client.
    /// </summary>
    [RegisterAs(typeof(QueueServiceClientFactory))]
    [RegisterSingleInstance]
    public class QueueServiceClientFactory
    {

        readonly IOptions<AzureStorageOptions> options;
        readonly AzureIdentityCredential credential;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="credential"></param>
        public QueueServiceClientFactory(IOptions<AzureStorageOptions> options, AzureIdentityCredential credential)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        /// <summary>
        /// Creates a new queue service client.
        /// </summary>
        /// <returns></returns>
        public QueueServiceClient CreateQueueServiceClient()
        {
            if (options.Value.ConnectionString != null)
                return new QueueServiceClient(options.Value.ConnectionString);

            var uri = options.Value.QueueServiceUri;
            if (uri == null && options.Value.AccountName != null)
                uri = new Uri($"https://{options.Value.AccountName}.queue.core.windows.net/");
            if (uri == null)
                throw new InvalidOperationException("Could not determine Queue Service URI.");

            if (options.Value.AccountKey == null || options.Value.UseDefaultCredential)
                return new QueueServiceClient(uri, credential);

            if (options.Value.AccountKey != null && options.Value.AccountName != null)
                return new QueueServiceClient(uri, new StorageSharedKeyCredential(options.Value.AccountName, options.Value.AccountKey));

            throw new InvalidOperationException("Cannot retrieve Queue Service Client, no connection method specified.");
        }

    }

}
