using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 数据结构类 注册数据
public class RegisterData
{
    /// <summary>
    /// 采用自定义的 可序列化的字典 来存储注册数据 方便进行Xml的序列化、反序列化
    /// </summary>
    /// <typeparam name="string"> 账号 </typeparam>
    /// <typeparam name="string"> 密码 </typeparam>
    /// <returns></returns>
    public SerializableDic<string, string> regInfo = new SerializableDic<string, string>();
}
