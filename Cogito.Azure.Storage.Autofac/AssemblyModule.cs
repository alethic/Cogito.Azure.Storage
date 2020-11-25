using Autofac;

using Cogito.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;

namespace Cogito.Azure.Storage.Autofac
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<Cogito.Azure.Identity.Autofac.AssemblyModule>();
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.Configure<AzureStorageOptions>("Azure:Storage");
            builder.RegisterType<BlobServiceClientFactory>().AsSelf().SingleInstance();
            builder.RegisterType<QueueServiceClientFactory>().AsSelf().SingleInstance();
            builder.RegisterType<ShareServiceClientFactory>().AsSelf().SingleInstance();
            builder.Register(ctx => ctx.Resolve<BlobServiceClientFactory>().CreateBlobServiceClient()).SingleInstance();
            builder.Register(ctx => ctx.Resolve<ShareServiceClientFactory>().CreateShareServiceClient()).SingleInstance();
            builder.Register(ctx => ctx.Resolve<QueueServiceClientFactory>().CreateQueueServiceClient()).SingleInstance();
        }

    }

}
