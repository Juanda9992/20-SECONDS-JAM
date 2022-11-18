using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplayer : MonoBehaviour
{
    private Queue<GameObject> objectsInScreen = new Queue<GameObject>();
    [SerializeField] private int maxItemsInScreen;
    [SerializeField]private GameObject objectPrefab;

    [SerializeField] private Color explosionColor, fallColor, pushColor;

    public void InstantiateUIElement(DamageableObject objectToShow, int value)
    {
        GameObject currentObject = Instantiate(objectPrefab,Vector3.zero,Quaternion.identity);
        currentObject.transform.SetParent(this.transform);
        TextMeshProUGUI currentOBjectText = currentObject.GetComponent<TextMeshProUGUI>();
        currentOBjectText.text = objectToShow.Name + ": " + value;
        ChangeTextColor(objectToShow.damageType,currentOBjectText);
        CheckObjectsInScreen(currentObject);

    }

    private void ChangeTextColor(DamageableObject.DamageType damage,TextMeshProUGUI textToChange)
    {
        if(damage == DamageableObject.DamageType.explosion)
        {
            textToChange.color = explosionColor;
        }
        else if(damage == DamageableObject.DamageType.fall)
        {
            textToChange.color = fallColor;
        }
        else if(damage == DamageableObject.DamageType.push)
        {
            textToChange.color = pushColor;
        }
    }

    private void CheckObjectsInScreen(GameObject objectToCheck)
    {
        if(objectsInScreen.Count >= maxItemsInScreen)
        {
            Destroy(objectsInScreen.Dequeue());
        }
        objectsInScreen.Enqueue(objectToCheck);
    }
    private void OnEnable()
    {
        ListDisplayer.onObjectReceived += InstantiateUIElement; 
    }
}
