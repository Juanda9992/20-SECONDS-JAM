using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloorSign : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(transform.up * Random.Range(0,360));
    }
}
