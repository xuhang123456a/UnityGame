using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public static Player Instance;

	// 所有持有的物品
	private Dictionary<int, ItemModel> itemModelDic;

	List<ItemDefine> data;

	private void Awake()
    {
		Instance = this;

		// 虚拟一些定义，真实情况是从配置表读的
		data = new List<ItemDefine>();
		data.Add(new ItemDefine(1, "aaaaa", "prop_1", "这是a物品"));
		data.Add(new ItemDefine(2, "bbbbbb", "prop_2", "这是b物品"));
		data.Add(new ItemDefine(3, "cccccccc", "prop_3", "这是c物品"));
		data.Add(new ItemDefine(4, "ddddddddd", "prop_6", "这是d物品"));
		data.Add(new ItemDefine(5, "eeeeeeeeee", "prop_7", "这是e物品"));

		// 虚拟一些数据
		itemModelDic = new Dictionary<int, ItemModel>();
		itemModelDic.Add(data[0].ID, new ItemModel(data[0], 1));
		itemModelDic.Add(data[1].ID, new ItemModel(data[1], 1));
		itemModelDic.Add(data[2].ID, new ItemModel(data[2], 99));
		itemModelDic.Add(data[3].ID, new ItemModel(data[3], 1009));
	}
	
	public Dictionary<int,ItemModel> GetBagData()
    {
		return itemModelDic;
    }

	void Update () {
        // 切换背包
        if (Input.GetKeyDown(KeyCode.Space))
        {
			UI_BagPanel.Instance.Toggle();
        }
		else if (Input.GetKeyDown(KeyCode.A))
		{
			itemModelDic.Add(data[4].ID, new ItemModel(data[4], 1));
			UI_BagPanel.Instance.UpdateBag();
		}
	}

	public void UseItem(int id)
    {
        if (itemModelDic.ContainsKey(id))
        {
			if(itemModelDic[id].count > 0)
            {
				itemModelDic[id].count -= 1;
                if (itemModelDic[id].count <= 0)
                {
					itemModelDic.Remove(id);
					UI_ItemInfoPanel.Instance.Clean();
                }
				UI_BagPanel.Instance.UpdateBag();
            }
        }
    }
}
