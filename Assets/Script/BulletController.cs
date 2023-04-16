using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject enemy;
    KillCounter killCounterScript;

    private void Start()
    {
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var hit = other.gameObject;

            float randomX = UnityEngine.Random.Range(-20, 20);
            float randomZ = UnityEngine.Random.Range(-20, 20);

            var zombie = (GameObject)Instantiate(enemy);
            zombie.transform.position = new Vector3(randomX, 0, randomZ);
            zombie.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);

            Destroy(hit);
            Destroy(gameObject);
            killCounterScript.AddKills();
        }
    }
}
