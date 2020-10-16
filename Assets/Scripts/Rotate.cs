using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 1;
    public float maxSpeed = 10;
    public float changeDirectionProbability = 0.005f;

    private bool sipnClockwise = false;
    private bool canChange = true;

    private Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        int val;
        do
        {
            val = Mathf.FloorToInt(Random.value *10);
        } while (val == 0 || val > 4);
 
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/circle"+val);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < changeDirectionProbability && canChange)
        {
            canChange = false;
            Invoke("ChangeDirection", 1f);
        }
        Vector3 dir = sipnClockwise ? Vector3.back : Vector3.forward;
        var vel = myRigidBody.GetPointVelocity(new Vector2(2, 2));

        if ((sipnClockwise && vel.y < maxSpeed))
        {
            myRigidBody.AddTorque(speed);
        }
        else if ((!sipnClockwise && vel.y > -maxSpeed))
        {
            myRigidBody.AddTorque(-speed);
        }
        else
        {
            myRigidBody.AddTorque(sipnClockwise ? -speed : speed);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        canChange = true;
        sipnClockwise = !sipnClockwise;
    }
}
