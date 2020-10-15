using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Knife : MonoBehaviour
{
    public float speed = 60f;
    public UnityEvent onHit;
    public UnityEvent onMiss;
    
    private bool isMoving = false;
    private Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        
        //set events
        var go = GameObject.Find("counter");
        onHit.AddListener(go.GetComponent<BaseCounter>().RemoveKnife);
        
        go = GameObject.Find("EventSystem");
        onHit.AddListener(go.GetComponent<GameFlow>().SpawnNewKnife);
        
        onMiss.AddListener(go.GetComponent<GameFlow>().GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
    }

    public void StartMoving()
    {
        print("go");
        isMoving = true;
    }
    
    public void StopMoving()
    {
        var btn = GameObject.Find("Fire").GetComponent<Button>();
        btn.onClick.RemoveListener(StartMoving);
        
        isMoving = false;
    }

    public void MissHit()
    {
        //not to touch anything
        gameObject.layer = 0;
        //remove remaning forces
        myRigidbody2D.velocity = Vector2.zero;
        myRigidbody2D.angularVelocity = 0;
        
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody2D.AddForce(new Vector2(Random.value * 10,Random.value* 10), ForceMode2D.Impulse);   
        myRigidbody2D.AddTorque(3f,ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StopMoving();
        if (other.gameObject.CompareTag("knife"))
        {
            onMiss.Invoke();
            MissHit();
        }
        else
        {
            onHit.Invoke();
            myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.SetParent(other.gameObject.transform);       
        }
    }
}
