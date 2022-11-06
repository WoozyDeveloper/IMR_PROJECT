using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //follow the player
        this.GetComponent<NavMeshAgent>().SetDestination(this.GetComponent<Transform>().position);
    }
}
