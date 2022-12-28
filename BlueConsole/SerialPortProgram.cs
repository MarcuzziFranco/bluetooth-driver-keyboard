using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Timers;
using WindowsInput.Native;
using WindowsInput;
using BlueConsole.Config;

namespace BlueConsole
{
    class SerialPortProgram
    {
        private SerialPort serialPort;
        private readonly InputSimulator inputSimulator = new InputSimulator();
        private string newBufferInput = "";
        private readonly MapKeyboard mapKeyboard;
        private VirtualKeyCode keyAction;
        private System.Timers.Timer timerHold = new System.Timers.Timer();

        private Configuration _configuration;

        public SerialPortProgram(Configuration configuration)
        {
            _configuration = configuration;

            serialPort = new SerialPort(_configuration.port,
                                        _configuration.serialRait, 
                                        Parity.None, 
                                        8);

            timerHold.Enabled = false;
            timerHold.Elapsed += new ElapsedEventHandler(EnableRepetKeyEvent);

            mapKeyboard = new MapKeyboard(_configuration.defaultMap,_configuration.ListMapsKeyboards);
            Console.WriteLine("Incoming Data:");

            serialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            serialPort.Open();

        }

      
        private void Port_DataReceived(object sender,SerialDataReceivedEventArgs e)
        {
            newBufferInput = serialPort.ReadTo(_configuration.endOfMessage);
            ProcessKeyBuffer(newBufferInput);  
        }

        private void ProcessKeyBuffer(string input)
        { 
            if (input[0] == _configuration.command_key_press){
                keyAction = mapKeyboard.GetKeyboardAction(input); 
                if((int)keyAction == _configuration.keyCodeChangeMap)
                    mapKeyboard.changeMapKeys();
                else inputSimulator.Keyboard.KeyDown(keyAction); 
            }
            if(input[0] == _configuration.command_key_hold){
                timerHold.Enabled = true;
                timerHold.Interval = _configuration.time_hold;
                timerHold.Start();
            }
            if(input[0] == _configuration.command_key_released){
                timerHold.Enabled = false;
                timerHold.Stop();             
            }
        }

        private void EnableRepetKeyEvent(object source, ElapsedEventArgs e)
        {
            timerHold.Interval = _configuration.repetition_interval_time;
            inputSimulator.Keyboard.KeyPress(keyAction);
        }

    }
}
