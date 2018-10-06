using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneLoad : MonoBehaviour {

	public void LoadSceneNum(int num)
	{
		if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
			Debug.LogWarning ("Cannot load the scene " + num);

        MyProgressBarLoadingScript.LoadScene(num);
       // LoadingScreenManager.LoadScene(num);
    }

}