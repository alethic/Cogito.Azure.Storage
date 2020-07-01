using Autofac;

using Cogito.Autofac;

namespace Cogito.Components.Azure.Storage.Tables
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<Cogito.Components.Azure.Storage.AssemblyModule>();
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.Register(ctx => ctx.Resolve<CloudTableClientFactory>().CreateCloudTableClient()).SingleInstance();
        }

    }

}
