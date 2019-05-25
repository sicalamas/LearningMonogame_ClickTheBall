using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickTheBall.GameClasses
{
    class Player : Entity
    {
        public int score;
        private Ball ball;

        public Player(Ball ball)
        {
            this.ball = ball;
            ball.setPlayer(this);
        }

        public override void init()
        {
            spriteRectangle = new Rectangle(16, 0, 16, 16);

            Random rand = new Random(this.GetHashCode());
            position = new Vector2(rand.Next(GameConfig.WIDTH), rand.Next(GameConfig.HEIGHT));

            velocity = new Vector2(1.0f, 1.0f);

            scale = GameConfig.SCALE;
        }

        public override void update(GameTime gT)
        {
            updatePosition();
            processInput(gT);
        }
        public override void draw(SpriteBatch sB)
        {
            sB.Draw(GameConfig.gameTexture, position, spriteRectangle, GameConfig.spColor, 0, new Vector2(8, 8), scale, SpriteEffects.None, 0);
        }

        public void updatePosition()
        {
            position.X = Mouse.GetState().Position.X;
            position.Y = Mouse.GetState().Position.Y;
        }

        public void processInput(GameTime gT)
        {
            MouseState mS = Mouse.GetState();
            if(mS.LeftButton == ButtonState.Pressed)
            {
                if(Vector2.Distance(mS.Position.ToVector2(),ball.getPosition()) <= 8 * GameConfig.SCALE )
                {
                    score += 1;

                    Random rand = new Random(this.GetHashCode() + (int)gT.TotalGameTime.TotalMilliseconds);
                    
                    ball.setPosition
                        (
                            new Vector2
                            (
                                rand.Next(8 * (int)GameConfig.SCALE, GameConfig.WIDTH - 8 * (int)GameConfig.SCALE),
                                rand.Next(8 * (int)GameConfig.SCALE, GameConfig.HEIGHT - 8 * (int)GameConfig.SCALE)
                            )
                        );
                }
            }
        }
    }
}
