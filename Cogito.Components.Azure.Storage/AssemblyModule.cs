using Autofac;

using Cogito.Autofac;

namespace Cogito.Components.Azure.Storage
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.Register(ctx => ctx.Resolve<BlobServiceClientFactory>().CreateBlobServiceClient()).SingleInstance();
            builder.Register(ctx => ctx.Resolve<ShareServiceClientFactory>().CreateShareServiceClient()).SingleInstance();
            builder.Register(ctx => ctx.Resolve<QueueServiceClientFactory>().CreateQueueServiceClient()).SingleInstance();
        }

    }

}
