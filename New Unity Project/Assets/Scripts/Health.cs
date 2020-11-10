using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFXPrefab;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            TriggerDeathVFX();
        }
        else
        {
            StartCoroutine(BlinkColor());
        }
    }

    private void TriggerDeathVFX()
    {
        var deathVfx = Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        Destroy(deathVfx, 0.5f);
    }

    IEnumerator BlinkColor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
