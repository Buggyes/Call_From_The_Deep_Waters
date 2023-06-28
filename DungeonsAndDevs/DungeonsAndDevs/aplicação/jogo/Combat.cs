using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonsAndDevs.Entidades.Personagens.Inimigos;

namespace DungeonsAndDevs.Aplicação.Jogo
{
	public class Combat
	{
		int bossCounter { get; set; }
		public Enemy Encounter(bool bossFight)
		{
			Enemy enemy = new Enemy();
			if (bossFight)
			{
				
			}
			else
			{

			}
			return enemy;
		}
	}
}
