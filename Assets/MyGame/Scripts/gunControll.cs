using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControll : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    private Rigidbody rb;
    public GameObject gunCubeSpawn;
    private Vector3 gunCubeSpawnPos;

    private Quaternion gunCubeSpawnRot;
    public GameObject bullet;
    private GameObject bulletInst;
    private int i = 0;
    private bool playerNumberOne;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (this.transform.position.x < 0)
        {
            playerNumberOne = true;
        }
    }
    void Update()
    {
        if (playerNumberOne == true)
        {
            //rotate the gun left
            if (Input.GetKey("q"))
            {
                rb.AddTorque(0f, 0f, 5f);
            }
            //rotate the gun right
            if (Input.GetKey("e"))
            {
                rb.AddTorque(0f, 0f, -5f);
            }
            //shoot
            if (Input.GetKey("2"))
            {
                i--;
                if (i < 0)
                {
                    shoot();
                }
            }
        }
        else
        {
            //rotate the gun left
            if (Input.GetKey("u"))
            {
                rb.AddTorque(0f, 0f, 5f);
            }
            //rotate the gun right
            if (Input.GetKey("o"))
            {
                rb.AddTorque(0f, 0f, -5f);
            }
            //shoot
            if (Input.GetKey("8"))
            {
                i--;
                if (i < 0)
                {
                    shoot();
                }
            }
        }
    }
    bool pickUpShoot;
    void shoot()
    {
        pickUpShoot = playerGO.GetComponent<playerMove>().pickUpShoot;
        Rigidbody rbBullet;
        //get GunCube Pos and Rotation
        gunCubeSpawnPos = gunCubeSpawn.transform.position;
        gunCubeSpawnRot = gunCubeSpawn.transform.rotation;
        //Instatiate
        bulletInst = Instantiate(bullet, gunCubeSpawnPos, gunCubeSpawnRot) as GameObject;
        i = 20;
        if (pickUpShoot)
        {
            bulletInst.GetComponent<Rigidbody>().mass = bulletInst.GetComponent<Rigidbody>().mass / 2f;
            i = 10;
        }
        //add force
        rbBullet = bulletInst.GetComponent<Rigidbody>();
        rbBullet.AddForce(this.transform.up * 2f, ForceMode.Impulse);
    }
}
