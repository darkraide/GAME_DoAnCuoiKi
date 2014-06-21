using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public abstract class VisibleGameEntity : GameEntity
    {
        protected My2DSprite _MainModel;

        protected My2DSprite MainModel
        {
            get { return _MainModel; }
            set { _MainModel = value; }
        }

        public override void Update(GameTime gameTime)
        {
            if (_MainModel != null)
                _MainModel.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_MainModel != null)
                _MainModel.Draw(gameTime, spriteBatch);
        }

        public virtual bool IsSelected(Vector2 vector2)
        {
            return _MainModel.IsSelected(vector2);
        }

        public virtual void Select(bool bSelected)
        {
            _MainModel.Select(bSelected);
        }

    }
}
