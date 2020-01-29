using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace masterMind
{
    public class WelcomePage
    {
        Window _mainWindow; // game window 
        WelcomeGUI _welcomeScreen = new WelcomeGUI(); // welcome window GUI + elements
        bool _ready = false; // ready field
        ButtonPress _checkReady; // check ready button
        
        // ctor for the welome page including it's logic
        public WelcomePage(Window _gameWindow)
        {
            this._mainWindow = _gameWindow;
            //
            DisplayInfoCheckReady();
        }
        public void DisplayInfoCheckReady()
        {
            // loop while the use hasn't quit or pressed ready
            while(Input.quit != true && _ready != true)
            {
                // clear the window
                _mainWindow.Clear(Color.White);
                // check for a quit
                Input.CheckQuit();
                
                // draw everything needed 
                _welcomeScreen.Draw();
                
                // new button press object
                buildToggleButton();

                // check for mouse hover over the ready button, if a mouse over event happens change the btn color to dark green
                _checkReady.button.OnHoverChangeColor();
                _checkReady.button.OnHover += (btn) => _checkReady.button.btnColor = Color.RGBColor(20, 68, 30);
                
                // refresh window
                _mainWindow.Refresh(5);

                // checks if the user has pressed the ready button, which starts the game
                if(_checkReady.isPressed())
                {
                    // exit while loop
                    _ready = true;
                    // clear window
                    _mainWindow.Clear(Color.White);
                    // remove elements to be drawn
                    _welcomeScreen.removeElements();
                    // refresh
                    _mainWindow.Refresh(5);
                    // delay before jumping in to the main game. 
                    SplashKit.Delay(500);
                }
            }
        }
        // build the game start ready button toggle check
        public void buildToggleButton()
        {
            _checkReady = new ButtonPress(_welcomeScreen._readyButton);
        }
    }
}