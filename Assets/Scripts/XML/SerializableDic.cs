using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableDic<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

        // 进入根结点
        reader.Read();
        // 一直读 直到读到根节点的末尾
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            TKey tKey = (TKey)keySer.Deserialize(reader);
            TValue tVal = (TValue)valueSer.Deserialize(reader);

            this.Add(tKey, tVal);
        }
        // 将根节点的结束部分读了
        reader.Read();
    }

    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

        foreach (KeyValuePair<TKey, TValue> kv in this)
        {
            keySer.Serialize(writer, kv.Key);
            valueSer.Serialize(writer, kv.Value);
        }
    }
}
