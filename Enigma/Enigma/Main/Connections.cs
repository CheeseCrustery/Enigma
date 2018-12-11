using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
	public struct Connections
	{
		public char[,] data { get; }

		public Connections(int length)
		{
			data = new char[length, 2];
		}

		public Connections(char[,] array)
		{
			if (array.GetLength(1) != 2)
			{
				throw new ArgumentOutOfRangeException();
			}
			data = array;
		}

		public static Connections operator +(Connections connections, char character)
		{
			for (int i = 0; i < connections.data.GetLength(0); i++)
			{
				for (int j = 0; j <= 1; j++)
				{
					if (!connections.inRange(connections.data[i, j]))
					{
						connections.data[i, j] = character;
						return connections;
					}
				}
			}
			return connections;
		}

		public static Connections operator -(Connections connections, char character)
		{
			for (int i = 0; i < connections.data.GetLength(0); i++)
			{
				for (int j = 0; j <= 1; j++)
				{
					if (connections.data[i,j] == character)
					{
						connections.data[i, 0] = '\0';
						connections.data[i, 1] = '\0';
						return connections;
					}
				}
			}
			return connections;
		}

		public bool isFull()
		{
			for (int i = 0; i < data.Length/2; i++)
			{
				if ((!inRange(data[i,0])) || (!inRange(data[i, 1]))) {
					return false;
				}
			}
			return true;
		}

		public int connectionStatus(int i)
		{
			// 0: No connection
			// 1: Cable selected, but not connected
			// 2: Full connection

			if (!inRange(data[i,0]) && !inRange(data[i, 1]))
			{
				return 0;
			} else if (!inRange(data[i, 1]))
			{
				return 1;
			}

			return 2;
		}

		bool inRange(char character)
		{
			if ((Convert.ToInt16(character) >= 65) && (Convert.ToInt16(character) <= 90))
			{
				return true;
			}
			return false;
		}
	}
}
