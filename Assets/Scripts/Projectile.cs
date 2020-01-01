using UnityEngine;

public enum ProjectileType
{
    CANDY_CANE = 0
}
public class Projectile : MonoBehaviour
{
    public ProjectileType projectileType;
    public int DamageValue = 1;

    public GameObject DestroyEffect;
    // Start is called before the first frame update
    public void Kill()
    {
        if (DestroyEffect != null)
        {
            Instantiate(DestroyEffect, this.transform.position, Quaternion.identity);
        }

        this.gameObject.SetActive(false);
    }
}
