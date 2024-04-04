using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPanel : BasePanel<RegisterPanel>
{
    public UIInput inputUserName;
    public UIInput inputPassWord;
    public UIButton btnClose;
    public UIButton btnReg;

    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            // 打开登录面板
            LoginPanel.Instance.ShowMe();
            // 隐藏注册面板
            HideMe();
        }));

        btnReg.onClick.Add(new EventDelegate(() =>
        {
            // 注册的限制
            if (inputUserName.value.Length < 5 ||
                inputPassWord.value.Length < 5)
            {
                // 更新提示信息
                TipPanel.Instance.labInfo.text = "用户名和密码都必须大于等于5位";
                // 打开提示面板
                TipPanel.Instance.ShowMe();
                return;
            }

            // 注册成功
            if (LoginMgr.Instance.CanRegister(inputUserName.value, inputPassWord.value))
            {
                // 隐藏注册面板
                HideMe();

                // 注册成功后 顺便将刚注册的用户名和密码 自动填入登录面板
                LoginPanel.Instance.inputUserName.value = inputUserName.value;
                LoginPanel.Instance.inputPassWord.value = inputPassWord.value;
                // 注册成功后 还应将之前记录数据中的 上一次服务器id给清空
                LoginMgr.Instance.LoginData.lastServerID = 0;

                // 打开登录面板
                LoginPanel.Instance.ShowMe();
            }
            // 注册失败
            else
            {
                // 更新提示信息
                TipPanel.Instance.labInfo.text = "该用户名已存在";
                // 打开提示面板
                TipPanel.Instance.ShowMe();
            }
        }));

        // 一开始隐藏注册面板
        HideMe();
    }

    // 打开注册面板时 应该是空的
    public override void ShowMe()
    {
        base.ShowMe();
        inputUserName.value = "";
        inputPassWord.value = "";
    }
}
