using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDamagedList : MonoBehaviour
{
    public Queue<DamageableObject> damagedObjects = new Queue<DamageableObject>();
    [SerializeField] private float timeBetweenSendObjectsToList;
    private ListDisplayer displayer;
    private ScoreCalculator calculator;

    private void Start()
    {
        displayer = GameObject.FindObjectOfType<ListDisplayer>();
    }
    public void AddObjectsToList(DamageableObject objectToAdd)
    {
        damagedObjects.Enqueue(objectToAdd);
    }

    public void StartSendingObjects()
    {
        StartCoroutine("SendObjectsToDisplay");
    }

    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {
        if(statusToRead == Game_State.GameStatus.calculating)
        {
            StartSendingObjects();
        }
    }
    private IEnumerator SendObjectsToDisplay()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenSendObjectsToList);
        while(damagedObjects.Count > 0)
        {
            Debug.LogWarningFormat("sended at {0}",Time.time);
            DamageableObject currentObject = damagedObjects.Peek();
            displayer.ShowObjectsDamaged(currentObject);
            damagedObjects.Dequeue();
            yield return wait;
        }
        yield return new WaitForSeconds(1);
        Game_State.Game_State_Instance.UpdateStatus(Game_State.GameStatus.finished);
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
