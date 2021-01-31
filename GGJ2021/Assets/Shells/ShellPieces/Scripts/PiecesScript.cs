using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesScript : MonoBehaviour
{
    public Sprite piece1,piece2,piece3,piece4,piece5,piece6,piece7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece1; 
        transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece2; 
        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece3; 
        transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece4;
        transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece5; 
        transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece6; 
        transform.GetChild(6).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = piece7;  
    }
}
