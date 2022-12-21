using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictorySceneToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDOwn());
    }

    IEnumerator countDOwn()
    {
        Debug.Log("b");
        SceneManager.LoadScene("OpenScene");
        yield return new WaitForSeconds(3f);

    }
    // Update is called once per frame
    void Update()
    {
        //SceneManager.LoadScene("OpenScene");
    }
}
