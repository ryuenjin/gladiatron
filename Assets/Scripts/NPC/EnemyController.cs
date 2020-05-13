using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //utilizado para ativar inteligencia artificial do programa


public class EnemyController : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint; //definição para area de ataque
    public LayerMask playerLayers; //layer para definição de objeto

    public float lookRadius = 10f; //raio que o inimigo irá olhar para começar a seguir o jogador
    Transform target;
    NavMeshAgent agent;

    public float attackRange = 0.5f; //distancia do ataque
    public int attackDamage = 40; //dano do ataque

    public float attackRate = 2f; //velocidade do ataque
    float nextAttackTime = 0; //proximo ataque que é uma definição para velocidade do ataque



    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius) //aqui é usado para dizer a distancia do inimigo que correrá atras do jogador
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                
            }
        }

        if (Time.time >= nextAttackTime)
        {
           
           nextAttackTime = Time.time + 1f / attackRate;
            Attack();
        }

    }

    void FaceTarget() //função utilizada para objeto virar a face para o jogador
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        
        
    }

    void OnDrawGizsmosSelected() //serve para desenhar uma esfera para indicar algo na tela
    {
        
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Attack() //função criada para atacar
    {
        //Play animação de ataque
        animator.SetTrigger("EAtaque");
        //Detectar os inimigos no alcance
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);
        //Ataca-los
        foreach (Collider player in hitPlayer)
        {

            player.GetComponent<Health>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected() //utilizado para criar uma esfera de onde o ataque ira partir, para determinar a distancia do ataque
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


}
