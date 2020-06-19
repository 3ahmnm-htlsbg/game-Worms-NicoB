using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0f, 0.5f, 0f, Space.Self);
    }
}
