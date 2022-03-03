using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnClickItem(int id);
public enum ITEM_TYPE
{
    NONE,
    NUM,
    FLAG,
    MINE,
}

public class Commons
{
    public static void Quick_Sort(int[] nums, int l, int r)
    {
        if (l + 1 >= r)
        {
            return;
        }
        int first = l, last = r - 1, key = nums[first];
        while (first < last)
        {
            while (first < last && nums[last] >= key)
            {
                --last;
            }
            nums[first] = nums[last];
            while (first < last && nums[first] <= key)
            {
                ++first;
            }
            nums[last] = nums[first];
        }
        nums[first] = key;
        Quick_Sort(nums, l, first);
        Quick_Sort(nums, first + 1, r);
    }

    public static void DebugLog<T>(T[] nums)
    {
        string str = "";
        foreach (T data in nums)
        {
            str += data + ",";
        }
        Debug.Log(str);
    }

    public static void DebugLog<T>(T[,] nums)
    {
        string str = "{";
        int row = nums.GetLength(0);
        int col = nums.GetLength(1);
        for(int i = 0; i < row; ++i)
        {
            for(int j = 0; j < col; ++j)
            {
                str += nums[i,j] + ",";
            }
            str = str + "\n";
        }
        str = str + "}";
        Debug.Log(str);
    }
}
