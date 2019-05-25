using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickTheBall.GameClasses
{
    class Ball : Entity
    {
        Player player;
        public override void init()
        {
            spriteRectangle = new Rectangle(0, 0, 16, 16);

            Random rand = new Random(this.GetHashCode());
            position = new Vector2(GameConfig.WIDTH / 2, GameConfig.HEIGHT / 2);

            velocity = new Vector2(1.0f, 1.0f);

            scale = GameConfig.SCALE;
        }

        public override void update(GameTime gT)
        {
            updatePosition();
            setVelocity();
        }
        public override void draw(SpriteBatch sB)
        {
            sB.Draw(GameConfig.gameTexture, position, spriteRectangle, GameConfig.spColor, 0, new Vector2(8, 8), scale, SpriteEffects.None, 0);
        }

        public virtual void updatePosition()
        {
            position += velocity;
        }

        public virtual void setVelocity()
        {
            velocity *= 1.001f;
            if (position.X > GameConfig.WIDTH - 8 * GameConfig.SCALE || position.X < 0.0f + 8 * GameConfig.SCALE) velocity.X *= -1.0f;
            else if (position.Y > GameConfig.HEIGHT - 8 * GameConfig.SCALE || position.Y < 0.0f + 8 * GameConfig.SCALE) velocity.Y *= -1.0f;
        }

        public virtual Vector2 getVelocity()
        {
            return velocity;
        }

        internal Vector2 getPosition()
        {
            return position;
        }

        internal void setPlayer(Player p)
        {
            player = p;
        }

        internal void setPosition(Vector2 p)
        {
            position = p;
        }

        public void randomDirection(GameTime gT)
        {
            Random rand = new Random(this.GetHashCode() + (int)gT.TotalGameTime.TotalMilliseconds);
            Vector2 v = new Vector2((rand.Next(20) - 10), (rand.Next(20) - 10)); // A (-1 to 1, -1 to 1) random vector 
            Console.WriteLine("Random vector = " + v.ToString());
            // Get vector lenght
            float originalLength = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); Console.WriteLine("original lenght = " + originalLength);
            float otherLenght = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y); Console.WriteLine("other lenght = " + otherLenght);
            // Normalize vector
            Vector2 newVector = new Vector2(v.X / otherLenght, v.Y / otherLenght); Console.WriteLine("Normalized new Vector lenght = " + newVector.ToString());
            newVector *= originalLength; Console.WriteLine("Multiplied new vector lenght = " + newVector.ToString());
            velocity = newVector;
        }
    }
}
