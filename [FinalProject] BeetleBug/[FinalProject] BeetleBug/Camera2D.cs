using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _FinalProject__BeetleBug
{
    public class Camera2D : InvisibleGameEntity
    {
        private AbstractPathUpdater _PathUpdater = null;

        public AbstractPathUpdater PathUpdater
        {
            get { return _PathUpdater; }
            set { _PathUpdater = value; }
        }

        protected Matrix _World = Matrix.Identity; // bien doi he truc toa do cua doi tuong sang he truc toa do cua the gioi thuc

        public Matrix World
        {
            get { return _World; }
            set { _World = value; }
        }
        protected Matrix _View = Matrix.Identity; // bien doi he truc toa do the gioi thuc sang he truc toa do cua CAMERA

        public Matrix View
        {
            get { return _View; }
            set { _View = value; }
        }
        protected Matrix _Projection = Matrix.Identity; // tao ra anh tu CAMERA

        public Matrix Projection
        {
            get { return _Projection; }
            set { _Projection = value; }
        }

        public Matrix WVPMatrix // World -> Screen
        {
            get
            {
                return World * View * Projection;
            }
        }

        public Matrix InvWVPMatrix // Screen -> World
        {
            get
            {
                return Matrix.Invert(WVPMatrix);
            }
        }


        // Canh co dinh, CAMERA di chuyen

        public float xScale, yScale, zRot, xTran, yTran;

        public Camera2D(float xscale, float yscale, float zrot, float xtran, float ytran)
        {
            xScale = xscale;
            yScale = yscale;
            zRot = zrot;
            xTran = xtran;
            yTran = ytran;
        }

       

        public void Update(GameTime gameTime)
        {
            // Camera thay doi => Su dung matran VIEW
            // Neu nguoc lai thi dung ma tran WORLD

            if (PathUpdater != null)
            {
                PathUpdater.Update(gameTime);
                Vector3 CurPos = PathUpdater.GetCurrentPosition();
                xTran = CurPos.X;
                yTran = CurPos.Y;
            }

            View = Matrix.CreateScale(xScale, yScale, 1)
                 * Matrix.CreateRotationZ(zRot)
                 * Matrix.CreateTranslation(xTran, yTran, 0);
        }
    }
}
