using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gotoObject;
    private Vector3 gotoPosition, initialPosition, destinationPosition, firstMonsterPosition;
    private bool inSight;//true if the monster can see the player, false otherwise
    [SerializeField] private GameObject player;
    private bool freezeStatus;

    private RaycastHit hit1, hit2, hit3, hit4, hit5, hit6, hit7, hit8, hit9, hit10, hit11;

    // Start is called before the first frame update
    void Start()
    {
        gotoPosition = gotoObject.transform.position;
        animator = GetComponent<Animator>();
        inSight = false;
        initialPosition = Vector3.zero;
        firstMonsterPosition = transform.position;

        freezeStatus = false;
    }

    public void setFreezeStatus(bool status)
    {
        freezeStatus = status;
    }

    public bool getFreezeStatus()
    {
        return freezeStatus;
    }

    public bool getSight()
    {
        return inSight;
    }


    private void moveAround()
    {
        if (approximatePosition(transform.position, firstMonsterPosition))//check if we arrived at the initial position
        {
            animator.Play("monsterRun");
            //Debug.Log("goto");

            GetComponent<NavMeshAgent>().SetDestination(gotoPosition);
            //GetComponent<NavMeshAgent>().destination = gotoPosition;
        }
        else if(approximatePosition(transform.position, gotoPosition))
        {
            //Debug.Log("back");
            GetComponent<NavMeshAgent>().SetDestination(firstMonsterPosition);
        }
    }

    private bool approximatePosition(Vector3 a, Vector3 b)
    {
        Vector3Int x = new Vector3Int((int)a.x, 0, (int)a.z);
        Vector3Int y = new Vector3Int((int)b.x, 0, (int)b.z);
        if (x == y)
            return true;
        return false;
    }

    private bool checkSight()
    {
        return (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit1, 20f) && hit1.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.2f, .0f, .0f)), out hit2, 20f) && hit2.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.2f, .0f, .0f)), out hit3, 20f) && hit3.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.4f, .0f, .0f)), out hit4, 20f) && hit4.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.4f, .0f, .0f)), out hit5, 20f) && hit5.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.6f, .0f, .0f)), out hit6, 20f) && hit6.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.6f, .0f, .0f)), out hit7, 20f) && hit7.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.8f, .0f, .0f)), out hit8, 20f) && hit8.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.8f, .0f, .0f)), out hit9, 20f) && hit9.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(1f, .0f, .0f)), out hit10, 20f) && hit10.transform.tag == "Player") ||
                  (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(1f, .0f, .0f)), out hit11, 20f) && hit11.transform.tag == "Player");
    }

    // Update is called once per frame
    void Update()
    {
        inSight = checkSight();

        

        GetComponent<NavMeshAgent>().isStopped = getFreezeStatus();
        if (inSight)
        {
            initialPosition = transform.position;//position that the monster has
            destinationPosition = player.transform.position;

            #region DEBUG ONLY
#if UNITY_EDITOR
            //Debug.Log("L am vazut!!!" + extraInformation.transform.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit1.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.2f, .0f, .0f)) * hit2.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.2f, .0f, .0f)) * hit3.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.4f, .0f, .0f)) * hit4.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.4f, .0f, .0f)) * hit5.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.6f, .0f, .0f)) * hit6.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.6f, .0f, .0f)) * hit7.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.8f, .0f, .0f)) * hit8.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.8f, .0f, .0f)) * hit9.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(1f, .0f, .0f)) * hit10.distance, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(1f, .0f, .0f)) * hit11.distance, Color.green);
#endif
            #endregion
            //follow the player  
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            transform.LookAt(player.transform);
        }
        else
        {

            //GetComponent<NavMeshAgent>().SetDestination(this.GetComponent<Transform>().position);
            moveAround();

            #region DEBUG ONLY
#if UNITY_EDITOR
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.2f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.2f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.4f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.4f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.6f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.6f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0.8f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(0.8f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(1f, .0f, .0f)) * 20f, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(1f, .0f, .0f)) * 20f, Color.red);
#endif
            #endregion
        }

        if (approximatePosition(transform.position, destinationPosition))//the monster arrives in the last seen spot
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
