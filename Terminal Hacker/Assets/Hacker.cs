using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // variables declared outside of functions are Member Variables
    // game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into today?\n" +
                    "1) The local high school\n" +
                    "2) A large national bank\n" +
                    "3) NORAD\n" +
                    "\nPlease enter your selection number: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please choose a level, Mr. Bond: ");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection: ");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level + ".");
    }
}
