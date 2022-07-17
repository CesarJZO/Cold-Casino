using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField]

    GameObject explosionPrefab;

    [SerializeField]

    Rigidbody2D rigidbody;

    [SerializeField]

    SpriteRenderer sprite;

    [SerializeField]

    float strength;

    Animator explosionAnim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(transform.right * strength);
        
    }

    void Update()
    {
        
        if(explosionAnim is null) return;

        if(!explosionAnim.GetCurrentAnimatorStateInfo(0).IsTag("Explosion"))
            Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject explosion = Instantiate(explosionPrefab, this.transform);
        explosionAnim = explosion.GetComponent<Animator>();
        sprite.enabled = false;
        
    }
}
