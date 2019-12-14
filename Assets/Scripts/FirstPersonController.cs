using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float speedRot;
    public Transform transformCamera;
    public float jumpForce;
    public GameObject gun;
    public Shooter shooter;
    private Rigidbody fpsRB;

    void Start()
    {
        fpsRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            fpsRB.AddForce(Vector3.up * jumpForce);
        fpsRB.velocity = (transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                        (transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        /* transform.Translate((Vector3.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                            (Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime)); */

        transform.Rotate(Vector3.up * speedRot * Time.deltaTime * Input.GetAxis("Mouse X"));
        transformCamera.Rotate(-Vector3.right * speedRot * Time.deltaTime * Input.GetAxis("Mouse Y"));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gun")
        {
            Destroy(collision.gameObject);
            gun.SetActive(true);
            shooter.isActive = true;
        }
    }
}
