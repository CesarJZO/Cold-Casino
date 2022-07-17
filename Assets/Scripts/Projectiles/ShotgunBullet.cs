using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{

    [SerializeField]

    new Rigidbody2D rigidbody;

    [SerializeField]

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
    }
}
