using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{
    [SerializeField] GameObject cactusPrefab;

    public void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject defender = Instantiate(cactusPrefab, worldPos, Quaternion.identity) as GameObject;
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
