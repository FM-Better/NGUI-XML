using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPanel : BasePanel<TipPanel>
{
    // 确认按钮
    public UIButton btnSure;
    // 提示内容
    public UILabel labInfo;

    public override void Init()
    {
        // 点击确认按钮
        btnSure.onClick.Add(new EventDelegate(() =>
        {
            HideMe();
        }));

        // 一开始隐藏面板
        HideMe();
    }

    /// <summary>
    /// 提供 外部调用的修改提示内容的 方法
    /// </summary>
    /// <param name="nowInfo"> 要提示的内容 </param>
    public void ChangeInfo(string nowInfo)
    {
        labInfo.text = nowInfo;
    }
}
