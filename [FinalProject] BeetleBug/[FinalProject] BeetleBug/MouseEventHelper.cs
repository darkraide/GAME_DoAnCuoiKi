using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class MouseEventHelper : InvisibleGameEntity
    {
        private MouseState CurrentState, PrevState;
        private bool bPrevUp = true; // mac dinh chuot luon luon khong nhan

        private MouseEventHelper()
        {
        }

        private static MouseEventHelper Instance = new MouseEventHelper();
        public static MouseEventHelper GetInstance()
        {
            return Instance;
        }

        public int ScrollWheelValue()
        {
            return CurrentState.ScrollWheelValue;
        }

        public void ProcessNewState(MouseState mouseState)
        {
            PrevState = CurrentState;
            CurrentState = mouseState;
        }

        // Co doi tu UP <-> DOWN hay khong? 
        public bool HasLeftButtonDownEvent()
        {
            try
            {
                if (PrevState.LeftButton == ButtonState.Released &&
                    CurrentState.LeftButton == ButtonState.Pressed)
                    return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool HasLeftButtonUpEvent()
        {
            try
            {
                if (PrevState.LeftButton == ButtonState.Pressed &&
                    CurrentState.LeftButton == ButtonState.Released)
                    return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        // Hien tai UP/DOWN hay khong ?
        public bool IsLeftButtonDown()
        {
            return CurrentState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftButtonUp()
        {
            return CurrentState.LeftButton == ButtonState.Released;
        }

        public Vector2 GetMouseDifference()
        {
            try
            {
                return new Vector2(CurrentState.X - PrevState.X,
                    CurrentState.Y - PrevState.Y);
            }
            catch (Exception)
            {

            }
            return Vector2.Zero;
        }

        public bool HasRightButtonUpEvent()
        {
            try
            {
                if (PrevState.RightButton == ButtonState.Pressed &&
                    CurrentState.RightButton == ButtonState.Released)
                    return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public Vector2 GetCurrentPos()
        {
            return new Vector2(CurrentState.X, CurrentState.Y);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ProcessNewState(Mouse.GetState());
        }

    }
}
