using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private GameObject monster;
    private bool inSight;//true if the monster can see the player, false otherwise
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inSight = true;//momentan true pana se face scriptul care l seteaza
    }

    // Update is called once per frame
    void Update()
    {
       // if (inSight)
       // {
            //follow the player
       //     Debug.Log("Ma duc!!!");
            this.GetComponent<NavMeshAgent>().SetDestination(player.GetComponent<Transform>().position);
       //     this.transform.LookAt(player.transform);
        //}
        
    }
}
