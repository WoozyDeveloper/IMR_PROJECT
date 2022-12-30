using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Player player;
    private Rigidbody collectable;
    [SerializeField] private bool pickedUp;
    [SerializeField] private Hand leftHand, rightHand;
    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;

        collectable = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        pickedUp = leftHand.isInHand() || rightHand.isInHand();
        if(pickedUp)
        {
            player.addBattery();
            Destroy(gameObject);
        }
    }

    
}
