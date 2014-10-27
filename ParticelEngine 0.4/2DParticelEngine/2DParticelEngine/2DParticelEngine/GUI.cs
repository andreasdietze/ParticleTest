using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DParticelEngine
{
    class GUI : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //Yellow Buttons
        public Texture2D YelArrowLeftTex, YelArrowRightTex;
        Rectangle YelArrowLeftRec, YelArrowRightRec;

        //Green Buttons
        public Texture2D GreArrowLeftTex, GreArrowRightTex;
        Rectangle GreArrowLeftRec, GreArrowRightRec;

        //Red Buttons
        public Texture2D RedButtonOffTex, RedButtonOnTex;
        Rectangle RedButtonRec_0, RedButtonRec_1, RedButtonRec_2;

        //Framecount
        private float fps;
        private float updateInterval = 1.0f;
        private float timeSinceLastUpdate = 0.0f;
        private float framecount = 0;
        public SpriteFont guiDebug;

        MouseState mouseState, lastMouseState;

        public GUI(Game game)
            : base(game)
        {
            lastMouseState = Mouse.GetState();

            //Arrows
            YelArrowLeftRec = new Rectangle(25, 500, 75, 75);
            YelArrowRightRec = new Rectangle(100, 500, 75, 78);
            GreArrowLeftRec = new Rectangle(25, 600, 75, 75);
            GreArrowRightRec = new Rectangle(100, 596, 75, 78);

            //Buttons
            RedButtonRec_0 = new Rectangle(30, 400, 40, 40);
            RedButtonRec_1 = new Rectangle(80, 400, 40, 40);
            RedButtonRec_2 = new Rectangle(130, 400, 40, 40);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Font
            guiDebug = Game.Content.Load<SpriteFont>("guiDebug");

            //Arrows
            YelArrowLeftTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gelbLinks");
            YelArrowRightTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gelbRechts");
            GreArrowLeftTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gruenLinks");
            GreArrowRightTex = Game.Content.Load<Texture2D>(@"Tex/Gui/gruenRechts");

            //Buttons
            RedButtonOffTex = Game.Content.Load<Texture2D>(@"Tex/Gui/bOf");
            RedButtonOnTex = Game.Content.Load<Texture2D>(@"Tex/Gui/bOn");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 520 && mouseState.Y < 550))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    Game1.instance.particleEngine.downClick();
                    /*foo += 1;
                    x = (float)Math.Cos(foo) * 2; //wackeleffekt 
                    y = (float)Math.Sin(foo) * 3;
                    YelArrowLeftRec = new Rectangle(25 + (int)x, 400 + (int)y, 75, 75);*/
                }
                lastMouseState = Mouse.GetState(); // Click für 1 Frame
            }
            if ((mouseState.X > 120 && mouseState.X < 185) && (mouseState.Y > 520 && mouseState.Y < 550))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    Game1.instance.particleEngine.upClick();
                }
                lastMouseState = Mouse.GetState();
            }
            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 620 && mouseState.Y < 650))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    Game1.instance.particleEngine.particleManager = ParticleEngine.ParticleManager.mixed;
                }
                lastMouseState = Mouse.GetState();
            }

            if ((mouseState.X > 120 && mouseState.X < 185) && (mouseState.Y > 620 && mouseState.Y < 650))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    Game1.instance.particleEngine.particleManager = ParticleEngine.ParticleManager.single;
                }
                lastMouseState = Mouse.GetState();
            }
            base.Update(gameTime);
        }

        internal void drawGUI(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone);
            //spriteBatch.Begin();
            spriteBatch.Draw(YelArrowLeftTex, YelArrowLeftRec, Color.White);
            spriteBatch.Draw(YelArrowRightTex, YelArrowRightRec, Color.White);
            spriteBatch.Draw(GreArrowLeftTex, GreArrowLeftRec, Color.White);
            spriteBatch.Draw(GreArrowRightTex, GreArrowRightRec, Color.White);

            spriteBatch.Draw(RedButtonOffTex, RedButtonRec_0, Color.White);
            spriteBatch.Draw(RedButtonOffTex, RedButtonRec_1, Color.White);
            spriteBatch.Draw(RedButtonOffTex, RedButtonRec_2, Color.White);

            if ((mouseState.X > 25 && mouseState.X < 90) && (mouseState.Y > 520 && mouseState.Y < 550))
            {
                // if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                // {
                spriteBatch.Draw(RedButtonOnTex, RedButtonRec_0, Color.White);
                spriteBatch.Draw(RedButtonOnTex, RedButtonRec_1, Color.White);
                spriteBatch.Draw(RedButtonOnTex, RedButtonRec_2, Color.White);
                // }
                // lastMouseState = Mouse.GetState(); // Click für 1 Frame
            }


            spriteBatch.End();
        }

        public void DrawDebugMonitor(GameTime gameTime, SpriteBatch spriteBatch)
        {
            /* Framecount */
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            framecount++;
            timeSinceLastUpdate += elapsed;
            if (timeSinceLastUpdate > updateInterval)
            {
                fps = framecount / timeSinceLastUpdate;
                framecount = 0;
                timeSinceLastUpdate -= updateInterval;
            }
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone);
            //spriteBatch.Begin();
            spriteBatch.DrawString(guiDebug, "Mouse: " + "X " + mouseState.X.ToString() + " Y " + mouseState.Y.ToString(), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(guiDebug, "ParticleCount: " + Game1.instance.particleEngine.particles.Count.ToString(), new Vector2(0, 20), Color.White);
            spriteBatch.DrawString(guiDebug, "FPS: " + fps.ToString(), new Vector2(0, 40), Color.White);
            spriteBatch.End();
        }
    }
}
