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
        private bool isJump;//czy skok
        private bool isFall;//czy spada gracz
        private int jumpHeight;//aktualna wysokosc skoku
        private int maxJumpHeight;//maksymalna wysokosc skoku
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
            jump = new List<Texture2D>();
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_00"));//0
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_01"));//1
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_02"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_03"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_04"));
            walk.Add(content.Load<Texture2D>("MrDefaulto_Walk_05"));
            jump.Add(content.Load<Texture2D>("MrDefaulto_Fall"));
            jump.Add(content.Load<Texture2D>("MrDefaulto_Jump"));
            isJump = false;
            polozenie = new Vector2(16, 210);
            maxJumpHeight = 32;
            jumpHeight = 0;
            isFall = false;
            fazaKroku = 0;
        }

        //-------------------------------------------------------

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isJump == false)
            {
                if (isFall == false)
                {
                    spriteBatch.Draw(walk[fazaKroku], polozenie, Color.White);
                }
                else
                {
                    spriteBatch.Draw(jump[0], polozenie, Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(jump[1], polozenie, Color.White);
            }
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

        //------------------------------------------------------------------

        public void Jump()
        {
            if(isJump == true)
            {
                if (jumpHeight < maxJumpHeight)
                {
                    jumpHeight+=2;
                    polozenie.Y-=2;
                }
                else
                {
                    isJump = false;
                    isFall = true;
                }
            }
            if(isFall== true)
            {
                if(jumpHeight>=0)
                {
                    jumpHeight-=2;
                    polozenie.Y+=2;
                }
                else
                {
                    isFall = false;
                }
            }
        }

        //--------------------------------------------------------------------

        public void Click()
        {
            isJump = true;
        }
    }
}
