using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game Config Data
    string[] lvl1Pwds = {"books", "aisle", "self", "password", "font", "borrow" };
    string[] lvl2Pwds = {"prisoner", "handcuffs", "holster", "uniform", "arrest" };

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

    private void ShowMainMenu()
    {
        curScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
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

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well Done!");
        }
        else
        {
            Terminal.WriteLine("Wrong password. Try again");
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLvlNum = (input == "1" || input == "2");
        if (isValidLvlNum)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame()
    {
        curScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = lvl1Pwds[Random.Range(0, lvl1Pwds.Length)];
                break;
            case 2:
                password = lvl2Pwds[Random.Range(0, lvl2Pwds.Length)];
                break;
            default:
                Debug.LogError("Invalid Level #");
                break;
        }
        Terminal.WriteLine("Please enter the password: ");
    }
}
