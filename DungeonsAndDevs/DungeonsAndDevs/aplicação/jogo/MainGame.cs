using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonsAndDevs.Entidades.Personagens;
using DungeonsAndDevs.Entidades.Personagens.Jogador;

namespace DungeonsAndDevs.Aplicação.Jogo
{
	public class MainGame
	{
		public static void Game()
		{
			TextDisplay.DisplayTitle();
			TextDisplay.DisplayLore();
            bool quitGame = false;
			do
			{
			ChooseClass:
				Player player = new Player();
                Console.WriteLine("Escolha uma classe:");
                Console.WriteLine("1 - Mergulhador");
                Console.WriteLine("2 - Artilheiro");
                Console.WriteLine("3 - Mosqueteiro");
				string choice = Console.ReadLine();
				if (choice.Equals("1") || choice.Equals("2") || choice.Equals("3"))
				{
					int choiceInt = int.Parse(choice);
					player.playerClass = (PlayerClass)choiceInt-1;
				}
				else
				{
					Console.Clear();
                    goto ChooseClass;
				}
                Console.WriteLine("Nome do seu personagem:");
				player.Name = Console.ReadLine();
				Console.Clear();
				TextDisplay.DisplayContext(player.Name);
            } while (!quitGame);
		}

	}
}
