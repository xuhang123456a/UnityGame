using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // 组件
    public GameObject enemy1Template;
    public GameObject enemy2Template;
    public GameObject enemy3Template;

    // 字段
    public float speed1;
    public float speed2;
    public float speed3;
    int timer1 = 0;
    int timer2 = 0;
    int timer3 = 0;
    public Vector2 range;

    // 敌人的集合，用于管理敌人
    public List<Enemy> enemies = new List<Enemy>();

    // 协程
    Coroutine coroutine = null;

    public void Begin()
    {
        coroutine = StartCoroutine(GenerateEnemies());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        enemies.Clear();
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            if (timer1 > speed1)
            {
                GenerateEnemy(enemy1Template);
                timer1 = 0;
            }
            if (timer2 > speed2)
            {
                GenerateEnemy(enemy2Template);
                timer2 = 0;
            }
            if (timer3 > speed3)
            {
                GenerateEnemy(enemy3Template);
                timer3 = 0;
            }
            timer1++;
            timer2++;
            timer3++;
            yield return new WaitForSeconds(1f);
        }
    }
    void GenerateEnemy(GameObject template)
    {
        GameObject obj = Instantiate(template, this.transform);
        Enemy p = obj.GetComponent<Enemy>();
        enemies.Add(p);
    }
}
