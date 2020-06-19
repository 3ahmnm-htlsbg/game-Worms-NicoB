using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCylinder : MonoBehaviour
{
    [SerializeField] bool goLeft;
    // Update is called once per frame
    [SerializeField] int i = 60;
    void Update()
    {
        i--;
        if (goLeft && i >= -10 && i <= 40)
        {
            this.transform.Translate(-Vector3.right * Time.deltaTime);
        }
        if (goLeft == false && i >= -10 && i <= 40)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime);
        }

    }
}
