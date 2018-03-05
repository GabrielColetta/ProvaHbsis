using Library.Application.Services;
using Library.Domain.Contracts;
using Library.Persistence.Context;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Library.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IBookService, BookService>(Lifestyle.Scoped);

            container.Register<IContext, ApplicationContext>(Lifestyle.Scoped);
            container.Verify();
            return container;
        }
    }
}
