using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game Config Data
    string[] lvl1Pwds = {"books", "aisle", "shelf", "password", "font", "borrow" };
    string[] lvl2Pwds = {"prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] lvl3Pwds = { "cryptology", "hacking", "cipher", "encryption", "authentication" };
    const string menuHint = "You may type menu at any time.";

    // Game State
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen curScreen;
    string password;

	// Use this for initialization
	void Start () {
        level = 0;
        print(lvl1Pwds);
        ShowMainMenu();
    }

    void OnUserInput(string input)
    {
        if (input.Equals("menu", System.StringComparison.OrdinalIgnoreCase))
        {
            ShowMainMenu();
        }
        else if (curScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (curScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void ShowMainMenu()
    {
        curScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NSA");
        Terminal.WriteLine("Enter your selection: ");
    }

    private void RunMainMenu(string input)
    {
        bool isValidLvlNum = (input == "1" || input == "2" || input == "3");
        if (isValidLvlNum)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    private void AskForPassword()
    {
        curScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password. hint " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = lvl1Pwds[Random.Range(0, lvl1Pwds.Length)];
                break;
            case 2:
                password = lvl2Pwds[Random.Range(0, lvl2Pwds.Length)];
                break;
            case 3:
                password = lvl3Pwds[Random.Range(0, lvl3Pwds.Length)];
                break;
            default:
                Debug.LogError("Invalid Level #");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        curScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ______
   /     //  
  /     //
 /____ //
(_____(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '}
"
                );
                break;
            case 3:
                Terminal.WriteLine("You hacked into the NSA!");
                Terminal.WriteLine(@"
 _   _  _____  ___  
| \ | |/  ___|/ _ \ 
|  \| |\ `--./ /_\ \
| . ` | `--. \  _  |
| |\  |/\__/ / | | |
\_| \_/\____/\_| |_/
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
