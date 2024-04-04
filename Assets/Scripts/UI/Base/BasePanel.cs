using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel<T> : MonoBehaviour where T : class
{
    private static T instance;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        instance = this as T;
    }

    protected virtual void Start()
    {
        Init();
    }

    /// <summary>
    /// 将初始化操作封装到抽象函数中
    /// 并且将该函数包装到Start函数里
    /// 子类就不需要对start进行操作
    /// </summary>
    public abstract void Init();

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
