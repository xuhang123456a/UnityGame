using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour {
    // 组件
    public Rigidbody2D rigibodyBird;
    public Animator ani;
    public GameObject bulletTemplate;

    // 委托事件 通知
    public delegate void DeathNotify();
    public UnityAction<int> OnScore;

    // 字段
    public float HP = 10f;
    protected float initHp;
    public float speed = 100f;// 移动速度
    protected float fireTimer = 0;// 攻击时间间隔
    public float fireRate = 10;// 攻击频率 （每秒攻击次数）
    protected bool death = false;
    protected Vector3 initPos;
    bool isFlying = false;

    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        this.initPos = transform.position;

        OnStart();
    }

    // Start虚函数
    virtual protected void OnStart()
    {

    }

    public void Init()
    {
        this.transform.position = this.initPos;
        this.Idle();
        this.death = false;
        this.HP = this.initHp;
    }

    void Update()
    {
        Debug.Log("Unit Unit Unit Update");
        if (this.death) return;
        if (!this.isFlying) return;
        fireTimer += Time.deltaTime;

        OnUpdate();
    }

    // Update虚函数
    virtual protected void OnUpdate()
    {

    }

    public void Idle()
    {
        this.rigibodyBird.simulated = false;
        this.isFlying = false;
        this.ani.SetTrigger("Idle");
    }

    public void Fly()
    {
        this.rigibodyBird.simulated = true;
        this.isFlying = true;
        this.ani.SetTrigger("Fly");
    }
}
