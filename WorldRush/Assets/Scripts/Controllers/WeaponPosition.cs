using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform _weaponHolder;
    [SerializeField]
    private GameObject _weapon;

#pragma warning disable 0649

    private void Start() {
        Instantiate(_weapon, _weaponHolder);
        transform.position = new Vector3(0.25f, 0.05f, 0.05f);
        transform.rotation = Quaternion.Euler(2, -2, 120);
        transform.localScale = new Vector3(0.1f, 0.15f, 0.1f);
        }

    }
