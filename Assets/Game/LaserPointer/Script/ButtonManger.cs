using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManger : MonoBehaviour
{
    public void FreeCat()  //点击 成功抓到界面 放回自然选项 执行的函数
    {
        SceneManager.LoadScene(1);
        Debug.Log("放回自然");
    }
    public void TakeBack()  //点击 成功抓到界面 带回猫舍选项 执行的函数
    {
        GlobalSaveManager.instance.saveManager.catNum++;
        GlobalSaveManager.instance.saveManager.SaveGame();
        SceneManager.LoadScene(2);
        Debug.Log("带回猫舍");
    }

    public void GoBack()  //点击 失败界面 回到草原选项 执行的函数
    {
        SceneManager.LoadScene(1);
        Debug.Log("回到草原");
    }

}
