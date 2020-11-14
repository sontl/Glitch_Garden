using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public void SpendStars()
    {
        FindObjectOfType<StarDisplay>().SpendStars(starCost);
    }

    public bool haveEnoughStar()
    {
        int currentStarCost = FindObjectOfType<StarDisplay>().GetTotalStarCost();
        if (starCost > currentStarCost)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
