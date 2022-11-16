using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDamagedList : MonoBehaviour
{
    public Queue<DamageableObject> damagedObjects = new Queue<DamageableObject>();
    [SerializeField] private float timeBetweenSendObjectsToList;
    private ListDisplayer displayer;

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
    private IEnumerator SendObjectsToDisplay()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenSendObjectsToList);
        while(damagedObjects.Count > 0)
        {
            displayer.ShowObjectsDamaged(damagedObjects.Dequeue());
            yield return wait;
        }
    }
}
