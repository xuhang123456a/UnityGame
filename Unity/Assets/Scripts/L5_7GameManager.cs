using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L5_7UserInfo
{
    public string userName;
    public string passWord;
    public bool IsMan;

    public L5_7UserInfo(string userName, string passWord, bool isMan)
    {
        this.userName = userName;
        this.passWord = passWord;
        IsMan = isMan;
    }
}

public class L5_7GameManager : MonoBehaviour {

	private static L5_7GameManager instance;
    public List<L5_7UserInfo> userInfos = new List<L5_7UserInfo>();

    public static L5_7GameManager Instance
    {
        get
        {
            if (instance == null) instance = new L5_7GameManager();
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public void SaveUserInfo(L5_7UserInfo userInfo)
    {
        userInfos.Add(userInfo);
    }

    public L5_7UserInfo GetUserInfo(string userName)
    {
        for(int i = 0; i < userInfos.Count; ++i)
        {
            if(userName == userInfos[i].userName)
            {
                return userInfos[i];
            }
        }

        return null;
    }
}
