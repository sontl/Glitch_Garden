using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if (isAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void Fire()
    {
        Instantiate(projectilePrefab, gun.transform.position, transform.rotation);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);
            isCloseEnough = (Mathf.Ceil(spawner.transform.position.y) - Mathf.Ceil(transform.position.y) == 0);
            Debug.Log("spawner.transform.position.y: " + (spawner.transform.position.y).ToString());
            Debug.Log("transform.position.y: " + (transform.position.y).ToString());
            Debug.Log("isCloseEnough " + isCloseEnough);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                Debug.Log("myLaneSpawner set");
            }
        }
    }

    private bool isAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
