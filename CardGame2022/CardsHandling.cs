using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2022
{
    /// <summary>
    /// A card is an int.
    /// This is a set of helper (static) attributes and methods to handle cards.
    /// Abstract - do not create an instance of.
    /// </summary>
    internal abstract class CardsHandling
    {
        #region Constant class attributes
        public static readonly int minValue = 1;
        public static readonly int maxValue = 104;
        public static readonly int numberOfRows = 4;
        public static readonly int maxInRow = 5;
        public static readonly int numberOfCardsInEachHand = 10;
        private static readonly Random random = new Random();
        #endregion
        #region Public class methods for cards
        /// <summary>
        /// Method to create a malus value (non-official)
        /// </summary>
        /// <param name="card">The numeric value for the card</param>
        /// <returns>The malus incurred by this card</returns>
        public static int MalusValue (int card)
        {
            int res = 1;
            // TODO: actual malus here
            return res;
        }
        /// <summary>
        /// Returns a list of all the possible cards (in order)
        /// </summary>
        /// <returns>All cards in the game</returns>
        public static List<int> AllTheCards()
        {
            List <int> cards = new List<int>();
            for (int i=minValue; i<=maxValue; i++)
            {
                cards.Add(i);
            }
            return cards;
        }
        /// <summary>
        /// Deals a card from an existing deck
        /// </summary>
        /// <param name="cards">The deck of cards, MODIFIED by this call</param>
        /// <returns>A card not in the deck anymore</returns>
        public static int DrawNewCardFrom(List<int> cards)
        {
            int i = random.Next(cards.Count);
            int res = cards[i];
            cards.RemoveAt(i);
            return res;
        }
        /// <summary>
        /// Returns true when the card is lower than all final cards of the current rows (and all rows contain at least a card)
        /// </summary>
        /// <param name="newCard">The new card to check</param>
        /// <param name="allRows">All current rows as lists of cards</param>
        /// <returns>true iff the card cannot be inserted</returns>
        public static bool IsLowerThanAllRows(int newCard, List<List<int>> allRows)
        {
            int i = 0;
            while (i<numberOfRows && allRows[i]!=null && allRows[i].Count>0 && newCard <allRows[i].Last())
            {
                i++;
            }
            return i == numberOfRows;
        }
        /// <summary>
        /// Returns true when that row is full
        /// </summary>
        /// <param name="row">The row as a list of cards</param>
        /// <returns>true iff the row contains the maximum number of cards</returns>
        public static bool IsFull(List<int> row)
        {
            return row.Count == maxInRow;
        }
        /// <summary>
        /// Computes the row to put the card in according to the rules of the game
        /// </summary>
        /// <param name="newCard">The card to play</param>
        /// <param name="allRows">The state of the game</param>
        /// <returns>The row to put the card in, -1 if non-existent</returns>
        public static int GetCorrectRowIndexOrNegative(int newCard, List<List<int>> allRows)
        {
            if (IsLowerThanAllRows(newCard, allRows))
            {
                return -1;
            }
            else
            {
                int res = -1;
                int dist = maxValue;
                for (int i = 0; i < numberOfRows; i++)
                {
                    if (allRows[i].Count==0)
                    {
                        dist = 0;
                        res = i;
                    }
                    else if (newCard> allRows[i].Last() && newCard - allRows[i].Last() <dist)
                    {
                        dist = newCard - allRows[i].Last();
                        res = i;
                    }
                }
                return res;
            }
        }
        /// <summary>
        /// A method that displays a list of cards as a string
        /// </summary>
        /// <param name="cards">The cards</param>
        /// <returns>The string output</returns>
        public static string ListOfCardsToString(List<int> cards)
        {
            string res = "";
            foreach (int card in cards)
            {
                res += " " + card;
            }
            return res;
        }
        /// <summary>
        /// A method that display a list of list of cards (rows) as a string
        /// </summary>
        /// <param name="allRows">The rows (lists of cards)</param>
        /// <returns>The string output</returns>
        public static string AllRowsToString(List<List<int>> allRows)
        {
            string res = "";
            for (int i=0; i<allRows.Count; i++)
            {
                res+= i.ToString()+":"+ListOfCardsToString(allRows[i])+Environment.NewLine;
            }
            return res;
        }
        /// <summary>
        /// A method that plays a card when possible
        /// </summary>
        /// <param name="card">The card to play</param>
        /// <param name="allRows">The current rows - MODIFIED by this method</param>
        /// <returns>A couple consisting in a) true iff the card could NOT be played and an action (
        /// choosing a row to collect) is required, b) an int containing the malus incurred, 0 if the card
        /// was simply inserted in a row, greated than 0 when a row was filled and automatically collected</returns>
        public static (bool, int) PlayerPlaysCard(int card, List<List<int>> allRows)
        {
            if (IsLowerThanAllRows(card, allRows))
            {
                return (true, 0);
            }
            int row = GetCorrectRowIndexOrNegative(card, allRows);
            if (row<0)
            {
                return (true, 0);
            }
            if (!IsFull(allRows[row]))
            {
                allRows[row].Add(card);
                return (false, 0);
            }
            else
            {
                int malus = PickThisRow(row, card, allRows);
                return (false, malus);
            }
        }
        /// <summary>
        /// Method that computes the value of the malus for a list of cards (row) collected
        /// </summary>
        /// <param name="cards">The list of cards</param>
        /// <returns>The (total) malus</returns>
        public static int GetMalusForCards(List<int> cards)
        {
            int res = 0;
            foreach (int card in cards)
            {
                res += MalusValue(card);
            }
            return res;
        }
        /// <summary>
        /// Method that collects (clears) a row of cards and puts a card in its place
        /// </summary>
        /// <param name="row">The number of the selected row</param>
        /// <param name="newCard">The new card</param>
        /// <param name="allRows">The current state of the game, MODIFIED by this call</param>
        /// <returns>The (total) malus incurred</returns>
        public static int PickThisRow(int row, int newCard, List<List<int>> allRows)
        {
            int res = GetMalusForCards(allRows[row]);
            allRows[row].Clear();
            allRows[row].Add(newCard);
            return res;
        }
        #endregion
    }
}
