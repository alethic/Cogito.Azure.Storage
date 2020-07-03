using System;

using Cogito.Extensions.Options.Configuration.Autofac;

namespace Cogito.Components.Azure.Storage
{

    /// <summary>
    /// Options for Azure Storage.
    /// </summary>
    [RegisterOptions("Cogito:Components:Azure:Storage")]
    public class AzureStorageOptions
    {

        /// <summary>
        /// URI for the Blob service.
        /// </summary>
        public Uri BlobServiceUri { get; set; }

        /// <summary>
        /// URI for the Share service.
        /// </summary>
        public Uri ShareServiceUri { get; set; }

        /// <summary>
        /// URI for the Queue service.
        /// </summary>
        public Uri QueueServiceUri { get; set; }

        /// <summary>
        /// URI for the table service.
        /// </summary>
        public Uri TableServiceUri { get; set; }

        /// <summary>
        /// Allow usage of the default system credentials. Does not apply to Share services.
        /// </summary>
        public bool UseDefaultCredential { get; set; } = true;

        /// <summary>
        /// Alternatively, connection string for Azure storage account.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Alternatively, the name of the storage account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Alternatively, the key of the storage account.
        /// </summary>
        public string AccountKey { get; set; }

    }

}
