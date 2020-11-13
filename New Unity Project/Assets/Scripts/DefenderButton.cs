using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    public void OnMouseDown()
    {
        var defenders = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefenderPrefab(defenderPrefab);
        
    }

}
