using System;
using SplashKitSDK;

namespace masterMind
{
    // used to the main function needing user input,
    // most used to control the quit logic
    // all functions in this class are static and public
    public class Input 
    {
        // stores the logic is the user wants to quit, (is public and static)
        public static Boolean quit {get; set;}
        // stores the logic of if the user wants a hint (is also static and public)
        public static Boolean hintRequested {get; set;}

        private static double _mouseX, _mouseY;
        // publicly read the x location of the mouse
        public static double MouseX
        {
            get{return _mouseX;} 
        }
        // publicly read the y location of the mouse
        public static double MouseY
        {
            get{return _mouseY;} 
        }
        // method to set the x + y of the mouse
        public static void GetMousePos()
        {
            _mouseX = SplashKit.MouseX();
            _mouseY = SplashKit.MouseY();
        }
        // check if the user wants to quit
        public static void CheckQuit()
        {
            SplashKit.ProcessEvents();

            // if the user requests quit, or presses the escape key set the logic of quit to true

            if (SplashKit.KeyDown(KeyCode.EscapeKey) || SplashKit.QuitRequested() ) //if the escape key is pressed or the window is exited then turn quit to equal true
                {
                    quit = true; // make quit true in turn ending the game and closing the window
                }
            else
            {
                quit = false;
            }
        }
        // if user presses the h key, sets the logic to show that the user requested a hint
        public static void CheckHintRequested()
        {
            SplashKit.ProcessEvents();

            if (SplashKit.KeyDown(KeyCode.HKey)) //if the escape key is pressed or the window is exited then turn quit to equal true
            {
                hintRequested = true; // make quit true in turn ending the game and closing the window
            }
            else
            {
                hintRequested = false;
            }
        }
    }
}
