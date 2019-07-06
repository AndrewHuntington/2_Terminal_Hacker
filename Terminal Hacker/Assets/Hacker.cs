using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string greeting = "Hello, Andy.";

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu(greeting);
    }

    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting + "\nWhat would you like to hack into today?\n" +
                    "1) The local high school\n" +
                    "2) A large national bank\n" +
                    "3) NORAD\n" +
                    "\nPlease enter your selection number: ");
    }

    void OnUserInput(string input)
    {
        print("The user typed " + input);
    }
}
