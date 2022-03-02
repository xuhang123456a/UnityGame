using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int row = 0;
    public int col = 0;
    public GameObject item;
    public Transform item_parent;
    private GameObject[,] allItems;
    public int mineCount = 10;
    void Start()
    {
        // 设置炸弹位置
        int[] nums = new int[mineCount];
        for (int i = 0; i < mineCount; ++i)
        {
            nums[i] = Random.Range(0, row * col);
        }

        for (int i = 0; i < row * col; ++i)
        {
            for (int j = 0; j < mineCount; ++j)
            {
                if (i == nums[j])
                {
                    item.GetComponent<UI_Item>().Num = nums[j];
                    item.GetComponent<UI_Item>().stat = ITEM_STAT.NUM;
                    Debug.LogFormat("item Num={0} stat={1}", item.GetComponent<UI_Item>().Num, item.GetComponent<UI_Item>().stat);
                }
            }
            Instantiate(item, item_parent);
        }
    }

    void Update()
    {

    }
}
