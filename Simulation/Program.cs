
using Simulation;

namespace Simulation
{
	class Program
	{

		static void Main(string[] args)
		{
			Hero hero = new Hero("Kahraman", 450, 10, 0, 1); // Kahraman 100 HP, 10 saldırı gücü, 0 metre başlangıç
			int distance = 5000;  // Kahramanın gitmesi gereken toplam mesafe


			// Düşmanların oluşturulması ve konum bilgileri
			List<Character> enemies = new List<Character>
		{
			new Character("Böcek", 50, 10, 1524),  // İlk düşman 50 HP, 10 saldırı gücü, 1000 metre konum
                        new Character("Aslan", 75, 15, 2546),   // İkinci düşman 75 HP, 15 saldırı gücü, 3000 metre konum
			new Character("Zombi", 120,20,4500),
			new Character("Mutant", 50,5,500),
		};

			List<Character> orderedEnemies = enemies.OrderBy(enemy => enemy.Position).ToList(); // düşmanları pozisyona göre sıraladı.

			// Kahraman ve düşmanların başlangıç bilgileri
			Console.WriteLine($"Kaynak Uzaklığı {distance} metrede");
			Console.WriteLine($"Kahraman bilgileri: İsim = {hero.Name}, Sağlık = {hero.Health}, Saldırı Gücü = {hero.AttackPower}");
			Console.WriteLine("-------------------------------------------");
			foreach (var enemy in orderedEnemies)
			{
				Console.WriteLine($"Düşman bilgileri: İsim = {enemy.Name}");
				Console.WriteLine($"Düşman bilgileri: Sağlık = {enemy.Health}");
				Console.WriteLine($"Düşman bilgileri: Gücü = {enemy.AttackPower}");
				Console.WriteLine("-------------------------------------------");
			}
			foreach (var enemy in orderedEnemies)
			{
				Console.WriteLine($"{enemy.Position} Metrede {enemy.Name} var");

			}
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine($"Kahraman yolculuğa {hero.Health} Sağlık ile başladı!  ");

			// Her bir düşmanla karşılaşma simülasyonu
			foreach (var enemy in orderedEnemies)
			{
				// Kahraman düşmanın konumuna kadar ilerliyor
				while (hero.Position < enemy.Position)
				{
					hero.Position += hero.Speed;

				}

				Console.WriteLine($"Kahraman {hero.Position} metrede {enemy.Name} ile karşılaştı!");

				// Savaş başlıyor ve sonucu hemen yazdırılıyor
				while (hero.IsAlive() && enemy.IsAlive())
				{
					hero.Attack(enemy);
					if (enemy.IsAlive())
					{
						enemy.Attack(hero);
					}

					// Savaş sonucunun direkt gösterimi
					if (!hero.IsAlive())
					{
						Console.WriteLine($"Kahraman {hero.Position} metrede öldü! Simülasyon sona erdi.");
						return; // Simülasyon sona eriyor
					}
					else if (!enemy.IsAlive())
					{
						enemy.Attack(hero);//Aynı sayıda vuruş yaptıkları için son bir düşman saldırısına ihtiyaç vardı
						Console.WriteLine($"{enemy.Name} yenildi! Kahraman yolculuğuna {hero.Health} sağlık ile devam ediyor.");
						break; // Savaş bitince diğer düşmana geçiyoruz
					}
				}
			}

			// Tüm düşmanlar yenildiyse
			if (hero.IsAlive())
			{
				Console.WriteLine("Kahraman hayatta kaldı ve yolculuğunu başarıyla tamamladı!");
			}
		}

	}
}
