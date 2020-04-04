using System;
using uangsaku.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace uangsaku.UI.Web.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}