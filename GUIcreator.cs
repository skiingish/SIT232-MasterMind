using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace masterMind
{
    // this class looks after all placement of elements on the GUI
    // the child classes are used for different sets of GUI
    public class GUIcreator
    {
        // title text 
        protected text titleText = new text("CodeBreaker", "TravelingTypewriter.otf", 60, 20, 0);
        // local collection of the elements that need to be drawn using the IDraw interface, and it's inheritaned classes
        protected Collection<IDraw> _tobeDrawn = new Collection<IDraw>();
        // public access and setter for the elements in the the collection of IDraw objects
        public Collection<IDraw> elementsToBeDrawn
        {
            get{return _tobeDrawn;}
            set{_tobeDrawn = value;}
        }
        // draw all the required elements
        public void Draw() 
        {
            foreach (var item in elementsToBeDrawn)
            {
                item.Draw();
            }
        }
        // used to remove all objects from the element to be drawn collection
        public void removeElements()
        {
            elementsToBeDrawn.Clear();
        }
    }
    // used to draw the welcome GUI
    public class WelcomeGUI : GUIcreator
    {
        text welcomeText = new text("Welcome to CodeBreaker", "big_noodle_titling.ttf", 50, 300, 0);
        
        Image infoPng = new Image("Info Box", "infoBox.png", 25, 50);

        public Button _readyButton = new Button(475, 665, Color.Green, 50);

        //text readyText = new text("Ready", "big_noodle_titling.ttf", 30, 500, 160);


    public WelcomeGUI()
        {
            //## add everything to the collection to be drawn ##
            _tobeDrawn.Add(welcomeText);
            _tobeDrawn.Add(infoPng);
            _tobeDrawn.Add(_readyButton);
            //_tobeDrawn.Add(readyText);
        }
    }
    // set the required objects needed for the users guess GUI
    public class userGuessGUI : GUIcreator
    {
        
        // buttons
        public Button _BlackButton = new Button(500,160, Color.Black);
        public Button _redButton = new Button(550,160, Color.Red);
        public Button _greenButton = new Button(600,160, Color.Green);
        public Button _BlueButton = new Button(650,160, Color.Blue);
        public Button _YellowButton = new Button(700,160, Color.Yellow);
        public Button _OrangeButton = new Button(750,160, Color.Orange);
            
        // background rectangles
        Rectangle guessesBackGround = new Rectangle(Color.LightGray, 5, 65, 450, 635);
        Rectangle optionsBackground = new Rectangle(Color.LightGray, 470, 65, 450, 200);
        Rectangle selectionBackground = new Rectangle(Color.LightGray, 470, 300, 450, 200);
        Rectangle timeAttemptsBackground = new Rectangle(Color.LightGray, 470, 550, 450, 150);
        // text
        text text2 = new text("Past Attempts", "big_noodle_titling.ttf", 40, 40, 70);
        text text3 = new text("Options", "big_noodle_titling.ttf", 40, 500, 70);
        text text4 = new text("Selection", "big_noodle_titling.ttf", 40, 500, 300);
        text text5 = new text("Time", "big_noodle_titling.ttf", 40, 500, 550);
        text text6 = new text("Attempts", "big_noodle_titling.ttf", 40, 750, 550);

        
        public userGuessGUI()
        {
             //## add everything to the collection to be drawn ##
            
            // rectangles 
            _tobeDrawn.Add(guessesBackGround);
            _tobeDrawn.Add(optionsBackground);
            _tobeDrawn.Add(selectionBackground);
            _tobeDrawn.Add(timeAttemptsBackground);
            // buttons
            _tobeDrawn.Add(_BlackButton);
            _tobeDrawn.Add(_redButton);
            _tobeDrawn.Add(_greenButton);
            _tobeDrawn.Add(_BlueButton);
            _tobeDrawn.Add(_YellowButton);
            _tobeDrawn.Add(_OrangeButton);
            // text
            _tobeDrawn.Add(titleText);
            _tobeDrawn.Add(text2);
            _tobeDrawn.Add(text3);
            _tobeDrawn.Add(text4);
            _tobeDrawn.Add(text5);
            _tobeDrawn.Add(text6);
        }
    } 
}