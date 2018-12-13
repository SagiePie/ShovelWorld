//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//using UnityEditor;

//public class TileAutomata : MonoBehaviour {
//    [Header("Tilemap Vars")]
//    [Range(0, 100)]
//    public int initChance;

//    [Range(1, 8)]
//    public int birthLimit;

//    [Range(1, 8)]
//    public int deathLimit;

//    [Range(1, 10)]
//    public int numR;
//    public int count = 0;

//    private int[,] terrainMap;
//    public Vector3Int tmpSize;
//    public Tilemap topMap;
//    public Tilemap bottomMap;
//    //public TerrainTile topTile;
//    //public AnimatedTile bottomTile;

//    int width, height;

//    public void DoSimulation(int num)
//    {
//        ClearMap(false);
//        width = tmpSize.x;
//        height = tmpSize.y;

//        if(terrainMap == null)
//        {
//            terrainMap = new int[width, height];
//            InitPos();
//        }

//        for (int i = 0; i < num; i++)
//            terrainMap = GenTilePos(terrainMap);
//        for (int x = 0; x < width; x++)
//        {
//            for (int y = 0; y < height; y++)
//            {
//                //if (terrainMap[x, y] == 1)
//                //    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
//                //bottomTile.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), bottomTile);
//            }
//        }
//    }

//    public void InitPos()
//    {
//        for (int x = 0; x < width; x++)
//        {
//            for (int y = 0; y < height; y++)
//            {
//                terrainMap[x, y] = Random.Range(1, 101) < initChance ? 1 : 0;
//            }
//        }
//    }

//    public int[,] GenTilePos(int[,] oldMap)
//    {
//        int[,] newMap = new int[width, height];
//        int neighbor;
//        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

//        for(int x = 0; x < width; x++)
//        {
//            for(int y = 0; y < height; y++)
//            {
//                neighbor = 0;
//                foreach(var b in myB.allPositionsWithin)
//                {
//                    if (b.x == 0 && b.y == 0)
//                        continue;
//                    if (x + b.x >= 0 && x + b.x < width && y + b.y >= 0 && y + b.y < height)
//                        neighbor += oldMap[x + b.x, y + b.y];
//                    else
//                        neighbor++;
//                }
//                if(oldMap[x, 1] == 1)
//                {
//                    if (neighbor < deathLimit)
//                        newMap[x, y] = 0;
//                    else
//                        newMap[x, y] = 1;
//                }
//                if(oldMap[x, y] == 0)
//                {
//                    if (neighbor > birthLimit)
//                        newMap[x, y] = 1;
//                    else
//                        newMap[x, y] = 0;
//                }
//            }
//        }
//        return newMap;
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//            DoSimulation(numR);
//        if (Input.GetMouseButtonDown(1))
//            ClearMap(true);
//        if(Input.GetMouseButtonDown(2))
//        {
//            SaveAssetMap();
//            count++;
//        }
//    }

//    public void SaveAssetMap()
//    {
//        string saveName = "tmapXY_" + count;
//        var mapFind = GameObject.Find("Grid");

//        if(mapFind)
//        {
//            var savePath = "Assets/Maps/" + saveName + ".prefab";
//            if (PrefabUtility.CreatePrefab(savePath, mapFind))
//                EditorUtility.DisplayDialog("Tilemap saved", "Your Tilemap was saved under: " + savePath, "continue");
//            else
//                EditorUtility.DisplayDialog("Tilemap NOT saved", "An ERROR occured while trying to save Tilemap under: " + savePath, "continue");
//        }
//    }

//    public void ClearMap(bool complete)
//    {
//        topMap.ClearAllTiles();
//        bottomMap.ClearAllTiles();
//        if (complete)
//            terrainMap = null;
//    }
//}
