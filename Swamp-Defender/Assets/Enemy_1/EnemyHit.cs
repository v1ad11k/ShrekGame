using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.ToString() == "LHand" || collision.gameObject.name.ToString() == "RHand")
        {
            if (collision.gameObject.transform.root.GetComponent<Animator>().GetBool("Fight") == true)
            { transform.root.GetComponent<EnemyAI>().OnHit(collision.gameObject.transform.root.GetComponent<GG_MOVE1>().GetForce());
                Debug.Log("Hit");
            }
        }
    }
}
