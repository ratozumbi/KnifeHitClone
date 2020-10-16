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
        // onHit.AddListener(go.GetComponent<GameFlow>().PlayHit); depricated in favour of winning sound
        
        onMiss.AddListener(go.GetComponent<GameFlow>().GameOver);
        onMiss.AddListener(go.GetComponent<GameFlow>().PlayMiss);
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
        isMoving = true;
        GameObject.Find("EventSystem").GetComponent<GameFlow>().PlayFire();
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
        gameObject.layer = LayerMask.NameToLayer("nothing");
        //remove remaning forces
        myRigidbody2D.velocity = Vector2.zero;
        myRigidbody2D.angularVelocity = 0;
        
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody2D.AddForce(new Vector2( -5, -5), ForceMode2D.Impulse);   
        myRigidbody2D.AddTorque(10f,ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMoving) return; //prevent double miss count-
        StopMoving();
        if (other.gameObject.CompareTag("knife"))
        {
            onMiss.Invoke();
            MissHit();
        }
        else
        {
            onHit.Invoke();
            Destroy(myRigidbody2D); //so the knife spins with the circle
            // myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.SetParent(other.gameObject.transform);
        }
    }
}
