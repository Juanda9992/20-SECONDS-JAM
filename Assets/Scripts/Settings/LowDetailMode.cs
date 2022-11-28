using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowDetailMode : MonoBehaviour
{
    [SerializeField]private Toggle toggle;
    private bool isToggled;
    // Start is called before the first frame update
    void Start()
    {
        isToggled = toggle.isOn;
    }

    public void ChangeQuality()
    {   
        isToggled = toggle.isOn;
        if(isToggled)
        {
            QualitySettings.SetQualityLevel(0);
        }
        else
        {
            QualitySettings.SetQualityLevel(3);
        }
    }

}
