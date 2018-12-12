using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class _FormMain : Form
    {
        Enigma enigma;
        Form previous;
		CharacterEllipse wires;
		List<IHitbox> hitboxes;

		public _FormMain(Enigma enigma, Form previous)
        {
            InitializeComponent();
            this.enigma = enigma;
            this.previous = previous;

            hitboxes = new List<IHitbox>();
			wires = new CharacterEllipse(30, 60, 200);

			enigma.cableConnections = new Connections(new char[,] { { 'A', 'Q' }, { 'C', 'G' }, { 'A', 'T' } });

            enigma.wheelCombination[0] = 0;
            enigma.wheelCombination[1] = 1;
            enigma.wheelCombination[2] = 2;

            enigma.wheelSettings[0] = 0;
            enigma.wheelSettings[1] = 0;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            previous.Show();
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
			enigma.wheelSettings[2] = 0;

			string input = IO.convertEnigma(textBoxInput.Text);
			textBoxOutput.Text = enigma.code(input);
		}

		private void _FormMain_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black, 5);
			Font font = new Font("Arial", 16);
			Brush brush = new SolidBrush(Color.Black);
			wires.drawBody(e.Graphics, font, brush, pen);
			wires.drawConnections(e.Graphics, pen, enigma.cableConnections, MousePosition);
		}

		private void _FormMain_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < hitboxes.Count; i++)
			{
				hitboxes[i].testClick(MousePosition);
			}
		}
	}
}
