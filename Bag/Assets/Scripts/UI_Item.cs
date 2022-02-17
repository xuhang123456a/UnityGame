using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Item : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
	public Sprite Normal;
	public Sprite Select;

    public Image image;
    public Image iconImg;
    public Text count;

    // 数据
    public ItemModel model;

    public void Init(ItemModel model)
    {
        this.model = model;
        image.sprite = Normal;
        count.text = model.count.ToString();
        iconImg.sprite = Resources.Load<Sprite>(model.itemDefine.ImgSrc);
    }

    // 鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = Select;
    }

    // 鼠标退出
    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = Normal;
    }

    // 鼠标点击
    public void OnPointerClick(PointerEventData eventData)
    {
        // 通知物品信息显示面板
        UI_ItemInfoPanel.Instance.ShowItem(model);
    }
}
