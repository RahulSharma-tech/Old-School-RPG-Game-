using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
     Health target = null;
    float damage = 0;
    [SerializeField] float speed = 3f;
    [SerializeField] bool isHoming = true;
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float maxLifeTime = 10f;
    [SerializeField] float lifeAfterImpact = 0.2f;
    [SerializeField] GameObject[] destroyOnHit = null;

    private void Start()
    {
        transform.LookAt(GetAimLocation());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (isHoming && !target.IsDead()) {
            transform.LookAt(GetAimLocation());
        }
        
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    public void SetTarget(Health target,float damage) {

        this.target = target;
        this.damage = damage;

        Destroy(gameObject,maxLifeTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) return;
        if (target.IsDead()) return;
        
            target.TakeDamage(damage);
        if (hitEffect != null) {

            Instantiate(hitEffect, GetAimLocation(), transform.rotation);
        }
        foreach (GameObject toDestroy in destroyOnHit) {
            Destroy(toDestroy);

        }
            Destroy(gameObject,lifeAfterImpact);
        
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if(targetCapsule == null) { return target.transform.position; }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }
}
