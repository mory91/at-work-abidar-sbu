using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace at_work_abidar_sbu
{
    public class Map
    {
        public List<MapObject> obstacles = new List<MapObject>();
        public double width { get; set; }
        public double height { get; set; }
        
        public void Save(string path)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, settings);
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                file.Write(json);
            }
        }

        public static Map Load(string path)
        {
            System.IO.StreamReader sr = new
               System.IO.StreamReader(path);
            string json = sr.ReadToEnd();
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            Map map = JsonConvert.DeserializeObject<Map>(json, settings);
            return map;
        }
    }
}
