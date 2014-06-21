using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    class Global
    {
        public static List<Form> Forms = new List<Form>();
        public static string CurrentLevel = "";
        public static Camera2D CurrentCamera = null;
        public static ContentManager Content = null;
        public static Form CurrentForm = null;
        public static Map CurrentMap = null;
        public static Effect CurrentEffect = null;
        public static bool bQuit = false;
        public static GraphicsDevice GraphicsDevice { get; set; }

        public static int SwitchToForm(int FormID)
        {
            int OldFormID = -1;
            if (FormID == 1)
            {
                MusicHelper.GetInstance().playSong(0);
            }

            if (OldFormID == FormID)
                return OldFormID;

            if (CurrentForm != null)
                OldFormID = CurrentForm.ID;


            for (int i = 0; i < Forms.Count; i++)
                if (FormID == Forms[i].ID)
                {
                    CurrentForm = Forms[i];
                    break;
                }

            return OldFormID;

        }
    }
}
