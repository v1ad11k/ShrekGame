using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameControl : MonoBehaviour
{
    private int Day;
    private List<GameObject> EnemysList;
    [SerializeField]
    private GameObject WC;
    [SerializeField]
    private GameObject Enemy1;
    [SerializeField]
    private GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        Day=0;
        Debug.Log(Day);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (WC.GetComponent<WC_Contr>()._GetState())
            {
                Day++;
                GenerateVoln(Day);
                Debug.Log(Day);
            }
        }
    }
    private void GenerateVoln(int d)
    {
        GameObject obj;
        Transform tr = Spawn.transform;
        for(int i = 1; i <= d; i++)
        {
            obj = Enemy1;
            Instantiate(obj, tr.position,tr.rotation);
            EnemysList.Add(obj);
            Debug.Log(EnemysList.Count + EnemysList[0].name);
            tr.position=tr.position + new Vector3(tr.position.x - 8, 0, 0);
        }
    }
}
