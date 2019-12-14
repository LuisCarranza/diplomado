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
        decalTMP = Instantiate(decalPrefab, transform.position, Quaternion.Euler(normal));
        decalTMP.transform.parent = collision.transform;  //objectTransform
        Destroy(this.gameObject);
    }
}
