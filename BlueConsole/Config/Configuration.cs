using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsole.Config
{
    public class Configuration
    {
        public string port { get; set; }
        public int serialRait { get; set; }
        public string endOfMessage { get; set; }
        public string command_key_press { get; set; }
        public string command_key_hold { get; set; }
        public string command_key_released { get; set; }
        public int time_hold { get; set; }
        public int repetition_interval_time { get; set; }

    }
}
