using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
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

    private Vector3 initPos;

    public float HP = 10f;
    private float initHp;

    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        this.Idle();
        this.initPos = transform.position;
        this.initHp = HP;
    }

    public void Init()
    {
        this.transform.position = this.initPos;
        this.Idle();
        this.death = false;
        this.HP = this.initHp;
    }

    float fireTimer = 0;
    void Update()
    {
        if (this.death) return;

        fireTimer += Time.deltaTime;

        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        this.transform.position = pos;

        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(bulletTemplate);
            go.transform.position = this.transform.position;

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
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Element bullet = collision.GetComponent<Element>();
        if (bullet == null)
            return;
        Debug.Log("[Player] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (bullet.side == SIDE.ENEMY)
        {
            this.HP -= bullet.power;
            if (this.HP <= 0)
                this.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (collision.gameObject.name.Equals("scoreArea"))
        {
            if (this.OnScore != null)
            {
                this.OnScore(1);
            }
        }
    }
}
