using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDatabase", menuName = "FETiles/Database", order = 1)]
public class TileAssetDatabase : ScriptableObject
{
    public TileType Type;

    public List<Sprite> sprites;
}
