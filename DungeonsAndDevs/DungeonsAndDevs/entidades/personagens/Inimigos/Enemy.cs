using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDevs.Entidades.Personagens.Inimigos
{
	public class Enemy : Character
	{
		public Enemy()
		{
			Skills = new List<Utils.Skill>();
			Advantages = new List<DamageType>();
			Disadvantages = new List<DamageType>();
		}
	}
}
