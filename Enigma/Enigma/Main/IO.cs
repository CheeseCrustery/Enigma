using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Enigma
{
    class IO
    {
        public static string chooseFile(string title, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;

            do
            {
                dialog.ShowDialog();
            } while (!dialog.CheckFileExists);

            return dialog.FileName;
        }

        /*
        public static Enigma deserializeEnigma(string path)
        {
            string versionName = null;
            List<char[]> wheels = new List<char[]>();
            int cables = 0;
            int wheelsPerMachine = 0;
            char[] reflector = new char[26];

            string line;
            StreamReader reader = new StreamReader(path);
            string variable = "";

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line[0] == '>')
                {
                    variable = line.Substring(1);
                }
                else if (line != "")
                {
                    switch (variable)
                    {
                        case "versionName":
                            versionName = line;
                            break;
                        case "cables":
                            cables = Convert.ToInt16(line);
                            break;
                        case "wheels":
                            wheels.Add(line.ToCharArray());
                            break;
                        case "wheelsPerMachine":
                            wheelsPerMachine = Convert.ToInt16(line);
                            break;
                        case "reflector":
                            if (Convert.ToInt16(line[0]) < Convert.ToInt16(line[1]))
                            {
                                reflector[Convert.ToInt16(line[0]) - 65] = line[1];
                            }
                            else
                            {
                                reflector[Convert.ToInt16(line[1]) - 65] = line[0];
                            };
                            break;
                        default:
                            MessageBox.Show("Fehler:\n Falsche Variable in Enigma-Datei");
                            break;
                    };
                };
            };
            return new Enigma(versionName, cables, wheelsPerMachine, wheels, reflector);
        }
        */
        
    }
}
