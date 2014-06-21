using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class KeyboardEventHelper : InvisibleGameEntity
    {
        private KeyboardState CurrentState, prevState;

        private KeyboardEventHelper()
        {
        }

        private static KeyboardEventHelper Instance = new KeyboardEventHelper();

        public static KeyboardEventHelper GetInstance()
        {
            return Instance;
        }
        public void ProcessNewState(KeyboardState keyboardState)
        {
            prevState = CurrentState;
            CurrentState = keyboardState;
        }

      
        public bool HasKeyUpEvent(Keys key)
        {
            try
            {
                if (prevState.IsKeyDown(key) &&
                    CurrentState.IsKeyUp(key))
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            ProcessNewState(Keyboard.GetState());
        }
    }
}
