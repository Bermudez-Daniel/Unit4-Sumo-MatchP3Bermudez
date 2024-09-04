using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed = 15f;
    private bool homing;
    private float rocketStrenght = 15f;
    private float aliveTimer = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(homing && target != null)
        {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag(target.tag))
        {
            Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
            Vector3 away = -col.contacts[0].normal;
            targetRigidbody.AddForce(away * rocketStrenght, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }



    public void Fire(Transform newTarget)
    {
        target = homingTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }
}
