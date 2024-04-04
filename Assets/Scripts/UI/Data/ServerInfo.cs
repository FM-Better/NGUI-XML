using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// 数据结构类 服务器信息
public class ServerInfo
{
    public SerializableDic<int, Server> serverInfoDic = new SerializableDic<int, Server>();
}

// 数据结构类 服务器
public class Server
{
    [XmlAttribute]
    public int id;
    [XmlAttribute]
    public string name;
    [XmlAttribute]
    public bool isNew;
    [XmlAttribute]
    public int state;
}