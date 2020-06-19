using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Bullet : MonoBehaviour
{
    bool hasdestroyed = false;

    Vector3 oldPos;
    Vector3 direction;
    bool hasTriggered;
    [SerializeField] GameObject particleSystemGO;

    private float shake1;
    private float shake2;
    void Start()
    {
        oldPos = transform.position;
    }
    void Update()
    {
        Destroy(gameObject, 8);
        if (hasTriggered == false)
        {
            CheckPosition();
        }

    }
    void OnTriggerEnter(Collider target)
    {
        hasTriggered = true;
        Instantiate(particleSystemGO, this.transform.position, Quaternion.identity);
        ShakeCamera();
        if (target.tag == "Player")
        {
            if (hasdestroyed == false)
            {
                Debug.Log("Player Died");
                target.gameObject.GetComponent<PlayerMove>().PlayerDied();
                hasdestroyed = true;
            }
        }
        Destroy(gameObject, 0);
    }
    void ShakeCamera()
    {
        shake1 = Random.Range(1.5f, 2.5f);
        shake2 = Random.Range(1.5f, 2.5f);
        CameraShaker.Instance.ShakeOnce(shake1, shake2, .1f, 1f);
    }
    void CheckPosition()
    {
        if (transform.position.x < oldPos.x)
        {
            direction = oldPos + transform.position;
        }
        else
        {
            direction = oldPos - transform.position;
        }
        float sign = (direction.y > 0) ? 1 : -1;
        float offset = (sign >= 0) ? 0 : 360;

        float angle = Vector3.Angle(Vector3.right, direction) * sign;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, angle), 100 * Time.deltaTime);

        oldPos = transform.position;
    }
}
