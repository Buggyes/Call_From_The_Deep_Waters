using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndDevs.Utils;



namespace DungeonsAndDevs.Entidades.Personagens
{
	public abstract class Character
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int Strength { get; set; }
		public int Defense { get; set; }
		public List<Skill> Skills { get; set; }
		public List<DamageType> Advantages { get; set; }
		public List<DamageType> Disadvantages { get; set; }
		public List<DOT> ActiveDOTs { get; set; }
		public List<int> DOTTurnsToWearOff { get; set; }
		private Random random = new Random();
		protected Character()
		{
			Skills = new List<Utils.Skill>();
			Advantages = new List<DamageType>();
			Disadvantages = new List<DamageType>();
			ActiveDOTs = new List<DOT>();
			DOTTurnsToWearOff = new List<int>();
		}
		public int TakeSkillDamage(Skill skill, Character agressor)
		{
			ApplyDOT(skill.Type);
			double calcDamage = skill.BaseDmg;
			foreach (DamageType dt in Disadvantages)
			{
				if (dt == skill.Type)
				{
					calcDamage *= 1.20;
				}
			}
			foreach (DamageType dt in Advantages)
			{
				if (dt == skill.Type)
				{
					calcDamage *= 0.80;
				}
			}
			double strengthFactor = agressor.Strength / 100.0;
			calcDamage *= (1 + strengthFactor);
			double damageReduction = Defense / (Defense + 40);
			double finalHealth = Health - (calcDamage - (calcDamage * damageReduction));
			Health = (int)finalHealth;
			int finalDamage = (int)(calcDamage - (calcDamage * damageReduction));
			Console.WriteLine(Name+ "recebeu "+finalDamage+" de dano "+skill.Type.ToString());
            return Health;
		}
		//Fire = 70%
		//Bleed = 60%
		//Poison = 50%
		protected void ApplyDOT(DamageType damageType)
		{
			int proc = 0;
			switch (damageType)
			{
				case DamageType.fogo:
					proc = random.Next(100);
					if(proc < 70)
					{
						ActiveDOTs.Add(DOT.fogo);
						DOTTurnsToWearOff.Add(3);
					}
					break;
				case DamageType.sangramento:
					proc = random.Next(100);
					if (proc < 60)
					{
						ActiveDOTs.Add(DOT.sangramento);
						DOTTurnsToWearOff.Add(5);
					}
					break;
				case DamageType.veneno:
					proc = random.Next(100);
					if (proc < 50)
					{
						ActiveDOTs.Add(DOT.veneno);
						DOTTurnsToWearOff.Add(7);
					}
					break;
			}
		}
		public void UpdateDOTs()
		{
			int fireTotal = 0,
				bleedTotal = 0,
				poisonTotal = 0;

			for (int i = 0; i < ActiveDOTs.Count; i++)
			{
				switch (ActiveDOTs[i])
				{
					case DOT.fogo:
						Health -= 10;
						fireTotal += 10;
						DOTTurnsToWearOff[i]--;
                        if (DOTTurnsToWearOff[i] == 0)
						{
							ActiveDOTs.Remove(ActiveDOTs[i]);
							DOTTurnsToWearOff.Remove(DOTTurnsToWearOff[i]);
						}
						break;
					case DOT.sangramento:
						Health -= 8;
						bleedTotal += 8;
						DOTTurnsToWearOff[i]--;
						if (DOTTurnsToWearOff[i] == 0)
						{
							ActiveDOTs.Remove(ActiveDOTs[i]);
							DOTTurnsToWearOff.Remove(DOTTurnsToWearOff[i]);
						}
						break;
					case DOT.veneno:
						Health -= 5;
						poisonTotal += 5;
						DOTTurnsToWearOff[i]--;
						if (DOTTurnsToWearOff[i] == 0)
						{
							ActiveDOTs.Remove(ActiveDOTs[i]);
							DOTTurnsToWearOff.Remove(DOTTurnsToWearOff[i]);
						}
						break;
				}
			}
			if(fireTotal != 0)
			{
				Console.WriteLine(Name + " recebe " + fireTotal + " de dano de fogo");
			}
			if (bleedTotal != 0)
			{
				Console.WriteLine(Name + " recebe " + bleedTotal + " de dano de sangramento");
			}
			if (poisonTotal != 0)
			{
				Console.WriteLine(Name + " recebe " + poisonTotal + " de dano de veneno");
			}
		}
	}
}
