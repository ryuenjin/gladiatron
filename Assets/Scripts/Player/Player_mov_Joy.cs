using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov_Joy : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    public float Velocidade = 30;// velocidade de movimento
    public float VelMax = 200;
    Animator anim;
    Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //codigo antigo de movimento
        /*var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * Velocidade + Input.GetAxis("Horizontal") * Velocidade, rigidbody.velocity.y, joystick.Vertical * Velocidade + Input.GetAxis("Vertical") * Velocidade);

        //setando animação de movimento
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Parado",true);
        }
        else
        {
            anim.SetBool("Parado",false);
        }*/

        Vector3 vel = new Vector3(
         joystick.Horizontal * Velocidade + Input.GetAxis("Horizontal") * Velocidade,
          0,
          joystick.Vertical * Velocidade + Input.GetAxis("Vertical") * Velocidade
          );
        if (vel.magnitude > 0.1f)//direção do personagem 
        {
            Vector3 direcaoParaOlhar = transform.position + vel * 3;
            transform.LookAt(direcaoParaOlhar);
        }

        //movimentação com animação de movimento
        rigidbody.velocity = new Vector3(vel.x, rigidbody.velocity.y, vel.z);

        anim.SetBool("Correndo", vel.magnitude > 0.1);
    }
}
