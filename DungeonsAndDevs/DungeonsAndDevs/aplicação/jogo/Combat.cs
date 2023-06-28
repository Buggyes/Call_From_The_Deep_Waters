using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonsAndDevs.Entidades.Personagens;
using DungeonsAndDevs.Entidades.Personagens.Inimigos;

namespace DungeonsAndDevs.Aplicação.Jogo
{
	struct Combat
	{
		public static void Attack(Character character, Character target, int skillIndex)
		{
			for (int i = 0; i < character.Skills.Count; i++)
			{
				if (skillIndex == i)
				{
					target.TakeSkillDamage(character.Skills[i], character);
					break;
				}
			}
		}
	}
}
