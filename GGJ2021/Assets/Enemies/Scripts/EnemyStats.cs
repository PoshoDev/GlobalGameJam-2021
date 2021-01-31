using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "weapon"){
            Debug.Log("Enemy got hit by a weapon");

            hp--;
            if(hp == 0){
                //Enemy Dies
                Debug.Log("Enemy hp is now dead");
                Destroy(gameObject);
            }else{
                Debug.Log("Enemy hp is now "+hp);
            }
            
        }
    }
}
