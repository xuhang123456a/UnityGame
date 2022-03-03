using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance;

    public int row = 0;
    public int col = 0;
    public GameObject item;
    public Transform item_parent;
    private GameObject[,] allItems;
    public int mineCount = 10;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 设置炸弹位置，不重复
        int[] nums = new int[mineCount];
        for (int i = 0; i < mineCount; ++i)
        {
            bool needRand = false;
            do
            {
                nums[i] = Random.Range(0, row * col);
                //Debug.LogWarning("   " + i+"    " +nums[i]);
                for (int j = 0; j < i; ++j)
                {
                    if (nums[i] == nums[j])
                    {
                        needRand = true;
                        break;
                    }
                    needRand = false;
                }
            }
            while (needRand);
        }
        Commons.DebugLog(nums);
        Commons.Quick_Sort(nums, 0, nums.Length);
        Commons.DebugLog(nums);

        int numsIndex = 0;
        allItems = new GameObject[row, col];
        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                GameObject go = Instantiate(item, item_parent);
                allItems[i, j] = go;
                int id = (i * col) + j;
                go.GetComponent<UI_Item>().Id = id;
                go.GetComponent<UI_Item>().Num = 0;
                go.GetComponent<UI_Item>().itemType = ITEM_TYPE.NUM;

                if (numsIndex < mineCount)
                {
                    int curRow = Mathf.FloorToInt(nums[numsIndex] / col);
                    int curCol = nums[numsIndex] % col;
                    Debug.LogFormat("numsIndex:{5},数值为{4}    ({0},{1})   自己的({2},{3})", i, j, curRow, curCol, nums[numsIndex],numsIndex);
                    if (i == curRow && j == curCol)
                    {
                        Debug.LogWarning("就是这个"+ nums[numsIndex]);
                        go.GetComponent<UI_Item>().Num = nums[numsIndex];
                        go.GetComponent<UI_Item>().itemType = ITEM_TYPE.MINE;
                        numsIndex++;
                    }
                }
            }
        }
        Debug.LogWarning("炸弹数量：" + numsIndex + "    " + nums.Length);
        // 设置数字
        OnUpdateNums();
    }

    void OnUpdateNums()
    {
        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                // 如果当前格子是炸弹 则更新周围数字
                if (allItems[i, j].GetComponent<UI_Item>().itemType == ITEM_TYPE.MINE)
                {
                    for (int m = -1; m <= 1; ++m)
                    {
                        for (int n = -1; n <= 1; ++n)
                        {
                            if (i + m >= 0 && i + m < row
                                && j + n >= 0 && j + n < col
                                && allItems[i + m, j + n].GetComponent<UI_Item>().itemType == ITEM_TYPE.NUM)
                            {
                                allItems[i + m, j + n].GetComponent<UI_Item>().Num += 1;
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnClickItem(int id)
    {
        int i = Mathf.FloorToInt(id / col);
        int j = id % col;
        Debug.LogFormat("点击了{0},({1},{2})", id, i, j);
        bool[,] visited = new bool[row, col];
        Dfs(visited, i, j);
    }

    public void Dfs(bool[,] visited, int i, int j)
    {
        visited[i, j] = true;
        if (allItems[i, j].GetComponent<UI_Item>().itemType == ITEM_TYPE.NUM && allItems[i, j].GetComponent<UI_Item>().Num > 0)
        {
            return;
        }

        for (int m = -1; m <= 1; ++m)
        {
            for (int n = -1; n <= 1; ++n)
            {
                if (i + m >= 0 && i + m < row && j + n >= 0 && j + n < col && !visited[i + m, j + n]
                    && allItems[i + m, j + n].GetComponent<UI_Item>().itemType == ITEM_TYPE.NUM)
                {
                    //Debug.LogFormat("allItem ({0},{1})", i + m, j + n);
                    allItems[i + m, j + n].GetComponent<UI_Item>().isShow = true;
                    if (allItems[i + m, j + n].GetComponent<UI_Item>().Num == 0)
                        Dfs(visited, i + m, j + n);
                }
            }
        }
    }
}
