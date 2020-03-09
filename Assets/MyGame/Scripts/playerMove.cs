using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody rb;
    public bool jumpBool;
    private bool playerNumberOne;
    private GameObject gameManager;

    private bool hasSpawnProt;
    Material m_Material;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        rb = GetComponent<Rigidbody>();
        if (this.transform.position.x < 0)
        {
            playerNumberOne = true;
        }
        m_Material = GetComponent<Renderer>().material;
        StartCoroutine(SpawnProtection());
    }
    void Update()
    {
        if (playerNumberOne == true)
        {
            if (Input.GetKey("a"))
            {
                rb.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }
            if (Input.GetKeyDown("s") && jumpBool == true)
            {
                jump();
                jumpBool = false;
            }
        }
        else
        {
            if (Input.GetKey("j"))
            {
                rb.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }
            if (Input.GetKey("l"))
            {
                rb.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }
            if (Input.GetKeyDown("k") && jumpBool == true)
            {
                jump();
                jumpBool = false;
            }
        }
    }
    void jump()
    {
        rb.AddForce(0f, 5f, 0f, ForceMode.Impulse);
    }
    void OnTriggerStay(Collider target)
    {
        if (target.tag == "cubeScene")
        {
            jumpBool = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PickUp")
        {
            gameManager.GetComponent<gameManager>().HealPlayer(playerNumberOne);
            Destroy(col.gameObject);
        }
    }
    public void PlayerDied()
    {
        if (!hasSpawnProt)
        {
            gameManager.GetComponent<gameManager>().PlayerDiedGM(playerNumberOne);
            Destroy(gameObject);
        }
    }
    IEnumerator SpawnProtection()
    {
        hasSpawnProt = true;
        m_Material.color = Color.red;

        yield return new WaitForSeconds(3);
        m_Material.color = Color.green;
        hasSpawnProt = false;
    }
}
