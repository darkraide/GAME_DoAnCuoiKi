using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class SelectLevelForm : Form
    {
        private MyButton[] mybutton;
        private List<My2DSprite> spritesButton = new List<My2DSprite>();
        private List<My2DSprite> spritesLevelButton = new List<My2DSprite>();
        private List<My2DSprite> spritesLable = new List<My2DSprite>();
        private List<My2DSprite> spritesPanel = new List<My2DSprite>();
        private Button button, levelbutton;
        private Panel panel;
        private int idx = -1;
        private int levelnum = -1;
        private bool _Hide = true;

        public bool Hide
        {
            get { return _Hide; }
            set { _Hide = value; }
        }

        public SelectLevelForm()
        {
            LoadContent();
            
        }

        private void LoadContent()
        {
            CreateBackground(0, 0, "bg_SelectLevel");
            CreateLable(20, 20, "lb_BeetleBugSmall");
            CreatePanel(338, 129, "panel_LevelSelect");

            // Casual Button 
            mybutton = Global.Content.Load<MyButton[]>("XML\\SelectLevelButton");
            for (int i = 0; i < mybutton.Length; i++)
            {
                CreateButton(mybutton[i].Left, mybutton[i].Top, mybutton[i].Name, 0.3f, "Button\\");
            }

            // Number Level Button
            mybutton = Global.Content.Load<MyButton[]>("XML\\LevelNumberButton");
            for (int j = 0; j < mybutton.Length; j++)
            {
                CreateButtonLevel(mybutton[j].Left, mybutton[j].Top, mybutton[j].Name, 0.3f, "Level\\");
            }
        }

        private void CreateButton(int left, int top, string strButtonName, float depth, string Path)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>(Path + strButtonName + "_button"));
            texture.Add(Global.Content.Load<Texture2D>(Path + strButtonName + "_button_clicked"));
            button = new Button(left, top, texture);
            button.Depth = depth;
            spritesButton.Add(button);
        }

        private void CreateButtonLevel(int left, int top, string strButtonName, float depth, string Path)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>(Path + strButtonName + "_button"));
            texture.Add(Global.Content.Load<Texture2D>(Path + strButtonName + "_button_clicked"));
            levelbutton = new Button(left, top, texture);
            levelbutton.Depth = depth;
            spritesLevelButton.Add(levelbutton);
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
            spritesPanel.Add(lable);
        }

        private void CreatePanel(int left, int top, string strPanelName)
        {
            List<Texture2D> texture = new List<Texture2D>();
            texture.Add(Global.Content.Load<Texture2D>("Panel\\" + strPanelName));
            panel = new Panel(left, top, texture);
            panel.Depth = 0.4f;
            spritesPanel.Add(panel);

        }


        private Form CreateMainMenuForm(int FormID)
        {
            Form mainMenuForm = new MainMenuForm();
            mainMenuForm.ID = FormID;
            return mainMenuForm;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            base.Draw(gameTime, spriteBatch);


            for (int i = 0; i < spritesButton.Count; i++)
                spritesButton[i].Draw(gameTime, spriteBatch);

            for (int k = 0; k < spritesLevelButton.Count; k++)
                spritesLevelButton[k].Draw(gameTime, spriteBatch);
            

            for (int j = 0; j < spritesPanel.Count; j++)
                spritesPanel[j].Draw(gameTime, spriteBatch);

            

            spriteBatch.End();

            
        }

        public override void Update(GameTime gameTime)
        {
            
            Vector2 worldPos = MouseEventHelper.GetInstance().GetCurrentPos();

            if (MouseEventHelper.GetInstance().HasLeftButtonDownEvent())
            {
                idx = button.GetSelectedButtonIndex(worldPos, spritesButton);
                
                if (idx != -1)
                {
                    for (int i = 0; i < spritesButton.Count; i++)
                        spritesButton[i].Select(i == idx);
                }

                levelnum = levelbutton.GetSelectedButtonIndex(worldPos, spritesLevelButton);

                if (levelnum != -1)
                    for (int j = 0; j < spritesLevelButton.Count; j++)
                        spritesLevelButton[j].Select(j == levelnum);
            }

            if (MouseEventHelper.GetInstance().HasLeftButtonUpEvent())
            {

                for (int i = 0; i < spritesButton.Count; i++)
                    spritesButton[i].Select(false);

                switch (idx)
                {
                    case 0:
                        idx = -1;
                        Global.CurrentForm = CreateMainMenuForm(1) ;
                        break;
                    case 1:
                        idx = -1;
                        
                        break;
                    case 2:
                        idx = -1;
                        break;
                    case 3:
                       
                        idx = -1;
                        break;

                    case -1:
                        break;
                }

                for (int j = 0; j < spritesLevelButton.Count; j++)
                    spritesLevelButton[j].Select(false);

                switch (levelnum)
                {
                    case 1:
                        levelnum = -1;
                        break;

                    case 2:
                        levelnum = -1;
                        break;

                    case 3:
                        levelnum = -1;
                        break;

                    case 4:
                        levelnum = -1;
                        break;

                    case 5:
                        levelnum = -1;
                        break;

                    case 6:
                        levelnum = -1;
                        break;

                    case 7:
                        levelnum = -1;
                        break;

                    case 8:
                        levelnum = -1;
                        break;

                    case 9:
                        levelnum = -1;
                        break;

                    case 10:
                        levelnum = -1;
                        break;

                    case -1:
                        break;

                }
            }

            base.Update(gameTime);
            for (int i = 0; i < spritesButton.Count; i++)
                spritesButton[i].Update(gameTime);

            for (int k = 0; k < spritesLevelButton.Count; k++)
                spritesLevelButton[k].Update(gameTime);

            for (int j = 0; j < spritesPanel.Count; j++)
                spritesPanel[j].Update(gameTime);

            
        }
    }
}
