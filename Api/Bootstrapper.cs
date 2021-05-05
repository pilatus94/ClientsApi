using Api.Repository;
using Nancy;
using Nancy.TinyIoc;

namespace Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IClientRepository>(new ClientRepository());

            base.ConfigureApplicationContainer(container);
        }
    }
}
