using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour
{
    public float timer;
    public int levelToLoadIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(loadScene());
    }


    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(levelToLoadIndex);
    }
}
