using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace masterMind
{
    // image class which uses the draw method from the interface IDraw
    // used to draw images needed in the static GUI
    public class Image : IDraw
    {
        // name of the image
        string imgName;
        // the image
        Bitmap _img;
        // x + y pos
        double _x, _y;
        // ctor using the image name, file name, and x + y pos
        public Image(string imageName, string fileName, double X, double Y)
        {
            this.imgName = imageName;
            this._img = new Bitmap(imageName, fileName);
            this._x = X;
            this._y = Y;
        }
        // draw the image at it's x and y
        public void Draw()    
        {
            SplashKit.DrawBitmap(_img, _x, _y);
        }
    
    }
    
}