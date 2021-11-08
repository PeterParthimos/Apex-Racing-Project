using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public Button back;

    // Start is called before the first frame update
    void Start()
    {
        //Sets onClick for back button
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads main menu
    void Back() {
        SceneManager.LoadScene("MainMenu");
    }
}
