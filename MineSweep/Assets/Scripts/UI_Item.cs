using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Item : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
	// 初始不展示，点击才展示
	public bool isShow;
	// 类型
	public ITEM_TYPE itemType;
	
	public Text text;
	// 初始颜色
	private Color defaultColor;
    private int num;
	public int Num
    {
        get
        {
			return num;
        }
        set
        {
			num = value;
        }
    }
	// 唯一标识
	private int id;
	public int Id
    {
		get
		{
			return id;
		}
		set
		{
			id = value;
		}
	}

	void Awake()
    {
		itemType = ITEM_TYPE.NONE;
		text.text = "";
		defaultColor = GetComponent<Image>().color;
	}

	void Start () {
	}

	void Init()
    {

    }

	void Update () {
        switch (itemType)
        {
			case ITEM_TYPE.NONE:
				text.text = "";
				break;
			case ITEM_TYPE.NUM:
				if (isShow)
				{
					if (Num != 0)
					{
						text.text = Num.ToString();
					}
                    else
                    {
						text.text = "";
					}
				}
				break;
			case ITEM_TYPE.FLAG:
                if (!isShow)
				{
					text.text = "旗子";
				}
				break;
			case ITEM_TYPE.MINE:
                if (isShow)
				{
					text.text = "炸弹";
				}
				break;
			default:
				break;
		}

        if (isShow)
        {
			Image image = GetComponent<Image>();
			image.color = Color.yellow;
		}
	}

	public void ChangeItemStat(ITEM_TYPE newStat)
    {
		this.itemType = newStat;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
		if (!isShow)
		{
			Image image = GetComponent<Image>();
			image.color = Color.red;
		}
		else 
		{

		}
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		Image image = GetComponent<Image>();
		image.color = defaultColor;
	}

	public void OnPointerClick(PointerEventData eventData)
    {
        if (!isShow)
		{
			this.isShow = true;
			GameLogic.Instance.OnClickItem(Id);
		}
	}
}
