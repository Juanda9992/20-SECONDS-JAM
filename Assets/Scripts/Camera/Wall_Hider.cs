using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Hider : MonoBehaviour
{
    [SerializeField] private LayerMask wallsMask;
    [SerializeField] private Color hideColor;
    private GameObject previousObject;
    private void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if(Physics.Raycast(ray,out RaycastHit hit, 10,wallsMask))
        {
            if(previousObject != hit.collider.gameObject)
            {
                if(previousObject != null)
                {
                    previousObject.GetComponent<Renderer>().material.color = Color.white;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material.color = hideColor;
                previousObject = hit.collider.gameObject;
            }
        }
        else
        {
            if(previousObject != null)
            {
                previousObject.GetComponent<Renderer>().material.color = Color.white;
                previousObject = null;
            }
        }
    }
}
