using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {

    public GameObject boundary;

    private void FixedUpdate()
    {
        //character movement with wasd
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        transform.Translate(x, y, 0);
    }
}
