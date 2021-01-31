using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MechrabMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    public NavMeshAgent nav;
    void Start()
    {
        player =  GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
