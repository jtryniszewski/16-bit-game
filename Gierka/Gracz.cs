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
        private Vector2 polozenie;
        private int fazaKroku;

        //------------------------------------------------------

        public Gracz(ContentManager content)
        {
            this.content = content;
        }

        //------------------------------------------------------

        public void Initialize()
        {
            walk = new List<Texture2D>();
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_00"));//0
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_01"));//1
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_02"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_03"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_04"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_05"));
            polozenie = new Vector2(16, 226);
            fazaKroku = 0;
        }

        //-------------------------------------------------------

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(walk[fazaKroku], polozenie, Color.White);
        }

        //--------------------------------------------------------

        public void Move()
        {
            if(polozenie.X<464)
            {
                polozenie.X++;
                if(fazaKroku<5)
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
