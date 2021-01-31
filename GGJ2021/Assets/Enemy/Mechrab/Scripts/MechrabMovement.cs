using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MechrabMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public NavMeshAgent nav;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
