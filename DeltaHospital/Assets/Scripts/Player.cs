using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int batteryNumber;
    [SerializeField] private TextMeshProUGUI batteryText;
    private Hand leftHand, rightHand;
    [SerializeField] private GameObject batteryObj;
    public bool batterySpawned;

    // Start is called before the first frame update
    void Start()
    {
        batterySpawned = false;

        leftHand = GameObject.FindWithTag("leftHand").GetComponent<Hand>();
        rightHand = GameObject.FindWithTag("rightHand").GetComponent<Hand>();

        Application.targetFrameRate = 250;
        batteryNumber = 0;
        batteryText.text = batteryNumber.ToString();
    }

    public void addBattery()
    {
        batteryNumber++;
        batteryText.text = batteryNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftHand.checkHandRotation() && !batterySpawned)
        {
            batterySpawned = true;
            Vector3 handPosition = leftHand.transform.position;
            Vector3 handDirection = leftHand.transform.forward;
            //batteryObj.GetComponent<Collider>().enabled = false;
            Instantiate(batteryObj,handPosition + handDirection * 1.5f, Quaternion.identity);
            batteryNumber--;
        }
        else if(rightHand.checkHandRotation())
        {
            Debug.Log("Give RIGHT");
            // rightHand.GetComponent<Collider>().enabled = false;
            // Instantiate(batteryObj, rightHand.getPosition(), Quaternion.identity);
            // batteryNumber--;

        }
        if(!leftHand.checkHandRotation() && batterySpawned)
        {
            batterySpawned = false;

            batteryObj.GetComponent<Collider>().enabled = true;
        }
    }
}
