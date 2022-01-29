using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L5_7LoginPanel : MonoBehaviour {
    public static L5_7LoginPanel Instance;

    private InputField userName;
    private InputField passWord;

    private Button okButton;
    private Button backButton;

    private void Awake()
    {
        Instance = this;
        userName = transform.Find("UserName/InputField").GetComponent<InputField>();
        passWord = transform.Find("PassWord/InputField").GetComponent<InputField>();

        okButton = transform.Find("OKButton").GetComponent<Button>();
        backButton = transform.Find("BackButton").GetComponent<Button>();

        okButton.onClick.AddListener(OKButtonClick);
        backButton.onClick.AddListener(BackButtonClick);

        gameObject.SetActive(false);
    }

    private void OKButtonClick()
    {
        if (string.IsNullOrEmpty(userName.text)
            || string.IsNullOrEmpty(passWord.text))
        {
            L5_7FloatWindow.Instance.ShowInfo("请输入账号或密码");
        }
        else
        {
            L5_7UserInfo userInfo = L5_7GameManager.Instance.GetUserInfo(userName.text);
            if (L5_7GameManager.Instance.GetUserInfo(userName.text) == null)
            {
                L5_7FloatWindow.Instance.ShowInfo("用户不存在！");
            }
            else if(userInfo.passWord != passWord.text)
            {
                L5_7FloatWindow.Instance.ShowInfo("用户名或密码输入错误！");
            }
            else if(userInfo.passWord == passWord.text)
            {
                L5_7FloatWindow.Instance.ShowInfo("登录成功！");
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
    }
}
