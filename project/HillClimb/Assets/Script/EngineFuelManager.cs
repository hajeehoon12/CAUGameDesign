using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngineFuelManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public float maxFuel; // max fuel temp value = 5
    public float currentFuel; // current fuel
    
    [SerializeField] Slider slider_JetEngine;
    [SerializeField] TMP_Text txt_JetEngine;

    PlayerController thePC; // player controller connect
    public bool isFuel { get; private set; } // can get but cannot revise value
    public bool isEmpty { get; private set; }


    void Start()
    {

        maxFuel = PlayerPrefs.GetFloat("Fuel", 5);
        currentFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = currentFuel;
        thePC = GameObject.Find("Player").GetComponent< PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFuel > 0) {
            isFuel = true;
        } else {
            isFuel = false;
            currentFuel = 0;
            thePC.GameOver();
        }
        
        if (thePC.boosterPressed)
        {
            currentFuel -= Time.deltaTime;
        }

        if (currentFuel == 0)
            isEmpty = true;
        else
            isEmpty = false;
        slider_JetEngine.value = currentFuel;
        txt_JetEngine.text = Mathf.Round(currentFuel / maxFuel * 100f).ToString() + " %";

    }
}
