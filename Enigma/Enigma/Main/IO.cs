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

		public static string convertEnigma(string input)
		{
			//Kleinschreibung zu Großschreibung
			//Satzzeichen zu 'X'
			//Zahlen ausschreiben

			string output = "";
			int temp;

			string[] zahlen = { "NULL", "EINS", "ZWEI", "DREI", "VIER", "FUENF", "SECHS", "SIEBEN", "ACHT", "NEUN" };
			char[] marks = { '.', '!', '?' };

			for (int i = 0; i < input.Length; i++)
			{
				temp = Convert.ToInt16(input[i]);

				//Zahlen
				if ((temp >= 48) && (temp <= 57))
				{
					if (output[output.Length - 1] == 'X')
					{
						output += zahlen[temp - 48] + "X";
					}
					else
					{
						output += "X" + zahlen[temp - 48] + "X";
					}
				}

				//Satzzeichen
				if (marks.Contains(input[i]))
				{
					output += "X";
				}

				//Kleinbuchstaben
				if ((temp >= 97) && (temp <= 122))
				{
					output += Convert.ToChar(temp - 32);
				}

				//Grossbuchstaben
				if ((temp >= 65) && (temp <= 90))
				{
					output += input[i];
				}
			}

			return output;
		}
    }
}
