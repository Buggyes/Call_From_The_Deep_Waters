using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDevs.Entidades.Personagens.Jogador
{
	public enum PlayerClass
	{
		diver, bombardier, musketeer
	};
	public class Player : Character
	{
		public PlayerClass playerClass { get; set; }
		public Player()
		{
			Skills = new List<Utils.Skill>();
			Advantages = new List<DamageType>();
			Disadvantages = new List<DamageType>();
		}
		public void setInitialStats()
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				pickName();
			}
			switch (playerClass)
			{
				case PlayerClass.diver:
					Health = 130;
					Strength = 5;
					Defense = 20;
					Skills.Add(new Utils.Skill("Tiro de arpão", DamageType.puncture, 20, 20, false));
					Skills.Add(new Utils.Skill("Espetada de arpão", DamageType.bleed, 10, 0, false));
					Advantages.Add(DamageType.puncture);
					Advantages.Add(DamageType.cut);
					Disadvantages.Add(DamageType.eletric);
					Disadvantages.Add(DamageType.explosion);
					break;

				case PlayerClass.bombardier:
					Health = 100;
					Strength = 10;
					Defense = 5;
					Skills.Add(new Utils.Skill("Dinamite", DamageType.explosion, 25, 0, true));
					Skills.Add(new Utils.Skill("Molotov", DamageType.fire, 5, 0, true));
					Skills.Add(new Utils.Skill("Granada de Ferro", DamageType.explosion, 15, 50, true));
					Advantages.Add(DamageType.fire);
					Disadvantages.Add(DamageType.cut);
					Disadvantages.Add(DamageType.puncture);
					break;

				case PlayerClass.musketeer:
					Health = 100;
					Strength = 12;
					Defense = 10;
					Skills.Add(new Utils.Skill("Tiro de Concussão", DamageType.impact, 20, 0, false));
					Skills.Add(new Utils.Skill("Tiro Penetrante", DamageType.puncture, 16, 50, false));
					Skills.Add(new Utils.Skill("Tiro Inflamável", DamageType.explosion, 10, 0, false));
					Advantages.Add(DamageType.impact);
					Advantages.Add(DamageType.puncture);
					Disadvantages.Add(DamageType.bleed);
					Disadvantages.Add(DamageType.fire);
					break;
			}
		}
		private void pickName()
		{
			Random random = new Random();
			switch (playerClass)
			{
				case PlayerClass.diver:
					int pickedDiverName = random.Next(4);
					switch (pickedDiverName)
					{
						case 0:
							Name = "Orion Deepwater";
							break;
						case 1:
							Name = "Coraline Deepsea";
							break;
						case 2:
							Name = "Nauticus Stormrider";
							break;
						case 3:
							Name = "Triton Wavebreaker";
							break;
					}
					break;
				case PlayerClass.bombardier:
					int pickedBombName = random.Next(4);
					switch (pickedBombName)
					{
						case 0:
							Name = "Ember Blaststone";
							break;
						case 1:
							Name = "Magnus Thunderstrike";
							break;
						case 2:
							Name = "Flint Ironsides";
							break;
						case 3:
							Name = "Archer Duskwood";
							break;
					}
					break;
				case PlayerClass.musketeer:
					int pickedMuskName = random.Next(5);
					switch (pickedMuskName)
					{
						case 0:
							Name = "Valeria Silverthorn";
							break;
						case 1:
							Name = "Griffin Blackwood";
							break;
						case 2:
							Name = "Roderick Swiftblade";
							break;
						case 3:
							Name = "Isabella Moonshadow";
							break;
						case 4:
							Name = "Victor Crossfire";
							break;
					}
					break;
			}
		}
	}
}
