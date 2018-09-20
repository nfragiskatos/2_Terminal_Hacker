using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    enum Screen { MainMenu, Password, Win};
    Screen curScreen;
    String password;

	// Use this for initialization
	void Start () {
        level = 0;
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
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "combobulate";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
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
        Terminal.WriteLine("You have chosen level " + level);
    }


}
