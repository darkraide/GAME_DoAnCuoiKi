using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class QuitWarningForm : Form
    {
        private MyButton[] mybutton;
        private List<My2DSprite> spritesButton = new List<My2DSprite>();
        private List<My2DSprite> spritesPanel = new List<My2DSprite>();
        private bool _Hide = true;
        private Button button;
        private Panel panel;

        public bool Hide
        {
            get { return _Hide; }
            set { _Hide = value; }
        }

        public QuitWarningForm()
        {
            LoadContent();
        }

        private void LoadContent()
        {
            CreatePanel(454, 241, "WarningQuitPanel");
            mybutton = Global.Content.Load<MyButton[]>("XML\\QuitWarningButton");
            for (int i = 0; i < mybutton.Length; i++)
            {
                CreateButton(mybutton[i].Left, mybutton[i].Top, mybutton[i].Name);
            }
        }

        private void CreateButton(int left, int top, string strButtonName)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Button\\" + strButtonName + "_button"));
            texture.Add(Global.Content.Load<Texture2D>("Button\\" + strButtonName + "_button_clicked"));
            button = new Button(left, top, texture);
            button.Depth = 0.3f;
            spritesButton.Add(button);
        }

        private void CreatePanel(int left, int top, string strPanelName)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Panel\\" + strPanelName));
            panel = new Panel(left, top, texture);
            panel.Depth = 0.4f;
            spritesPanel.Add(panel);
            
        }
      

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            base.Draw(gameTime, spriteBatch);

            for (int i = 0; i < spritesPanel.Count; i++)
                spritesPanel[i].Draw(gameTime, spriteBatch);

            for (int j = 0; j < spritesButton.Count; j++)
                spritesButton[j].Draw(gameTime, spriteBatch);

            

            
        }

        private int idx = -1;
        

        public override void Update(GameTime gameTime)
        {
            Vector2 worldPos = MouseEventHelper.GetInstance().GetCurrentPos();

            if (MouseEventHelper.GetInstance().HasLeftButtonDownEvent())
            {
                idx = button.GetSelectedButtonIndex(worldPos, spritesButton);

                if (idx != -1)
                    for (int i = 0; i < spritesButton.Count; i++)
                        spritesButton[i].Select(i == idx);
            }

            if (MouseEventHelper.GetInstance().HasLeftButtonUpEvent())
            {
                switch (idx)
                {
                    case 0: Hide = true;
                        idx = -1;
                        break;

                    case 1: Global.bQuit = true;
                        idx = -1;
                        break;
                    
                    default: Hide = true;
                        break;

                }
            }

            base.Update(gameTime);
            for (int i = 0; i < spritesButton.Count; i++)
                spritesButton[i].Update(gameTime);

            for (int j = 0; j < spritesPanel.Count; j++)
                spritesPanel[j].Update(gameTime);
        }
    }
}
