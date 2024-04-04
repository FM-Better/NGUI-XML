using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseServerPanel : BasePanel<ChooseServerPanel>
{
    public UILabel labLastInfo;
    public UISprite sprState;
    public UILabel labRange;
    public Transform svLeft;
    public Transform svRight;

    // 记录上一次面板右侧 显示的按钮
    private List<GameObject> itemList = new List<GameObject>();

    public override void Init()
    {
        // 动态创建左侧按钮

        // 得到服务器数据
        ServerInfo info = LoginMgr.Instance.ServerInfo;
        int serverNum = info.serverInfoDic.Count;

        // 将所有服务器按10区一个范围划分
        int num = serverNum / 10;
        if (serverNum % 10 != 0)
            num++;

        for (int i = 0; i < num; ++i)
        {
            // 创建一个左侧按钮
            GameObject btn = Instantiate(Resources.Load<GameObject>("UI/BtnServerRange"));
            // 为创建的按钮设置父对象 设置位置
            btn.transform.SetParent(svLeft, false);
            btn.transform.localPosition = new Vector3(-77, 62 + i * -65, 0);
            // 得到脚本 设置按钮信息
            ServerRange serverRange = btn.GetComponent<ServerRange>();
            int beginID = i * 10 + 1;
            int endID = (i + 1) * 10;
            // 如果serverNum < 当前endID 则当前endID = serverNum
            if (serverNum < endID)
                endID = serverNum;
            serverRange.SetInfo(beginID, endID);
        }

        // 一开始隐藏选服面板
        HideMe();
    }

    // 提供给外部 更新选服面板右侧的显示内容的 方法
    public void UpdatePanel(int beginID, int endID)
    {
        // 更新上方的Label
        labRange.text = "服务器  " + beginID + " - " + endID;

        // 删除上一次显示的按钮
        // 删除对应的按钮
        for (int i = 0; i < itemList.Count; ++i)
            Destroy(itemList[i].gameObject);
        // 清空列表
        itemList.Clear();

        // 创建下方的按钮
        Server nowInfo;
        int row;
        int col;
        for (int i = beginID; i <= endID; ++i)
        {
            // 获取当前ID对应的服务器数据
            nowInfo = LoginMgr.Instance.ServerInfo.serverInfoDic[i];

            // 动态创建按钮
            GameObject btn = Instantiate(Resources.Load<GameObject>("UI/BtnServer"));
            // 为按钮设置父对象 设置坐标
            btn.transform.SetParent(svRight, false);
            row = (i - beginID) / 2;
            col = (i - beginID) % 2;
            btn.transform.localPosition = new Vector3(14 + col * 300, 62 + row * -90, 0);

            // 得到脚本 设置按钮信息
            ServerItem serverItem = btn.GetComponent<ServerItem>();
            serverItem.SetInfo(nowInfo);

            // 创建成功后 将该按钮存入列表中
            itemList.Add(btn);
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();

        // 更新上方上次登录的显示信息
        // 如果上次没有登录过服务器
        int lastID = LoginMgr.Instance.LoginData.lastServerID;
        if (lastID == 0)
        {
            labLastInfo.text = "无";
            sprState.gameObject.SetActive(false);
        }
        // 如果上次有登录过服务器
        else
        {
            // 取得ID对应的服务器信息
            Server info = LoginMgr.Instance.ServerInfo.serverInfoDic[lastID];
            labLastInfo.text = info.id + "区  " + info.name;
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

        // 更新右侧按钮显示
        int endID = 10;
        // 如果serverNum < 当前endID 则当前endID = serverNum
        if (endID > LoginMgr.Instance.ServerInfo.serverInfoDic.Count)
            endID = LoginMgr.Instance.ServerInfo.serverInfoDic.Count;
        UpdatePanel(1, endID);
    }
}
