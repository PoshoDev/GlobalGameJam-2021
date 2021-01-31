using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20;
    public float impactForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("bullet hit something");
        if(other.transform.tag == "enemy" ||other.transform.tag == "terrain" ){
            
            Destroy(gameObject);
        }
        
    }     
}
