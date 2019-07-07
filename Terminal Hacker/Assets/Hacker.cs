using UnityEngine;

public class Hacker : MonoBehaviour
{
    // variables declared outside of functions are Member Variables
    // Game configureation data
    string[] level1Passwords = { "gym", "class", "book", "student", "teacher" };
    string[] level2Passwords = { "account", "withdraw", "finance", "transfer", "interest" };
    string[] level3Passwords = { "mutually", "assured", "destruction", "America", "Canada" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
  
    void Update()
    {
        // Used to test that Random.Range() works properly
        //print(Random.Range(0, level1Passwords.Length));
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
        else if (currentScreen == Screen.Password)
        {
            RunPasswordCheck(input);
        }

    }

    void RunPasswordCheck(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Password invalid. Please try again.");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Password correct. Accessing network...");
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
       _.-'`'-._
    .-'    _    '-.
     `-.__  `\_.-'
       |  `-``\|
       `-.....-A
               #
               #
");
                break;
            case 2:
                Terminal.WriteLine(@"
|#######====================#######|
|#(1)*UNITED STATES OF AMERICA*(1)#|
|#**          /===\   ********  **#|
|*# {G}      | ( ) |             #*|
|#*  ******  | /v\ |    O N E    *#|
|#(1)         \===/            (1)#|
|##=========ONE DOLLAR===========##|
------------------------------------
");
                break;
            case 3:
                Terminal.WriteLine(@"
          _ ._  _ , _ ._
        (_ ' ( `  )_  .__)
      ( (  (    )   `)  ) _)
     (__ (_   (_ . _) _) ,__)
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________
");
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
        
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please choose a level, Mr. Bond: ");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection: ");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                Terminal.WriteLine("Welcome to the LAHS network.\n" +
                    "Please enter the security password: ");
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                Terminal.WriteLine("Welcome to the CitiBank network.\n" +
                    "Please enter the security password: ");
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                Terminal.WriteLine("Welcome to NORAD.\n" +
                    "Please enter the security password: ");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
