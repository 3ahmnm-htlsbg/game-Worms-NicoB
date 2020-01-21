using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    private Rigidbody rb;
    public bool jumpBool;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (Input.GetKey("a"))
        {
            rb.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey("s") && jumpBool == true)
        {
            jump();
            jumpBool = false;
        }
    }
    void jump()
    {
        rb.AddForce(0f, 3f, 0f, ForceMode.Impulse);
    }
    void OnTriggerStay(Collider target)
    {
        if (target.tag == "cubeScene")
        {
            jumpBool = true;
        }
    }
}
