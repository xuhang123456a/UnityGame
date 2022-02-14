using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
	public GameObject enemyTemplate;
	public List<Enemy> enemies = new List<Enemy>();

    Coroutine coroutine = null;
    public Vector2 range;

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
            GenerateEnemy();
            yield return new WaitForSeconds(2f);
        }
    }
    void GenerateEnemy()
    {
        GameObject obj = Instantiate(enemyTemplate, this.transform);
        Enemy p = obj.GetComponent<Enemy>();
        enemies.Add(p);

        float y = Random.Range(range.x, range.y);
        obj.transform.localPosition = new Vector3(0, y, 0);
    }
}
