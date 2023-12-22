using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.ToString()=="Body")
        {
            if (transform.root.GetComponent<Animator>().GetBool("IsFight") == true && transform.root.GetComponent<Animator>().GetBool("IsRun") == false)
            { collision.gameObject.transform.root.GetComponent<GG_MOVE1>().OnHit(0); }
        }
    }
}
