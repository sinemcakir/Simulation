using Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulation
{

	class Hero : Character
	{
		public int Speed { get; set; }

		public Hero(string name, int health, int attackPower, int position, int speed) : base(name, health, attackPower, position)
		{
			Speed = speed;
		}
	}
}
