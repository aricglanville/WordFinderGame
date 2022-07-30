using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

using FinalProject.Services;


namespace FinalProject.Pages
{
    public class GamePageModel : PageModel
    {

        public ApiClass apiClass { get; set; }

        public Boolean realWord;

        /**************VARIABLES***********/

        List<string[]> DieList = new List<string[]>
        {
            new string[] { "A", "A", "E", "E", "G", "N" },
            new string[] { "A", "B", "B", "J", "O", "O" },
            new string[] { "A", "C", "H", "O", "P", "S" },
            new string[] { "A", "F", "F", "K", "P", "S" },
            new string[] { "A", "O", "O", "T", "T", "W" },
            new string[] { "C", "I", "M", "O", "T", "U" },
            new string[] { "D", "E", "I", "L", "R", "X" },
            new string[] { "D", "E", "L", "R", "V", "Y" },
            new string[] { "D", "I", "S", "T", "T", "Y" },
            new string[] { "E", "E", "G", "H", "N", "W" },
            new string[] { "E", "E", "I", "N", "S", "U" },
            new string[] { "E", "H", "R", "T", "V", "W" },
            new string[] { "E", "I", "O", "S", "S", "T" },
            new string[] { "E", "L", "R", "T", "T", "Y" },
            new string[] { "H", "I", "M", "N", "U", "Qu"},
            new string[] { "H", "L", "N", "N", "R", "Z" },
        };

        List<string> ChosenWords = new List<string>();//keep track of words the user has already chosen
        
        public string[] boggleBoard = new string[16];




        /*******************************Functions****************************/
        public void OnGet()
        {
            PopulateBoard();

            apiClass = new ApiClass("asdf");
            realWord = apiClass.check;

        }

        //function to loop through the board and load a rolled die into each slot
        public void PopulateBoard()
        {
            int availableDice = 16;
            //go through each square in the boggle board
            for (int i = 0; i < boggleBoard.Length; i++ )
            {
                    boggleBoard[i] = RollDie(availableDice);
                    availableDice--;
            }
        }

        public string RollDie(int dice)
        {
            string letter = "";
            Random rnd = new Random();
            int die = rnd.Next(dice);
            int face = rnd.Next(5);

            letter = DieList[die][face];

            DieList.RemoveAt(die);//remove the die that was just rolled

            return letter.ToUpper();
        }
	}
}
