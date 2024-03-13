using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinDosett
{
    internal class ReadWriteFile
    {
        public static string path = (FileSystem.Current.AppDataDirectory + "\\Files\\Medicin.txt"); 
        public static string ReadFile(string fileName)
        {
            string line = "";
            using (StreamReader reader = new StreamReader(path + fileName))
            {
                line = reader.ReadToEnd();

            }
            return line;
        }

        public static void WriteFile(string input)
        {
            using (StreamWriter writer = new StreamWriter(path, true)) 
            {
                writer.WriteLine(input);
            }
        }

    }
}
