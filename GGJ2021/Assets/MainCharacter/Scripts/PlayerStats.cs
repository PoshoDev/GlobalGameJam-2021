using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int[] shells;
    public int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        Debug.Log("Player is colliding");
        if (col.gameObject.transform.tag == "enemy"){
            if (hp == 1){
                Debug.Log("Player is dead");
            }else{
                Destroy(col.gameObject);
                hp--;
                Debug.Log("Player lost shell, "+hp+" hp remaining.");
                
            }
        }
        if (col.gameObject.transform.tag == "shell"){
            if (hp == 3){
                Debug.Log("Player has max shells, replacing 1st shell");
            }else{
                hp++;
                Destroy(col.gameObject);
                Debug.Log("Player picked up shell, now has "+hp+" hp.");

            }
        }
    }
}
