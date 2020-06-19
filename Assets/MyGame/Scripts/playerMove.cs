using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] AudioClip tankGas;
    private Rigidbody rb;
    public bool jumpBool;
    private bool playerNumberOne;
    private GameObject gameManager;

    private bool hasSpawnProt;
    Material m_Material;
    public bool pickUpShoot;
    Animator animator;

    AudioSource audioSource;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        gameManager = GameObject.FindWithTag("GameManager");
        rb = GetComponent<Rigidbody>();
        if (this.transform.position.x < 0)
        {
            playerNumberOne = true;
        }
        m_Material = GetComponent<Renderer>().material;
        StartCoroutine(SpawnProtection());
        audioSource = GetComponent<AudioSource>();
    }
    float scale = 0;
    float pitch;
    bool pitchDown;
    bool pitchUp;
    void PitchAudio()
    {
        if (pitchUp == true)
        {
            scale += 0.05f;
            if (pitch <= 2.4f)
            {
                //sin 0 => 0 || sin 90 => 1
                pitch = 3 * Mathf.Sin(scale);
            }
            if (pitch >= 2.5f)
            {
                pitch = 2.5f;
            }
            audioSource.pitch = pitch;
        }
        else if (pitchDown == true)
        {
            scale -= 0.05f;
            if (pitch >= 0f)
            {
                //sin 0 => 0 || sin 90 => 1
                pitch = 3 * Mathf.Sin(scale);
            }
            if (pitch <= 0.02f)
            {
                pitch = 0f;
                pitchDown = false;
            }
            audioSource.pitch = pitch;
        }
    }
    void Update()
    {
        PitchAudio();
        if (playerNumberOne == true)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                scale = 0;
                pitch = 0;
                pitchUp = true;
                pitchDown = false;
            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                scale = 70;
                pitchUp = false;
                pitchDown = true;
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(transform.right * -.5f, ForceMode.Impulse);
                animator.SetInteger("move", 1);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(transform.right * .5f, ForceMode.Impulse);
                animator.SetInteger("move", 2);
            }
            else if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = tankGas;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                animator.SetInteger("move", 0);
            }
            //jump
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
                rb.AddForce(transform.right * -.5f, ForceMode.Impulse);
                animator.SetInteger("move", 1);
            }
            if (Input.GetKey("l"))
            {
                rb.AddForce(transform.right * .5f, ForceMode.Impulse);
                animator.SetInteger("move", 2);
            }
            else if (!Input.GetKey("j") && !Input.GetKey("l"))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = tankGas;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else if (!Input.GetKey("l") && !Input.GetKey("j"))
            {
                animator.SetInteger("move", 0);
            }
            //jump
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
            gameManager.GetComponent<GameManager>().HealPlayer(playerNumberOne);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PickUpShoot")
        {
            StartCoroutine(CountPickUp());
            Destroy(col.gameObject);
        }
    }
    public void PlayerDied()
    {

        if (!hasSpawnProt)
        {
            gameManager.GetComponent<GameManager>().PlayerDiedGM(playerNumberOne);
            Destroy(gameObject);
        }
    }
    IEnumerator CountPickUp()
    {
        pickUpShoot = true;
        yield return new WaitForSeconds(5);
        pickUpShoot = false;
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
