using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : BasePanel<LoginPanel>
{
    public UIInput inputUserName;
    public UIInput inputPassWord;
    public UIToggle togRememberPW;
    public UIToggle togAutoLog;
    public UIButton btnReg;
    public UIButton btnLog;

    public override void Init()
    {
        togRememberPW.onChange.Add(new EventDelegate(() =>
        {
            // 如果记住密码没有勾选，则自动登录也应该取消勾选
            if (!togRememberPW.value)
                togAutoLog.value = false;
        }));

        togAutoLog.onChange.Add(new EventDelegate(() =>
        {
            // 如果自动登录勾选，则记住密码也应该勾选
            if (togAutoLog.value)
                togRememberPW.value = true;
        }));

        btnReg.onClick.Add(new EventDelegate(() =>
        {
            // 登录面板隐藏
            HideMe();

            // 注册面板打开
            RegisterPanel.Instance.ShowMe();
        }));

        btnLog.onClick.Add(new EventDelegate(() =>
        {
            // 如果登录信息正确
            if (LoginMgr.Instance.CheckInfo(inputUserName.value, inputPassWord.value))
            {
                // 记录数据
                LoginMgr.Instance.LoginData.userName = inputUserName.value;
                LoginMgr.Instance.LoginData.passWord = inputPassWord.value;
                LoginMgr.Instance.LoginData.rememberPW = togRememberPW.value;
                LoginMgr.Instance.LoginData.autoLog = togAutoLog.value;
                LoginMgr.Instance.SaveLoginData();

                // 如果之前选择过服务器 那么应该打开服务器面板
                if (LoginMgr.Instance.LoginData.lastServerID != 0)
                    ServerPanel.Instance.ShowMe();
                // 没有选择过 则应该打开服务器选择面板
                else
                    ChooseServerPanel.Instance.ShowMe();

                // 登录面板隐藏
                HideMe();
            }
            // 如果登录信息错误
            else
            {
                // 更新提示信息
                TipPanel.Instance.labInfo.text = "用户名或密码错误";
                // 现实提示面板
                TipPanel.Instance.ShowMe();
            }

        }));

        //获取我们的 登录数据 更新面板上的显示
        LoginData data = LoginMgr.Instance.LoginData;

        //更新 两个Tog
        togRememberPW.value = data.rememberPW;
        togAutoLog.value = data.autoLog;

        //更新用户名
        if (data.userName != "")
            inputUserName.value = data.userName;

        //是否记住密码
        if (data.rememberPW)
            inputPassWord.value = data.passWord;

        // 是否自动登录
        if (data.autoLog)
        {
            // 如果登录信息正确
            if (LoginMgr.Instance.CheckInfo(inputUserName.value, inputPassWord.value))
            {
                // 如果之前选择过服务器 那么应该打开服务器面板
                if (LoginMgr.Instance.LoginData.lastServerID != 0)
                    ServerPanel.Instance.ShowMe();
                // 没有选择过 则应该打开服务器选择面板
                else
                    ChooseServerPanel.Instance.ShowMe();

                // 登录面板隐藏
                HideMe();
            }
            // 如果登录信息错误
            else
            {
                // 更新提示信息
                TipPanel.Instance.labInfo.text = "用户名或密码错误";
                // 现实提示面板
                TipPanel.Instance.ShowMe();
            }
        }
    }
}
