using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerItem : MonoBehaviour
{
    public UIButton btnServer;
    public UISprite sprNew;
    public UILabel labInfo;
    public UISprite sprState;

    // 用于存储当前服务器id
    private int nowID;

    void Start()
    {
        btnServer.onClick.Add(new EventDelegate(() =>
        {
            // 记录当前选择的服务器id并保存
            LoginMgr.Instance.LoginData.lastServerID = nowID;
            LoginMgr.Instance.SaveLoginData();

            // 打开服务器面板
            ServerPanel.Instance.ShowMe();

            // 隐藏选服面板
            ChooseServerPanel.Instance.HideMe();
        }));
    }

    // 提供给外部 一个用于设置左侧单个服务器按钮信息的方法
    public void SetInfo(Server info)
    {
        // 记录当前的服务器id
        nowID = info.id;

        // 更新Lable
        labInfo.text = info.id + "区  " + info.name;

        // 更新SprNew
        if (info.isNew)
            sprNew.gameObject.SetActive(true);
        else
            sprNew.gameObject.SetActive(false);

        // 更新SprState
        sprState.gameObject.SetActive(true);
        switch (info.state)
        {
            case 0:
                sprState.gameObject.SetActive(false);
                break;
            case 1:
                sprState.spriteName = "ui_DL_liuchang_01";
                break;
            case 2:
                sprState.spriteName = "ui_DL_fanhua_01";
                break;
            case 3:
                sprState.spriteName = "ui_DL_huobao_01";
                break;
            case 4:
                sprState.spriteName = "ui_DL_weihu_01";
                break;
        }
    }
}
