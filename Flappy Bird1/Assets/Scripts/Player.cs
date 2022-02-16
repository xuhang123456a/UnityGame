using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Unit
{
    // 委托事件 通知
    public event DeathNotify OnDeath;

    override protected void OnStart()
    {
        this.Idle();
        this.initHp = HP;
    }

    override protected void OnUpdate()
    {
        Debug.Log("Player Player Player Update");
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
        Enemy enemy = collision.GetComponent<Enemy>();
        if (bullet == null && enemy == null)
            return;
        Debug.Log("[Player] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (bullet != null && bullet.side == SIDE.ENEMY)
        {
            this.HP -= bullet.power;
            if (this.HP <= 0)
                this.Die();
        }
        if(enemy != null)
        {
            this.HP = 0;
            this.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("[Player] OnTriggerEnter2D: " + collision.gameObject.name + "  " + gameObject.name + " " + Time.time);
        if (collision.gameObject.name.Equals("scoreArea"))
        {
            if (this.OnScore != null)
            {
                this.OnScore(1);
            }
        }
    }
}
