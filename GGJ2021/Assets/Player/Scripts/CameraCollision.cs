﻿using UnityEngine; using System.Collections;
 

public class CameraCollision : MonoBehaviour {
 

     public float minDistance = 1.0f;
     public float maxDistance = 4.0f;
     public float smooth = 10.0f;
     Vector3 dollyDir;
     float distance; 
     void Awake()
     {
         dollyDir = transform.localPosition.normalized;
         distance = transform.localPosition.magnitude;
     }
     void Update()
     {
            transform.rotation = Quaternion.Euler(transform.rotation.x,35f,transform.rotation.z);
             Vector3 desiredCameraPos = transform.parent.TransformPoint( dollyDir * maxDistance );
             RaycastHit hit;
             if( Physics.Linecast( transform.parent.position, desiredCameraPos, out hit ) && hit.transform.tag == "terrain" )
             {
                 distance = Mathf.Clamp( hit.distance, minDistance, maxDistance );
             }
             else
             {
                 distance=maxDistance;
             }
             transform.localPosition=Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth); 
     }
}