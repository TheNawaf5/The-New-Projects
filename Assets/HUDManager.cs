using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; set; }

    [Header("Ammo")]
    public TextMeshProUGUI magazineAmmoUI;
    public TextMeshProUGUI totalAmmoUI;
    public Image ammoTypeUI;

    [Header("Weapon")]
    public Image activeWeaponUI;
    public Image unActiveWeaponUI;

    [Header("Throwables")]
    public Image lethalUI;
    public TextMeshProUGUI lethalAmountUI;

    public Image tacticalUI;
    public TextMeshProUGUI tacticalAmountUI;

    public Sprite emptySlot;

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

    private void Update()
    {
        Wepaon activeWeapon = WeaponManager.Instance.activeWeaponSlot.GetComponentInChildren<Wepaon>();
        Wepaon unActiveWeapon = GetUnActiveWeaponSlot().GetComponentInChildren<Wepaon>();

        if (activeWeapon)
        {
            magazineAmmoUI.text = $"{activeWeapon.bulletsLeft / activeWeapon.bulletsPerBurst}";
            totalAmmoUI.text = $"{activeWeapon.magazineSize / activeWeapon.bulletsPerBurst}";

            Wepaon.WeaponModel model = activeWeapon.thisWeaponModel;
            ammoTypeUI.sprite = GetAmmoSprite(model);

            activeWeaponUI.sprite = GetWeaponSprite(model);

            if(unActiveWeapon)
            {
                unActiveWeaponUI.sprite = GetWeaponSprite(unActiveWeapon.thisWeaponModel);
            }
            else
            {
                magazineAmmoUI.text = "";
                totalAmmoUI.text = "";

                ammoTypeUI.sprite = emptySlot;
                
                activeWeaponUI.sprite = emptySlot;
                unActiveWeaponUI.sprite = emptySlot;
            }
        }
    }

        private Sprite GetWeaponSprite(Wepaon.WeaponModel model)
        {
            switch (model)
            {
                case Wepaon.WeaponModel.Pistol1911:
                    return Instantiate(Resources.Load<GameObject>("Pistol1911_Weapon")).GetComponent<SpriteRenderer>().sprite;

                case Wepaon.WeaponModel.M16:
                    return Instantiate(Resources.Load<GameObject>("M16_Weapon")).GetComponent<SpriteRenderer>().sprite;

                default:
                    return null;
            }
        }
        private Sprite GetAmmoSprite(Wepaon.WeaponModel model)
        {
            switch (model)
            {
                case Wepaon.WeaponModel.Pistol1911:
                    return Instantiate(Resources.Load<GameObject>("Pistol_Ammo")).GetComponent<SpriteRenderer>().sprite;

                case Wepaon.WeaponModel.M16:
                    return Instantiate(Resources.Load<GameObject>("Rifle_Ammo")).GetComponent<SpriteRenderer>().sprite;

                default:
                    return null;
            }
        }
        private GameObject GetUnActiveWeaponSlot()
        {
            foreach (GameObject weaponSlot in WeaponManager.Instance.weaponSlots)
            {
                if (weaponSlot != WeaponManager.Instance.activeWeaponSlot)
                {
                    return weaponSlot;
                }
            }
            return null;
        }
    
    }
