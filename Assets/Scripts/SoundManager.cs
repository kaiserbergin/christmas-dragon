using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource LazerFire;
    public AudioSource Explosion;
    public AudioSource Die;
    public AudioSource Wave;
    public AudioSource LazerImpact;
    // Start is called before the first frame update
    public void PlayLazer()
    {
        LazerFire.Play();
    }

    public void PlayExplosion()
    {
        Explosion.Play();
    }

    public void PlayDeath()
    {
        Die.Play();
    }

    public void PlayWave()
    {
        Wave.Play();
    }

    public void PlayImpact()
    {
        LazerImpact.Play();
    }
}
