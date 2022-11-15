using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public delegate void onTimerOut();
    public static event onTimerOut OnTimerOut;
    public const float TIME = 20;
    private float currentTime;
    private bool hasPressedAKey = false, hasExploded = false;
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
        }

        if(currentTime <= 0 && !hasExploded)
        {
            hasExploded = true;
            OnTimerOut?.Invoke();
        }

    }
}
