using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L5_7RegisterPanel : MonoBehaviour
{
    public static L5_7RegisterPanel Instance;

    private InputField userName;
    private InputField passWord;
    private InputField rePassWord;
    private Toggle IsMan;

    private Button okButton;
    private Button backButton;

    private void Awake()
    {
        Instance = this;
        userName = transform.Find("UserName/InputField").GetComponent<InputField>();
        passWord = transform.Find("PassWord/InputField").GetComponent<InputField>();
        rePassWord = transform.Find("RePassWord/InputField").GetComponent<InputField>();
        IsMan = transform.Find("GenderGroup/Toggle").GetComponent<Toggle>();

        okButton = transform.Find("OKButton").GetComponent<Button>();
        backButton = transform.Find("BackButton").GetComponent<Button>();

        okButton.onClick.AddListener(OKButtonClick);
        backButton.onClick.AddListener(BackButtonClick);

        gameObject.SetActive(false);
    }

    private void OKButtonClick()
    {
        if (string.IsNullOrEmpty(userName.text)
            || string.IsNullOrEmpty(passWord.text)
            || string.IsNullOrEmpty(rePassWord.text))
        {
            L5_7FloatWindow.Instance.ShowInfo("请输入账号或密码");
        }
        else if (passWord.text != rePassWord.text)
        {
            L5_7FloatWindow.Instance.ShowInfo("密码不一致");
        }
        else
        {
            if(L5_7GameManager.Instance.GetUserInfo(userName.text) == null)
            {
                L5_7UserInfo userInfo = new L5_7UserInfo(userName.text, passWord.text, IsMan.isOn);
                L5_7GameManager.Instance.SaveUserInfo(userInfo);
                L5_7FloatWindow.Instance.ShowInfo("注册成功，请登录");
            }
            else
            {
                L5_7FloatWindow.Instance.ShowInfo("请勿重复注册");
            }
        }
    }

    private void BackButtonClick()
    {
        L5_7MainPanel.Instance.Show();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        userName.text = "";
        passWord.text = "";
        rePassWord.text = "";
        IsMan.isOn = true;
    }
}
