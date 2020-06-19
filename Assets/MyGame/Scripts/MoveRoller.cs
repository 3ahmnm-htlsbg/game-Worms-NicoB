using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoller : MonoBehaviour
{
    Rigidbody rb;
    bool hasTriggered;
    [SerializeField] GameObject particleSystemGO;
    bool hasdestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(new Vector3(0f, 0f, -180f));
    }
    void OnTriggerEnter(Collider target)
    {
        hasTriggered = true;
        if (target.tag == "Player")
        {
            if (hasdestroyed == false)
            {
                Debug.Log("Player Died");
                target.gameObject.GetComponent<PlayerMove>().PlayerDied();
                Instantiate(particleSystemGO, this.transform.position, Quaternion.identity);
                Destroy(gameObject, 0);
                hasdestroyed = true;
            }
        }

    }
}
