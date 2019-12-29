using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public AsetroidType Type = AsetroidType.SMALL;
    private int Health = 1;

    public void DoDamage(int damage) {
        Health -= damage;
        if (Health <= 0)
            DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Debug.Log("shoulda destroyed");
    }
}