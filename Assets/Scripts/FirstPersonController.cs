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

    private float angleX;
    private float angleY;

    void Start()
    {
        fpsRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            // fpsRB.AddForce(Vector3.up * jumpForce);
            fpsRB.velocity = new Vector3(fpsRB.velocity.x, jumpForce, fpsRB.velocity.z);

        fpsRB.velocity = (transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                        (transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        /* transform.Translate((Vector3.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) +
                            (Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime)); */

        transform.Rotate(Vector3.up * speedRot * Time.deltaTime * Input.GetAxis("Mouse X"));
        transformCamera.Rotate(-Vector3.right * speedRot * Time.deltaTime * Input.GetAxis("Mouse Y"));

        // Limitar el ángulo de giro de la cámara
        // Mathf.Clamp(angleX, 10f, 190f);
        // transformCamera.Rotate()
        // Quaternion.Euler(angleX, 0f, 0f);

        // Añadir camara como objeto y pasarle desde el editor la cámara
        // angleX = -speedRot * Time.deltaTime * Input.GetAxis("Mouse Y");
        // angleX = Mathf.Clamp(angleX, -90f, 90f);
        // transformCamera.rotation = Quaternion.Euler(angleX, angleY, 0f); //Usar localRotation

        // angleY = speedRot * Time.deltaTime * Input.GetAxis("Mouse X");
        // transform.rotation = Quaternion.Euler(0f, angleY, 0f);
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
