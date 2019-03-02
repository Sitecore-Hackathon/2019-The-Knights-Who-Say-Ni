using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Knights.Feature.KeywordFieldHelper.Services
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