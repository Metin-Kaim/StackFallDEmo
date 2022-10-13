using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer meshRenderer;
    new Collider collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<MeshCollider>();
    }

    public void Break()
    {
        collider.enabled = false;
        rb.isKinematic = false;

        Vector3 forcePoint = transform.parent.position;
        float parentXPos = transform.parent.position.x;
        float xPos = meshRenderer.bounds.center.x;

        Vector3 subDir = (parentXPos - xPos < 0) ? Vector3.right : Vector3.left;

        Vector3 dir = (Vector3.up * 1.5f + subDir*1.5f).normalized;

        float force = Random.Range(10,25);//30,45
        float torque = Random.Range(50,75);//110,180

        rb.AddForceAtPosition(dir * force, forcePoint, ForceMode.Impulse);

        rb.AddTorque(Vector3.left * torque);

        rb.velocity = Vector3.down;

    }
}
