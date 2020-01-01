using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public AsetroidType Type = AsetroidType.SMALL;
    public int Health = 1;
    public Rigidbody Rigidbody;

    void Awake()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    public void DoDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Projectile projectile))
        {
            DoDamage(projectile.DamageValue);
            projectile.Kill();
        }
    }

}