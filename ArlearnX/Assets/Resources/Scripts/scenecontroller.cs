using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenecontroller : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject guideCanvas;
    public void Scan(){
        SceneManager.LoadScene(2);

    }
    public void QuitApp(){
        Application.Quit();
    }
    public void MainMenu(){
        SceneManager.LoadScene(1);
    }
   public void OnGuideButtonClick()
    {
        mainCanvas.SetActive(false);
        guideCanvas.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        mainCanvas.SetActive(true);
        guideCanvas.SetActive(false);
    }
    
    
}
