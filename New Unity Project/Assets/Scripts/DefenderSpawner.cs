using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender selectedDefenderPrefab;

    public void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefenderPrefab(Defender prefab)
    {
        this.selectedDefenderPrefab = prefab;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        if (selectedDefenderPrefab)
        {
            Defender defender = Instantiate(selectedDefenderPrefab, worldPos, Quaternion.identity) as Defender;
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        int newX = Mathf.RoundToInt(worldPos.x);
        int newY = Mathf.RoundToInt(worldPos.y);
        Vector2 newWorldPos = new Vector2(newX, newY);
        return newWorldPos;
    }
}
