using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StarLogic : MonoBehaviour {
    [Header("Size of Tilemap")]
    public int width;
    public int height;

    [Header("Working Tile")]
    public Tilemap tilemap;
    public TileBase tile;

    [Header("Extra Vars")]
    public float seed;
    public int interval;

    private void Awake()
    {
        int[,] map = CreateScene.GenerateArray(width, height, true);
        CreateScene.RenderMap(map, tilemap, tile);

        map = CreateScene.PerlinNoiseSmooth(map, seed, interval);
        CreateScene.UpdateMap(map, tilemap);
    }
}
