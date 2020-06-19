using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCube : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    GameObject inst;
    GameObject instBefore;
    GameObject cornerBefore;
    float length;
    Vector3 vectorLength;
    [SerializeField] float distance = 0.2f;
    [SerializeField] float heightTank = 2.5f;
    [SerializeField] float lengthTank = 4.7f;
    // Start is called before the first frame update
    void Start()
    {
        instBefore = Instantiate(prefab, this.transform.position - this.transform.right * distance, transform.rotation);
        instBefore.GetComponent<HingeJoint>().connectedBody = this.GetComponent<Rigidbody>();
        cornerBefore = this.gameObject;
    }
    int rowToBuild = 1;
    void Update()
    {
        if (length <= lengthTank && rowToBuild == 1)
        {
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, 0));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, 0));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            vectorLength = cornerBefore.transform.position - instBefore.transform.position;
            length = vectorLength.magnitude;

        }
        if (length >= lengthTank && rowToBuild == 1)
        {
            rowToBuild = 2;
            cornerBefore = instBefore;
            length = 0;
        }
        if (length <= heightTank && rowToBuild == 2)
        {
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -90));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -90));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            vectorLength = cornerBefore.transform.position - instBefore.transform.position;
            length = vectorLength.magnitude;
        }
        if (length >= heightTank && rowToBuild == 2)
        {
            rowToBuild = 3;
            cornerBefore = instBefore;
            length = 0;
        }
        if (length <= lengthTank && rowToBuild == 3)
        {
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -180));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -180));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            vectorLength = cornerBefore.transform.position - instBefore.transform.position;
            length = vectorLength.magnitude;
        }
        if (length >= lengthTank && rowToBuild == 3)
        {
            rowToBuild = 4;
            cornerBefore = instBefore;
            length = 0;
        }
        if (length <= heightTank && rowToBuild == 4)
        {
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -270));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            inst = Instantiate(prefab, instBefore.transform.position - instBefore.transform.right * distance, Quaternion.Euler(0, 0, -270));
            inst.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
            instBefore = inst;
            vectorLength = cornerBefore.transform.position - instBefore.transform.position;
            length = vectorLength.magnitude;
        }
        if (length >= heightTank && rowToBuild == 4)
        {
            this.GetComponent<HingeJoint>().connectedBody = instBefore.GetComponent<Rigidbody>();
        }
    }
}
