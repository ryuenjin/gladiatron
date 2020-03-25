using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Player_mov : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected bool jump;
    public int velocidade = 10;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        //anm = GetComponent<Animator>();
    }


    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * velocidade + Input.GetAxis("Horizontal") * velocidade,
            rigidbody.velocity.y, joystick.Vertical * velocidade + Input.GetAxis("Vertical") * velocidade);

        if (!jump && (joybutton.Pressed || Input.GetButton("Fire2")))
        {
            jump = true;
            rigidbody.velocity += Vector3.up * 3f;
            
        }
        if(jump && (!joybutton.Pressed || Input.GetButton("Fire2")))
        {
            jump = false;
        }

    }
}
