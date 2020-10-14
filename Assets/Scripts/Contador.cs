using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{

    public int totalHits = 10;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalHits; i++)
        {
            var go = Instantiate(Resources.Load<GameObject>("Prefabs/Defence/Tower"), transform.position, transform.rotation, transform.parent);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
