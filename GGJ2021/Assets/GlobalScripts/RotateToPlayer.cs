using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,transform.GetChild(0).transform.eulerAngles.y,0);
    }
}
