using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class Character : My2DSprite
    {
        int nRows, nCols;

         public Character(float left, float top, List<Texture2D> textures, int nrows, int ncols)
            : base(left, top, textures)
        {
            State = 0;
            Depth = 0.05f;
            nRows = nrows;
            nCols = ncols;
            _nTextures = nCols;
            _Height = textures[0].Height / nRows;
            _Width = textures[0].Width / nCols;

        }

         private float Timer = 0;
         private int CurrentRow = 0;
         Rectangle sourceRectangle;
         Rectangle destinationRectangle;

         public override void Update(GameTime gameTime)
         {
             //base.Update(gameTime);
             Timer += (float)gameTime.ElapsedGameTime.Milliseconds;
             if (Timer >= 200)
             {
                 _iTextures = (_iTextures + 1) % (_nTextures - 1);
                 Timer = 0;
             }
             sourceRectangle = new Rectangle((int)_Width * (_iTextures + 1), (int)_Height * CurrentRow, (int)_Width, (int)_Height);
         }

         public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
         {
             //base.Draw(gameTime, spriteBatch);
             destinationRectangle = new Rectangle((int)_Left, (int)_Top, (int)_Width, (int)_Height);
             switch (State)
             {
                 case 0: Rectangle sourceRectanglestand = new Rectangle(0, (int)_Height * CurrentRow, (int)_Width, (int)_Height); 
                     spriteBatch.Draw(_Textures[0], destinationRectangle, sourceRectanglestand, Color.White, 0f, Vector2.Zero, SpriteEffects.None,_Depth); 
                     break;
                 case 1: spriteBatch.Draw(_Textures[0], destinationRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, _Depth); 
                     break;
             }
         }

         public void Move(int moveStep)
         {
             State = 1;
             switch (moveStep)
             {
                 case 0:
                     State = 1;
                     CurrentRow = 0;
                     break;
                 case 1:
                     CurrentRow = 1;
                     break;
                 case 2:
                     CurrentRow = 2;
                     break;
                 case 3:
                     CurrentRow = 3;
                     break;
             }
         }
    }
}
