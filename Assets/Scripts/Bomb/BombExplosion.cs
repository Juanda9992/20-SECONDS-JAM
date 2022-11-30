using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float explosionRange;
    public float explosionForce;
    public float upwardsModifier;
    [SerializeField] private LayerMask destructiblesLayer;
    [SerializeField] private GameObject explosionParticle;
    private ObjectsDamagedList damagedList;
    private Rigidbody playerRb;

    private void Start()
    {
        damagedList = GameObject.FindObjectOfType<ObjectsDamagedList>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void Explode()
    {
        Instantiate(explosionParticle,transform.position,Quaternion.identity);
        Collider[] explosionColliders = Physics.OverlapSphere(transform.position,explosionRange,destructiblesLayer);
        Debug.Log(explosionColliders);
        ExplodePlayer();
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
    private void ExplodePlayer()
    {
        playerRb.freezeRotation = false;
        playerRb.AddExplosionForce(explosionForce * 1.5f,transform.position,explosionRange,upwardsModifier,ForceMode.VelocityChange);
        playerRb.AddTorque(Random.insideUnitSphere * 38,ForceMode.VelocityChange);
    }
    private void ReadGameStatus(Game_State.GameStatus statusToRead)
    {      
        if(statusToRead == Game_State.GameStatus.calculating)
        {
            Explode();
        }
    }
    private void OnEnable()
    {
        Game_State.Game_State_Instance.onStatusChanged += ReadGameStatus;
    }
}
