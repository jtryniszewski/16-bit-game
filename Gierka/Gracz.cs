using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Gierka
{
    class Gracz
    {
        private ContentManager content;
        private List<Texture2D> walk;
        private List<Texture2D> jump;
        private Vector2 polozenie;
        private int fazaKroku;
        private bool ISRight;
        private Vector2 starePolozenie;

        //------------------------------------------------------

        public Gracz(ContentManager content)
        {
            this.content = content;
        }

        //------------------------------------------------------

        public void Initialize()
        {
            walk = new List<Texture2D>();
            jump = new List<Texture2D>();
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_00"));//0
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_01"));//1
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_02"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_03"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_04"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_05"));
            jump.Add(content.Load<Texture2D>("MrDefaulto_Fall"));
            jump.Add(content.Load<Texture2D>("MrDefaulto_Jump"));
            fazaKroku = 0;
            ISRight = true;
        }

        //------------------------------------------------------

        public Vector2 Position//akcesor do ustawienia pozycji gracza na mapie
        {
            set
            {
                starePolozenie = polozenie;
                polozenie = value;
            }
            get
            {
                return polozenie;
            }
        }

        //-------------------------------------------------------

        public void Draw(SpriteBatch spriteBatch)
        {
           
            if(ISRight)
            {
                spriteBatch.Draw(walk[fazaKroku], polozenie, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(walk[fazaKroku], polozenie, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
            }
        }

        //--------------------------------------------------------

        public void Move()
        {
            if(starePolozenie.X<polozenie.X)
            {
                ISRight = true;
                if(fazaKroku<5)
                {
                    fazaKroku++;
                }
                else
                {
                    fazaKroku = 0 ;
                }
            }
            if(starePolozenie.X>polozenie.X)
            {
                ISRight = false;
                if (fazaKroku < 5)
                {
                    fazaKroku++;
                }
                else
                {
                    fazaKroku = 0;
                }
            }
        }
    }
}
