using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Wepaon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource shootingSound1911;
    public AudioSource reloadingSound1911;

    public AudioSource shootingSoundM16;
    public AudioSource reloadingSoundM16;
    public AudioSource emptyManagizeSound1911;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
                shootingSound1911.Play();
                break;
            case WeaponModel.M16:
                shootingSoundM16.Play();
                break;
        }
    }
    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
                reloadingSound1911.Play();
                break;
            case WeaponModel.M16:
                reloadingSoundM16.Play();
                break;
        }
    }
}
