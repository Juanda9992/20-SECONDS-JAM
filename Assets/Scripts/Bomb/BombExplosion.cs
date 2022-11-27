using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float explosionRange;
    public float explosionForce;
    public float upwardsModifier;
    [SerializeField] private LayerMask destructiblesLayer;
    private ObjectsDamagedList damagedList;

    private void Start()
    {
        damagedList = GameObject.FindObjectOfType<ObjectsDamagedList>();
    }
    private void Explode()
    {
        Collider[] explosionColliders = Physics.OverlapSphere(transform.position,explosionRange,destructiblesLayer);
        Debug.Log(explosionColliders);
        foreach(var destructible in explosionColliders)
        {
            if(destructible.TryGetComponent<DamageableObject>(out DamageableObject damageObj))
            {
                if(destructible.TryGetComponent(out StaticObject staticObj))
                {
                    staticObj.Trigger();
                }
                damageObj.damageType = DamageableObject.DamageType.explosion;
                damagedList.AddObjectsToList(damageObj);
                damageObj.rb.AddExplosionForce(explosionForce,transform.position,explosionRange,upwardsModifier,ForceMode.VelocityChange);
            }
        }
        damagedList.StartSendingObjects();
        gameObject.SetActive(false);
    }

    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {      
        if(statusToRead == Game_State.GameStatus.calculating)
        {
            Explode();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Game_State.Game_State_Instance.UpdateStatus(Game_State.GameStatus.calculating);
        }
    }
    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += ReadGameStatus;
    }
}
