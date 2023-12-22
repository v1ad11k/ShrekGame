using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float LookRadius;
    private Animator ani;
    private int Health;
    private void Start()
    {
        Health = 100;
        agent=GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        target =PlayerManager.instance.player.transform;
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= LookRadius)
        {
            ani.SetBool("IsRun", true);
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                ani.SetBool("IsFight", true);
                ani.SetBool("IsRun", false);
                LookTarget();
            }
            else
            {
                ani.SetBool("IsFight", false);
                ani.SetBool("IsRun", true);
            }
        }
        else
        {
            ani.SetBool("IsRun", false);
        }
        
    }
    void LookTarget()
    {
        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime);
    }
    private void SetHealth(int h)
    {
        Health -= h;
    }
    public void OnHit(int i)
    {
        SetHealth(i);
        if (Health <= 0)
        {
            ani.SetTrigger("Die");
            Destroy(gameObject);
        }
    }


}
