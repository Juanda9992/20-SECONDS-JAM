using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float explosionRange;

    [SerializeField] private LayerMask destructiblesLayer;
    private void Explode()
    {
        Collider[] explosionColiders = Physics.OverlapSphere(transform.position,explosionRange,destructiblesLayer);

        foreach(var destructible in explosionColiders)
        {
            if(destructible.TryGetComponent<DamageableObject>(out DamageableObject damageObj))
            {
                Debug.Log(damageObj.name);
            }
        }
    }

    private void OnEnable()
    {
        BombTimer.OnTimerOut += Explode;
    }
}
