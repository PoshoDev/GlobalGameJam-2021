using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mechrab, starfish;

    public int maxX;
    public int maxZ;
    public int maxEnemies;
    public int chrabCount, starCount;
    public int enemyCount;
    public bool spawning = false;
    public GameObject spawnerDoor;
    public float doorSpeed = 1.0f;
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
                int xPos = Random.Range(-maxX,maxX);
                int zPos = Random.Range(-maxZ,maxZ);
                Instantiate(mechrab,transform.position+new Vector3(xPos,0,zPos),Quaternion.identity);
                enemyCount++;
            }

            if(starCount > 0){
                int xPos = Random.Range(-maxX,maxX);
                int zPos = Random.Range(-maxZ,maxZ);
                Instantiate(starfish,transform.position+new Vector3(xPos,-2,zPos),Quaternion.identity);
                enemyCount++;
            }
            yield return new WaitForSeconds(4f);
            
        }
    }
}
