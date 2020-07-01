using System;

using Cogito.Extensions.Options.Configuration.Autofac;

namespace Cogito.Components.Azure.Storage
{

    /// <summary>
    /// Options for Azure Storage.
    /// </summary>
    [RegisterOptions("Azure.Storage")]
    public class AzureStorageOptions
    {

        /// <summary>
        /// URI for the storage account. If provided the current Azure Identity will be used for connections.
        /// </summary>
        public Uri ServiceUri { get; set; }

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
