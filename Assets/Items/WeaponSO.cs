using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Sword, Axe, Spear, Bow, Dagger, Hammer, Scythe }

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/New Weapon", order = 1)]
public class WeaponSO : ItemSO
{
    public int Damage;

    public int Range;

    public WeaponType type;
}
