using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRange : MonoBehaviour
{
    public UILabel labRange;
    public UIButton btnServerRange;

    private int beginID;
    private int endID;

    void Start()
    {
        btnServerRange.onClick.Add(new EventDelegate(() =>
        {
            // 在右侧动态加载出对应范围的服务器信息
            ChooseServerPanel.Instance.UpdatePanel(beginID, endID);
        }));
    }

    // 提供给外部一个更新Label的方法
    public void SetInfo(int beginID, int endID)
    {
        this.beginID = beginID;
        this.endID = endID;

        labRange.text = beginID + " - " + endID + "区";
    }
}
