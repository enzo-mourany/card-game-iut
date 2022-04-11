using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2022
{
    internal class CardView
    {
        private Point Position;
        private int card;
        private int malus;
        
        internal CardView(Point _Position, int _card)
        {
            this.Position = _Position;
            this.card = _card;
            malus = CardsHandling.MalusValue(this.card);
        }
    }
}
