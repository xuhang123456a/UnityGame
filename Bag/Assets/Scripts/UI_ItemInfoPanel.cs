using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemInfoPanel : MonoBehaviour {
	public static UI_ItemInfoPanel Instance;

    private ItemModel currItem;

    public Image iconImg;
    public Text infoText;
    public Button button;

	void Awake()
    {
		Instance = this;
        SetActive(false);

        button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        if (currItem == null)
        {
            return;
        }

        // 使用道具
        print("使用" + currItem.itemDefine.Name);
        Player.Instance.UseItem(currItem.itemDefine.ID);
    }

	public void SetActive(bool isOpen)
    {
        gameObject.SetActive(isOpen);
    }

    public void ShowItem(ItemModel model)
    {
        currItem = model;
        iconImg.sprite = Resources.Load<Sprite>(model.itemDefine.ImgSrc);
        infoText.text = model.itemDefine.Info;
    }

    public void Clean()
    {
        currItem = null;
        iconImg.sprite = null;
        infoText.text = null;
    }
}
