using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerBulletPrefab;

    [SerializeField]
    private Transform BulletExit;

    public float BulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    //To be replaced with design pattern later
    void Shoot()
    {
        GameObject temp = ObjectPool.instance.SpawnFromPool("PlayerBullet", BulletExit.position, Quaternion.identity);
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(Vector3.forward * BulletSpeed, ForceMode.Impulse);

        GetComponent<AudioSource>().Play();


    }
}
