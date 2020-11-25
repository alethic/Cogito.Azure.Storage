using Autofac;

using Cogito.Autofac;

namespace Cogito.Azure.Storage.Tables.Autofac
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<Cogito.Azure.Storage.Autofac.AssemblyModule>();
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.RegisterType<CloudTableClientFactory>().AsSelf().SingleInstance();
            builder.Register(ctx => ctx.Resolve<CloudTableClientFactory>().CreateCloudTableClient()).SingleInstance();
        }

    }

}
