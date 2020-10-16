using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    [Tooltip("Base knives counter")]
    public int totalHits = 10;
    [Tooltip("Counter symbol alignment")]
    public float spacing = 0.3f;
    
    private int currHits = 0;
    private readonly List<GameObject> _knives = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
        int win = PlayerPrefs.GetInt("win", 0);

        totalHits = 3 + win; 
        currHits = totalHits -1;
        for (int i = 0; i < totalHits; i++)
        {
            var go = Instantiate(
                Resources.Load<GameObject>("Prefabs/knifeCounter"),
                gameObject.transform);
            go.name = "knife " + i;
            go.transform.localPosition = new Vector3(0, i *spacing, 0);
            go.transform.rotation = Quaternion.Euler(0, 0, -90);
            _knives.Add(go);
        }   
    }

    public void RemoveKnife()
    {
        _knives[currHits].GetComponent<KnifeCounter>().Disable();
        currHits--;

        if (currHits <  0)
        {
            GameObject.Find("EventSystem").GetComponent<GameFlow>().Victory();
        }

    }

}
