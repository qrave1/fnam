using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform checkpoint;
    public static int toPlayerChance;
    public float delay = 10f;
    NavMeshAgent agent;
    Animator anim;
    public Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = agent.GetComponent<Animator>();
        Invoke("Move", delay);
    }

    void Move()
    {
        NextPoints point = checkpoint.GetComponent<NextPoints>();
        if (point is AttackPoints) 
        {
            AttackPoints nearPoint = checkpoint.GetComponent<AttackPoints>();
            bool isOpen = nearPoint.isOpen;
            if (isOpen)
            {
                agent.destination = player.position;
                agent.speed = 6;
            }
            else
            {
                checkpoint = point.getNext();
                agent.destination = checkpoint.position;
                Invoke("Move", delay);
            }
        } 
        else 
        {
            checkpoint = point.getNext();
            agent.destination = checkpoint.position;
            Invoke("Move", delay);
        }
    }

    void Update()
    {
        if (agent.velocity.x != 0 | agent.velocity.z != 0)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}
