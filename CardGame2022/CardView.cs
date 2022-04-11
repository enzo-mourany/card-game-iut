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
        // DrawCard proprieties
        public Size cardSize;
        public Color colorCard = Color.Red;
        public Font fontCardText = new Font("Poppins", 12.0f);
        public SolidBrush brushCard = new SolidBrush(Color.White);
        
        internal CardView(Point _Position, int _card)
        {
            this.Position = _Position;
            this.card = _card;
            this.malus = CardsHandling.MalusValue(this.card);
        }

        public void DrawCard(int card, Graphics g)
        {
            String text = card.ToString();
            Rectangle rect = new Rectangle(this.Position, cardSize);
            Pen p = new Pen(colorCard);
            g.DrawRectangle(p, rect);
            g.DrawString(text, fontCardText, brushCard, Position);
        }
    }
}
