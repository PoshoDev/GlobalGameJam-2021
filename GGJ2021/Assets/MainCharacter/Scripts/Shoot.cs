 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Shoot : MonoBehaviour
 {
     // Script should be attached to spawn point of foam rather than foam itself!!
     public GameObject bullet;    
     public float fireRate = 0.5F;
     private float nextFire = 0.0F;
 
     // Start is called before the first frame update
     void Start()
     {
 
     }
 
     // Update is called once per frame
     void Update()
     {
         if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             GameObject instFoam = Instantiate(bullet, transform.position, transform.rotation);
             
         }
 
     }
 }
