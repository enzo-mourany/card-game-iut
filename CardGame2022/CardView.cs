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

        /// <summary>
        /// Method to draw a card
        /// </summary>
        /// <param name="card">The numeric value for the card</param>
        /// <param name="g">The graphic where the card will be drawn</param>
        public void DrawCard(int card, Graphics g)
        {
            String text = card.ToString();
            Rectangle rect = new Rectangle(this.Position, cardSize);
            Pen p = new Pen(colorCard);
            g.DrawRectangle(p, rect);
            g.DrawString(text, fontCardText, brushCard, Position);
        }

        /// <summary>
        /// Method check if a point is in the view
        /// </summary>
        /// <param name="p">The point</param>
        /// <returns>True if the view contains p</returns>
        public bool Contains(Point p)
        {
            Rectangle r = new Rectangle(Position, cardSize);
            return r.Contains(p);
        } 
    }
}
