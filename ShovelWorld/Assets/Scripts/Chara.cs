using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {

    public GameObject boundary;

    private void FixedUpdate()
    {
        //character movement with wasd
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            transform.Translate(x, y, 0);
        }
       else
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 1.0f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 1.0f;
            transform.Translate(x, y, 0);
        }
    }
}
