using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class SettingForm : Form
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

        public SettingForm()
        {
            LoadContent();
        }

        private void LoadContent()
        {
            CreatePanel(80, 235, "SettingBase");
            mybutton = Global.Content.Load<MyButton[]>("XML\\SettingMenuButton");
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
            button.Depth = 0.01f;
            spritesButton.Add(button);
        }

        private void CreatePanel(int left, int top, string strPanelName)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Panel\\" + strPanelName));
            panel = new Panel(left, top, texture);
            panel.Depth = 0.05f;
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
        private bool Music = true;
        private bool Sound = true;

        public override void Update(GameTime gameTime)
        {
            Vector2 worldPos = MouseEventHelper.GetInstance().GetCurrentPos();

            if (MouseEventHelper.GetInstance().HasLeftButtonDownEvent())
            {
                idx = button.GetSelectedButtonIndex(worldPos, spritesButton);
            }

            if (MouseEventHelper.GetInstance().HasLeftButtonUpEvent())
            {
                switch (idx)
                {             
                    case 0: if (Sound == true)
                        {
                            SoundEffectHelper.GetInstance().Mute();
                            spritesButton[idx].State = 1;
                        }
                        else
                        {
                            SoundEffectHelper.GetInstance().unMute();
                            spritesButton[idx].State = 0;
                        }
                        break;

                    case 1: if (Music == true)
                        {
                            MusicHelper.GetInstance().Mute();
                            spritesButton[idx].State = 1;
                        }
                        else
                        {
                            MusicHelper.GetInstance().unMute();
                            spritesButton[idx].State = 0;
                        }
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
