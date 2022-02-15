using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigibodyBird;
    public Animator ani;
    public float speed = 100f;
    public float fireRate = 10;
    private bool death = false;

    public delegate void DeathNotify();

    public event DeathNotify OnDeath;

    public UnityAction<int> OnScore;

    public GameObject bulletTemplate;

    //private Vector3 initPos;

    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        this.Fly();
        //this.initPos = transform.position;
        Destroy(this.gameObject, 5f);
    }

    float fireTimer = 0;
    void Update()
    {
        if (this.death) return;

        fireTimer += Time.deltaTime;

        this.transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);
        Fire();
    }

    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(bulletTemplate);
            go.transform.position = this.transform.position;
            go.GetComponent<Element>().direction = -1;
            fireTimer = 0f;
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
        this.ani.SetTrigger("Die");
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
        Destroy(this.gameObject,0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Element bullet = collision.GetComponent<Element>();
        if (bullet == null)
            return;
        Debug.Log("[Enemy] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (bullet.side == SIDE.PLAYER)
        {
            this.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("[Enemy] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (collision.gameObject.name.Equals("scoreArea"))
        {
            if (this.OnScore != null)
            {
                this.OnScore(1);
            }
        }
    }
}
