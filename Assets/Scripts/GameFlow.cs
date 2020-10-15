using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewKnife()
    {
        var go = Instantiate(
            Resources.Load<GameObject>("Prefabs/knife"),
            gameObject.transform);
        go.transform.localPosition = new Vector3(0, -4.5f, 0);
    }

    public void GameOver()
    {
        
    }
}
