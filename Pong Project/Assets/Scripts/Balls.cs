using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{

    public Rigidbody2D ball;
    public float speed;
    public ParticleSystem effect;
    

    private Vector3 start_position;
    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position;
        trajectoryOrigin = transform.position;
        Launch();


    }

   

    void Launch()
    {

        ball.velocity = Vector2.zero;
        transform.position = start_position;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        ball.velocity = new Vector2(speed * x, speed * y);

        GetComponent<TrailRenderer>().enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float temp = Mathf.Abs(ball.velocity.x) + Mathf.Abs(ball.velocity.y);
        if (temp  < (speed*2 - 0.01) || temp > speed*2 + 0.01)
        {
            ball.velocity = NormalizedZidan(ball.velocity) * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
        trajectoryOrigin = transform.position;


        //rotate particle berdasarkan object yang di collide , ini belum effisien
        Quaternion rotation = Quaternion.identity;
        if (collision.gameObject.name == "Wall1")
        {
            rotation = Quaternion.identity;
        } else if (collision.gameObject.name == "Wall2")
        {
            rotation = Quaternion.Euler(0F, 0f, 180f);
        } else if(collision.gameObject.name == "Player1")
        {
            rotation = Quaternion.Euler(0F, 0f, -90f);
        } else if (collision.gameObject.name == "Player2")
        {
            rotation = Quaternion.Euler(0F, 0f, 90f);
        }
        ParticleSystem clone = Instantiate(effect, collision.contacts[0].point, rotation);
        clone.transform.tag = "Clone";

    }

    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
 
    private Vector2 NormalizedZidan(Vector2 vector)
    {
        if (vector.x < 0)
        {
            vector.x = -1;
        }
        else
        {
            vector.x = 1;
        }

        if(vector.y < 0)
        {
            vector.y = -1;
        }
        else
        {
            vector.y = 1;
        }
     
        return vector;
    }

    public void Reset()
    {
        GetComponent<TrailRenderer>().enabled = false;
        


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);//hancurkan semua gameObject particle untuk optimasi
        }
        Invoke("Launch", 1);

    }




}
