using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject _settingsButton;

    //private SettingsButton settingsButtonImage = SettingsButton.image;



    void Start()
    {
        //gameObject.GetComponent<SettingsButton.settingsButtonImage>().enabled = false;
        var settingsButton = GetComponent<GameObject>();
        //settingsButton.enabled = false;

    }

    
}
