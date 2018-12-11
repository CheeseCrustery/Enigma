using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma
{
	class CharacterEllipse
	{
		int width;
		int height;
		int x;
		int y;
		const double characterRadian = Math.PI / (26 / 2);
		HitboxCharacterEllipse[] hitboxes;

		public CharacterEllipse(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public CharacterEllipse(int x, int y, int diameter)
		{
			this.x = x;
			this.y = y;
			this.width = diameter;
			this.height = diameter;
		}

		public void drawBody(Graphics graphics, Font font, Brush brush, Pen pen)
		{
			//Circle
			graphics.DrawEllipse(pen, x, y, width, height);
			
			//Letters
			Point point;
			char character;
			for (int i = 0; i < 26; i++)
			{
				point = new Point(x + width / 2, y + height / 2);

				point.X +=
					Convert.ToInt16(Math.Cos(characterRadian * i - Math.PI / 2) * (width / 2 + font.Size) -
					font.Size / 2);
				point.Y +=
					Convert.ToInt16(Math.Sin(characterRadian * i - Math.PI / 2) * (height / 2 + font.Size) -
					font.Size / 2);

				character = Convert.ToChar(65 + i);
				graphics.DrawString(Convert.ToString(character), font, brush, point);
			}
		}

		public void drawConnections(Graphics graphics, Pen pen, Connections connections, Point mousePosition)
		{
            int arrayLength = connections.data.GetLength(0);
            for (int i = 0; i < arrayLength; i++)
			{
				switch (connections.connectionStatus(i))
				{
					case 1: graphics.DrawLine(pen, getLetterPosition(connections.data[i,0]), mousePosition); MessageBox.Show("ALARRRRRRRRRM"); break;
					case 2: graphics.DrawLine(pen, getLetterPosition(connections.data[i, 0]), getLetterPosition(connections.data[i, 1])); break;
				}
			}
		}

		private Point getLetterPosition(char character)
		{
			int characterInt = Convert.ToInt16(character) - 65;

			if ((characterInt < 0) || (characterInt > 25))
			{
				throw new ArgumentOutOfRangeException();
			}

			Point point = new Point(x + width / 2, y + height / 2);
			point.X += Convert.ToInt16(Math.Cos(characterRadian * characterInt - Math.PI / 2)) * width / 2;
			point.Y += Convert.ToInt16(Math.Sin(characterRadian * characterInt - Math.PI / 2)) * height / 2;

			return point;
		}
	}
}
