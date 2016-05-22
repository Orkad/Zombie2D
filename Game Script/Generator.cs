using UnityEngine;
using System.Collections;

public static class Generator{

    public static GroundItem Generate(Item item, Vector2 position)
    {
        GameObject go = Object.Instantiate(Resources.Load<GameObject>("ItemPrefab"));
        go.name = item.name;
        go.transform.position = position;
        GroundItem gItem = go.AddComponent<GroundItem>();
        gItem.refItem = item;
        gItem.droppable = false;
        return gItem;
    }
}
