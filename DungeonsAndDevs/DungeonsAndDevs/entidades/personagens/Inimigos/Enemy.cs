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

		public void PickStats(int enemyIndex, int stage)
		{
			if (boss)
			{
				switch (enemyIndex)
				{
					case 0:
						Name = "Nerida, A Sereia";
						CurrentHealth = 250;
						Strength = 2;
						Defense = 0;
						Skills.Add(new Utils.Skill("Grito Estridente", DamageType.impacto, 8, 0, false));
						Skills.Add(new Utils.Skill("Lança das Marés", DamageType.perfuracao, 30, 0, false));
						Skills.Add(new Utils.Skill("Cuspe Ácido", DamageType.veneno, 6, 0, false));
						Advantages.Add(DamageType.sangramento);
						Disadvantages.Add(DamageType.explosao);
						break;
					case 1:
						Name = "Vorax, o Megalodon";
						CurrentHealth = 300;
						Strength = 15;
						Defense = 0;
						Skills.Add(new Utils.Skill("Fúria das Profundezas", DamageType.impacto, 10, 0, false));
						Skills.Add(new Utils.Skill("Mordida Devastadora", DamageType.sangramento, 10, 0, false));
						Skills.Add(new Utils.Skill("Torrente do Fim dos Tempos", DamageType.impacto, 30, 50, false));
						Advantages.Add(DamageType.sangramento);
						Disadvantages.Add(DamageType.explosao);
						break;
					case 2:
						Name = "Kraken, o Polvo Colossal";
						CurrentHealth = 350;
						Strength = 20;
						Defense = 20;
						Skills.Add(new Utils.Skill("Esmagamento Profundo", DamageType.impacto, 15, 0, false));
						Skills.Add(new Utils.Skill("Sopro Tempestuoso", DamageType.eletricidade, 8, 0, false));
						Skills.Add(new Utils.Skill("Abraço Abissal", DamageType.perfuracao, 12, 0, false));
						Advantages.Add(DamageType.impacto);
						Advantages.Add(DamageType.veneno);
						Disadvantages.Add(DamageType.fogo);
						break;
				}
			}
			else
			{
				switch (enemyIndex)
				{
					case 0:
						Name = "Tubarao Branco";
						CurrentHealth = 105;
						Strength = 10;
						Defense = 3;
						Skills.Add(new Utils.Skill("Fúria Aquática", DamageType.impacto, 10, 0, false));
						Skills.Add(new Utils.Skill("Presas Implacáveis", DamageType.sangramento, 6, 0, false));
						Skills.Add(new Utils.Skill("Espiral do Terror", DamageType.corte, 10, 0, false));
						Disadvantages.Add(DamageType.impacto);
						break;
					case 1:
						Name = "Cardume de Tainha";
						CurrentHealth = 98;
						Strength = 3;
						Defense = 10;
						Skills.Add(new Utils.Skill("Frenesi Aquático", DamageType.impacto, 10, 0, false));
						Skills.Add(new Utils.Skill("Investida Coletiva", DamageType.perfuracao, 12, 0, false));
						Skills.Add(new Utils.Skill("Redemoinho Prateado", DamageType.sangramento, 7, 0, false));
						Advantages.Add(DamageType.perfuracao);
						Disadvantages.Add(DamageType.explosao);
						break;
					case 2:
						Name = "Água Viva";
						CurrentHealth = 95;
						Strength = 10;
						Defense = 10;
						Skills.Add(new Utils.Skill("Choque Elétrico", DamageType.eletricidade, 10, 10, false));
						Skills.Add(new Utils.Skill("Lesão Arremetida", DamageType.fogo, 8, 0, false));
						Skills.Add(new Utils.Skill("Dança Tóxica", DamageType.veneno, 6, 0, false));
						Advantages.Add(DamageType.perfuracao);
						Disadvantages.Add(DamageType.explosao);
						break;
				}
			}
			double calcHealth = CurrentHealth + (CurrentHealth * (stage / 100));
			CurrentHealth = (int)calcHealth;
			double calcStrength = Strength + (Strength * (stage / 100));
			Strength = (int)calcStrength;
			double calcDefense = Defense + (Defense * (stage / 100));
			Defense = (int)calcDefense;
			MaximumHealth = CurrentHealth;
		}
	}
}
