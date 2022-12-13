using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public float fadeStep = 0.1f;
    public Button startButton;
    public Button exitButton;

    private Volume volume;
    private Vignette vignette;
    private FadeCanvasLoader load;

    private void Start()
    {
        load = FadeCanvasLoaderManager.instance.fadeCanvasLoader;
        volume = GlobalVolume.instance.volume;
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            LoadScene();
        }
        startButton.onClick.AddListener(() => LoadNextScene());
        startButton.onClick.AddListener(() => ExitGame());
    }

    void LoadScene()
    {
        load.FadeIn();
        StartCoroutine(VignetteFadeIn(load.fadeDuration));
    }

    void LoadNextScene()
    {
        startButton.onClick.RemoveAllListeners();
        load.FadeOut();
        StartCoroutine(VignetteFadeOut(load.fadeDuration, 1));
    }

    void ExitGame()
    {
        startButton.onClick.RemoveAllListeners();
        load.FadeOut();
        StartCoroutine(VignetteFadeOut(load.fadeDuration, 0));
    }

    IEnumerator VignetteFadeIn(float fadeDuration)
    {
        float value = 1f;
        vignette.intensity.Override(value);
        while (vignette.intensity.value > 0)
        {
            value -= 1f / fadeDuration * fadeStep;
            vignette.intensity.Override(value);
            yield return new WaitForSeconds(fadeStep);
        }
    }

    IEnumerator VignetteFadeOut(float fadeDuration, int index)
    {
        float value = 0f;
        vignette.intensity.Override(value);
        while (vignette.intensity.value < 1)
        {
            value += 1f / fadeDuration * fadeStep;
            vignette.intensity.Override(value);
            yield return new WaitForSeconds(fadeStep);
        }

        if (index != 0)
        {
            StartCoroutine(LoadNextSceneByAsync(index));
        }
        else
        {
            GlobalSaveManager.instance.saveManager.SaveGame();
            Application.Quit();
        }
    }

    IEnumerator LoadNextSceneByAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + index);

        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        load.FadeIn();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
