using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 数据结构类 登录数据
public class LoginData
{
    // 账号
    public string userName;
    //密码
    public string passWord;
    // 上一次登录的服务器号
    public int lastServerID;
    // 是否记住密码
    public bool rememberPW;
    //是否自动登录
    public bool autoLog;
}
