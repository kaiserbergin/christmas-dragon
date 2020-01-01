using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public AsetroidType Type = AsetroidType.SMALL;
    public int Health = 1;
    public Rigidbody Rigidbody;

    public GameObject Explosion;

    public UIManager UIManager;

    void Awake()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    public void DoDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            DestroyAsteroid();
        }
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

            int inc = 0;
            switch (Type)
            {
                case AsetroidType.SMALL:
                    inc = 10;
                    break;
                case AsetroidType.MEDIUM:
                    inc = 25;
                    break;
                case AsetroidType.LARGE:
                    inc = 50;
                    break;
                case AsetroidType.MEGA:
                    inc = 100;
                    break;
            }
            UIManager.IncrimentScore(inc);
        }
        else if (other.TryGetComponent(out DragonController player))
        {
            player.Kill();
        }
    }

}