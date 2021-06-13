using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileData", menuName = "FETiles/Tile", order = 1)]
public class CustomFETileSO : ScriptableObject
{
    public TileType type;
    public bool Passable;
    public int SpeedCost;
    public int DefBoost;
    public float DodgeBoost;
}
