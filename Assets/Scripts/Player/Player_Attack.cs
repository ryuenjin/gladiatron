using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Animator anim;//chama as animações
    Rigidbody rigidbody;
    protected BT_Attack BT_Attack;
    public Transform attackPoint; //ponto do ataque apartir da arma do personagem
    public LayerMask enemyLayers;

    public float attackRange = 0.5f; //distancia do ataque
    public int attackDamage = 40; //dano do ataque

    public float attackRate = 2f;
    float nextAttackTime = 0;

    protected BotoesLivres BotoesLivres;

    // Start is called before the first frame update
    void Start()
    {
        BT_Attack = FindObjectOfType<BT_Attack>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        BotoesLivres = GetComponent<BotoesLivres>();

    }

    // Update is called once per frame
    void Update()
    {
        //chama BotoesLivres
        // bool botoesLivres = !joystickPtr.Pressed && !BT_PULO.Pressed && !BT_Attack.Pressed;
        

        if (BotoesLivres && Input.GetButtonDown("Fire1"))
        {
            Ataque();
        }
    }
    
    public void Ataque()
        {
            anim.SetTrigger("Ataque01");
            //Detectar os inimigos no alcance
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            //Ataca-los
            foreach (Collider enemy in hitEnemies)
            {

                enemy.GetComponent<Health>().TakeDamage(attackDamage);

            }

        }

        void OnDrawGizmosSelected() //utilizado para criar uma esfera de onde o ataque ira partir, para determinar a distancia do ataque
        {
            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        }
    private void FixedUpdate()
    {

    }

}
