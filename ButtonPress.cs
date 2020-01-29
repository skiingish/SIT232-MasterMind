using System;
using SplashKitSDK;

namespace masterMind
{
    // class used to check for button presses, 
    // this is older code written when build first started
    public class ButtonPress
    {   
        // the state of if the button has been pressed
        private Boolean _pressed {get; set;}
        private Boolean _xLocTrue, _yLocTrue;
        // if the mouse has clicked
        private Boolean _clicked;
        // x and y of the mouse pos
        private double _mouseX, _mouseY;
        // public access to the state of pressed
        public Boolean Pressed
        {
            get {return _pressed;}
        }
        // the button object to be checked
        public Button button;
        // the value of the button thats store which in turn when be used for user guess selection input
        public string buttonNumber;
        // ctor for the button press
        public ButtonPress()
        {

        }
        // ctor to build a new button press object passing in the required button to check
        public ButtonPress(Button buttonToCheck)
        {
            this.button = buttonToCheck;
        }
        // ctor overload to pass in the button to be check and the value of that button if it is pressed
        public ButtonPress(Button buttonToCheck, string buttonNumberToCheck)
        {
            this.button = buttonToCheck;
            this.buttonNumber = buttonNumberToCheck;
        }
        // get the users mouse pos 
        private void GetMousePos()
        {
            Input.GetMousePos();
            _mouseX = Input.MouseX;
            _mouseY = Input.MouseY;
        }
        // check if the user clicked
        private void GetMouseClick()
        {
            SplashKit.ProcessEvents();

            if (SplashKit.MouseDown(MouseButton.LeftButton))
            {
                _clicked = true;
            }
            else
            {
                _clicked = false;
            }
        }
        // checks if the button was pressed and if so returns true on the button object
        public bool isPressed()
        {
            // get the location of the mouse
            GetMousePos();
            // did the mouse click
            GetMouseClick();
            
            // if the mouse is inside the space of the button taken by the button set x y loc to true
            if (_mouseY >= button.Y - button.Size && _mouseY <= button.Y + button.Size)
            {
                _xLocTrue = true;
            }
            if (_mouseX >= button.X - button.Size && _mouseX <= button.X + button.Size)
            {
                _yLocTrue = true;
            }
            // if both x and y locations are true and the mouse also click, then return as true for a true button click
            if (_xLocTrue && _yLocTrue && _clicked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}