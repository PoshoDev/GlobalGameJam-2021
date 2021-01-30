using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 angle = new Vector3(.5f,0,.5f);

    public float speed = 0;

    void Start()
    {
        transform.GetComponent<Rigidbody>().AddForce(angle * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
