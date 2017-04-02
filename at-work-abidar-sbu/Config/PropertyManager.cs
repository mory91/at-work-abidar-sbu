using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace at_work_abidar_sbu
{
    class PropertyManager
    {
        private static PropertyManager instance;
        Dictionary<string , Dictionary<string,string>> properties =
            new Dictionary<string, Dictionary<string, string>>();
        private PropertyManager()
        {

        }
        public static PropertyManager i => instance ?? (instance = new PropertyManager());

        public void Load(string config)
        {
            Monitor.Enter(properties);
            if (properties.ContainsKey(config))
                properties.Remove(config);

            Dictionary<string, string> property = new Dictionary<string, string>();
            string jsondata = System.IO.File.ReadAllText(config+".json");
            property = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsondata);
            properties.Add(config,property);
            Monitor.Exit(properties);            
        }

        public double GetDoubleValue(string config, string key)
        {
            return Convert.ToDouble(properties[config][key]);
        }
        public int GetIntValue(string config, string key)
        {
            return Convert.ToInt32(properties[config][key]);
        }
        public string GetStringValue(string config, string key)
        {
            return properties[config][key];
        }

        public Dictionary<string, string> GetConfig(string config)
        {
            return properties[config];
        }

        public void SaveConfig(string config , Dictionary<string, string> property)
        {
            
            string json = JsonConvert.SerializeObject(property);
            System.IO.File.WriteAllText(config + ".json", json);
            Console.Write(json);

        }
    }
}
