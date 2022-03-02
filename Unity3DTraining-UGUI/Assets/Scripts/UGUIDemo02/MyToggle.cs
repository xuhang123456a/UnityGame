using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {

	public GameObject isOnGameObject;
	public GameObject isOffGameObject;

	private Toggle toggle;
	private bool isOn;

	private void Start()
    {
		toggle = this.GetComponent<Toggle>();
		isOn = toggle.isOn;
		OnValueChange(isOn);

	}

	public void OnValueChange(bool isOn)
    {
		isOnGameObject.SetActive(isOn);
		isOffGameObject.SetActive(!isOn);
    }
}
