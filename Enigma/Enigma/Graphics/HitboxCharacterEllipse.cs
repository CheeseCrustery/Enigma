using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Enigma
{
	class HitboxCharacterEllipse : IHitbox
	{
		int x;
		int y;
		int width;
		int height;

		public HitboxCharacterEllipse(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public bool testClick(Point coordinates)
		{
			if (
				coordinates.X >= x &&
				coordinates.X <= x + width &&
				coordinates.Y >= y &&
				coordinates.X <= y + height
				)
			{
				return true;
			}
			return false;
		}
	}
}
