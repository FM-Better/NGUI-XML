using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登录管理器 用于管理 登录相关的数据
/// </summary>
public class LoginMgr
{
    private static LoginMgr instance = new LoginMgr();
    public static LoginMgr Instance => instance;

    private LoginMgr()
    {
        // 获取上一次的登录数据
        loginData = XmlDataMgr.Instance.LoadData(typeof(LoginData), "LoginData") as LoginData;

        // 获取注册数据
        registerData = XmlDataMgr.Instance.LoadData(typeof(RegisterData), "RegisterData") as RegisterData;

        // 获取服务器数据
        serverInfo = XmlDataMgr.Instance.LoadData(typeof(ServerInfo), "ServerInfo") as ServerInfo;
    }

    // 登录面板中 记录的登录数据 私有变量 防止外部直接修改
    private LoginData loginData;
    // 提供 只能得不能改的 公共属性给外部 获取 上一次的登录数据
    public LoginData LoginData => loginData;

    // 提供给外部 存储登录数据的方法
    public void SaveLoginData()
    {
        XmlDataMgr.Instance.SaveData(loginData, "LoginData");
    }

    // 判断登录信息是否正确
    public bool CheckInfo(string userName, string passWord)
    {
        if (registerData.regInfo.ContainsKey(userName))
        {
            if (registerData.regInfo[userName] == passWord)
                return true;
        }
        return false;
    }

    // 注册面板中 记录的注册数据 私有变量 防止外部直接修改
    private RegisterData registerData;
    // 提供 只能得不能改的 公共属性给外部 获取 注册相关的数据
    public RegisterData RegisterData => RegisterData;

    // 提供给外部 存储注册数据的方法
    public void SaveRegisterData()
    {
        XmlDataMgr.Instance.SaveData(registerData, "RegisterData");
    }

    // 判断是否注册成功
    public bool CanRegister(string userName, string passWord)
    {
        // 如果已有该用户名
        if (registerData.regInfo.ContainsKey(userName))
        {
            return false;
        }
        registerData.regInfo.Add(userName, passWord);
        SaveRegisterData();
        return true;
    }

    // 配置文件中 记录的服务器数据 私有变量 防止外部直接修改
    private ServerInfo serverInfo;
    // 提供 只能得不能改的 公共属性给外部 获取 服务器相关的数据
    public ServerInfo ServerInfo => serverInfo;
}
