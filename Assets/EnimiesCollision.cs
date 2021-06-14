using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimiesCollision : MonoBehaviour
{
    private void Awake()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }
    private void OnParticleCollision(GameObject other)
    {
        print("Collision" + other.gameObject.name);
    }
}
