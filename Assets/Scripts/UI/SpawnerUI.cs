using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private float timeToHideText;
    private PlayerSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
    }

    private void HideText()
    {
        infoText.gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void ShowText()
    {
        infoText.gameObject.transform.parent.gameObject.SetActive(true);
        infoText.text = "You are starting in the "  +spawner.currentPoint.spawnPointName;
        Invoke("HideText",timeToHideText);
    }
    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.playing)
        {
            ShowText();
        }
    }

    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += ReadGameStatus;    
    }

    private void OnDisable() 
    {
        Game_State.Game_State_Instance.onStatusChanged -= ReadGameStatus;    
    }
}
