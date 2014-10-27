using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DParticelEngine
{
    public class ParticleEngine
    {
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        public List<Particle> particles;
        private List<Texture2D> textures;
        private Texture2D texture;
        public int foo = 0;
        public enum ParticleManager { none, single, mixed, shapes, colors, vertical, horizontal }
        public ParticleManager particleManager = ParticleManager.single;
        float size;
        float verFl, horFl;

        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
            verFl = 2.0f;
            horFl = 2.0f;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();



            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int total = 10;
                for (int i = 0; i < total; i++)
                {
                    particles.Add(GenerateNewParticelStream());
                }
            }
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].LT <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        private Particle GenerateNewParticelStream()
        {
            switch (particleManager)
            {
                case ParticleManager.none:
                    break;
                case ParticleManager.single:
                    if (foo < 4)
                    {
                        size = (float)random.NextDouble();
                    }
                    else
                    {
                        size = (float)random.NextDouble() / 8;
                    }
                    texture = textures[foo];
                    horFl = 10.0f;
                    verFl = 2.0f;
                    break;
                case ParticleManager.mixed:
                    texture = textures[random.Next(textures.Count)];
                    size = (float)random.NextDouble() / 2;
                    verFl = 10.0f;
                    horFl = 2.0f;
                    break;
                case ParticleManager.shapes:
                    break;
                case ParticleManager.colors:
                    break;
                case ParticleManager.vertical:
                    verFl = 10.0f;
                    break;
                case ParticleManager.horizontal:
                    horFl = 10.0F;
                    break;

            }

            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * verFl - 1), 1f * (float)(random.NextDouble() * horFl - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

            int ttl = 20 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);  //Wenn Bälle mitgezeichnet werden als Particel -> SpriteSortMode.Immediate, BlendState.Additive
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public void upClick()
        {
            if (foo < 10) //number of textures - 1
                foo++;
        }

        public void downClick()
        {
            if (foo > 0)
                foo--;
        }
    }
}
