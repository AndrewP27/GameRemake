using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonRemake
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UtilitiesPkmTable.initTable();
            UtilitiesTmTable.initTable();
            UtilitiesItemTable.initTable();

            ChoseFight choice = new ChoseFight();
            Application.Run(choice);

            Trainer trainer1 = choice.trainer1;

            Trainer trainer2 = choice.trainer2;
            if (trainer1.askNumPokemon() > 0 && trainer2.askNumPokemon() > 0)
            {
                Form1 battle = new Form1(trainer1, trainer2);
                Application.Run(battle);

                trainer1 = battle.trainer1;
                trainer2 = battle.trainer2;
            }
        }
    }
}
