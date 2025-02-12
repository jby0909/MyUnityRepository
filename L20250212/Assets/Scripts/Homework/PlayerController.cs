using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text text;
    int speed = 1;
    int count = 3;
    DeadEvent deadEvent = new DeadEvent();
    ParticleSystem particle;
    MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deadEvent.Dead += new EventHandler(PlayerDead);
        particle = GetComponent<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void PlayerDead(object sender, EventArgs e)
    {
        meshRenderer.enabled = false;
        particle.Play();
        //text.text = "Game Over";
        //Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            count--;
            if (count < 0)
            {
                count = 0;
            }
            text.text = deadEvent.OnDead(count);
        }
    }

    
}

public class DeadEvent
{
    public event EventHandler Dead;

    public string OnDead(int count)
    {
        if(count <= 0)
        {
            Dead(this, EventArgs.Empty);
            return "Game Over";
        }
        else
        {
            return $"³²Àº ¸ñ¼û : {count} / 3 ";
        }
    }
}
