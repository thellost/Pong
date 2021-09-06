using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayer1;
    public Rigidbody2D body;
    public float speed;
    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;
   

    private float movement;
    private Vector3 start_position;
    void Start()
    {
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        body.velocity = new Vector2(body.velocity.x, movement * speed * Time.deltaTime);
    }

    public void Reset()
    {
        body.velocity = Vector2.zero;
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    
}
