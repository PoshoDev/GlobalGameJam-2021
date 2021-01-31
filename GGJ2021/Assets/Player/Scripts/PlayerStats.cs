using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public Sprite[] sprites= new Sprite[3];

    public GameObject[] companions= new GameObject[3];
    int[] shells = new int[3] { 0, 0, 0 };

    int lostShell;
    public int shell1;
    public int shell2;
    public int shell3;
    public int hp = 1;
    public float hitTimer = 2F;
    public float nextHit = 0.0F;
    public float timeTillNextHit;

    public GameObject animatedShell;
    public GameObject fireSnail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
     
     public void Update()
     {
        updateShells();
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
                transform.GetChild(0).GetComponent<Animator>().SetBool("gotHit",true);
                hp--;
                lostShell = shells[0];
                shells[0] = shells[1];
                shells[1] = shells[2];
                shells[2] = 0;
                updateShells();
                Instantiate(animatedShell,transform.GetChild(0).GetChild(0).GetChild(0).position,transform.GetChild(0).GetChild(0).GetChild(0).rotation);
                removeFirstCompanion();
                StartCoroutine(ShellAnimation(lostShell));
                Debug.Log("Player lost shell, "+hp+" hp remaining.");
            }
        }
        if (col.gameObject.transform.tag == "shell"){
            if (hp == 4){
                Debug.Log("Player has max shells, replacing 1st shell");
                lostShell = shells[0];
                shells[0] = shells[1];
                shells[1] = shells[2];
                shells[2] = col.gameObject.GetComponent<ShellScript>().shellId;
                shellMechanics(shell2,3);
                updateShells();
                Instantiate(animatedShell,transform.GetChild(0).GetChild(0).GetChild(0).position,transform.GetChild(0).GetChild(0).GetChild(0).rotation);
                StartCoroutine(ShellAnimation(lostShell));
                Destroy(col.gameObject);
            }else{
                int id = col.gameObject.GetComponent<ShellScript>().shellId;
                shells[hp-1] = id;
                shellMechanics(id,hp-1);
                updateShells();
                hp++;
                Destroy(col.gameObject);
                Debug.Log("Player picked up shell, now has "+hp+" hp.");
            }


        }

        
    }
    IEnumerator ShellAnimation(int lostShell){  
        GameObject aniShell = GameObject.Find("Animated Shell Creator(Clone)");
        aniShell.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[lostShell];
        aniShell.transform.GetChild(0).GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1.2f);
        Destroy(aniShell);
    }
    void updateShells(){
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[shell1];
        transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = sprites[shell2];
        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite = sprites[shell3];
        
    }
    void removeFirstCompanion(){
        Destroy(companions[0]);
        companions[0] = companions[1];
        companions[1] = companions[2];
    }
    void shellMechanics(int id, int pos){
        switch (id){
            case 1:
                if(pos > 2){
                    removeFirstCompanion();
                    companions[2] = Instantiate(fireSnail,transform.position,transform.rotation);
                }else{
                   companions[pos] = Instantiate(fireSnail,transform.position,transform.rotation);
                }
            break;
            case 2:
            break;
            case 3:
            break;
        }
    }
}