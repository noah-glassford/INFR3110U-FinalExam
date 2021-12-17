using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float MovementUpperBound;
    public float MovementLowerBound;

    public float MovementMultipler;
    private float t = 0;

    private bool goingUp = true;

    [SerializeField]
    private Transform bulletExit;

    private void Update()
    {
        #region RandMovement
        if (t >= 1)
            goingUp = false;
        else if (t <= 0)
            goingUp = true;

        if (goingUp)
            t += Time.deltaTime;
        else
            t -= Time.deltaTime;

        MovementMultipler = Mathf.Lerp(MovementUpperBound, MovementLowerBound, t);


        Vector3 movement = Vector3.zero;
        movement.x = Random.Range(-2,2);
       

        movement *= MovementMultipler;

        movement.z = Random.Range(-0.001f, 0f);

        GetComponent<CharacterController>().Move(movement);

        #endregion

       

    }

    private void FixedUpdate()
    {
        if (Random.value > 0.99f)
            Shoot();

        //shooting
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
            PlayerPointManager.instance.Points += 500;
            PlayerPointManager.instance.Timer += 1;
        }
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }

    }

    void Shoot()
    {
        GameObject temp = ObjectPool.instance.SpawnFromPool("EnemyBullet", bulletExit.position, Quaternion.identity);
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(-Vector3.forward * 0.2f, ForceMode.Impulse);

        GetComponent<AudioSource>().Play();


    }

}
