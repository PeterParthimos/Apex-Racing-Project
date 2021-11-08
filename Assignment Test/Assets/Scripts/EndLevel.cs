using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public Button mainMenu;
    public Button restart;

    // Start is called before the first frame update
    void Start()
    {
        //Sets onClick listeners for butyons
        mainMenu.onClick.AddListener(MainMenu);
        restart.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads main menu
    void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    //Reloads current scene
    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
