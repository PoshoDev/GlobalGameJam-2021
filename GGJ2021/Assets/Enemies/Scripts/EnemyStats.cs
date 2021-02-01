using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 3;
    public GameObject urchinShell,radioShell,armorShell;
    public AudioSource[] walking;
    public AudioSource[] hurt;
    public AudioSource[] death;

    public AudioSource hit;
    void Start()
    {
        int ran = Random.Range(0,2);
        walking[ran].Play();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "weapon"){
            
            hit.Play();
            hp--;
            if(hp == 0){
                //Enemy Dies
                
                int ran = Random.Range(0,10);
                switch(ran){
                    case 1:
                        Instantiate(urchinShell,transform.position - new Vector3(0,3,0),transform.rotation);
                    break;
                    case 2:
                        Instantiate(radioShell,transform.position- new Vector3(0,3,0),transform.rotation);
                    break;
                    case 3:
                        Instantiate(armorShell,transform.position- new Vector3(0,3,0),transform.rotation);
                    break;
                }
                
                StartCoroutine("Death");
            }else{
                int ran = Random.Range(0,2);
                hurt[ran].Play();
            }
            
        }
    }
    IEnumerator Death(){
        int ran = Random.Range(0,2);
        death[ran].Play();
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
