using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private TorchLight torchLight;
    [SerializeField] private bool touchedTheGround;
    [SerializeField] private Player player;
    private Rigidbody collectable;
    [SerializeField] private bool pickedUp;
    [SerializeField] private Hand leftHand, rightHand;

    public bool isDropped()
    {
        return touchedTheGround;
    }

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
        touchedTheGround = false;

        leftHand = GameObject.FindWithTag("leftHand").GetComponent<Hand>();
        rightHand = GameObject.FindWithTag("rightHand").GetComponent<Hand>();

        collectable = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }


    // private void OnCollisionEnter(Collision collision) {
    //     if(collision.gameObject.tag == "ground")
    //     {
    //         touchedTheGround = true;    
    //         Debug.Log("Il fac true pe touchtheground!!!");
    //     }
    // }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            touchedTheGround = true;    
            Debug.Log("Il fac true pe touchtheground!!!");
        }
        
        if(touchedTheGround)
        {
            player.addBattery();
            Debug.Log("Destroy!!!");
            Destroy(gameObject);
        }
    }

    
}
