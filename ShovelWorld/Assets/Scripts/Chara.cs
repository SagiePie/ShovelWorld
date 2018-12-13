using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {

    public GameObject boundary;
    public bool faceRight = true;
    public float horizontalMove = 1f;
    public float runSpeed = 5f;
    public Animator myAnimator;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("music");
    }

    private void FixedUpdate()
    {
        float temp = Input.GetAxis("Horizontal");
        myAnimator.SetFloat("Speed", Mathf.Abs(temp));

        //flips character
        if (temp > 0 && !faceRight)
            Flip();
        else if (temp < 0 && faceRight)
            Flip();

        //character movement with wasd
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Run();
        else
        {
            FindObjectOfType<AudioManager>().Play("walking");
            Walk();
        }
    }

    private void Run()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalMove * runSpeed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * horizontalMove * runSpeed;
        transform.Translate(x, y, 0);
    }

    private void Walk()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalMove;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * horizontalMove;
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
