using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Knife : MonoBehaviour
{
    public float speed = 60f;

    private bool isMoving = false;

    private Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }
    
    public void StopMoving()
    {
        isMoving = false;
    }

    public void MissHit()
    {
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody2D.AddForce(new Vector2(Random.value * 10,Random.value* 10), ForceMode2D.Impulse);   
        myRigidbody2D.AddTorque(3f,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        StopMoving();
        if (other.gameObject.CompareTag("knife"))
        {
            MissHit();
        }
        else
        {
            transform.SetParent(other.gameObject.transform);       
        }
    }
}
