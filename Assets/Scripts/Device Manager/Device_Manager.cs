using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Device_Manager : MonoBehaviour
{
    private IEnumerator Start()
    {
        while(true)
        {
            foreach(var controller in Gamepad.all)
            {
                Debug.Log(controller.name);
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void AddControl(InputDevice device, InputDeviceChange change)
    {
        if(change == InputDeviceChange.Added)
        {
            Debug.Log($"Added controller {device.displayName}" );
        }

        else if(change == InputDeviceChange.Removed)
        {
            Debug.Log($"Removed controller {device.displayName}" );
        }
    }
    private void OnEnable() 
    {
        InputSystem.onDeviceChange += AddControl;    
    }

    private void OnDisable() 
    {
        InputSystem.onDeviceChange -= AddControl;    
    }
}
