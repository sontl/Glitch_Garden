using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 100f;
    [SerializeField] float projectileSpeed = 1f;
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f));
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var objectHealth = collision.GetComponent<Health>();
        objectHealth.DealDamage(damage);
        Destroy(gameObject);
    }

}
