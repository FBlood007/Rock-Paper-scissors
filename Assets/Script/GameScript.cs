using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class GameScript : MonoBehaviour
{

    string rock = "Rock", paper = "Paper", scissor = "Scissor";

    //String to store random computer selection
    string randomResult;
    //String to store random Player input selection
    string playerSelection;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Rock-Paper-Scissor \n Select your Input: \n R = Rock, P = Paper, S = Scissor");
    }

    //Method to generate random Rock-Paper-Scissor string
    void RandomResultSelection()
    {
        var RndB = new System.Random();
        var results = new List<string> { "Rock", "Paper", "Scissor" };
        int index = RndB.Next(results.Count);
        randomResult = results[index];
    }    

    // Update is called once per frame
    void Update()
    {
        DetectInput();
       
    }

    //This method displays the final result
    void DisplayResult(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log($"You have choose {playerSelection} \n" + $"Computer choose {randomResult}");
                Debug.Log("Draw");
                break;
            case 1:
                Debug.Log($"You have choose {playerSelection} \n" + $"Computer choose {randomResult}");
                Debug.Log("You Won !!!");
                break;
            case -1:
                Debug.Log($"You have choose {playerSelection} \n" + $"Computer choose {randomResult}");
                Debug.Log("Computer Won !!!");
                break;
            default:
                Debug.Log("Please give correct input - Select P, R or S");
                break;

        }
    }

    //Method to detect the Player Input
    void DetectInput()
    {
        RandomResultSelection();
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    if(keyCode == KeyCode.P) {
                        playerSelection = paper;
                        FinalResult();

                    }
                    else if (keyCode == KeyCode.R)
                    {
                        playerSelection = rock;
                        FinalResult();

                    }
                    else if (keyCode == KeyCode.S)
                    {
                        playerSelection = scissor;
                        FinalResult();

                    }
                    else
                    {
                        DisplayResult(3);
                    }

                    break;
                }
            }
        }
       

        }
    //Method to find compare the result
    void FinalResult()
    {
        
        if (randomResult == paper && playerSelection == paper || randomResult == rock && playerSelection == rock || randomResult == "Scissor" && playerSelection == "Scissor" )
        {
            DisplayResult(0);
        }
        else if (randomResult == paper && playerSelection == scissor)
        {
            DisplayResult(1);
        }
        else if (randomResult == scissor && playerSelection == paper)
        {
            DisplayResult(-1);
           
        }
        else if (randomResult == rock && playerSelection == paper)
        {
            DisplayResult(1);
        }
        else if (randomResult == paper && playerSelection == rock)
        {
            DisplayResult(-1);
        }
        else if (randomResult == scissor && playerSelection == rock)
        {
            DisplayResult(1);
        }
        else if (randomResult == rock && playerSelection == scissor)
        {
            DisplayResult(-1);
        }
    }
}

   
