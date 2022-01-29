using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L5_7MainPanel : MonoBehaviour
{
    public static L5_7MainPanel Instance;

    private Button registerButton;
    private Button loginButton;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        registerButton = transform.Find("RegisterButton").GetComponent<Button>();
        loginButton = transform.Find("LoginButton").GetComponent<Button>();

        registerButton.onClick.AddListener(RegisterButtonClick);
        loginButton.onClick.AddListener(LoginButtonClick);
    }

    private void RegisterButtonClick()
    {
        L5_7RegisterPanel.Instance.Show();
        gameObject.SetActive(false);
    }

    private void LoginButtonClick()
    {
        L5_7LoginPanel.Instance.Show();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
