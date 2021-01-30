using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int[] shells = new int[3] { 0, 0, 0 };
    public int shell1;
    public int shell2;
    public int shell3;
    public int hp = 1;
    public float hitTimer = 2F;
    public float nextHit = 0.0F;
    public float timeTillNextHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
     
     public void Update()
     {
     
        shell1=shells[0];
        shell2=shells[1];
        shell3=shells[2];
        if (Time.time < nextHit){
            timeTillNextHit = nextHit-Time.time;
        }else{
            timeTillNextHit = 0;
        }
        
        if (Time.time > nextHit){
            transform.GetChild(0).GetComponent<Animator>().SetBool("gotHit",false);
        }
    }
    void OnCollisionEnter(Collision col)
    {
         if (col.gameObject.transform.tag == "enemy" && Time.time > nextHit){
            nextHit = Time.time + hitTimer;
            if (hp == 1){
                Debug.Log("Player is dead");
            }else{
                //Destroy(col.gameObject);
                transform.GetChild(0).GetComponent<Animator>().SetBool("gotHit",true);
                //hp--;
                shells[0] = shells[1];
                shells[1] = shells[2];
                shells[2] = 0;
                Debug.Log("Player lost shell, "+hp+" hp remaining.");
            }
        }
        if (col.gameObject.transform.tag == "shell"){
            //nextHit = Time.time + nextHit;
            if (hp == 4){
                Debug.Log("Player has max shells, replacing 1st shell");
                shells[0] = shells[1];
                shells[1] = shells[2];
                shells[2] = col.gameObject.GetComponent<ShellScript>().shellId;
                Destroy(col.gameObject);
            }else{
                
                shells[hp-1] = col.gameObject.GetComponent<ShellScript>().shellId;
                hp++;
                Destroy(col.gameObject);
                Debug.Log("Player picked up shell, now has "+hp+" hp.");
            }
        }
    }
}