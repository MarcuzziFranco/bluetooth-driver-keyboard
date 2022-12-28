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
        public ManagerConfiguration()
        {
            string jsonStringFile = File.ReadAllText("Config/settings.json");
            Configuration configuration = JsonSerializer.Deserialize<Configuration>(jsonStringFile);

            Console.WriteLine(configuration.port);
            Console.WriteLine(configuration.serialRait);
            Console.WriteLine(configuration.endOfMessage);
            Console.WriteLine(configuration.command_key_press);
            Console.WriteLine(configuration.command_key_hold);
            Console.WriteLine(configuration.command_key_released);
            Console.WriteLine(configuration.time_hold);
            Console.WriteLine(configuration.repetition_interval_time);

        }

    }
}
