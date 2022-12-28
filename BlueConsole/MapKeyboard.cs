using BlueConsole.Config;
using System;
using System.Collections.Generic;
using WindowsInput.Native;


namespace BlueConsole
{
    public class MapKeyboard
    {
        private List<Dictionary<string, VirtualKeyCode>> listMapKeyboars = new List<Dictionary<string, VirtualKeyCode>>();
        private int mapSelect = 1;
        private readonly List<ListMapsKeyboard> _configurationListMapsKeys;
        private readonly int defaultMapSelect;
        public MapKeyboard(int defaultMap,List<ListMapsKeyboard> configurationListMapsKeys)
        {
            _configurationListMapsKeys = configurationListMapsKeys;
            defaultMapSelect = defaultMap; 
            mapSelect = defaultMapSelect;
            LoadConfigurationKeysMaps();
        }

        private void LoadConfigurationKeysMaps()
        {
            int mapCount = -1;
            _configurationListMapsKeys.ForEach(map =>
            {
                mapCount++;
                listMapKeyboars.Add(new Dictionary<string, VirtualKeyCode>());
                for (int i = 0; i < map.ListKeys.Count; i++)
                {
                    var key = map.ListKeys[i];
                    listMapKeyboars[mapCount].Add("P-" + key.hardwareEntryCode, (VirtualKeyCode)key.outputCodeVk);
                }
            });
        }

        public VirtualKeyCode GetKeyboardAction(string keyCodePress)
        {         
            return listMapKeyboars[mapSelect][keyCodePress];    
        }

        public void changeMapKeys()
        {
            if (mapSelect < listMapKeyboars.Count-1) mapSelect++;
            else mapSelect = defaultMapSelect;
        }

        //Depercate
        private string FilterCodeAction (string keyCodePress)
        {
            string code = String.Concat(keyCodePress[0],keyCodePress[1],keyCodePress[2]);
            return code;

        }

        
    }
}
