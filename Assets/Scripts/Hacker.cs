using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;

    // Types
    enum Screen { Main_Menu, Password, Win};
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.Main_Menu;
        var game_title = "Terminal Hacker 1.0";
        Terminal.ClearScreen();
        Terminal.WriteLine(game_title);
        Terminal.WriteLine($"Welcome to Terminal Hacker 1.0");
        Terminal.WriteLine("Choose a game difficulty");
        Terminal.WriteLine("Press 1 for Easy");
        Terminal.WriteLine("Press 2 for Medium");
        Terminal.WriteLine("Press 3 for Hard");
        Terminal.WriteLine("Make your difficulty selection: ");
    }

    void OnUserInput(string input)
    {
        if(input.ToLower() == "menu") // we can always go direct to main menu
        {
            currentScreen = Screen.Main_Menu;
            ShowMainMenu();
        }
        else if(currentScreen == Screen.Main_Menu)
        {
            RunMainMenu(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1" || input == "2")
        {
            level = Int32.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please input a valid command.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine($"You have chosen level {level}");
        Terminal.WriteLine("Please enter password: ");
    }

}
