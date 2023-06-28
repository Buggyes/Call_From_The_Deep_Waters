using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDevs.Entidades.Personagens.Inimigos
{
	public class Enemy : Character
	{
		public bool boss { get; set; }
		public void PickStats(int enemyIndex)
		{
			if (boss)
			{
				switch (enemyIndex)
				{
					case 0:
						Name = "Tubarao Branco";
						Health = 105;
						Strength = 5;
						Defense = 3;
						Skills.Add(new Utils.Skill("Fúria Aquática", DamageType.impacto, 10, 0, false));
						Skills.Add(new Utils.Skill("Presas Implacáveis", DamageType.sangramento, 5, 0, false));
						Skills.Add(new Utils.Skill("Espiral do Terror", DamageType.corte, 10, 0, false));
						Disadvantages.Add(DamageType.corte);
						Disadvantages.Add(DamageType.perfuracao);
						break;
					case 1:
						break;
					case 2:
						break;
				}
			}
			else
			{
				switch (enemyIndex)
				{
					case 0:
						break;
					case 1:
						break;
					case 2:
						break;
				}
			}
		}
	}
}
