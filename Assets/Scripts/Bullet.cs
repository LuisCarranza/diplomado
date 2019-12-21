using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;
    private GameObject decalTMP;

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.GetContact(0).normal;
        // Debug.Log(collision.transform.name);
        // decalTMP = Instantiate(decalPrefab, transform.position, Quaternion.Euler(normal));
        decalTMP = Instantiate(decalPrefab, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, normal));
        decalTMP.transform.parent = collision.transform;  //objectTransform
        Destroy(this.gameObject);
    }
}
