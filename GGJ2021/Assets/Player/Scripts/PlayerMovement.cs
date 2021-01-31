using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        // Move the controller
        if (Input.GetKey("w")){
            transform.Translate(Vector3.forward * speed);
            transform.GetChild(0).GetComponent<Animator>().SetBool("walking",true);
        }
        if (Input.GetKey("s")){
            transform.Translate(Vector3.back * speed);
            transform.GetChild(0).GetComponent<Animator>().SetBool("walking",true);
        }
        if (Input.GetKey("a")){
            transform.Translate(Vector3.left * speed);
            transform.GetChild(0).GetComponent<Animator>().SetBool("walking",true);
        }
        if (Input.GetKey("d")){
            transform.Translate(Vector3.right * speed);
            transform.GetChild(0).GetComponent<Animator>().SetBool("walking",true);
        }
        if (!Input.GetKey("d") &&!Input.GetKey("s") &&!Input.GetKey("a") &&!Input.GetKey("w")){
            transform.GetChild(0).GetComponent<Animator>().SetBool("walking",false);
        }
        

        // Player and Camera rotation
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        //rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }
    void OnTriggerEnter(Collider other)
    {
        
        
    }
}