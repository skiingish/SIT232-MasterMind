using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace masterMind
{
    // stores the postion, color, size, width and height of all child shapes
    public abstract class Shape
    {

        protected double _x, _y;

        protected Color _requiredColor;
        protected double _size;
        
        protected double _width, _height;

    }
    // delegate used for the mouseover event
    public delegate void HoverAction(Button btn);
    public class Button : Shape, IDraw
    {
    // new size field and set to 20 as the size of all buttons unless overridden
    new private double _size = 20;
    // public access to the X pos
    public double X
    {
        get {return _x;}
    }
    // public access to the Y pos 
    public double Y
    {
        get {return _y;}
    }
    // public getter and setter for the size of the button 
    public double Size
    {
        get {return _size;}
        set {_size = value;}
    }
    // public setter for the button color (manly used for mouse over)
    public Color btnColor
    {
        
        set{_requiredColor = value;}
    }
    // circle object created out of a circle button
    public Circle Circle
    {
        get
        {
            return new Circle() {Radius = Size, Center = new Point2D() {X = X, Y = Y}};
        }
    }
    
     
    // ctor for creating circle buttons 
    public Button(double x, double y, Color buttonColor)
    {
        _x = x;
        _y = y;
        _requiredColor = buttonColor;
        
    }
    // ctor overload to create a new circle button taking in a new size for the button
    public Button(double x, double y, Color buttonColor, double Size)
    {
        _x = x;
        _y = y;
        _requiredColor = buttonColor;
        _size = Size;
    }
    // method to draw in the circle buttons 
    public void Draw()
    {
        SplashKit.FillCircle(_requiredColor, _x, _y, _size);
    }
    // overload to draw the circle buttons which sets a new x + y pos
    public void Draw(int xPos, int yPos) 
    {
        SplashKit.FillCircle(_requiredColor, xPos, yPos, _size);
    }
    // overload for the Circle button draw method also taking in a different size 
    public void Draw(int xPos, int yPos, int newSize) 
    {
        SplashKit.FillCircle(_requiredColor, xPos, yPos, newSize);
    }
    // returns true if the mouse is hovering over the button
    public bool IsMouseHover
    {
        get
        {
            return SplashKit.PointInCircle(SplashKit.MousePosition(), Circle);

        }
    }
    // event used to for the hover action methods
    public event HoverAction OnHover;
    
    // this method is used to change the size of the A button on a hover action
    public void OnHoverChangeSize()
    {
        if (IsMouseHover)
        {        
            
            if(OnHover != null)
            {
                OnHover(this);
            }
        }
        else
        {
            Size = 20;
        } 
    }
    // this method changes the color of a button upon hover
    public void OnHoverChangeColor()
    {
        if (IsMouseHover)
        {        
            
            if(OnHover != null)
            {
                OnHover(this);
            }
        }
        else
        {
            btnColor = Color.Green;
        } 
    }
    
    }
    // class used for rectangle objects 
    public class Rectangle : Shape, IDraw
    {
        // ctor which creates a rectangle passing in it's color, location (x + y) and width and height
        public Rectangle(Color RectangleColor, double x, double y, double width, double height)
        {
            this._x = x;
            this._y = y;
            this._requiredColor = RectangleColor;
            this._width = width;
            this._height = height;
        }

        // method to draw the rectangle
        public void Draw()
        {
            SplashKit.FillRectangle(_requiredColor, _x, _y, _width, _height);
        }
    }
}