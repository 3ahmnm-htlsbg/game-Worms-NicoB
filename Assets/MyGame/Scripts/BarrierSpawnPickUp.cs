using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawnPickUp : MonoBehaviour
{
    [SerializeField] GameObject healPick;
    [SerializeField] GameObject shootPick;
    Vector3 spawnPosition;
    void OnTriggerEnter(Collider target)
    {
        if (target.name.Contains("Bullet") || target.name.Contains("Roller"))
        {
            if (target.gameObject.transform.position.x >= 0.36)
            {
                spawnPosition = new Vector3(-0.7f, target.gameObject.transform.position.y, 0f);
            }
            else
            {
                spawnPosition = new Vector3(1f, target.gameObject.transform.position.y, 0f);
            }
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Instantiate(shootPick, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(healPick, spawnPosition, Quaternion.identity);
            }
            if (target.name.Contains("Roller"))
            {
                Destroy(target.gameObject);
            }
        }
    }
}
