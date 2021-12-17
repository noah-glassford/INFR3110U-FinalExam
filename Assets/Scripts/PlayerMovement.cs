using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float movement = Input.GetAxis("Horizontal"); //Get movement on Horizontal axis

        Vector3 movementVector = Vector3.zero;

        movementVector.x = movement * Time.deltaTime * Speed;

        controller.Move(movementVector);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            PlayerPointManager.instance.Lives -= 1;
            Destroy(collision.gameObject);
        }
    }
}
