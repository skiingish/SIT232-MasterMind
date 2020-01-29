using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace masterMind
{
    //used to get the guess from the user
    public class UserGuess
    {
        private const int GUESSSIZE = 4; // size of the users guess is always 4
        Window _theGameWindow; // main game window
        userGuessGUI userInterface = new userGuessGUI(); // game window GUI + elements
        List<Button> _usersGuessToDraw = new List<Button>(); // stores the users guess to draw
        List<int[]> _PastGuesses = new List<int[]>(); // stores all passed in past guesses 
        Collection<ButtonPress> _toggleButtons = new Collection<ButtonPress>();
        int _countCorrect;
        int _positionCorrect;
        string[] _theUsersGuess = new string[GUESSSIZE];
        string singleStringGuess;
        int _numOfGuesses;
        public string theUsersGuess
        {
            get{return singleStringGuess;}
        }
        public UserGuess(Window _gameWindow, List<int[]> pastGueses, int countC, int posC, int attempts)
        {
            this._theGameWindow = _gameWindow;
            this._PastGuesses = pastGueses;
            this._countCorrect = countC;
            this._positionCorrect = posC;
            this._numOfGuesses = attempts;
            // check the amount of guesses the user has had in case it's time to quit. 
            checkAttempts();
            
            // this is where the magic happens :) see below 
            getUserGuess();
            
        }
        public void getUserGuess()
        {
            // count is use to make sure the while loop keeps loop while the user needs to make more of a selection. 
            int count = 0;
            // loops while the count is below 4 so make sure the user enters a 4 number guess
            while (count < GUESSSIZE && Input.quit != true)
            {
                //clear the game window
                _theGameWindow.Clear(Color.White);
                
                // check if the user asked to quit
                Input.CheckQuit();
                
                // check if user wants a hint (used for testing mainly)
                Input.CheckHintRequested();
                
                // sneaky sneaky hint printers method
                printHint();
                
                // draw all the buttons, rectangles and text to the screen 
                userInterface.Draw();
                // checks to see if a mouse over has happened on any of the toggle buttons
                // if the event is happening then change the toggle button in question to a bigger size to show mouse over
                foreach (var item in _toggleButtons)
                {
                    item.button.OnHoverChangeSize();
                    item.button.OnHover += (btn) => item.button.Size = 30;
                    //item.button.OnHover += (btn) => _theGameWindow.Clear(Color.Black);
                }

                // builds the toggle buttons used for user input
                buildToggleButtons();
                
                // check each button in the collection if any button returns as pressed then
                // at that button number to the guess plus increase the guess count
                foreach (var item in _toggleButtons)
                {
                    if (item.isPressed())
                    {
                        // breaks if the user has already picked one of the options
                        // stopping them from picking the same number twice
                        if (_theUsersGuess.Contains(item.buttonNumber))
                        {
                            break;
                        }
                        // add the number of the button pressed to the users guessed
                        _theUsersGuess[count] = item.buttonNumber;
                        // used for testing
                        System.Console.WriteLine($"guess: {item.buttonNumber}");
                        // add to the list so the current guess is drawn
                        _usersGuessToDraw.Add(item.button);
                        // increase count
                        count++;
                        // delay is used not to flood the guess with the same number.
                        // commented out due to use of the above Contains method 
                        //SplashKit.Delay(150);
                    }
                }
                
                
                // draw the guess to the user
                int drawXpos = 550;
                foreach (var item in _usersGuessToDraw)
                {
                    item.Draw(drawXpos, 420, 40);
                    drawXpos = drawXpos + 90;
                }
                // draw in all past guesses to the side of the screen
                DrawPastGuesses();

                // display the current game infomation terms of the correctness of the users guess.
                SplashKit.DrawText(_countCorrect + " correct, " + _positionCorrect + " in the right place ", Color.Black, "Dosis-Regular.otf", 18, 250, 660);
                // display the number of guesses
                SplashKit.DrawText(Convert.ToString(_numOfGuesses), Color.Black, "Dosis-Regular.otf", 55, 830, 620);
                // display the gameTime
                SplashKit.DrawText(Convert.ToString(CodeBreaker.totalGameTime.Ticks / 1000), Color.Black, "Dosis-Regular.otf", 55, 630, 620);
                // refresh that window yo!
                _theGameWindow.Refresh(1);
            } // while loop ends

            //used for testing, to print the guess to the console
            singleStringGuess = string.Join("", _theUsersGuess); //try converting array to one string to be passed to the game logic to be tested
            System.Console.WriteLine("Your Guess :" + singleStringGuess);

        }
        // called to check where the user is within the limit of guesses
        private void checkAttempts()
        {
            //displays if the user if on their last guess
            if(_numOfGuesses == 11)
            {
                _theGameWindow.Clear(Color.Black);
                SplashKit.DrawText("LAST GUESS!", Color.Red, "TravelingTypewriter.otf", 60, 330, 200);
                _theGameWindow.Refresh(20);
                SplashKit.Delay(1000);
            }
            
            //user hits a blank screen with the game over text if they have run out of guesses, also gets stuck there until they press quit.
            if (_numOfGuesses == 12)
            {
                while(Input.quit != true)
                {
                _theGameWindow.Clear(Color.Black);
                SplashKit.DrawText("GAME OVER!", Color.Red, "TravelingTypewriter.otf", 60, 330, 200);
                _theGameWindow.Refresh(20);
                Input.CheckQuit();
                }
            }
        }
        // below is used to draw all the uses guesses to the screen
        // loops over the _pastGuesses list, for each int array in _pastguesses
        // it loops each item drawing it where it needs to be and in the correct color
        // before moving on to the next guess  
        private void DrawPastGuesses()
        {
            int textYpos = 140;
            foreach (var i in _PastGuesses)
            {
                int circleXPos2 = 45;
                for (int x = 0; x < GUESSSIZE; x++)
                {
                    if (i[x] == 0)
                    {
                        SplashKit.FillCircle(Color.Black, circleXPos2, textYpos, 20);
                    }
                    if (i[x] == 1)
                    {
                        SplashKit.FillCircle(Color.Red, circleXPos2, textYpos, 20);
                    }
                    if (i[x] == 2)
                    {
                        SplashKit.FillCircle(Color.Green, circleXPos2, textYpos, 20);
                    }
                    if (i[x] == 3)
                    {
                        SplashKit.FillCircle(Color.Blue, circleXPos2, textYpos, 20);
                    }
                    if (i[x] == 4)
                    {
                        SplashKit.FillCircle(Color.Yellow, circleXPos2, textYpos, 20);
                    }
                    if (i[x] == 5)
                    {
                        SplashKit.FillCircle(Color.Orange, circleXPos2, textYpos, 20);
                    }

                    circleXPos2 = circleXPos2 + 50;
                }
                textYpos = textYpos + 50;
            }
        }
        //  prints the hint to the console if it's requested
        public void printHint()
        {
            if (Input.hintRequested)
            {
                System.Console.WriteLine("What you want a Hint?.... .." + CodeBreaker.answer);
            }
        }
        // creates a new button press object passing in each number that matches it's correct color
        // add thems all to the _toggleButtons collection. 
        public void buildToggleButtons()
        {
            //clear out the collection of buttons to check. 
            _toggleButtons.Clear();
            //create new button press checks passing the correct button and the No. of that button.
            ButtonPress _checkBlack = new ButtonPress(userInterface._BlackButton, "0");
            ButtonPress _checkRed = new ButtonPress(userInterface._redButton, "1");
            ButtonPress _checkGreen = new ButtonPress(userInterface._greenButton, "2");
            ButtonPress _checkBlue = new ButtonPress(userInterface._BlueButton, "3");
            ButtonPress _checkYellow = new ButtonPress(userInterface._YellowButton, "4");
            ButtonPress _checkOrange = new ButtonPress(userInterface._OrangeButton, "5");

            // add all buttons to btnPressed collection
            _toggleButtons.Add(_checkBlack);
            _toggleButtons.Add(_checkRed);
            _toggleButtons.Add(_checkGreen);
            _toggleButtons.Add(_checkBlue);
            _toggleButtons.Add(_checkYellow);
            _toggleButtons.Add(_checkOrange);
        }
    }
}