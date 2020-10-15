using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    
    public int totalHits = 10;
    public float spacing = 0.3f;
    
    private int currHits = 0;
    private List<GameObject> knifes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currHits = totalHits -1;
        for (int i = 0; i < totalHits; i++)
        {
            var go = Instantiate(
                Resources.Load<GameObject>("Prefabs/knifeCounter"),
                gameObject.transform);
            go.name = "knife " + i;
            go.transform.localPosition = new Vector3(0, i *spacing, 0);
            go.transform.rotation = Quaternion.Euler(0, 0, -90);
            knifes.Add(go);
        }   
    }

    public void RemoveKnife()
    {
        knifes[currHits].GetComponent<KnifeCounter>().Disable();
        currHits--;
        print("knifes left " + currHits);
        if (currHits <  0)
        {
            //TODO: trigger end game
        }

    }

}
