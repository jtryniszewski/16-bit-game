using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Gierka
{
    class PlayerControl
    {
        private int[,] mapa;
        private Vector2 position;
        private int[,] siatkaRuchu;
        private int wysokoscMapy, szerokoscMapy, wysokoscSiatki,szerokoscSiatki;

        public PlayerControl(int[,] mapa,Vector2 position,int wysokoscMapy, int szerokoscMapy)
        {
            this.mapa = mapa;
            this.position = position;
            this.szerokoscMapy = szerokoscMapy;
            this.wysokoscMapy = wysokoscMapy;
            wysokoscSiatki =  wysokoscMapy;
            szerokoscSiatki = (8 * szerokoscMapy);
            siatkaRuchu = new int[wysokoscMapy, szerokoscSiatki];
            UstawienieSiatki();
        }
        private void UstawienieSiatki()
        {
            for(int i =0;i<wysokoscMapy;i++)
            {
                for(int j =0;j<szerokoscMapy;j++)
                {
                    for(int jj = j*8;jj<(j*8)+8;jj++)
                    {
                        if(mapa[i,j]==0)
                        {
                            siatkaRuchu[i, jj] = 0;
                        }
                        else
                        {
                            siatkaRuchu[i, jj] = 1;
                        }
                    }
                }
            }
        }
        private void MoveRight()
        {
            if(siatkaRuchu[(int)(position.Y)/16,(int)(position.X+16)/2]==0)
            {
                position.X += 2;
            }
        }
        public Vector2 Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MoveRight();
            }
            return position;
        }
    }
}
