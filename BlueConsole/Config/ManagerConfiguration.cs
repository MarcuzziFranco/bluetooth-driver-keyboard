using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace BlueConsole.Config
{

    public class ManagerConfiguration
    {
        String jsonStringFile;
        public ManagerConfiguration()
        {
          jsonStringFile = File.ReadAllText("Config/settings.json");
        }

        public Configuration LoadConfiguration()
        {
            Configuration configuration = JsonSerializer.Deserialize<Configuration>(jsonStringFile);
            return configuration;
        }

        

    }
}
