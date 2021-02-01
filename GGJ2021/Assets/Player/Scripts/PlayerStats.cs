using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Sprite[] sprites= new Sprite[3];
    public Sprite[] pieces1;
    public AudioSource audio1,audio2,audio3,reload,hit;
    public Sprite[] pieces2;
    public Sprite[] pieces3;

    public Text text;

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

    public GameObject animatedPieces;
    public GameObject fireSnail;
    public GameObject urchin;
    public bool armor = false;

    public bool alive = true;

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
            if (!armor){
                hit.Play();
                if (hp == 1){
                    text.text = "Game Over";
                    alive = false;
                }else{
                    transform.GetChild(0).GetComponent<Animator>().SetBool("gotHit",true);
                    hp--;
                    lostShell = shells[0];
                    shells[0] = shells[1];
                    shells[1] = shells[2];
                    shells[2] = 0;
                    updateShells();
                    GameObject animPieces = Instantiate(animatedPieces,transform.GetChild(0).GetChild(0).GetChild(0).position, Quaternion.identity);
                    Destroy(companions[0]);
                    companions[0] = companions[1];
                    companions[1] = companions[2];
                    companions[2] = null;
                    StartCoroutine(ShellAnimation(lostShell));
                    Debug.Log("Player lost shell, "+hp+" hp remaining.");
                    if(shells[0] == 2 ){
                    armor = true;
                    }
                }
            }else{
                armor = false;
                Debug.Log("Armor protected player, "+hp+" hp remaining.");
            }
            
        }
        if (col.gameObject.transform.tag == "shell"){
            if (hp == 4){
                Debug.Log("Player has max shells, replacing 1st shell");
                lostShell = shells[0];
                shells[0] = shells[1];
                shells[1] = shells[2];
                shells[2] = col.gameObject.GetComponent<ShellScript>().shellId;
                Destroy(companions[0]);
                companions[0] = companions[1];
                companions[1] = companions[2];
                companions[2] = null;
                if(shells[0] == 2 ){
                    armor = true;
                }
                Instantiate(animatedPieces,transform.GetChild(0).GetChild(0).GetChild(0).position,transform.GetChild(0).GetChild(0).GetChild(0).rotation);
                shellMechanics(shells[2],3);
                updateShells();
                StartCoroutine(ShellAnimation(lostShell));
                Destroy(col.gameObject);
            }else{
                int id = col.gameObject.GetComponent<ShellScript>().shellId;
                shells[hp-1] = id;
                shellMechanics(id,hp-1);
                if(shells[0] == 2 ){
                    armor = true;
                }
                updateShells();
                hp++;
                Destroy(col.gameObject);
                Debug.Log("Player picked up shell, now has "+hp+" hp.");
            }


        }

        
    }
    IEnumerator ShellAnimation(int lostShell){  
        GameObject aniPieces = GameObject.Find("FallingPieces(Clone)");
        switch(lostShell){
            case 1:
                aniPieces.transform.GetComponent<PiecesScript>().piece1 = pieces1[0];
                aniPieces.transform.GetComponent<PiecesScript>().piece2 = pieces1[1];
                aniPieces.transform.GetComponent<PiecesScript>().piece3 = pieces1[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece4 = pieces1[3];
                aniPieces.transform.GetComponent<PiecesScript>().piece5 = pieces1[3];
                aniPieces.transform.GetComponent<PiecesScript>().piece6 = pieces1[3];
                aniPieces.transform.GetComponent<PiecesScript>().piece7 = pieces1[3];
            break;
            case 2:
                aniPieces.transform.GetComponent<PiecesScript>().piece1 = pieces2[0];
                aniPieces.transform.GetComponent<PiecesScript>().piece2 = pieces2[1];
                aniPieces.transform.GetComponent<PiecesScript>().piece3 = pieces2[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece4 = pieces2[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece5 = pieces2[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece6 = pieces2[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece7 = pieces2[2];
            break;
            case 3:
                aniPieces.transform.GetComponent<PiecesScript>().piece1 = pieces3[0];
                aniPieces.transform.GetComponent<PiecesScript>().piece2 = pieces3[1];
                aniPieces.transform.GetComponent<PiecesScript>().piece3 = pieces3[2];
                aniPieces.transform.GetComponent<PiecesScript>().piece4 = pieces3[3];
                aniPieces.transform.GetComponent<PiecesScript>().piece5 = pieces3[3];   
                aniPieces.transform.GetComponent<PiecesScript>().piece6 = pieces3[3];
                aniPieces.transform.GetComponent<PiecesScript>().piece7 = pieces3[3];
            break;

        }
        
        
        yield return new WaitForSeconds(1.2f);
        Destroy(aniPieces);
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
        reload.Play();
        switch (id){
            case 1:
                audio1.Play();
                if(pos > 2){
                    companions[2] = Instantiate(fireSnail,transform.position,transform.rotation);
                }else{
                    companions[pos] = Instantiate(fireSnail,transform.position,transform.rotation);
                }
            break;
            case 2:
                audio2.Play();
            break;
            case 3:
                audio3.Play();
                if(pos > 2){
                    companions[2] = Instantiate(urchin,transform.position,transform.rotation,transform);
                    restartUrchins();
                }else{
                    companions[pos] = Instantiate(urchin,transform.position,transform.rotation,transform);
                    restartUrchins();
                }
            break;
        }
    }

    void restartUrchins(){
        int urchins = 0;
        for(int i = 0; i < 3; i++){
            if(shells[i] == 3){
                switch (urchins){
                    case 0:
                        companions[i].transform.position = transform.position +  new Vector3(-4.24f,-1,-4.24f);
                    break;
                    case 1:
                        companions[i].transform.position = transform.position +  new Vector3(0,-1,6);
                    break;
                    case 2:
                        companions[i].transform.position = transform.position + new Vector3(4.24f,-1,-4.24f);
                    break;
                }
                urchins++;
            }
        }
    }
}