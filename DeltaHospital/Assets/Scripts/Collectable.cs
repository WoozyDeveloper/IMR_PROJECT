using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Player player;
    private Rigidbody collectable;
    // Start is called before the first frame update
    void Start()
    {
        collectable = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y - collectable.transform.position.y <= 2f)//TODO: nu i buna conditia e doar de proba
        {
            player.addBattery();
        }
    }
}
