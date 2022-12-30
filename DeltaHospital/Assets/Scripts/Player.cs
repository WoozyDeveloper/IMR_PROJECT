using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int batteryNumber;
    [SerializeField] private TextMeshProUGUI batteryText;

    // Start is called before the first frame update
    void Start()
    {
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

    }
}
