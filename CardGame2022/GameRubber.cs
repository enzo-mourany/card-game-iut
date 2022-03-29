using System;
using System.Collections.Generic;

namespace CardGame2022
{
    /// <summary>
    /// A class handling a single rubber of the game
    /// Logic class (model)
    /// </summary>
    internal class GameRubber
    {
        #region Internal type used for the FSM of a rubber
        enum State { CollectingCards, EndTurn, WaitingForChoiceOfRow, Finished,
            EndSelection,
            RubberOver
        }
        #endregion
        #region Property readable by other classes
        public int NumberOfPlayers { get; private set; }
        #endregion
        #region Association attribute
        private readonly GameController gameController;
        #endregion
        #region Private attributes
        private readonly List<List<int>> allRows;
        private readonly List<List<int>> playersHands;
        private readonly List<int> allCards;
        private readonly List<int> playersScores;
        private int playerChoosingARow;
        private State state;
        private Dictionary<int, int> cardsSelectedByPlayers;
        private int playerForSelection;
        private List<bool> affectOk;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for a single rubber
        /// </summary>
        /// <param name="numberOfPlayers">The number of players</param>
        /// <param name="gameController">A reference to the controller</param>
        internal GameRubber(int numberOfPlayers, GameController gameController)
        {
            NumberOfPlayers = numberOfPlayers;
            playersHands = new List<List<int>>();
            playersScores = new List<int>();
            for (int i=0; i < numberOfPlayers; i++)
            {
                playersHands.Add(new List<int>());
                playersScores.Add(0);
            }
            allRows = new List<List<int>>();
            for (int i=0; i<CardsHandling.numberOfRows; i++)
            {
                allRows.Add(new List<int>());
            }
            allCards = CardsHandling.AllTheCards();
            this.gameController=gameController;
            InitialDeal();
            playerForSelection = -1;
            state = State.CollectingCards;
        }
        #endregion
        #region Methods called by the logic or controller
        /// <summary>
        /// Access method for the score of a player
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>The score</returns>
        internal int GetCurrentScoreForPlayer(int player)
        {
            return playersScores[player];
        }
        /// <summary>
        /// Access method for the hand of a player
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>The hand (as a list of cards)</returns>
        internal List<int> GetCurrentHandForPlayer(int player)
        {
            return playersHands[player];
        }
        /// <summary>
        /// IMPORTANT METHOD
        /// Method called by this instance or the logic to perform a single action
        /// All of the logic of the game is performed here
        /// </summary>
        /// <returns>Null if the rubber continues, the final scores if over</returns>
        internal List<int> OneAction()
        {
            switch (state)
            {
                case State.CollectingCards:
                    if (cardsSelectedByPlayers == null)
                    {
                        gameController.UpdateState(allRows);
                        cardsSelectedByPlayers = new Dictionary<int, int>();
                        playerForSelection = 0;
                    }
                    int selectedCard = GetCardForPlayer(playerForSelection);
                    if (selectedCard <= 0)
                    {
                        gameController.AllowedInput = new List<int>(playersHands[playerForSelection]);
                        gameController.AskPlayerForCard(playerForSelection);
                    }
                    else
                    {
                        gameController.ResetInput();
                        cardsSelectedByPlayers.Add(playerForSelection, selectedCard);
                        playerForSelection++;
                        if (playerForSelection >= NumberOfPlayers)
                        {
                            playerForSelection = -1;
                            state = State.EndSelection;
                        }
                        OneAction();
                    }
                    break;
                case State.EndSelection:
                    state = State.EndTurn;
                    gameController.DisplayCardsSelected(cardsSelectedByPlayers);
                    break;
                case State.EndTurn:
                    if (affectOk == null)
                    {
                        affectOk = new List<bool>();
                        foreach (int _ in cardsSelectedByPlayers.Keys)
                        {
                            affectOk.Add(false);
                        }
                    }
                    PerformAffectAllCards(cardsSelectedByPlayers);
                    break;
                case State.WaitingForChoiceOfRow:
                    int selectedRow = GetRowForPlayer();
                    int malus = CardsHandling.GetMalusForCards(allRows[selectedRow]);
                    gameController.DisplayMalusForPlayer(malus, playerChoosingARow);
                    playersScores[playerChoosingARow] += malus;
                    allRows[selectedRow].Clear();
                    state = State.EndTurn;
                    OneAction();
                    break;
                case State.Finished:
                    gameController.UpdateState(allRows);
                    state = State.RubberOver;
                    gameController.DisplayRubberOver();
                    break;
                case State.RubberOver:
                    return playersScores;
            }
            return null;
        }
        #endregion
        #region Private methods
        private void InitialDeal()
        {
            for (int i=0;i<CardsHandling.numberOfRows;i++)
            {
                allRows[i].Add(DealNewCard());
            }
            foreach (List<int> hand in playersHands)
            {
                for (int i=0; i<CardsHandling.numberOfCardsInEachHand; i++)
                {
                    hand.Add(DealNewCard());
                }
            }
        }

        private int DealNewCard()
        {
            return CardsHandling.DrawNewCardFrom(allCards);
        }

        private int GetRowForPlayer()
        {
            return gameController.CurrentInt;
        }

        private void PerformAffectAllCards(Dictionary<int, int> cardsSelectedByPlayers)
        {
            bool canGoOn = true;
            int[] playerOrder = new int[NumberOfPlayers];
            List<int> theCards = new List<int>(cardsSelectedByPlayers.Values);
            theCards.Sort();
            foreach (int p in cardsSelectedByPlayers.Keys)
            {
               playerOrder[theCards.IndexOf(cardsSelectedByPlayers[p])]=p;
            }
            int player = playerOrder[0];
            int i = 0;
            while (i < cardsSelectedByPlayers.Count && canGoOn)
            {
                player = playerOrder[i];
                if (!affectOk[player])
                {
                    canGoOn = affectOk[player] = AffectOneCard(cardsSelectedByPlayers, player);
                }
                if (canGoOn)
                {
                    i++;
                }
            }
            if (i == cardsSelectedByPlayers.Count)
            {
                gameController.DisplayEndOfTurnMessage();
                state = FinishedOrSelection();
                OneAction();
            }
            else
            {
                playerChoosingARow = player;
                gameController.UpdateState(allRows);
                gameController.AskPlayerForRow(playerChoosingARow);
                List<int> rowNums = new List<int>();
                for (int j = 0; j < allRows.Count; j++)
                {
                    rowNums.Add(j);
                }
                gameController.AllowedInput = rowNums;
                state = State.WaitingForChoiceOfRow;
            }
        }

        private State FinishedOrSelection()
        {
            int i = 0;
            bool finished = true;
            while (finished && i < NumberOfPlayers)
            {
                finished = playersHands[i].Count == 0;
                i++;
            }
            if (finished)
            {
                return State.Finished;
            }
            else
            {
                cardsSelectedByPlayers = null;
                affectOk = null;
                return State.CollectingCards;
            }
        }

        private bool AffectOneCard(Dictionary<int, int> cardsSelectedByPlayers, int i)
        {
            (bool needsToChoose, int malus) = CardsHandling.PlayerPlaysCard(cardsSelectedByPlayers[i], allRows);
            if (needsToChoose)
            {
                return false;
            }
            else
            {
                gameController.DisplayCardPlayedByPlayer(cardsSelectedByPlayers[i], i);
                playersHands[i].Remove(cardsSelectedByPlayers[i]);
                if (malus > 0)
                {
                    gameController.DisplayMalusForPlayer(malus, i);
                    playersScores[i]+=malus;
                } 
                return true;
            }
        }

        private int GetCardForPlayer(int player)
        {
            int res = gameController.CurrentInt;
            if (!playersHands[player].Contains(res))
            {
                res = -1;
            }
            return res;
        }
        #endregion
    }
}