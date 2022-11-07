using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private GameObject monster;
    private bool inSight;//true if the monster can see the player, false otherwise
    private SightSensor sight;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inSight = false;//momentan true pana se face scriptul care l seteaza
    }

    private bool checkSight()
    {
        
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit extraInformation, 20f) && extraInformation.transform.tag == "Player";

        if (inSight)
        {
            //follow the player
            Debug.Log("L am vazut!!!" + extraInformation.transform.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * extraInformation.distance, Color.green);
            
            GetComponent<NavMeshAgent>().SetDestination(player.GetComponent<Transform>().position);
            transform.LookAt(player.transform);
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(this.GetComponent<Transform>().position);
            Debug.Log("NU VAD NIMIC AJUTOR!");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
