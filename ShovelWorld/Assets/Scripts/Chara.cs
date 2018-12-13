using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {

    public GameObject boundary;
    public bool faceRight = true;

    private void FixedUpdate()
    {
        float temp = Input.GetAxis("Horizontal");

        //flips character
        if (temp > 0 && !faceRight)
            Flip();
        else if (temp < 0 && faceRight)
            Flip();

        //character movement with wasd
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Run();
        else
            Walk();
    }

    private void Run()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Translate(x, y, 0);
    }

    private void Walk()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 1.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 1.0f;
        transform.Translate(x, y, 0);
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
