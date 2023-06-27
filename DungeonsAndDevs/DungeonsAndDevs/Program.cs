using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndDevs.Entidades.Personagens;
using DungeonsAndDevs.Entidades.Personagens.Jogador;

namespace DungeonsAndDevs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player pl = new Player();
            pl.playerClass = PlayerClass.diver;
            pl.setInitialStats();
            pl.TakeSkillDamage(pl.Skills[0]);
		}
    }
}
