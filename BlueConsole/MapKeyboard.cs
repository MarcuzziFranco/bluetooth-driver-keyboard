using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;
namespace BlueConsole
{
    public class MapKeyboard
    {
        private List<Dictionary<string, VirtualKeyCode>> listMapKeyboars = new List<Dictionary<string, VirtualKeyCode>>();
        private int defaultMap = 0;
        public MapKeyboard()
        {
            listMapKeyboars.Add(new Dictionary<string, VirtualKeyCode>()); 
            listMapKeyboars[0].Add("P-1", VirtualKeyCode.VK_O);
            listMapKeyboars[0].Add("P-2", VirtualKeyCode.VK_P);
            listMapKeyboars[0].Add("P-3", VirtualKeyCode.RIGHT);
            listMapKeyboars[0].Add("P-4", VirtualKeyCode.LEFT);
            listMapKeyboars[0].Add("P-5", VirtualKeyCode.END);
            listMapKeyboars[0].Add("P-6", VirtualKeyCode.SPACE);

        }

        public VirtualKeyCode GetKeyboardAction(string keyCodePress)
        {
            //Console.WriteLine(keyCodePress);
            return listMapKeyboars[defaultMap][keyCodePress];    
        }

        //Depercate
        private string FilterCodeAction (string keyCodePress)
        {
            string code = String.Concat(keyCodePress[0],keyCodePress[1],keyCodePress[2]);
            return code;

        }

        
    }
}
