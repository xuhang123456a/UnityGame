using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BagPanel : MonoBehaviour {

	public static UI_BagPanel Instance;

	private bool isOpen = false;

	private List<UI_Item> items = new List<UI_Item>();

	public Transform ItemsParent;
	public GameObject Prefab_Item;

	void Awake()
    {
		Instance = this;
		gameObject.SetActive(false);
    }

	void OnEnable()
	{
		UpdateBag();
	}

	// 更新背包
	public void UpdateBag()
    {
		DestroyItems();
		CreatItems();
    }

	// 切换开关背包
	public void Toggle()
    {
		isOpen = !isOpen;
		gameObject.SetActive(isOpen);
		// 同步告知物品信息面板
		UI_ItemInfoPanel.Instance.SetActive(isOpen);
    }

	public void CreatItems()
    {
		// 去和玩家要数据
		Dictionary<int, ItemModel> data = Player.Instance.GetBagData();
		foreach(var item in data.Values)
        {
			// 实例化格子物体（可以用对象池来创建）
            UI_Item temp = GameObject.Instantiate(Prefab_Item, ItemsParent).GetComponent<UI_Item>();
            // 需要初始化
            temp.Init(item);
            items.Add(temp);
        }
    }

	// 销毁全部物品
	public void DestroyItems()
    {
		for(int i = 0; i < items.Count; ++i)
        {
			Destroy(items[i].gameObject);
        }
		items.Clear();
    }
}
