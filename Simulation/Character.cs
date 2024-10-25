using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
	class Character
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int AttackPower { get; set; }
		public int Position { get; set; } // Düşman veya kahramanın bulunduğu konum

		public Character(string name, int health, int attackPower, int position)
		{
			Name = name;
			Health = health;
			AttackPower = attackPower;
			Position = position;
		}

		// Karakter saldırı metodu
		public void Attack(Character opponent)
		{
			opponent.Health -= AttackPower;
		}

		// Sağlık kontrolü (hayatta mı?)
		public bool IsAlive()
		{
			return Health > 0;
		}
	}

}
