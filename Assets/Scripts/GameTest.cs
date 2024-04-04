using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTest : MonoBehaviour
{
    public UIButton btnReLoad;
    public UIButton btnExit;
    void Start()
    {
        btnReLoad.onClick.Add(new EventDelegate(() =>
        {
            SceneManager.LoadScene("NGUI");
        }));

        btnExit.onClick.Add(new EventDelegate(() =>
        {
            // 编辑器模式
            UnityEditor.EditorApplication.isPlaying = false;

            // 打包后
            // Application.Quit();
        }));
    }
}
