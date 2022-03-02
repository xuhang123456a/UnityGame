using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Item : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
	public static UI_Item Instance;
	public ITEM_STAT stat;
	public Text text;
	private Color color;
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

	void Awake()
    {
		Instance = this;
    }

	void Start () {
		stat = ITEM_STAT.NONE;
	}

	void Init()
    {

    }

	void Update () {
        switch (stat)
        {
			case ITEM_STAT.NONE:
				text.text = "";
				break;
			case ITEM_STAT.NUM:
				text.text = Num.ToString();
				break;
			case ITEM_STAT.FLAG:
				text.text = "旗子";
				break;
			case ITEM_STAT.MINE:
				text.text = "炸弹";
				break;
		}
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
		Image image = GetComponent<Image>();
		color = image.color;
		image.color = Color.red;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		Image image = GetComponent<Image>();
		image.color = color;
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		Image image = GetComponent<Image>();
		image.color = color;
	}

}
