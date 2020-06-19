using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrack : MonoBehaviour
{
    List<Rigidbody> rigidbodyList = new List<Rigidbody>();
    void Update()
    {
        if (Input.GetKey("t"))
        {
            Debug.Log(rigidbodyList.Count);
            foreach (Rigidbody rigidbodyList in rigidbodyList)
            {
                rigidbodyList.AddForce(rigidbodyList.gameObject.transform.right * -200f);

            }

        }
        if (Input.GetKey("z"))
        {
            Debug.Log(rigidbodyList.Count);
            foreach (Rigidbody rigidbodyList in rigidbodyList)
            {
                rigidbodyList.AddForce(rigidbodyList.gameObject.transform.right * -200f);

            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        Rigidbody test = other.gameObject.GetComponent<Rigidbody>();
        if (test != null)
        {
            rigidbodyList.Add(test);
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void OnTriggerExit(Collider other)
    {
        rigidbodyList.Remove(other.gameObject.GetComponent<Rigidbody>());
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}