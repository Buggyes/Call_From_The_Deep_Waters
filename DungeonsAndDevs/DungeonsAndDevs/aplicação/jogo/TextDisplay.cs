using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using DungeonsAndDevs.Entidades.Personagens;
using DungeonsAndDevs.Entidades.Personagens.Inimigos;
using DungeonsAndDevs.Entidades.Personagens.Jogador;
using DungeonsAndDevs.Utils;

namespace DungeonsAndDevs.Aplicação.Jogo
{
	struct TextDisplay
	{
		public static void DisplayTitle()
		{
			string title = 
@" ,--.     .  .   .-,--'                .  .         .-,--.                ,.   ,   ,.   .              
| `-' ,-. |  |    \|__ ,-. ,-. ,-,-.   |- |-. ,-.   ' |   \ ,-. ,-. ,-.   `|  /|  / ,-. |- ,-. ,-. ,-. 
|   . ,-| |  |     |   |   | | | | |   |  | | |-'   , |   / |-' |-' | |    | / | /  ,-| |  |-' |   `-. 
`--'  `-^ `' `'   `'   '   `-' ' ' '   `' ' ' `-'   `-^--'  `-' `-' |-'    `'  `'   `-^ `' `-' '   `-' 
                                                                    |                                  
                                                                    '                                  ";
            Console.WriteLine(title);
			AskKey();
		}
		public static void DisplayEnemyArt(Enemy enemy, int enemyIndex)
		{
			string enemyArt = "";
			if (enemy.boss)
			{
				switch (enemyIndex)
				{
					case 0:
						enemyArt = @"         ..                                                 
       ::::.                                                
        ---.                                                
        .--                                                 
         :-       .:--=+++=:                                
        .+=:---=+**###%@#***-       .                       
    .:-=+++%%%####%%@@@@%#*#.     .==                       
    .-=****%%@@@@@@@@@%###*-      .=                        
         .::-=======**++++++++=:  =:                        
          :       .=*+**-=++=-=+*++            ..           
         .:   .:-=*=. =#*++++:   .. :+:    .:=+=.           
         -=+=---::    -**++*:       +*+-.:+***+=            
          :          =++***=       :+*******++=.            
          :        .+====++-        +===++==++-             
          :    ..:-==--:---=.       -------=+=...           
          -       :+=-::--==:-::     :::::.:-===+===-.      
          :        +=--:----:      ...::::::----=++***+=-.  
          -        .==--::::-:.  ..=::-----:--==***+++=:    
          :          :==--::::---:::::-=-:.:=-=*++=-.       
          :             :-==--=------=:     ==++*-          
                           .:-----:. ...     :++**:         
                                                ..:         ";
						break;
					case 1:
						enemyArt = @"                         .=*#:                              
                       .=###-                               
                      -*####:                               
                    .+#####%+                               
                .-=*#########:                              
          :-=+****#############+-:                   .::--: 
      .-+*+**######################*==+        .:=+*###*=.  
   .-******#############################**++++*#####+:      
  -#**#*#############%%%%%%%%%%%%%%%%%%%*+=-*%%%%#=         
 .#########%%%%%%%%%%%%%%%%%%%%%%###+-=-    :%#%%:          
  ######%%%%#####****####%%%%%####+          =%%#           
   +##############**###**#########+:.         -#*           
    .*######**##########***************+:       -           
      =*##*+**######*+=:     .:-=+****####+-.               
                                    .:-======.              ";
						break;
					case 2:
						enemyArt = @"                     :-====-:                     
                    =+++=-====                    
                   -**++=====+=                   
                 .:*#*+======*+:.                 
               :+++*##**+=+****===:               
     .--:     :*++-:+**#*+++**:-===-     --:.     
    =+-.    .:+#********++++++===+++:     ::-=    
   -++++---++++++******+==-====++===+++-::-+==-   
    :=+*********+*++**+===--=====+==========+=.   
       :#*#**+++++***++===-:-========+++**+.      
 -=+-: .##*+==+++**+++====-:::-====--==+**. .:::. 
-====-=++++++*****++===+++=-::-=++++==--=+=..-=-=:
 .:---===-=++***##*==-=****+=--=+*++++++=======--.
           .:::=#*+--+#****##+=-=*=-:.            
          -+==-:*====-..   .:=*+=+:-=-=-          
          .=+====--.           :=++==--:          ";
						break;
				}
			}
			else
			{
				switch (enemyIndex)
				{
					case 0:
						enemyArt = @"                       ..                         
                    .=##.                         
                   =*##=                          
                 .*####+                          
             .:=+#######:                         
       .:-=+**############+-.              .:--=: 
    .-+*+######*##############*#=:..  .-=*###+-.  
  :*****##########%%%%##%##%%%%%%%%#####%%*:      
 :########%%%%%%%%%%%%%%%%%%%##+*.   #%%#:        
 -#####%%%#####**####%%%%###*.       :#%#         
  :+###############**#######*-:.      .*+         
    =#####*#########=-==+*******#+-.    .         
     .---::------:.       .:--=+*###*-            ";
						break;
					case 1:
                        enemyArt = @"            .                                     
       :=**#@#+=-=+.     .:-=#-:. .-.             
       .-++**+--..-.    =#%%####*=++.             
                           ..-                    
                                                  
    .:=*.    -       ..+=     :      -=+*@+--:-=. 
  +%%%%%###=*+    .*@%@@%##*+#-     -+####*++:-=. 
    ...-.            ..:-..              .        
                                                  
                          :-=*#-:..:=             
       -==*@+-::-=.      +#%%###*+-==             
      -+####*++:-=.          .:                   
           .             .                        
                    .=+*#@%++--*-                 
                     -=+***=-:.--                 ";
						break;
					case 2:
                        enemyArt = @"           :+#%%%%*+-.        
        .+@@@@@@@@@@@@@*:     
       =@@@@@@@@@@@@@@@@@#    
     .#@@@@@@@@@@@@@@@@@@@%   
    :@@@@@@@@@@@@@@@@@@@@@@-  
   :@@@@@@@@@@@@@@@@@@@@@@@:  
 -*@@@@@@@@@@@@@@@@@@@@@@@@:  
-####*@@@@@@@@@@@@@@@@@@@@@*  
   +  .:=--=*=+####@@@@@@@@@%:
   -:::=:- =: - :-.-:+=+#+#@@%
   ==. =. - *  -.= -+  :. =:  
 :=  - .*:  * :: -:-.+  - +   
 *  ::+:-  :=-  .+.: =:-  -:  
.+    *  .-- : -- .:-- -   +  
     --  +    .=   :- .. --   
         -     +.   *   *     
                :   :   +.    
";
						break;
				}
			}
            Console.WriteLine(enemyArt);
        }
		public static void DisplayLore()
		{
			Console.WriteLine("Em um mundo vasto e misterioso, um dos três destemidos aventureiros ");
            Console.WriteLine("- o mergulhador experiente, o artilheiro especialista em explosivos ");
            Console.WriteLine("e o mosqueteiro habilidoso - embarcam em uma expedição em busca do");
            Console.WriteLine("lendário \"Tesouro das Profundezas\". Rumores dizem que o tesouro");
            Console.WriteLine("está escondido em uma ilha remota, cercada de perigosas criaturas");
            Console.WriteLine("marinhas.");
            AskKey();
		}
		public static void DisplayContext(string playerName)
		{
            Console.WriteLine(playerName+" embarca em sua jornada ao Tesouro das Profundezas.");
			AskKey();
		}
		public static void DisplayEnemy(Enemy enemy)
		{
			if (enemy.boss)
			{
                Console.WriteLine("Boss: "+enemy.Name);
            }
			else
			{
                Console.WriteLine("Inimigo: "+enemy.Name);
            }
			Console.WriteLine("Vida: " + enemy.CurrentHealth + "/" + enemy.MaximumHealth);
            Console.WriteLine("Força: "+enemy.Strength);
            Console.WriteLine("Defesa: "+enemy.Defense);
            Console.WriteLine();
        }
		public static void DisplayPlayer(Player player)
		{
            Console.WriteLine(player.playerClass.ToString()+"(a): "+player.Name);
            Console.WriteLine("Vida: " + player.CurrentHealth + @"/" + player.MaximumHealth);
			Console.WriteLine("Força: " + player.Strength);
			Console.WriteLine("Defesa: " + player.Defense);
            Console.WriteLine("\nHabilidades: ");
            int skillcount = 0;
            foreach (Skill skill in player.Skills)
            {
                Console.WriteLine((skillcount+1)+" - "+skill.Name+"("+skill.Type.ToString()+")");
                Console.WriteLine("Dano base = "+skill.BaseDmg+"\n");
                skillcount++;
            }
        }
		public static void DisplayDeath(Character player, Character enemy)
		{
			Random random = new Random();
			int randDeath = random.Next(5);
			switch (randDeath)
			{
				case 0:
                    Console.WriteLine(player.Name+" foi brutalmente dilacerado(a) por um(a) "+enemy.Name);
                    break;
				case 1:
					Console.WriteLine(player.Name + " não conseguiu finalizar o(a) " + enemy.Name);
					break;
				case 2:
					Console.WriteLine(player.Name + " viu uma luz no fim do tunel após receber um golpe do(a) " + enemy.Name);
					break;
				case 3:
					Console.WriteLine(player.Name + " bateu as botas enquanto lutava contra o(a) " + enemy.Name);
					break;
				case 4:
					Console.WriteLine(player.Name + " perdeu a consciência enquanto lutava contra " + enemy.Name);
					break;
			}
			AskKey();
		}
		public static void AskKey()
		{
			Console.WriteLine("(pressione qualquer tecla para continuar)");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
