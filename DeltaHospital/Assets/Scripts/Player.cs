using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int batteryNumber;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 250;
        batteryNumber = 0;
    }

    public void addBattery()
    {
        batteryNumber++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
