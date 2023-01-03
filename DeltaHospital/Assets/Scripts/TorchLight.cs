using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Light spotLight, pointLight;
    [SerializeField] private int secondsLimit;
    [SerializeField] private float time;
    [SerializeField] private int currentS;

    private void stopLight()
    {
        spotLight.enabled = false;
        pointLight.enabled = false;
    }

    public bool hasLight()
    {
        return spotLight.enabled;
    }

    private void startLight()
    {
        spotLight.enabled = true;
        pointLight.enabled = true;
    }

    private void resetLimit()
    {
        secondsLimit = 5;//Random.Range(180, 300);//3-5 min
        time = 0;
    }

    void Start()
    {
        time = .0f;
        currentS = 0;
        resetLimit();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        currentS = (int)time;
        if(currentS > secondsLimit)
        {
            stopLight();
            resetLimit();
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "battery" && !hasLight())
        {
            startLight();
            Destroy(other.gameObject);
        }    
    }
}
