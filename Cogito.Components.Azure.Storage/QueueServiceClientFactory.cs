using System;

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
            if (options.Value.ServiceUri != null)
                return new QueueServiceClient(options.Value.ServiceUri, credential);

            if (options.Value.ConnectionString != null)
                return new QueueServiceClient(options.Value.ConnectionString);

            throw new InvalidOperationException("Cannot retrieve Queue Service Client, no connection method specified.");
        }

    }

}
