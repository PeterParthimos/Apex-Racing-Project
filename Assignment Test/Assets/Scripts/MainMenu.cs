using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button track1;
    public Button track2;
    public Button controls;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        //Creates onClick listeners for each button
        track1.onClick.AddListener(Track1);
        track2.onClick.AddListener(Track2);
        controls.onClick.AddListener(Controls);
        exit.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads Track 1
    void Track1() {
        SceneManager.LoadScene("Track1");
    }

    //Loads Track 2
    void Track2() {
        SceneManager.LoadScene("Track2");
    }

    //Loads Controls
    void Controls() {
        SceneManager.LoadScene("Controls");
    }

    //Quits Application
    void Exit() {
        Application.Quit();
    }
}
