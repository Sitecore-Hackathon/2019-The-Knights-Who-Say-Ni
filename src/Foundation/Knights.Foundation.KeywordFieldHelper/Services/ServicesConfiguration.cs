using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Knights.Foundation.KeywordFieldHelper.Services
{
    public class ServicesConfiguration : IServicesConfigurator
    {
        #region Implementation of IServicesConfigurator

        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllers("Knights.*");
        }

        #endregion
    }
}