using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    
    public int totalHits = 10;
    
    private int currHits = 0;
    private List<GameObject> knifes;
    // Start is called before the first frame update
    void Start()
    {
        currHits = totalHits -1;
        for (int i = 0; i < totalHits; i++)
        {
            var go = Instantiate(
                Resources.Load<GameObject>("Prefabs/knifeCounter"),
                new Vector3(0,i*0.3f,0),
                Quaternion.identity,
                gameObject.transform);
            knifes.Add(go);
        }   
    }

    public void RemoveKnife()
    {
        knifes[currHits].GetComponent<KnifeCounter>().Disable();
        currHits--;

        if (currHits <  0)
        {
            //TODO: trigger end game
        }

    }

}
