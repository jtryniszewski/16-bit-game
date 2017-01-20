using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gierka
{
    class GameEngine
    {
        private Plansza mapa;
        private Gracz gracz;
        private ContentManager Content;
        private Vector2 startingPosition;
        private PlayerControl kontroler;

        public GameEngine(ContentManager Content)
        {
            this.Content = Content;
        }
        //----------------------------------------------------
        public void Initialize()
        {
            mapa = new Plansza(Content);
            gracz = new Gracz(Content);
            mapa.Initialize();
            gracz.Initialize();
            startingPosition = new Vector2();
        }
        //---------------------------------------------------
        #region PrzygotowanieMapy
        public void LadowanieMapy()//laduje mape i ustawia polozenie startowe gracza(w pszyszlosci bedzie tez rozmieszczac monety)
        {
            mapa.LadowaniePoziomu();
            StartPosition();
            gracz.Position = startingPosition;
            kontroler = new PlayerControl(mapa.Mapa(), gracz.Position, mapa.Wysokosc, mapa.Szeroksc);
        }
        private void StartPosition()
        {
            int[,] Ustawienie = mapa.Mapa();
            for(int i=0;i<mapa.Wysokosc;i++)
            {
                if(Ustawienie[i,0]==1)
                {
                    startingPosition.X = 0;
                    startingPosition.Y = (16 * i)-16;
                    break;
                }
            }

        }
        #endregion
        //---------------------------------------------------
        public void Draw(SpriteBatch spriteBatch)//rysuje wszystko
        {
            mapa.Draw(spriteBatch);
            gracz.Draw(spriteBatch);
        }
        public void Move()
        {
            gracz.Position = kontroler.Move();
            gracz.Move();
        }
    }
}
