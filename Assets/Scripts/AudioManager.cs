using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSourceProjectile;
    public AudioSource audioSourceExplosion;
    public AudioSource audioSourceHurtSFX;
    public AudioSource audioSourcePowerup;

    public void PlayProjectile()
    {
        audioSourceProjectile.Play();        
    }

    public void PlayExplosion()
    {
        audioSourceExplosion.Play();
    }

    public void PlayHurtSFX()
    {
        audioSourceHurtSFX.Play();
    }

    public void PlayPowerUp()
    {
        audioSourcePowerup.Play();
    }
}
