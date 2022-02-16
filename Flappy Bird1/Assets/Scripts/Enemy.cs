using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{   // 委托事件 通知
    public event DeathNotify OnDeath;

    // 敌人类型
    public ENEMY_TYPE enemyType;

    // 字段
    public Vector2 range;
    float initY;

    override protected void OnStart()
    {
        this.Fly();
        Destroy(this.gameObject, 5f);

        initY = Random.Range(range.x, range.y);
        this.transform.localPosition = new Vector3(0, initY, 0);
    }

    override protected void OnUpdate()
    {
        float y = 0;
        if (this.enemyType == ENEMY_TYPE.SWING_ENEMY)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3;
        }

        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed,initY + y, 0);
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


    public void Die()
    {
        this.death = true;
        this.ani.SetTrigger("Die");
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
        Destroy(this.gameObject, 0.4f);
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
