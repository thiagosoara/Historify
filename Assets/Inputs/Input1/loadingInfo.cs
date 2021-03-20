using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Text txtCarregando;

    public void BtnClick()
    {
        StartCoroutine(LoadGameProg());
    }
    IEnumerator LoadGameProg()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        while (async.isDone){
            txtCarregando.enabled = true;
            yield return null;
        }
    }
}
