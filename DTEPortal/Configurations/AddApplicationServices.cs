using NewCoreApp.Configurations;

namespace NewCoreApp.Configurations
{
    public class NewCoreApp : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDALService();
            //services.AddInfrastructureServices();
            //services.AddInfrastructureSchemeServices();
            //services.AddInfrastructureGFMSServices();
			services.AddControllers();
            services.AddHttpContextAccessor();

        }
    }
}
