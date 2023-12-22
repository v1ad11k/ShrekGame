using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float LookRadius;
    private Animator ani;
    private void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        target=PlayerManager.instance.player.transform;
    }
    private void FixedUpdate()
    {
       // Debug.Log(ani.GetBool("IsRun")+";"+ ani.GetBool("IsFight")+";"+ ani.GetBool("PickUp")+";"+ ani.GetBool("Raise"));
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= LookRadius)
        {
            //ani.SetBool("IsRun", true);
            //ani.SetBool("IsFight", false);
            if (ani.GetBool("IsRun")==true)
            {
                agent.SetDestination(target.position);
                LookTarget();
            }
            if (distance <= agent.stoppingDistance)
            {
                ani.SetBool("IsRun", false);
                ani.SetBool("IsFight", true);
                if (ani.GetBool("IsFight"))
                {
                    if (ani.GetBool("Rock") == false)
                    {
                        ani.SetBool("PickUp", true);
                        ani.SetBool("Raise", false);
                        ani.SetBool("Rock", true);
                    }
                    else
                    {
                        LookTarget();
                        ani.SetBool("PickUp", false);
                        ani.SetBool("Raise", true);
                        ani.SetBool("Rock", false);
                    }
                }             
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


}
