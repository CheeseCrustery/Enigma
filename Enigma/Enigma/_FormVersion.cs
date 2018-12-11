using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Enigma
{
    public partial class _FormVersion : Form
    {
        private Enigma enigma;

        public _FormVersion()
        {
            InitializeComponent();
        }

        private void buttonChooseVersion_Click(object sender, EventArgs e)
        {
            
            string path = IO.chooseFile("Enigma auswählen", "JSON-Dateien|*.json");
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            enigma = JsonConvert.DeserializeObject<Enigma>(data);

            richTextBoxVersion.Text = enigma.toString();
            
            buttonNext.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Form next = new _FormMain(enigma, this);
            next.Show();
            this.Hide();
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            enigma = new Enigma();
            Form next = new _FormMain(enigma, this);
            next.Show();
            this.Hide();
        }
    }
}
