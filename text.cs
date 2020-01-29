using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace masterMind
{   
    // text class, using interface IDraw to draw to the screen with all other screen elements
    public class text : IDraw
    {
        // the string to be displayed
        string _inputString;
        // the default color of black
        Color _textColor = Color.Black;
        // font 
        string _font;
        // size of font 
        int _fontSize;
        // x + y loc 
        double _x, _y;
        // ctor taking in the text needing to be displayed, the font, font size, x pos, y pos
        public text(string textToDisplay, string requiredFont, int fntSize, double X, double Y)
        {
            this._inputString = textToDisplay;
            this._font = requiredFont;
            this._fontSize = fntSize;
            this._x = X;
            this._y = Y;
        }
        //this overload overrides the black text color
        public text(string textToDisplay, Color textColor, string requiredFont, int fntSize, double X, double Y)
        {
            this._inputString = textToDisplay;
            this._textColor = textColor;
            this._font = requiredFont;
            this._fontSize = fntSize;
            this._x = X;
            this._y = Y;
        }
        // method to draw the text to screen
        public void Draw()
        {
            SplashKit.DrawText(_inputString, _textColor, _font, _fontSize, _x, _y); 
        } 
    }
}