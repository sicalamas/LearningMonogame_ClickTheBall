using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickTheBall.GameClasses
{
    class Entity
    {
        protected Rectangle spriteRectangle;
        protected Vector2 position;
        protected Vector2 velocity;
        protected float scale;

        public virtual void init() { }
        public virtual void update(GameTime gT) { }
        public virtual void draw(SpriteBatch sB) { }
    }
}
