using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;


namespace Gierka
{
    public class Plansza
    {
        private ContentManager content;
        private Texture2D trawa;//1
        private Texture2D ziemia;//2
        private Texture2D ziemaKrawedz;//3
        private Texture2D trawaKrawedz;//4
        private Texture2D jaskina;//5
        private Texture2D jaskinaKrawedz;//6
        private Texture2D ziemaJaskina;//z
        private Texture2D ziemaJaskinaKrawedz;//a
        private string[] poziom;

        //----------------------------------------------------------

        public Plansza(ContentManager content)
        {
            this.content = content;
        }

        //-----------------------------------------------------------

        public void Initialize()
        {
            trawa = content.Load<Texture2D>("Grass_top");
            ziemia = content.Load<Texture2D>("Dirt_fill");
            ziemaKrawedz = content.Load<Texture2D>("Dirt_edge_left");
            trawaKrawedz = content.Load<Texture2D>("Grass_edge_left");
            jaskina = content.Load<Texture2D>("Wall_cave_fill");
            jaskinaKrawedz = content.Load<Texture2D>("Wall_cave_entrance_left");
            ziemaJaskina = content.Load<Texture2D>("Dirt_edge_cave_top");
            ziemaJaskinaKrawedz = content.Load<Texture2D>("Dirt_edge_entre_left");
            LadowaniePoziomu();
        }

        //-----------------------------------------------------------

        public void LadowaniePoziomu()
        {
            poziom = File.ReadAllLines(@"C:\Users\jakub\Documents\visual studio 2015\Projects\ConsoleApplication9\ConsoleApplication9\obj\Debug\plik.txt");
        }

        //-----------------------------------------------------------

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0;i<poziom.Length;i++)
            {
                for(int j = 0;j<poziom[i].Length;j++)
                {
                    if(poziom[i][j]=='1')
                    {
                        spriteBatch.Draw(trawa,new Vector2(j*16,i*16),Color.White);
                    }
                    if(poziom[i][j] == '2')
                    {
                        spriteBatch.Draw(ziemia, new Vector2(j*16, i*16), Color.White);
                    }
                    if (poziom[i][j] == '3')
                    {
                        spriteBatch.Draw(ziemaKrawedz, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if (poziom[i][j] == '4')
                    {
                        spriteBatch.Draw(trawaKrawedz, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if (poziom[i][j] == '5')
                    {
                        spriteBatch.Draw(jaskina, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if (poziom[i][j] == '6')
                    {
                        spriteBatch.Draw(jaskinaKrawedz, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if (poziom[i][j] == '7')
                    {
                        spriteBatch.Draw(trawaKrawedz, new Vector2(j * 16, i * 16), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
                    }
                    if (poziom[i][j] == '8')
                    {
                        spriteBatch.Draw(ziemaKrawedz, new Vector2(j * 16, i * 16), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
                    }
                    if (poziom[i][j] == '9')
                    {
                        spriteBatch.Draw(jaskinaKrawedz, new Vector2(j * 16, i * 16), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
                    }
                    if (poziom[i][j] == 'z')
                    {
                        spriteBatch.Draw(ziemaJaskina, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if (poziom[i][j] == 'Z')
                    {
                        spriteBatch.Draw(ziemaJaskina, new Vector2(j * 16, i * 16), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipVertically, 0f);
                    }
                    if (poziom[i][j] == 'a')
                    {
                        spriteBatch.Draw(ziemaJaskinaKrawedz, new Vector2(j * 16, i * 16), Color.White);
                    }
                    if(poziom[i][j] == 'A')
                    {
                        spriteBatch.Draw(ziemaJaskinaKrawedz, new Vector2(j * 16, i * 16), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
                    }
                }
            }
        }

        //-----------------------------------------------------------

        public int[,] Mapa()
        {
            //lista ktora podaje przyjmuje wartosci 1 i 0
            //1 gdy wystepuje czesc mapy a 0 gdy mapa jest pusta
            int[,] mapa = new int[poziom.Length, poziom[0].Length];
            for (int i = 0; i < poziom.Length; i++)
            {
                for (int j = 0; j < poziom[i].Length; j++)
                {
                    if(poziom[i][j]=='0')
                    {
                        mapa[i,j] = 0;
                    }
                    else
                    {
                        mapa[i, j] = 1;
                    }
                }
            }
            return mapa;
        }
    }
}
