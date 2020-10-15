using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
