using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 angle = new Vector3(.5f,0,.5f);
    public float velX;
    public float velZ;

    public float bounceSpeed;

    public float speed = 0;

    void Start()
    {
        transform.GetComponent<Rigidbody>().AddForce(angle * speed);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vel = GetComponent<Rigidbody>().velocity;
        if(GetComponent<Rigidbody>().velocity.x < bounceSpeed && GetComponent<Rigidbody>().velocity.x  > 0 ){
            GetComponent<Rigidbody>().velocity = new Vector3(bounceSpeed, 0, GetComponent<Rigidbody>().velocity.z);
            if(GetComponent<Rigidbody>().velocity.z < bounceSpeed && GetComponent<Rigidbody>().velocity.z  > 0 ){
                GetComponent<Rigidbody>().velocity = new Vector3(bounceSpeed,0,bounceSpeed);
            }else{
                if(GetComponent<Rigidbody>().velocity.z > -bounceSpeed && GetComponent<Rigidbody>().velocity.z  < 0 ){
                    GetComponent<Rigidbody>().velocity = new Vector3(bounceSpeed,0,-bounceSpeed);
                }
            }
        }else{
            if(GetComponent<Rigidbody>().velocity.x > -bounceSpeed && GetComponent<Rigidbody>().velocity.x  < 0 ){
                GetComponent<Rigidbody>().velocity = new Vector3(-bounceSpeed, 0, GetComponent<Rigidbody>().velocity.z);
                if(GetComponent<Rigidbody>().velocity.z < bounceSpeed && GetComponent<Rigidbody>().velocity.z  > 0 ){
                    GetComponent<Rigidbody>().velocity = new Vector3(-bounceSpeed,0,bounceSpeed);
                }else{
                    if(GetComponent<Rigidbody>().velocity.z > -bounceSpeed && GetComponent<Rigidbody>().velocity.z  < 0 ){
                        GetComponent<Rigidbody>().velocity = new Vector3(-bounceSpeed,0,-bounceSpeed);
                }
            }
            }
        }
        
        velX = vel.x;
        velZ = vel.z;

    }
}
