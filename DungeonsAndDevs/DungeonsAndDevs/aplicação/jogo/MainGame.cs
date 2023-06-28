using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonsAndDevs.Entidades.Personagens;
using DungeonsAndDevs.Entidades.Personagens.Inimigos;
using DungeonsAndDevs.Entidades.Personagens.Jogador;

namespace DungeonsAndDevs.Aplicação.Jogo
{
	public class MainGame
	{
		public static void Game()
		{
			Random random = new Random();
			TextDisplay.DisplayTitle();
			TextDisplay.DisplayLore();
            bool quitGame = false;
			do
			{
				Console.Clear();
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
				player.setInitialStats();
				TextDisplay.DisplayContext(player.Name);
				bool gameEnded = false;
				int bossCountdown = 0;
				int stage = 0;
				do
				{
					bossCountdown++;
					stage++;
					int rollEnemy = random.Next(3);
					Enemy enemy = new Enemy();
					if(bossCountdown >= 3)
					{
						rollEnemy = random.Next(3);//caso adicionemos mais inimigos do que bosses ou vice versa
						enemy.boss = true;
						bossCountdown = 0;
					}
					enemy.PickStats(rollEnemy,stage);
					player.CurrentHealth = player.MaximumHealth;
					player.ActiveDOTs.Clear();
					player.DOTTurnsToWearOff.Clear();
					do
					{
					PlayerTurn:
						TextDisplay.DisplayEnemyArt(enemy,rollEnemy);
						TextDisplay.DisplayEnemy(enemy);
						TextDisplay.DisplayPlayer(player);
						player.UpdateDOTs();
						string selectedSkill = Console.ReadLine();
						if (int.TryParse(selectedSkill, out int result))
						{
							int selectedSkillInt = int.Parse(selectedSkill);
							selectedSkillInt--;
							if(selectedSkillInt < player.Skills.Count)
							{
								Combat.Attack(player, enemy, selectedSkillInt);
							}
							else
							{
								goto PlayerTurn;
							}
						}
						else
						{
							goto PlayerTurn;
						}
						enemy.UpdateDOTs();
						if (enemy.CurrentHealth > 0)
						{
							int enemyAttack = random.Next(enemy.Skills.Count);
							Combat.Attack(enemy, player, enemyAttack);
						}
						TextDisplay.AskKey();
					} while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0);
					if(player.CurrentHealth <= 0)
					{
						TextDisplay.DisplayDeath(player, enemy);
                        gameEnded = true;
					}
					else
					{
						player.CurrentExp = enemy.GiveXP(player.CurrentExp);
						player.checkLevel();
					}
				} while (!gameEnded);

			QuitScreen:
				Console.WriteLine("Sair do jogo?");
				Console.WriteLine("1 - Sim");
				Console.WriteLine("2 - Não");
				string yesNo = Console.ReadLine();
				if (yesNo.Equals("1") || yesNo.Equals("2"))
				{
					int yesNoInt = int.Parse(yesNo);
					switch (yesNoInt)
					{
						case 1:
							quitGame = true;
							break;
						case 2:
							break;
						default:
							goto QuitScreen;
					}
				}
				else
				{
					Console.Clear();
					goto QuitScreen;
				}
			} while (!quitGame);
		}

	}
}
