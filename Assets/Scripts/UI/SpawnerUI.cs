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

        infoText.text = "You are starting in the "  +spawner.currentPoint.spawnPointName;

        Invoke("HideText",timeToHideText);
    }

    private void HideText()
    {
        infoText.gameObject.transform.parent.gameObject.SetActive(false);
    }

}
