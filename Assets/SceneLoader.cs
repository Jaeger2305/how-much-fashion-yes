using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneLoader : MonoBehaviour
{
    public int destinationScene;

    public void SceneLoadAfterSeconds(int secondsToWaitBeforeReloading)
    {
        Debug.Log(string.Format("Loading scene {0} in {1}", destinationScene, secondsToWaitBeforeReloading));
        Invoke("SceneLoad", secondsToWaitBeforeReloading);
    }
    private void SceneLoad()
    {
        Debug.Log(string.Format("Loading scene {0} now", destinationScene));
        SceneManager.LoadScene(destinationScene);
    }
}