using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L5_7FloatWindow : MonoBehaviour
{
    public static L5_7FloatWindow Instance;

    private Button okButton;
    private Text infoText;

    private void Awake()
    {
        Instance = this;
        infoText = transform.Find("Info").GetComponent<Text>();
        okButton = transform.Find("OKButton").GetComponent<Button>();

        okButton.onClick.AddListener(OKButtonClick);
        gameObject.SetActive(false);
    }

    public void ShowInfo(string info)
    {
        gameObject.SetActive(true);
        infoText.text = info;
    }

    private void OKButtonClick()
    {
        gameObject.SetActive(false);
    }
}
