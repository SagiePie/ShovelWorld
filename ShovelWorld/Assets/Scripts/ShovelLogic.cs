using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShovelLogic : MonoBehaviour {

    public Sprite dirtPile;
    public Tile dirt;
    public GameObject chara;
    public Tilemap tilemap;
    private SpriteRenderer sr;

    //on trigger have dig animation and random pick loot
    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Collider>().tag == "star" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Star triggered");
            switch(RandomLoot())
            {
                case 0:
                    ReplaceStar();
                    break;
                case 1:
                    ReplaceStar();
                    break;
                case 2:
                    ReplaceStar();
                    break;
                case 3:
                    //check color of gem and load next scene
                    break;
                case 4:
                    ReplaceStar();
                    break;
            }
        }
    }

    private int RandomLoot()    //0 = nothing; 1 = light refill; 2 = shovel; 3 = gem; 4 = heart refill
    {
        int temp = Random.Range(0, 5);
        return temp;

    }

    private void ReplaceStar()
    {
        //sr = gameObject.GetComponent<SpriteRenderer>();
        //sr.sprite = dirtPile;
        tilemap.GetComponent<TileData>();
        //if(tilemap.GetComponent<Sprite>() == tag.Equals("star"))
        //{
            Vector3Int temp = tilemap.GetComponent<Vector3Int>();
            tilemap.SetTile(temp, dirt);
            tilemap.RefreshAllTiles();
        //}
    }
}
