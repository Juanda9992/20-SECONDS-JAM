using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public const float TIME = 20;
    private float currentTime;
    private bool hasPressedAKey = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = TIME;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !hasPressedAKey)
        {
            hasPressedAKey = true;
        }

        if(hasPressedAKey && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
        }

    }
}
