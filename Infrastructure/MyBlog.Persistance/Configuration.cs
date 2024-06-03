using Microsoft.Extensions.Configuration;

namespace MyBlog.Persistance
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MyBlog.API"));
                cfgManager.AddJsonFile("appsettings.json");
                return cfgManager.GetConnectionString("SqlServerConnection");
            }
        }
    }
}
