using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class Lable : My2DSprite
    {
        public Lable(float left, float top, List<Texture2D> textures)
            : base(left, top, textures)
        {
            
            this.Depth = 0.01f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //base.Draw(gameTime, spriteBatch);
           
              spriteBatch.Draw(_Textures[0], new Vector2(_Left, _Top), null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, _Depth);
            
        }
    }
}
