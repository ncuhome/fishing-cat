using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public Button exitButton;

    private void Start()
    {
        exitButton.onClick.AddListener(() => LoadMapScene());
    }

    void LoadMapScene()
    {
        SceneManager.LoadScene(1);
    }
}
