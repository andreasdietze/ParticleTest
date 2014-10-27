using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2DParticelEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ParticleEngine particleEngine;
        GUI gui;
        public SpriteManager spriteManager;


        public static Game1 instance;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            gui = new GUI(this);
            this.Components.Add(gui);

            spriteManager = new SpriteManager(this);
            this.Components.Add(spriteManager);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            List<Texture2D> textures1 = new List<Texture2D>();
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/smallParticle"));  // 2x2 Pixel
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/circle"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/star"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Shapes/diamond"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/red"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/green"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/blue"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/bunt1"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/red1"));
            textures1.Add(Content.Load<Texture2D>(@"Tex/Particle/Colors/yellow2"));
            particleEngine = new ParticleEngine(textures1, new Vector2(0, 0));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Paticle
            particleEngine.Draw(spriteBatch);

            //SpriteManager
            spriteManager.Draw(spriteBatch);

            //GUI
            gui.drawGUI(spriteBatch);
            gui.DrawDebugMonitor(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
