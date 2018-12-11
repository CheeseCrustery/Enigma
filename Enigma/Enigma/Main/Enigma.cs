using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    /*
     * Buchstaben zu Zahlen: A = 0; B = 1; ... ; Z = 25
     * Turnoverpoints: Wenn der nächste Rotor bei A->B vorgeschoben wird, dann B als Wert nehmen(=1)
     * Wheelcombination: Reflektor - Walze 0 - Walze 1 - Walze 2 
    */

    public class Enigma
    {
        public string versionName;
        public int cables;
        public int wheelsPerMachine;
        public List<char[]> wheels;
        public char[,] reflector;
        public int[] turnoverPoints;

        public Connections cableConnections;
        public int[] wheelSettings;
        public int[] wheelCombination;

        public Enigma()
        {
            //debugging purposes only

            this.wheels = new List<char[]>();
            this.reflector = new char[12,2];
            this.turnoverPoints = new int[5];

            this.cableConnections = new Connections(6);
            this.wheelSettings = new int[3];
            this.wheelCombination = new int[3];
        }
        
        public Enigma(string versionName, int cables, int wheelsPerMachine, List<char[]> wheels, char[,] reflector, int[] turnoverPoints)
        {
            this.versionName = versionName;
            this.wheels = wheels;
            this.cables = cables;
            this.wheelsPerMachine = wheelsPerMachine;
            this.reflector = reflector;
            this.turnoverPoints = turnoverPoints;

            this.cableConnections = new Connections(cables);
            this.wheelSettings = new int[wheelsPerMachine];
            this.wheelCombination = new int[wheelsPerMachine];
        }

        public string toString()
        {
            //gibt die Eigenschaften der Enigma in einem String zurück
            string version, stecker, walzenProMaschine, reflektor, walzen;

            version = 
                "Version:\n" + this.versionName;
            stecker = 
                "Stecker:\n" + this.cables;
            walzenProMaschine = 
                "Walzen pro Maschine:\n" + this.wheelsPerMachine;            
            reflektor = "Reflektor:\n";
                for (int i = 0; i<26/2; i++)
                {
                    reflektor += Convert.ToString(reflector[i, 0]) + Convert.ToString(reflector[i, 1]) + " - ";
                };
            walzen = "Walzen:";
                string temp;
                for (int i = 0; i < wheels.Count; i++)
                {
                    temp = new String(wheels[i]);
                    walzen += "\n" + temp + " - " + Convert.ToString(Convert.ToChar(turnoverPoints[i] + 64));
                };

            return version + "\n\n" + stecker + "\n\n" + walzenProMaschine + "\n\n" + reflektor + "\n\n" + walzen;
        }

        public string code(string input)
        {
            string output = "";
            char newCharacter;

            //Jeden Buchstaben einzeln verschlüsseln
            foreach (char character in input)
            {
                //Walzenstellung wird um 1 nach vorne verschoben,
                //ist die 1. Walze voll, wird die nächste gedreht
                wheelSettings[wheelsPerMachine-1]++;
                for (int i = wheelsPerMachine - 1; i >= 0; i--)
                {
                    if ((wheelSettings[i] == turnoverPoints[wheelCombination[i]]) && (i > 0))
                    {
                        wheelSettings[i - 1]--;
                    }
                    if (wheelSettings[i] >= 26)
                    {
                        wheelSettings[i] = 0;
                    }
                }

                //Steckerbrett > Walzen > Reflektor > Walzen > Steckerbrett
                newCharacter = cableRoutine(character);
                for (int i = wheelsPerMachine - 1; i >= 0; i--)
                {
                    newCharacter = wheelRoutine(newCharacter, wheelCombination[i], wheelSettings[i]);
                }
                newCharacter = reflectorRoutine(newCharacter);
                for (int i = 0; i < wheelsPerMachine; i++)
                {
                    newCharacter = wheelRoutineReverse(newCharacter, wheelCombination[i], wheelSettings[i]);
                }
                newCharacter = cableRoutine(newCharacter);                

                //Der Buchstabe wird an den Output angehängt
                output += newCharacter;
            }

            return output;
        }

        private char cableRoutine(char character)
        {
            // Es wird durch jede einzelne Steckerverbindung gegangen
            for (int i = 0; i < cables; i++)
            {
                // Wenn einer der beiden Buchstaben der gesuchte ist, dann wird der Tausch durchgeführt
                if (cableConnections.data[i,0] == character)
                {
                    character = cableConnections.data[i, 1];
                    break;
                } else if (cableConnections.data[i, 1] == character)
                {
                    character = cableConnections.data[i, 0];
                    break;
                }
            }
            return character;
        }

        private char wheelRoutine(char character, int wheel, int setting)
        {           
            char[] selectedWheel = wheels[wheel];

            //Buchstabe mit (Äquivalent aus der gewählten Walze + Walzendrehung) ersetzt
            int wheelIndex = Convert.ToInt16(charCalculate(character, setting)) - 65;
            character = selectedWheel[wheelIndex];
            //Walzendrehung beim Output mit einberechnet
            character = charCalculate(character, -setting);
            return character;
        }

        private char wheelRoutineReverse(char character, int wheel, int setting)
        {
            char[] selectedWheel = wheels[wheel];

            //Drehung angewendet
            character = charCalculate(character, setting);

            //Durch wheel-Werte gegangen bis Wert gefunden, dann Index mit Drehung zurückgegeben
            for (int i = 0; i < selectedWheel.Length; i++)
            {
                if (selectedWheel[i] == character)
                {
                    character = charCalculate(Convert.ToChar(i + 65), -setting);                    
                    return character;
                }
            }

            //Falls durch Fehler kein Wert gefunden, wird 'Cancel'-Char zurückgegeben
            return Convert.ToChar(24);
        }

        private char reflectorRoutine(char character)
        {
            // Es wird durch jede einzelne Verbindung gegangen
            for (int i = 0; i < 26/2; i++)
            {
                // Wenn einer der beiden Buchstaben der gesuchte ist, dann wird der Tausch durchgeführt
                if (reflector[i, 0] == character)
                {
                    character = reflector[i, 1];
                    break;
                }
                else if (reflector[i, 1] == character)
                {
                    character = reflector[i, 0];
                    break;
                }
            }
            return character;
        }

        private char charCalculate(char character, int value)
        {
            //Hält den zurückgegebenen Char im Bereich von A-Z bzw 0-25

            int characterNumber = Convert.ToInt16(character) - 65 + value;
            if (characterNumber >= 0)
            {
                characterNumber = characterNumber % 26;
            } else
            {
                characterNumber = 26 - (Math.Abs(characterNumber) % 26);
            }
            return Convert.ToChar(characterNumber + 65);
        }
    }
}
