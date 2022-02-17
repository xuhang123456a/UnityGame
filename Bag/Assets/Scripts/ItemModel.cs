using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel
{
    // 定义
    public ItemDefine itemDefine;

    // 数量
    public int count;

    public ItemModel(ItemDefine itemDefine, int count)
    {
        this.itemDefine = itemDefine;
        this.count = count;
    }
}

// 物品的定义(静态)
public class ItemDefine
{
    public int ID;
    public string Name;
    public string ImgSrc;
    public string Info;

    public ItemDefine(int iD, string name, string imgSrc, string info)
    {
        ID = iD;
        Name = name;
        ImgSrc = imgSrc;
        Info = info;
    }
}

