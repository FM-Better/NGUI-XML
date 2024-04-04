using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerPanel : BasePanel<ServerPanel>
{
    public UILabel labInfo;
    public UIButton btnChange;
    public UIButton btnSure;
    public UIButton btnReturn;

    public override void Init()
    {
        btnChange.onClick.Add(new EventDelegate(() =>
        {
            // 打开选服面板
            ChooseServerPanel.Instance.ShowMe();

            // 隐藏服务器面板
            HideMe();
        }));

        btnSure.onClick.Add(new EventDelegate(() =>
        {
            // 进入游戏
            SceneManager.LoadScene("GameScene");
        }));

        btnReturn.onClick.Add(new EventDelegate(() =>
        {
            // 返回到登录面板
            LoginPanel.Instance.ShowMe();
            //隐藏服务器面板
            HideMe();
        }));

        // 一开始隐藏服务器面板
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();

        // 更新服务器信息
        int id = LoginMgr.Instance.LoginData.lastServerID;
        Server info = LoginMgr.Instance.ServerInfo.serverInfoDic[id];
        labInfo.text = info.name;
    }
}
