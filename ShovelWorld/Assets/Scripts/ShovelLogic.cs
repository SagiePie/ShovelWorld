using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ShovelLogic : MonoBehaviour {
    [Header("Set in Inspector")]
    public Sprite dirtPile;
    public Sprite gem;
    public Tile dirt;
    public GameObject chara;
    public Tilemap tilemap;

    [HideInInspector]
    public int shovelLight = 12;
    public int currentShovel = 1;
    public int heart = 7;


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
                    RefillLight();
                    ReplaceStar();
                    break;
                case 2:
                    ShovelChange();
                    ReplaceStar();
                    break;
                case 3:
                    GemTrigger();
                    //check color of gem and load next scene
                    break;
                case 4:
                    RefillHeart();
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

    void RefillLight()
    {
        shovelLight = 12;
        //change sprite to full
    }

    void RefillHeart()
    {
        heart = 7;
    }

    void ShovelChange()
    {
        if (currentShovel == 1)
            currentShovel = 2;
        else if (currentShovel == 2)
            currentShovel = 3;
        else
            return;
    }

    void GemTrigger()
    {
        //change scene after gem
    }
}
