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
    public Transform chaoVerificador;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        /*if (Input.anyKey == false)
        {
            anim.Play("animacao");
        }*/
        var rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.velocity = new Vector3(joystick.Horizontal * velocidade + Input.GetAxis("Horizontal") * velocidade,
            rigidbody.velocity.y, joystick.Vertical * velocidade + Input.GetAxis("Vertical") * velocidade);

        //setando as animaçãoes do player
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("animacao", true);
        }
        else
        {
            anim.SetBool("animacao", false);
            
        }
                
        if (!Jump && (joybutton.Pressed || Input.GetButtonDown("Fire2")))
        {
            Jump = true;
            rigidbody.velocity += Vector3.up * 3f;
            
        }
        if(Jump && (!joybutton.Pressed || Input.GetButtonDown("Fire2")))
        {
            Jump = false;
        }
        if (Input.GetButton("Fire1"))
        {
            anim.Play("Ataque01");

        }

       

    }
    private void FixedUpdate()
    {
        
    }
}
