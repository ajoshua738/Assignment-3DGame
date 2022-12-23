using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{

    public static bool GameIsPaused = false;
    private int levelToLoadIndex;
    public GameObject pauseMenuUI;
    public FirstPersonController player;
    
   

  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<FirstPersonController>();
        pauseMenuUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (GameIsPaused)
            {
               Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }


    public void Resume()
    {

        player.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
       

    }

    void Pause()
    {

        player.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        
       


    }

    public void LoadMainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        Resume();
        
        levelToLoadIndex = 0;

        
        SceneManager.LoadScene(levelToLoadIndex);
        

    }

    public void Quit()
    {
        StartCoroutine(Wait());
        Application.Quit();
        Debug.Log("deez nuts");
    }
}
