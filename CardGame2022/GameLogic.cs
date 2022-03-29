using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2022
{
    /// <summary>
    /// This object handles the business (logic, non-graphic) part of a game
    /// </summary>
    internal class GameLogic
    {
        #region Association attributes
        private GameRubber currentRubber;
        private readonly GameController gameController;
        #endregion
        #region Private attributes
        private List<int> playersScores;
        private int numberOfPlayers;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor. Creates a new rubber
        /// </summary>
        /// <param name="numberOfPlayers">The number of players</param>
        /// <param name="gameController">The reference to the controller for this game</param>
        internal GameLogic(int numberOfPlayers, GameController gameController)
        {
            this.gameController = gameController;
            this.numberOfPlayers = numberOfPlayers;
            UpdateRubber(this.numberOfPlayers);
            playersScores = new List<int>();
            for (int i=0; i<this.numberOfPlayers;i++)
            {
                playersScores.Add(0);
            }
        }
        #endregion
        #region Methods called by the controller
        /// <summary>
        /// Method called by the controller when something needs to be done.
        /// </summary>
        internal void ActOnce()
        {
            if (currentRubber != null)
            {
                bool finished = UpdatePlayerScores(currentRubber.OneAction());
                if (finished)
                {
                    gameController.DisplayRubberScores(playersScores);
                    currentRubber = null;
                    gameController.DisplayGameOverMessage();
                }
            }
            else
            {
                gameController.DisplayGameOverMessage();
            }
        }
        /// <summary>
        /// Method to get all rows as a string for display purposes
        /// </summary>
        /// <param name="allRows">List of row (list of cards)</param>
        /// <returns></returns>
        internal string AllRowsToString(List<List<int>> allRows)
        {
            return CardsHandling.AllRowsToString(allRows);
        }
        /// <summary>
        /// Number of players access method
        /// </summary>
        /// <returns>The number of players</returns>
        internal int GetNumberOfPlayers()
        {
            return currentRubber.NumberOfPlayers;
        }
        /// <summary>
        /// Hand of player access method
        /// </summary>
        /// <param name="player">The selected player</param>
        /// <returns>The list of cards that is the hand of the player</returns>
        internal List<int> GetCurrentHandForPlayer(int player)
        {
            return currentRubber.GetCurrentHandForPlayer(player);
        }
        /// <summary>
        /// Player score access method
        /// </summary>
        /// <param name="player">The selected player</param>
        /// <returns>The score of the player</returns>
        internal int GetCurrentScoreForPlayer(int player) => currentRubber.GetCurrentScoreForPlayer(player);
        #endregion
        #region Private methods
        private bool UpdatePlayerScores(List<int> newScores)
        {
            if (newScores==null)
            {
                return false;
            }
            for (int i=0; i<playersScores.Count; i++)
            {
                playersScores[i] = newScores[i];
            }
            return true;
        }
        private void UpdateRubber(int numberOfPlayers)
        {
            currentRubber = new GameRubber(numberOfPlayers, gameController);
        }

        #endregion
    }
}
