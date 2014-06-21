using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyDataTypes;

namespace _FinalProject__BeetleBug
{
    public class MainMenuForm : Form
    {
        private MyButton[] mybutton;
        private List<My2DSprite> spritesButton = new List<My2DSprite>();
        private List<My2DSprite> spritesLable = new List<My2DSprite>();
        private Button button;
        private int idx = -1;
        private bool _Hide = true;

        public bool Hide
        {
            get { return _Hide; }
            set { _Hide = value; }
        }

        public MainMenuForm()
        {
            LoadContent();
            
        }

        private void LoadContent()
        {
            CreateBackground(0, 0, "bg_MainMenu");
            CreateLable(360, 90, "lb_BeetleBug");
            mybutton = Global.Content.Load<MyButton[]>("XML\\MainMenuButton");
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
            button.Depth = 0.02f;
            spritesButton.Add(button);
        }

        private void CreateBackground(int left, int top, string strBackgroundName)
        {
            
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Background\\" + strBackgroundName));
            this.MainModel = new My2DSprite(left, top, texture);
            
        }

        private void CreateLable(int left, int top, string strLableName)
        {

            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Lable\\" + strLableName));
            Lable lable = new Lable(left, top, texture);
            lable.Depth = 0.5f;
            spritesLable.Add(lable);
        }

        

        // Setting Form & More Form
        SettingForm settingForm = new SettingForm();
        QuitWarningForm quitWarningForm = new QuitWarningForm();

        private Form CreateSelectLevelForm(int FormID)
        {
            Form selectLevelForm = new SelectLevelForm();
            selectLevelForm.ID = FormID;
            return selectLevelForm;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            base.Draw(gameTime, spriteBatch);


            for (int i = 0; i < spritesButton.Count; i++)
                spritesButton[i].Draw(gameTime, spriteBatch);
            

            for (int j = 0; j < spritesLable.Count; j++)
                spritesLable[j].Draw(gameTime, spriteBatch);

            if (settingForm.Hide == false)
                settingForm.Draw(gameTime, spriteBatch);

            if (quitWarningForm.Hide == false)
                quitWarningForm.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            

            
        }

        public override void Update(GameTime gameTime)
        {
            if (settingForm.Hide == false)
                settingForm.Update(gameTime);

            if (quitWarningForm.Hide == false)
                quitWarningForm.Update(gameTime);

            Vector2 worldPos = MouseEventHelper.GetInstance().GetCurrentPos();

            if (MouseEventHelper.GetInstance().HasLeftButtonDownEvent())
            {
                idx = button.GetSelectedButtonIndex(worldPos, spritesButton);

                if (idx != -1)
                {
                    for (int i = 0; i < spritesButton.Count; i++)
                        spritesButton[i].Select(i == idx);
                }
            }

            if (MouseEventHelper.GetInstance().HasLeftButtonUpEvent())
            {

                for (int i = 0; i < spritesButton.Count; i++)
                    spritesButton[i].Select(false);

                switch (idx)
                {
                    case 0:
                        idx = -1;
                        Global.CurrentForm = CreateSelectLevelForm(1);
                        break;
                    case 1:
                        idx = -1;
                        settingForm.Hide = false;
                        break;
                    case 2:
                        idx = -1;
                        break;
                    case 3:
                        quitWarningForm.Hide = false;
                        idx = -1;
                        break;

                    case -1:
                        break;
                }
            }

            base.Update(gameTime);
            for (int i = 0; i < spritesButton.Count; i++)
                spritesButton[i].Update(gameTime);

            
        }
    }
}
