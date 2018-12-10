using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelLogic : MonoBehaviour {

    public Sprite dirtPile;
    public GameObject chara;

    //on trigger have dig animation and random pick loot
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private int RandomLoot()    //0 = nothing; 1 = light refill; 2 = shovel; 3 = gem; 4 = heart refill
    {
        int temp = Random.Range(0, 5);
        return temp;

    }
}
