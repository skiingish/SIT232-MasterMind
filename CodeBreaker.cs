using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;

namespace masterMind
{
    public class CodeBreaker
    {
        private const int SIZE = 4; //4 allways 4
        private Window _gameWindow;
        private String _inputGuess{get; set;}
        Random _rnd = new Random();
        int[] target = new int[SIZE];
        int countCorrect = 0;
        int positionCorrect = 0;
        int attempts = 0;
        static Timer gameTime = new Timer("Time Taken");
        int[] userNumber;
        List<int[]> _pastGuesses = new List<int[]>();    
        static string hint;
        public static string answer 
        {
            get{return hint;}
        }
        public static Timer totalGameTime
        {
            get{return gameTime;}
        }
        public CodeBreaker(Window ThisGameWindow)
        {
            this._gameWindow = ThisGameWindow;
        }
        
        public void codeToBreak()
        {
            //create a target that is 4 digits long
            //the distinct method is used to remove any duplicated random numbers
            while (target.Distinct().Count() != SIZE)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    //at the current index set a random number between 0 - 5 (next is used to make sure the number is a postive number and less then 6)
                    target[x] = _rnd.Next(6);
                }
            }
            //start the timer
            gameTime.Start();
            
            //stores a hint of the target answer
            hint = String.Join("",target);
            
            //main game logic loop (loops as long as quit isn't true or the user hasn't guessed correctly)
            while(true && Input.quit != true)
            {
                SplashKit.ProcessEvents();
                
                //check if the user has quit
                Input.CheckQuit();
            
                //creates a new user guess object, set as the new input guess
                UserGuess takeAPunt = new UserGuess(_gameWindow, _pastGuesses, countCorrect, positionCorrect, attempts);
                _inputGuess = takeAPunt.theUsersGuess; //!! change this to get a user input from the user
                
                //if the user has asked to quit then quit the game loop
                if (Input.quit)
                {
                    System.Console.WriteLine("quitting");
                    break;
                }
                //add one to attempts
                attempts++;
                
                //convert the user guess to an int array
                userNumber = _inputGuess.Select(v => v - '0').ToArray();
                
                //reset the correctness vaildation 
                countCorrect = 0;
                positionCorrect = 0;

                //check the users correctness
                //for each index in the users number
                for (int i = 0; i < SIZE; i++)
                {
                    //if the target contains any of the same numbers as the current index of users number, add to count correct
                    if (target.Contains(userNumber[i]))
                    {
                        countCorrect++;
                    }
                    //if the current index of target is the same as the current index of the users number then add to position correct
                    if (target[i] == userNumber[i])
                    {
                        positionCorrect++;
                    }    
                }
                //display if the user guesses the correct code and then quit. 
                if (positionCorrect == SIZE)
                {   
                    _gameWindow.Clear(Color.White);
                    SplashKit.DrawText($"All Correct!!!, Attempts Taken: {attempts}, Time Taken: {Convert.ToString(totalGameTime.Ticks / 1000)}", Color.Green, "TravelingTypewriter.otf", 30, 130, 200);
                    _gameWindow.Refresh(20);
                    SplashKit.Delay(3000);
                    break;
                }
                
                //tell the user the correctness for their guess
                System.Console.WriteLine(countCorrect + " correct, ");
                System.Console.WriteLine(positionCorrect + " in the right place. Try again");  
                
                //add the users guess to the list of past guesses
                //used to draw in the past guesses
                //this is where to add in the correctness code if it is to be drawn along side each guess
                _pastGuesses.Add(userNumber);
               
                //delay before letting the user guess again
                SplashKit.Delay(1000);
                
            }
        }
    }
}