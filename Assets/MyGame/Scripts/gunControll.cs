using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControll : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gunCubeSpawn;
    private Vector3 gunCubeSpawnPos;
    public GameObject gunCubeShoot;
    private Vector3 gunCubeShootPos;
    private Quaternion gunCubeSpawnRot;
    public GameObject bullet;
    private GameObject bulletInst;
    private int i = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            rb.AddTorque(0f, 0f, 5f);
        }
        if (Input.GetKey("e"))
        {
            rb.AddTorque(0f, 0f, -5f);
        }
        if (Input.GetKey("2"))
        {
            i--;
            if (i < 0)
            {
                shoot();
                i = 20;
            }
        }
    }
    void shoot()
    {
        Rigidbody rbBullet;
        //get GunCube Pos and Rotation
        gunCubeSpawnPos = gunCubeSpawn.transform.position;
        gunCubeSpawnRot = gunCubeSpawn.transform.rotation;
        //Instatiate
        bulletInst = Instantiate(bullet, gunCubeSpawnPos, gunCubeSpawnRot);
        //add force
        gunCubeShootPos = gunCubeShoot.transform.position;
        rbBullet = bulletInst.GetComponent<Rigidbody>();
        rbBullet.AddForce(gunCubeShootPos, ForceMode.Impulse);
    }
}
