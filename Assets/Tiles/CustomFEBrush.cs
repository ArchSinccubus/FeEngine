using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu]
[CustomGridBrush(false, false, false, "Prefab Brush / FETileBrush")]
public class CustomFEBrush : GridBrushBase
{
    public CustomFETile prefab, selectedTile;

    public TileAssetDatabase[] SpriteDatabases;

    TileType paintedType;

    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        if (GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, 0)) != null)
            return;



        CustomFETile temp = Instantiate(prefab);

        temp.TileData = selectedTile.TileData;

        TileAssetDatabase data = SpriteDatabases.Where(o => o.Type == paintedType).ToArray()[0];

        temp.Sprite.sprite = data.sprites[Random.Range(0, data.sprites.Count)];

        temp.transform.SetParent(brushTarget.transform);

        temp.transform.position = position;

        temp.transform.position += new Vector3(0.5f, 0.5f, 0);

        

        //base.Paint(gridLayout, brushTarget, position);
    }

    public override void Pick(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, Vector3Int pivot)
    {
        Transform Picked = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, position.z));

        if (Picked)
        {
            if (Picked.gameObject.GetComponent<CustomFETile>())
            {
                selectedTile = Picked.gameObject.GetComponent<CustomFETile>();
                paintedType = Picked.gameObject.GetComponent<CustomFETile>().TileData.type;
            }
        }

        base.Pick(gridLayout, brushTarget, position, pivot);
    }

    public override void BoxFill(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
    {
        base.BoxFill(gridLayout, brushTarget, position);
    }

    public override void Erase(GridLayout grid, GameObject brushTarget, Vector3Int position)
    {
        // Do not allow editing palettes
        if (brushTarget.layer == 1)
            return;

        Transform erased = GetObjectInCell(grid, brushTarget.transform, new Vector3Int(position.x, position.y, position.z));
        if (erased != null)
            Undo.DestroyObjectImmediate(erased.gameObject);
    }

    private static Transform GetObjectInCell(GridLayout grid, Transform parent, Vector3Int position)
    {
        //First get list of all object that are child of the grid
        int childCount = parent.childCount;

        //Get the world position of the grid cell clicked ....
        Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated(position));
        Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(position + Vector3Int.one));
        Bounds bounds = new Bounds((max + min) * .5f, max - min);
        //Cycle all the child and check if same object painted over, if in case, not paint again !
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            string tag = child.gameObject.tag;
            if (bounds.Contains(child.position))
                //I return child if that exist
                return child;
        }
        //otherwise just null
        return null;
    }
}
