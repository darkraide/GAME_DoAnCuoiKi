using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class My2DSprite
    {
        protected float _Left;

        public float Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        protected float _Top;

        public float Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        protected float _Width;

        public float Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        protected float _Height;

        public float Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        protected float _Depth = 1;

        public float Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }
        protected int _State = 0;

        public int State
        {
            get { return _State; }
            set { _State = value; }
        }

        protected float _Scale = 1;

        public float Scale
        {
            get { return _Scale; }
            set { _Scale = value; }
        }


        protected List<Texture2D> _Textures;

        public List<Texture2D> Textures
        {
            get { return _Textures; }
            set { 
                _Textures = value;
                _nTextures = _Textures.Count;
                _iTextures = 0;
                _Width = _Textures[0].Width;
                _Height = _Textures[0].Height;
                }
        }

        protected int _nTextures;

        public int nTextures
        {
            get { return _nTextures; }
            set { _nTextures = value; }
        }

        protected int _iTextures;

        public int iTextures
        {
            get { return _iTextures; }
            set { _iTextures = value; }
        }

        public My2DSprite(float left, float top, List<Texture2D> textures)
        {
            Left = left;
            Top = top;
            Textures = textures;
        }

        public virtual void Update(GameTime gameTime)
        {
            _iTextures = (_iTextures + 1) % _nTextures;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            InternalDraw(gameTime, spriteBatch);
        }

        protected void InternalDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            if (State == 0)
                spriteBatch.Draw(_Textures[_iTextures], new Vector2(_Left, _Top), null, Color.White, 0, Vector2.Zero, _Scale, SpriteEffects.None, _Depth);
            else
                if (State == 1)
                {
                    spriteBatch.Draw(_Textures[_iTextures], new Vector2(_Left, _Top), null,  Color.White, 0, Vector2.Zero, _Scale, SpriteEffects.None, _Depth);

                }
        }

        public bool IsSelected(Vector2 pos)
        {
            
            if (pos.X >= Left && pos.X <= Left + Width &&
                pos.Y >= Top && pos.Y <= Top + Height)
                return true;
            return false;
        }

        public void Select(bool bSelected)
        {
            if (bSelected)
                State = 1;
            else
                State = 0;
        }

    }
}
