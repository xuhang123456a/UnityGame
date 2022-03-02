using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollListener : MonoBehaviour,IBeginDragHandler, IEndDragHandler
{

	private ScrollRect scrollRect;
	private float[] pageArray = new float[] { 0, 0.3333f, 0.6666f, 1 };
	public Toggle[] toggleArray;
	private float targetHorizontalPosition = 0;
	private bool isDraging = false;

	void Start()
    {
		scrollRect = GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        float posX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(posX - pageArray[index]);
        for(int i = 1; i < pageArray.Length; i++)
        {
            float offsetTemp = Mathf.Abs(posX - pageArray[i]);
            if(offsetTemp < offset)
            {
                index = i;
                offset = offsetTemp;
            }
        }
        targetHorizontalPosition = pageArray[index];
        toggleArray[index].isOn = true;
    }

    public void MoveToPage1(bool isOn)
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[0];
        }
    }

    public void MoveToPage2(bool isOn)
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[1];
        }
    }

    public void MoveToPage3(bool isOn)
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[2];
        }
    }

    public void MoveToPage4(bool isOn)
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[3];
        }
    }
}
