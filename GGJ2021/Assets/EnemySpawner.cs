using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mechrab, starfish;
    public int xPos;
    public int zPos = 0;
    public int maxEnemies;
    public int chrabCount, starCount;
    public int enemyCount;
    public bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if(!spawning){
            StartCoroutine(SpawnEnemies());
            spawning = true;
        }
        
    }

    // Update is called once per frame
    IEnumerator SpawnEnemies(){
        while(maxEnemies > enemyCount){
            if(chrabCount > 0){
                xPos = Random.Range(-18,18);
                Instantiate(mechrab,transform.position+new Vector3(xPos,0,zPos),Quaternion.identity);
                enemyCount++;
            }

            if(starCount > 0){
                xPos = Random.Range(-18,18);
                Instantiate(starfish,transform.position+new Vector3(xPos,-2,zPos),Quaternion.identity);
                enemyCount++;
            }
            yield return new WaitForSeconds(2f);
            
        }
    }
}
