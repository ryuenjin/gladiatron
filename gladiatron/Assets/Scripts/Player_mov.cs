using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player_mov : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    public float velocidade = 10; //velocidade de movimento
    public float VelMax = 200;
    Animator anim;//chama as animações
    protected bool Jump;
    private float JumpTime;//limitando o pulo do Tigas
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        var rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.velocity = new Vector3(joystick.Horizontal * velocidade + Input.GetAxis("Horizontal") * velocidade,
            rigidbody.velocity.y, joystick.Vertical * velocidade + Input.GetAxis("Vertical") * velocidade);

        //setando as animaçãoes do player
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Correndo", true);
        }
        else
        {
            anim.SetBool("Correndo", false);
            
        }

        

        if (!Jump && (joybutton.Pressed || Input.GetButton("Fire2")))
        {
            Jump = true;
            rigidbody.velocity += Vector3.up * 3f;
            
        }
        if(Jump && (!joybutton.Pressed || Input.GetButton("Fire2")))
        {
            Jump = false;
        }

    }
}
