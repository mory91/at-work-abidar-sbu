using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class LabelHandler
    {
        private Dictionary<string, int> names = new Dictionary<string, int>();
        private Dictionary<int, string> numbers = new Dictionary<int, string>();
        public LabelHandler()
        {
            try
            {
                List<string> folderNames = File.ReadAllText("labels.text", Encoding.ASCII).Split('-').ToList();
                int labelNum = 1;
                foreach (var dir in folderNames)
                {
                    string[] images = Directory.GetFiles(dir);
                    foreach (var image in images)
                    {
                        names.Add(dir, labelNum); // HERE!
                        numbers.Add(labelNum, image);
                    }
                    labelNum++;
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }

        public int getNumber(string s)
        {
            return names[s];
        }

        public string getName(int n)
        {
            return numbers[n];
        }
    }
}
