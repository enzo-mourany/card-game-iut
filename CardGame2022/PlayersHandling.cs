using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2022
{
    /// <summary>
    /// A player is an int.
    /// This method contains helper (static) things to handle such ints.
    /// Abstract - do not create an instance of.
    /// </summary>
    internal abstract class PlayersHandling
    {
        #region Constant class attributes 
        public static readonly int minPlayers = 1;
        public static readonly int maxPlayers = 10;
        #endregion
    }
}
