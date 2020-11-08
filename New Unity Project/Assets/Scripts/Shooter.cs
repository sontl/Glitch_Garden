using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject zuchiniPrefab, gun;
    
    public void Fire()
    {
        Instantiate(zuchiniPrefab, gun.transform.position, transform.rotation);
    }

}
