using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RoundController : MonoBehaviour
{
    public int round;
    public VideoPlayer video;
    public RawImage videoImage;
    public Text roundText;
    public bool roundStart = false;
    public bool firstStart = true;
    public bool videoDone = true;

    public AudioSource mainSong;

    public GameObject northSpawner,southSpawner,eastSpawner,westSpawner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("VideoDonePlaying");
        northSpawner.GetComponent<EnemySpawner>().maxEnemies = 0;
        southSpawner.GetComponent<EnemySpawner>().maxEnemies = 0;
        eastSpawner.GetComponent<EnemySpawner>().maxEnemies = 0;
        westSpawner.GetComponent<EnemySpawner>().maxEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
            
        if(videoDone){
            if (!(video.isPlaying) && firstStart ) {
                    mainSong.Play();
                    firstStart = false;
                    video.gameObject.SetActive(false);
                    videoImage.enabled = false;
                    round = 0;
                    northSpawner.GetComponent<EnemySpawner>().maxEnemies = 1;
                    southSpawner.GetComponent<EnemySpawner>().maxEnemies = 1;
                    eastSpawner.GetComponent<EnemySpawner>().maxEnemies = 1;
                    westSpawner.GetComponent<EnemySpawner>().maxEnemies = 1;
                    roundStart = true;
                }
                if(GameObject.FindGameObjectsWithTag("enemy").Length == 0 && roundStart){
                    //roundStart = false;
                    Debug.Log("Round "+round+" over.");
                    round++;
                    roundText.text = "Round "+round;
                    northSpawner.GetComponent<EnemySpawner>().maxEnemies = (2*round);
                    northSpawner.GetComponent<EnemySpawner>().enemyCount = 0;
                    northSpawner.GetComponent<EnemySpawner>().spawning = false;

                    southSpawner.GetComponent<EnemySpawner>().maxEnemies = (2*round);
                    southSpawner.GetComponent<EnemySpawner>().enemyCount = 0;
                    southSpawner.GetComponent<EnemySpawner>().spawning = false;

                    eastSpawner.GetComponent<EnemySpawner>().maxEnemies = (2*round);
                    eastSpawner.GetComponent<EnemySpawner>().enemyCount = 0;
                    eastSpawner.GetComponent<EnemySpawner>().spawning = false;

                    westSpawner.GetComponent<EnemySpawner>().maxEnemies = (2*round);
                    westSpawner.GetComponent<EnemySpawner>().enemyCount = 0;
                    westSpawner.GetComponent<EnemySpawner>().spawning = false;
                }
        }       
    }
    IEnumerator VideoDonePlaying(){
        yield return new WaitForSeconds(2f);
        videoDone = true;
    }
}
