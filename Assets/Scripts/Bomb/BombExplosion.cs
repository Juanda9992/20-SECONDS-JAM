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
        Collider[] explosionColiders = Physics.OverlapSphere(transform.position,explosionRange,destructiblesLayer);

        foreach(var destructible in explosionColiders)
        {
            if(destructible.TryGetComponent<DamageableObject>(out DamageableObject damageObj))
            {
                damageObj.damageType = DamageableObject.DamageType.explosion;
                damagedList.AddObjectsToList(damageObj);
                damageObj.rb.AddExplosionForce(explosionForce,transform.position,explosionRange,upwardsModifier,ForceMode.VelocityChange);
            }
        }
        damagedList.StartSendingObjects();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }

    private void OnEnable()
    {
        BombTimer.OnTimerOut += Explode;
    }
}
