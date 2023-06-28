using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		private static void AskKey()
		{
			Console.WriteLine("(pressione qualquer tecla para continuar)");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
