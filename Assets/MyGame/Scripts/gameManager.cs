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
    void Start()
    {
        lifePlayerOne = 5;
        lifePlayerTwo = 5;
        Spawn(true);
        Spawn(false);
    }

    void Uodate()
    {
        textPlayerOne.text = lifePlayerOne.ToString();
        textPlayerTwo.text = lifePlayerTwo.ToString();
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
    public void PlayerDiedGM(bool PlayerOne)
    {
        if (PlayerOne == true)
        {
            lifePlayerOne -= 1;
            Spawn(true);
        }
        if (PlayerOne == false)
        {
            lifePlayerTwo -= 1;
            Spawn(false);
        }
    }
}
