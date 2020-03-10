using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    bool hasdestroyed = false;
    void Update()
    {
        Destroy(gameObject, 4);
    }
    void OnTriggerEnter(Collider target)
    {
        Debug.Log("Player Died");
        if (target.tag == "Player")
        {
            if (hasdestroyed == false)
            {
                target.gameObject.GetComponent<playerMove>().PlayerDied();
                hasdestroyed = true;
            }
            Destroy(gameObject, 0);
        }
    }
}
