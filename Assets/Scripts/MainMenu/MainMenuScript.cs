using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject helpMenu;


    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loadgame()
    {
        print("hello");
        SceneManager.LoadScene(1);
    }

    public void showHelp()
    {
        helpMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void showMenu()
    {
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
