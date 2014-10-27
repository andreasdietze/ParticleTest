using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DParticelEngine
{
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;
        private Texture2D yellow;
        private Texture2D yellow2;
        private Texture2D mixed;
        private Texture2D red1;

        Random rand;

        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;
        private float yellowAngle = 0;
        private float shake;

        private float blueSpeed = 0.025f;
        private float greenSpeed = 0.017f; //FreakShow : D
        private float redSpeed = 0.022f;
        private float yellowSpeed = 0.021f;

        private float distance = 100;

        public SpriteManager(Game1 game)
            : base(game)
        {
            rand = new Random();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            red = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/red");
            green = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/green");
            blue = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/blue");
            yellow = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow");
            yellow2 = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow2");
            mixed = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/bunt1");
            red1 = Game.Content.Load<Texture2D>(@"Tex/Particle/Colors/red1");
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;
            yellowAngle += yellowSpeed;
            shake += 0.11f;

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawSpriteChain01(spriteBatch);
            DrawSpriteChain02(spriteBatch);
            DrawSpriteChain03(spriteBatch);
        }

        public void DrawSpriteChain01(SpriteBatch spriteBatch)
        {

            Vector2 redPosition = new Vector2((float)Math.Cos(redAngle) * distance, 5);//(float)Math.Sin(redAngle) * distance);
            Vector2 greenPosition = new Vector2((float)Math.Sin(0) * distance, 5);//(float)Math.Sin(redAngle) * distance);
            Vector2 bluePosition = new Vector2((float)Math.Cos(blueAngle) * distance, (float)Math.Sin(blueAngle) * distance);
            Vector2 center = new Vector2(520, 180);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);//SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Draw(blue, center + bluePosition, Color.White);
            spriteBatch.Draw(blue, center - bluePosition, Color.White);
            spriteBatch.Draw(red, center + redPosition, Color.White);
            spriteBatch.Draw(red, center - redPosition, Color.White);
            spriteBatch.Draw(green, center - greenPosition, Color.White);
            spriteBatch.End();
        }

        public void DrawSpriteChain02(SpriteBatch spriteBatch)
        {
            Vector2 yellowPosition = new Vector2(((float)Math.Cos(yellowAngle) * 300) + ((float)Math.Cos(shake) * -3),
                ((float)Math.Sin(greenAngle) * 200) + (float)Math.Sin(shake) * -10);
            Vector2 yellowPosition2 = new Vector2(((float)Math.Cos(yellowAngle) * 300) + ((float)Math.Cos(shake) * 9),
                ((float)Math.Sin(greenAngle) * 200) + (float)Math.Sin(shake) * 15);
            //Vector2 bluePosition = new Vector2((float)Math.Cos(redAngle) * 300, (float)Math.Sin(blueAngle) * 200);
            Vector2 center = new Vector2(520, 180);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int i = 0; i < 2; i++)
            {
                spriteBatch.Draw(red, new Rectangle(((int)center.X + (int)yellowPosition.X) + 250, ((int)center.X + (int)yellowPosition.Y) -150 , 10, 10), Color.White);
                spriteBatch.Draw(yellow, new Rectangle(((int)center.X + (int)yellowPosition2.X) + 250, ((int)center.X + (int)yellowPosition2.Y) - 150, 10, 10), Color.White);

                spriteBatch.Draw(yellow, new Rectangle(((int)center.X + (int)yellowPosition.X) + 250, ((int)center.X + (int)yellowPosition.Y) - 150, 10, 10), Color.White);
                spriteBatch.Draw(red, new Rectangle(((int)center.X + (int)yellowPosition2.X) + 250, ((int)center.X + (int)yellowPosition2.Y) - 150, 10, 10), Color.White);

                spriteBatch.Draw(yellow, new Rectangle(((int)center.X + (int)yellowPosition.X) + 250, ((int)center.X + (int)yellowPosition.Y) -300, 10, 10), Color.White);
                spriteBatch.Draw(red, new Rectangle(((int)center.X + (int)yellowPosition2.X) + 250, ((int)center.X + (int)yellowPosition2.Y) -300, 10, 10), Color.White);

                spriteBatch.Draw(red, new Rectangle(((int)center.X - (int)yellowPosition.X) + 250, ((int)center.X - (int)yellowPosition.Y) - 150, 10, 10), Color.White);
                spriteBatch.Draw(yellow, new Rectangle(((int)center.X - (int)yellowPosition2.X) + 250, ((int)center.X - (int)yellowPosition2.Y) - 150, 10, 10), Color.White);

                spriteBatch.Draw(red, new Rectangle(((int)center.X - (int)yellowPosition.X) + 200, ((int)center.X - (int)yellowPosition.Y) - 300, 10, 10), Color.White);
                spriteBatch.Draw(yellow, new Rectangle(((int)center.X - (int)yellowPosition2.X) + 200, ((int)center.X - (int)yellowPosition2.Y) - 300, 10, 10), Color.White);

                spriteBatch.Draw(red, center - yellowPosition, Color.White);
                spriteBatch.Draw(yellow, center - yellowPosition, Color.White);
                spriteBatch.Draw(red, center - yellowPosition2, Color.White);
                spriteBatch.Draw(yellow, center - yellowPosition2, Color.White);

                spriteBatch.Draw(red, center + yellowPosition, Color.White);
                spriteBatch.Draw(yellow, center + yellowPosition, Color.White);
                spriteBatch.Draw(red, center + yellowPosition2, Color.White);
                spriteBatch.Draw(yellow, center + yellowPosition2, Color.White);
            }
            spriteBatch.End();
        }

        public void DrawSpriteChain03(SpriteBatch spriteBatch)
        {

            Vector2 greenPosition1 = new Vector2(((float)Math.Cos(greenAngle) * 300)
                + ((float)Math.Cos(shake) * 7), ((float)Math.Sin(greenAngle) * 200)
                + (float)Math.Sin(shake) * 10);
            Vector2 greenPosition2 = new Vector2(((float)Math.Cos(greenAngle) * 300)
                + ((float)Math.Cos(shake) * 7), ((float)Math.Sin(greenAngle) * 200)
                + (float)Math.Sin(shake) * 10);
            Vector2 greenPosition4 = new Vector2(((float)Math.Cos(greenAngle) * 300)
                + ((float)Math.Cos(shake) * -1), ((float)Math.Sin(greenAngle) * 200)
                + (float)Math.Sin(shake) * -1);
            Vector2 greenPosition3 = new Vector2(((float)Math.Cos(greenAngle) * 300)
                + ((float)Math.Cos(shake) * -3), ((float)Math.Sin(greenAngle) * 200)
                + (float)Math.Sin(shake) * -10);
            Vector2 center = new Vector2(520, 180);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            for (int i = 0; i < 2; i++)
            {
                spriteBatch.Draw(red, center + greenPosition2, Color.White);
                spriteBatch.Draw(blue, center + greenPosition3, Color.White);
                spriteBatch.Draw(red, center - greenPosition2, Color.White);
                spriteBatch.Draw(blue, center - greenPosition3, Color.White);

            }
            for (int i = 0; i < 2; i++)
            {

                spriteBatch.Draw(red, center - greenPosition2, Color.White);
                spriteBatch.Draw(blue, center - greenPosition3, Color.White);
                spriteBatch.Draw(yellow, center - greenPosition4, Color.White);

            }
            spriteBatch.End();
            /*foo += 1;
            x = (float)Math.Cos(foo) * 2; //wackeleffekt 
            y = (float)Math.Sin(foo) * 3;
            YelArrowLeftRec = new Rectangle(25 + (int)x, 400 + (int)y, 75, 75);*/
        }
    }
}
