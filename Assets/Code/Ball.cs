using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float xInitForce;
    public float yInitForce;
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void pushBall()
    {
        float yRandomInitForce = Random.Range(-yInitForce, yInitForce);
        float randomDir = Random.Range(0,2);

        if(randomDir < 1.0f)
        {
            rigidbody2D.AddForce(new Vector2(-xInitForce, yRandomInitForce));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(xInitForce, yRandomInitForce));
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    void RestartGame()
    {
        ResetBall();

        Invoke("pushBall", 2);
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}


