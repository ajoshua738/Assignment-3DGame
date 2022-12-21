using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenJumpSceneToGameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDOwn());
    }

    IEnumerator countDOwn()
    {
        Debug.Log("asdf");
        SceneManager.LoadScene("VictoryScene");
        yield return new WaitForSeconds(3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
