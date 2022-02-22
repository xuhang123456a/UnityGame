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

    private float touchTime = 0;
    private float startTime = 1.6f;

	void Awake()
    {
		Instance = this;
        SetActive(false);
        // 隐藏所有组件
        iconImg.gameObject.SetActive(false);
        infoText.gameObject.SetActive(false);

        //button.onClick.AddListener(ButtonClick);
        button.onClick.AddListener(LongButtonTouch);
    }

    void Update()
    {
        touchTime += Time.deltaTime;
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

    private void LongButtonTouch()
    {
        if (touchTime > startTime)
        {
            if (currItem == null) return;

            Player.Instance.UseItem(currItem.itemDefine.ID);
        }
    }

	public void SetActive(bool isOpen)
    {
        gameObject.SetActive(isOpen);
    }

    public void ShowItem(ItemModel model)
    {
        // 显示所有组件
        iconImg.gameObject.SetActive(true);
        infoText.gameObject.SetActive(true);

        currItem = model;
        iconImg.sprite = Resources.Load<Sprite>(model.itemDefine.ImgSrc);
        infoText.text = model.itemDefine.Info;
    }

    public void Clean()
    {
        currItem = null;
        iconImg.sprite = Resources.Load<Sprite>("prop_14");
        infoText.text = null;
    }
}
