using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class Button : My2DSprite
    {
        public Button(float left, float top, List<Texture2D> textures)
            : base(left, top, textures)
        {
            State = 0;
            this.Depth = 0.01f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //base.Draw(gameTime, spriteBatch);
            switch (State)
            {
                case 0: spriteBatch.Draw(_Textures[0], new Vector2(_Left, _Top), null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, _Depth);
                    break;
                case 1: spriteBatch.Draw(_Textures[1], new Vector2(_Left, _Top), null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, _Depth);
                    break;
            }
        }

        public int GetSelectedButtonIndex(Vector2 worldPos, List<My2DSprite> sprites)
        {
            
            for (int i = sprites.Count - 1; i >= 0; i--)
            
                if (sprites[i].IsSelected(worldPos))
                
                    return i;                                   

            return -1;
        }


    }
}
