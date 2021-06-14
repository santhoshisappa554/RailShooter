using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimiesCollision : MonoBehaviour
{
    private void Awake()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("particle collision " + gameObject.name);

        Destroy(gameObject);
    }
}
