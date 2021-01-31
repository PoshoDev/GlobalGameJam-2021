using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 100 * Time.deltaTime);
    }
}
