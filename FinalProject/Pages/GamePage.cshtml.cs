using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class GamePageModel : PageModel
    {
        public void OnGet()
        {
		}

		/**************VARIABLES***********/
		enum Dice
        {
			DIE0, //{A, A, E, E, G, N};
			DIE1, //{A B B J O O};
			DIE2, //{A C H O P S};
			DIE3, //{A F F K P S};
			DIE4, //{A O O T T W};
			DIE5, //{C I M O T U};
			DIE6, //{D E I L R X};
			DIE7, //{D E L R V Y};
			DIE8, //{D I S T T Y};
			DIE9, //{E E G H N W};
			DIE10, //{ E E I N S U};
			DIE11, //{ E H R T V W};
			DIE12, //{ E I O S S T};
			DIE13, //{ E L R T T Y};
			DIE14, //{ H I M N U Qu};
			DIE15  //{ H L N N R Z };
		}
		public int score = 0;
		public int timer = 0;
		public int letterCount;
		public string[] userInputs; //might have to be an array of pointers? so we can point to the location in the boggleBoard
		public string[,] boggleBoard = new string[4,4];





		//*******Functions:




	}
}
