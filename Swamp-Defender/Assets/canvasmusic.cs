using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasmusic : MonoBehaviour
{
    public GameObject modelMenuCanvas;
    
    void Start()
    {
        modelMenuCanvas.SetActive(false);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            modelMenuCanvas.SetActive(!modelMenuCanvas.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            modelMenuCanvas.SetActive(false);
        }
    }
}
