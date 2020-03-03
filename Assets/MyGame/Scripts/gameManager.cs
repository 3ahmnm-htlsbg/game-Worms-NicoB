using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject playerPref;
    public Text textPlayerOne;
    private int lifePlayerOne;
    public Text textPlayerTwo;
    private int lifePlayerTwo;
    private int lifeTotal = 5;

    [SerializeField] private Text textWinner;
    void Start()
    {
        lifePlayerOne = lifeTotal;
        lifePlayerTwo = lifeTotal;
        Spawn(true);
        Spawn(false);
        updateLife();
    }
    private void Update()
    {
        if (waitForInput == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                restartGame();
                waitForInput = false;
                textWinner.text = "";
            }
        }
    }
    void Spawn(bool playerOne)
    {
        if (playerOne == true)
        {
            //PlayerOne
            Instantiate(playerPref, new Vector3(-6.64f, 3.85f, 0f), Quaternion.identity);
        }
        if (playerOne == false)
        {
            //PlayerTwo
            Instantiate(playerPref, new Vector3(6.64f, 3.85f, 0f), Quaternion.identity);
        }
    }
    void updateLife()
    {
        textPlayerOne.text = lifePlayerOne.ToString();
        textPlayerTwo.text = lifePlayerTwo.ToString();
    }
    public void PlayerDiedGM(bool PlayerOne)
    {
        if (PlayerOne == true)
        {
            lifePlayerOne -= 1;
            updateLife();
            if (lifePlayerOne <= 0)
            {
                playerWon = "PlayerTwo";
                showWinner();
            }
            Spawn(true);
        }
        if (PlayerOne == false)
        {
            lifePlayerTwo -= 1;
            updateLife();
            if (lifePlayerTwo <= 0)
            {
                playerWon = "PlayerOne";
                showWinner();
            }
            Spawn(false);
        }

    }
    string playerWon;
    bool waitForInput;
    void showWinner()
    {
        textWinner.text = playerWon + " has won. Press Enter to restart.";
        waitForInput = true;
    }
    void restartGame()
    {

        lifePlayerOne = lifeTotal;
        lifePlayerTwo = lifeTotal;
        updateLife();
    }
}
