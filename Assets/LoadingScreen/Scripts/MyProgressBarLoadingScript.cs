using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyProgressBarLoadingScript : MonoBehaviour
{
    AsyncOperation ao;
    public GameObject loadingScreenBG;
    public Slider progressBar;
    public Text loadingText;

    public static int sceneToLoad = -1;
    static int loadingSceneIndex = 8;

    public static void LoadScene(int levelNum)
    {
        Application.backgroundLoadingPriority = ThreadPriority.High;
        sceneToLoad = levelNum;
        SceneManager.LoadScene(loadingSceneIndex);
    }

    void Start ()
    {
        if (sceneToLoad < 0)
            return;

        loadingScreenBG.SetActive(true);
        progressBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);

        loadingText.text = "LOADING...";

        StartCoroutine(LoadLevelWithProgress());
       

    }

    IEnumerator LoadLevelWithProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync(sceneToLoad); // Index of the level trying to load

        ao.allowSceneActivation = true; // Allow load when fully loaded
        while(!ao.isDone)
        {
            progressBar.value = ao.progress;
            loadingText.text = "LOADING " + Mathf.FloorToInt(ao.progress * 100) + "%";
            yield return null;
        }
        
    }


}
