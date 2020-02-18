﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 2);
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            target.gameObject.GetComponent<playerMove>().PlayerDied();
            Destroy(gameObject);
        }
    }
}