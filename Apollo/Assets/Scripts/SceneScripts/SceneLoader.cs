using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static string sceneName;
    public Animator animator;
    public void changeScene(string scene) {
        sceneName = scene;
        animator.SetTrigger("FadeTrigger");
        //OnFadeComplete(scene);
    }
    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneName);
    }
}
