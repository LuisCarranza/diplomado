using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;
    private GameObject decalTMP;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Vector3 normal = collision.GetContact(0).normal;
            // Debug.Log(collision.transform.name);
            // decalTMP = Instantiate(decalPrefab, transform.position,
            // Quaternion.Euler(normal));
            Vector3 position = collision.GetContact(0).point;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, normal);
            // decalTMP = Instantiate(decalPrefab, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, normal));
            decalTMP = Instantiate(decalPrefab, position + Vector3.forward * 0.05f, rotation);
            decalTMP.transform.parent = collision.transform;  //objectTransform
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().currentHealth -= 1;
        }
        Destroy(this.gameObject);
    }
}
