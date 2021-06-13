using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "FEUnits/New Unit", order = 1)]
public class UnitSO : ScriptableObject
{
    public string Name;

    public UnitType type;

    public StatsStruct BaseStats;

    public bool Dead;
}
