using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateScene : MonoBehaviour {

    public static int[,] GenerateArray(int width, int height, bool empty)   //creates new int array of size given
    {
        int[,] map = new int[width, height];
        for(int i = 0; i < map.GetUpperBound(0); i++)
        {
            for(int j = 0; j < map.GetUpperBound(1); j++)
            {
                if (empty)
                    map[i, j] = 0;
                else
                    map[i, j] = 1;
            }
        }
        return map;
    }

    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)    //renders map
    {
        //clear map
        tilemap.ClearAllTiles();

        for(int i = 0; i < map.GetUpperBound(0); i++)
        {
            for (int j = 0; j < map.GetUpperBound(1); j++)
            {
                if (map[i, j] == 1)
                    tilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
    }

    public static void UpdateMap(int[,] map, Tilemap tilemap)   //updates to reduce rendering
    {
        for (int i = 0; i < map.GetUpperBound(0); i++)
        {
            for (int j = 0; j < map.GetUpperBound(1); j++)
            {
                if (map[i, j] == 0)
                    tilemap.SetTile(new Vector3Int(i, j, 0), null);
            }
        }
    }

    public static int[,] PerlinNoise(int[,] map, float seed)
    {
        int newPoint;
        float reduction = 0.5f;

        for (int i = 0; i < map.GetUpperBound(0); i++)
        {
            newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(i, seed) - reduction) * map.GetUpperBound(1));

            newPoint += (map.GetUpperBound(1) / 2);
            for (int j = newPoint; j >= 0; j--)
                map[i, j] = 1;
        }
        return map;
    }

    public static int[,] PerlinNoiseSmooth(int[,] map, float seed, int interval)
    {
        if (interval > 1)
        {
            int newPoint, points;
            float reduction = 0.5f;
            Vector2Int currentPos, lastPos;
            List<int> noiseX = new List<int>();
            List<int> noiseY = new List<int>();

            for (int i = 0; i < map.GetUpperBound(0); i += interval)
            {
                newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(i, (seed - reduction))) * map.GetUpperBound(1));
                noiseY.Add(newPoint);
                noiseX.Add(i);
            }

            points = noiseY.Count;

            for (int i = 1; i < points; i++)
            {
                currentPos = new Vector2Int(noiseX[i], noiseY[i]);
                lastPos = new Vector2Int(noiseY[i - 1], noiseY[i - 1]);

                Vector2 diff = currentPos - lastPos;

                float heightChange = diff.y / interval;
                float currHeight = lastPos.y;

                for (int j = lastPos.x; j < currentPos.x; j++)
                {
                    for (int k = Mathf.FloorToInt(currHeight); k > 0; k--)
                        map[j, k] = 1;
                    currHeight += heightChange;
                }
            }
        }
        else
            map = PerlinNoise(map, seed);
        return map;
    }
}
