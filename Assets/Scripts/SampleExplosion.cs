using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleExplosion : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public bool explodable = false;

    void update()
    {
        if (explodable)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
                }
            }
        }
    }
}
