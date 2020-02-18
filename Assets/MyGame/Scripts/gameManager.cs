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
    void Start()
    {
        lifePlayerOne = lifeTotal;
        lifePlayerTwo = lifeTotal;
        Spawn(true);
        Spawn(false);
        updateLife();
    }
    void Spawn(bool playerOne)
    {
        if (playerOne == true)
        {
            //PlayerOne
            Instantiate(playerPref, new Vector3(-6.64f, 3.85f, 0f), this.transform.rotation);
        }
        if (playerOne == false)
        {
            //PlayerTwo
            Instantiate(playerPref, new Vector3(6.64f, 3.85f, 0f), this.transform.rotation);
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
                restartGame();
            }
            Spawn(true);
        }
        if (PlayerOne == false)
        {
            lifePlayerTwo -= 1;
            updateLife();
            if (lifePlayerTwo <= 0)
            {
                restartGame();
            }
            Spawn(false);
        }

    }
    void restartGame()
    {
        lifePlayerOne = lifeTotal;
        lifePlayerTwo = lifeTotal;
        updateLife();
    }
}
