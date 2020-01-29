using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace masterMind
{
    // the IDraw interface is used in the GUI creator for the reason of storing a collection of IDraw objects
    // so they can all be drawn on screen, regardless if they are buttons, shapes, text and images
    public interface IDraw
    {
        // used to control inheritanced classes draw function, and to make sure they all have a draw function
        void Draw();
    }
}