using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{

    private int levelToLoadIndex;

    public GameObject settingPanel;
    public GameObject mainMenuPanel;
    bool isSettingsOpen;


    // Start is called before the first frame update
    void Start()
    {
      
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isSettingsOpen = false;
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSettingsOpen && Input.GetButtonDown("Escape"))
        {
            BackBtnClicked();
        }

    }

  

    

    public void PlayBtnClicked()
    {
        levelToLoadIndex = 1;
        SceneManager.LoadScene(levelToLoadIndex);
    
        
    }


    public void SettingsBtnClicked()
    {
        isSettingsOpen = true;
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);

    }

    public void BackBtnClicked()
    {

        isSettingsOpen = false;
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);

    }


    public void QuitBtnClicked()
    {

       
     
        Application.Quit();
      
    }

   
}