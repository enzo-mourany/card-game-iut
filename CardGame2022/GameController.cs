using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    /// <summary>
    /// The game controller object allows a logic (GameLogic object) and view (MainWindow object) to communicate
    /// </summary>
    internal class GameController
    {
        #region Association attributes
        private readonly GameLogic gameLogic;
        private MainWindow mainWindow;
        #endregion
        #region Properties accessed by the logic
        /// <summary>
        /// The integer (checked) entered by the current user for the current interaction.
        /// </summary>
        internal int CurrentInt { get; private set; }
        /// <summary>
        /// The possible integer inputs to choose from selectable for the user for the next interaction.
        /// </summary>
        internal List<int> AllowedInput { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor. Creates a new game logic.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players (1-10) for the new game.</param>
        internal GameController(int numberOfPlayers)
        {
            gameLogic = new GameLogic(numberOfPlayers, this);
        }
        #endregion
        #region Methods called by the logic or view
        /// <summary>
        /// Method called by the logic when the state of the game (cards on the table) should be displayed.
        /// </summary>
        /// <param name="allRows">Each row of cards as a list of list of cards.</param>
        internal void UpdateState(List<List<int>> allRows)
        {
            mainWindow.WriteLine("All rows on the table:");
            mainWindow.WriteLine(gameLogic.AllRowsToString(allRows));
            for (int i=0; i<allRows.Count; i++)
            {
                mainWindow.UpdateRow(i, allRows[i]);
            }
            for (int i = 0; i < gameLogic.GetNumberOfPlayers(); i++)
            {
                mainWindow.UpdateHand(i, gameLogic.GetCurrentHandForPlayer(i));
                mainWindow.UpdateScore(i, gameLogic.GetCurrentScoreForPlayer(i));
            }
            
        }
        /// <summary>
        /// Method called when a rubber has ended to display the scores.
        /// </summary>
        /// <param name="playersScores">The list of all scores.</param>
        internal void DisplayRubberScores(List<List<int>> playersScores)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string message = "Final scores for this rubber:\n";

            mainWindow.WriteLine("Final scores for this rubber:");
            for (int i=0; i<playersScores.Count; i++)
            {
                message += "Player " + i + ": ";
                int sum = 0;
                for (int j = 0; j < playersScores[i].Count; j++)
                {
                    sum += playersScores[i][j];
                    message += playersScores[i][j] + " + ";
                }
                message += "= " + sum + "\n";
                mainWindow.WriteLine("Player " + i + ": " + playersScores[i]);
                
            }
            MessageBox.Show(message, "", buttons);
        }
        /// <summary>
        /// Method used by the window when a command is entered.
        /// </summary>
        /// <param name="text">The command entered, shoukd be an int within AllowedInput.</param>
        internal void Interpret(string text)
        {
            if (int.TryParse(text, out int res))
            {
                if (AllowedInput.Contains(res))
                {
                    CurrentInt = res;
                    AllowedInput = null;
                    gameLogic.ActOnce();
                }
                else
                {
                    mainWindow.WriteLine("Wrong number. Please enter only from " + CardsHandling.ListOfCardsToString(AllowedInput));
                }
            }
            else
            {
                mainWindow.WriteLine("Please enter an integer.");
            }
        }
        /// <summary>
        /// Method called to start the game.
        /// </summary>
        /// <param name="mainWindow">The window (view) to use for this game.</param>
        internal void StartMeUp(MainWindow mainWindow)
        {
            this.mainWindow= mainWindow;
            DisplayNewGame(gameLogic.GetNumberOfPlayers());
            gameLogic.ActOnce();
        }
        /// <summary>
        /// Method used by the logic to say that the game has ended.
        /// </summary>
        internal void DisplayGameOverMessage()
        {
            AllowedInput = new List<int> { 0 };
            mainWindow.WriteLine("The game has ended.");
        }
        /// <summary>
        /// Method used to prompt player "player" to select a card from their hand
        /// </summary>
        /// <param name="player">The player to select</param>
        internal void AskPlayerForCard(int player)
        {
            DisplayPlayerHand(player);
            DisplayCardSelectPromptForPlayer(player);
        }
        /// <summary>
        /// Method called to display the cards selected by players
        /// </summary>
        /// <param name="cardsSelectedByPlayers">The cards arranged by player</param>
        internal void DisplayCardsSelected(Dictionary<int, int> cardsSelectedByPlayers)
        {
            mainWindow.WriteLine("The selection has ended, these are the cards played:");
            foreach (int player in cardsSelectedByPlayers.Keys)
            {
                mainWindow.WriteLine("Player "+player+" has chosen "+ cardsSelectedByPlayers[player]);
            }
            gameLogic.ActOnce();
        }

        /// <summary>
        /// Method used for feedback when a card has been played (put in a row).
        /// </summary>
        /// <param name="card">The card played.</param>
        /// <param name="player">Who has played.</param>
        internal void DisplayCardPlayedByPlayer(int card, int player) => mainWindow.WriteLine("Player " + player + " plays " + card + ".");
        /// <summary>
        /// Method called when a player has collected a row, to display the malus update.
        /// </summary>
        /// <param name="malus">The malus (score change) incurred.</param>
        /// <param name="player">The player involved.</param>
        internal void DisplayMalusForPlayer(int malus, int player)
        => mainWindow.WriteLine("Player " + player + " has just received a " + malus + " malus.");
        /// <summary>
        /// Method called when a turn has ended
        /// </summary>
        internal void DisplayEndOfTurnMessage() => mainWindow.WriteLine("This turn has ended.");
        /// <summary>
        /// Method called to end a rubber
        /// </summary>
        internal void DisplayRubberOver()
        {
            mainWindow.WriteLine("End of rubber.");
            gameLogic.ActOnce();
        }

        /// <summary>
        /// Method used to reset the input whenever necessary
        /// </summary>
        internal void ResetInput() => CurrentInt = -1;
        /// <summary>
        /// Method used to prompt a player to choose a row because their card was too low.
        /// </summary>
        /// <param name="player">The player involved.</param>
        internal void AskPlayerForRow(int player)
        => mainWindow.WriteLine("Player " + player + ", your card is lower than all rows. Please pick a row (0-3) to collect.");
        #endregion
        #region Private methods

        private void DisplayPlayerHand(int player)
        {
            mainWindow.WriteLine("Player " + player + ", this is your hand:");
            mainWindow.WriteLine(CardsHandling.ListOfCardsToString(gameLogic.GetCurrentHandForPlayer(player)));
        }
        private void DisplayNewGame(int numberOfPlayers) => mainWindow.WriteLine("Starting a new game with " + numberOfPlayers + " players.");
        private void DisplayCardSelectPromptForPlayer(int i) => mainWindow.WriteLine("Player " + i + ", what card do you choose?");
        internal void NewGame()
        {
            gameLogic.NewGame();
        }

        #endregion

    }
}
