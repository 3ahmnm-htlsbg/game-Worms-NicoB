using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialChain : MonoBehaviour
{
    [SerializeField] Material chainMat;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Renderer>().material = chainMat;
    }
}
