using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    public Rigidbody2D rigibodyBird;
    public Animator ani;
    public float force;
    private bool death = false;

    public delegate void DeathNotify();

    public event DeathNotify OnDeath;

    public UnityAction<int> OnScore;

    private Vector3 initPos;

    void Start () {
        this.ani = this.GetComponent<Animator>();
        this.Idle();
        this.initPos = transform.position;
    }
	
    public void Init()
    {
        this.transform.position = this.initPos;
        this.Idle();
        this.death = false;
    }

	void Update () {
        if (this.death) return;
        if (Input.GetMouseButtonDown(0))
        {
            rigibodyBird.velocity = Vector2.zero;
            rigibodyBird.AddForce(new Vector2(0, force),ForceMode2D.Force);
        }
	}

    public void Idle()
    {
        this.rigibodyBird.simulated = false;
        this.ani.SetTrigger("Idle");
    }

    public void Fly()
    {
        this.rigibodyBird.simulated = true;
        this.ani.SetTrigger("Fly");
    }

    public void Die()
    {
        this.death = true;
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if(collision.gameObject.name.Equals("scoreArea"))
        {

        }
        else
            this.Die();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (collision.gameObject.name.Equals("scoreArea"))
        {
            if (this.OnScore != null)
            {
                this.OnScore(1);
            }
        }
    }
}
