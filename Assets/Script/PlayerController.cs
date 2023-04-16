using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    void Start()
    {

    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float inputY = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, inputX, 0);
        transform.Translate(0, 0, inputY);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    private void Fire() {
        var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        if (bullet != null) {
            //AudioSource aud = GetComponent<AudioSource>();
            //aud.Play();
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
            Destroy(bullet, 3.0f);
        }
    }
}
