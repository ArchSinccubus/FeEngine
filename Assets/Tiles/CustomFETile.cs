using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType { Grass, Road, Floor, Wall, Peak , Forest}

public class CustomFETile : MonoBehaviour
{
    public SpriteRenderer Sprite;

    public CustomFETileSO TileData;
}
