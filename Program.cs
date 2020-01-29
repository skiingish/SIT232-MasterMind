using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;
namespace masterMind
{

    public class Program
    {
        public static void Main()
        {
            // the main game window and size
            Window gameWindow = new Window("Hello Welcome to CodeBreaker", 950, 720);
            // welcome screen
            WelcomePage welcomeScreen = new WelcomePage(gameWindow);
            // create the code to be cracked
            CodeBreaker breakThatCode = new CodeBreaker(gameWindow);
            // attempt to crack the code 
            breakThatCode.codeToBreak();
        }
    }
}