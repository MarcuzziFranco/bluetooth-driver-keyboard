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

namespace BlueConsole
{
    class SerialPortProgram
    {

        private static char  COMMAND_KEY_PRESS = 'P';
        private static char COMMAND_KEY_HOLD = 'H';
        private static char COMMAND_KEY_RELEASED = 'R';
        private static int TIME_HOLD = 600;
        private static int REPETITION_INTERVAL_TIME = 25;

        private SerialPort serialPort = new SerialPort("COM6", 9600, Parity.None, 8);
        private readonly InputSimulator sim = new InputSimulator();
        private string newBufferInput = "";
        private readonly string endOfMessage = "@";
        private readonly MapKeyboard mapKeyboard;
        private VirtualKeyCode keyAction;
        private System.Timers.Timer timerHold = new System.Timers.Timer();
      

        public SerialPortProgram()
        { 
            timerHold.Enabled = false;
            timerHold.Elapsed += new ElapsedEventHandler(EnableRepetKeyEvent);

            mapKeyboard = new MapKeyboard();
            Console.WriteLine("Incoming Data:");

            serialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            serialPort.Open();

        }

      
        private void Port_DataReceived(object sender,SerialDataReceivedEventArgs e)
        {
            newBufferInput = serialPort.ReadTo(endOfMessage);
            ProcessKeyBuffer(newBufferInput);  
        }

        private void ProcessKeyBuffer(string input)
        { 
            if (input[0] == COMMAND_KEY_PRESS){
                keyAction = mapKeyboard.GetKeyboardAction(input);  
                sim.Keyboard.KeyDown(keyAction);    
            }
            if(input[0] == COMMAND_KEY_HOLD){
                timerHold.Enabled = true;
                timerHold.Interval = TIME_HOLD;
                timerHold.Start();
            }
            if(input[0] == COMMAND_KEY_RELEASED){
                timerHold.Enabled = false;
                timerHold.Stop();             
            }
        }

        private void EnableRepetKeyEvent(object source, ElapsedEventArgs e)
        {
            timerHold.Interval = REPETITION_INTERVAL_TIME;
            sim.Keyboard.KeyPress(keyAction);
        }

    }
}
