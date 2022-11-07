using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private Vector3 gotoPosition;
    private Vector3 initialPosition, destinationPosition, firstMonsterPosition;
    private GameObject monster;
    private bool inSight;//true if the monster can see the player, false otherwise
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inSight = false;//momentan true pana se face scriptul care l seteaza
        initialPosition = Vector3.zero;
        firstMonsterPosition = transform.position;

    }

    public bool getSight()
    {
        return inSight;
    }


    private void moveAround()
    {
        if (approximatePosition(transform.position, firstMonsterPosition))//check if we arrived at the initial position
        {
            GetComponent<NavMeshAgent>().SetDestination(gotoPosition);
        }
        else if(approximatePosition(transform.position, gotoPosition))
        {
            GetComponent<NavMeshAgent>().SetDestination(firstMonsterPosition);
        }
    }

    private bool approximatePosition(Vector3 a, Vector3 b)
    {
        Debug.Log("Intru in functie");
        Vector3Int x = new Vector3Int((int)a.x, (int)a.y, (int)a.z);
        Vector3Int y = new Vector3Int((int)b.x, (int)b.y, (int)b.z);
        if (x == y)
        {
            Debug.Log("AM AJUNS");
            return true;
        }
        Debug.Log("N am ajuns sau e ceva problema");
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        inSight = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit extraInformation, 20f) && extraInformation.transform.tag == "Player";

        if (inSight)
        {
            initialPosition = transform.position;//position that the monster has
            destinationPosition = player.transform.position;

            Debug.Log("L am vazut!!!" + extraInformation.transform.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * extraInformation.distance, Color.green);

            //follow the player  
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            transform.LookAt(player.transform);
        }
        else
        {
            //GetComponent<NavMeshAgent>().SetDestination(this.GetComponent<Transform>().position);
            Debug.Log("NU VAD NIMIC AJUTOR!");
            moveAround();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);
        }

        if(approximatePosition(transform.position, destinationPosition))//the monster arrives in the last seen spot
        {
            //send the monster back to its initial position
            GetComponent<NavMeshAgent>().SetDestination(firstMonsterPosition);
            if (approximatePosition(transform.position, initialPosition))//check if we arrived at the initial position
            {
                //begin the movement
                initialPosition = Vector3.zero;
            }
        }
    }
}
