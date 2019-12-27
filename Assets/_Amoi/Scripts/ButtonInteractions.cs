using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{

    private GameObject _optionMenu;
    private GameObject _rulesMenu;
    private GameObject _principalMenu;
    private GameObject _startMenu;
    private GameObject _pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        _optionMenu = GameObject.Find("OptionMenu");
        _rulesMenu = GameObject.Find("RulesMenu");
        _principalMenu = GameObject.Find("PrincipalMenu");
        _startMenu = GameObject.Find("StartMenu");
        _pauseMenu = GameObject.Find("PauseMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnQuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnOptionButton()
    {
        _optionMenu.SetActive(true);
    }

    public void OnRulesButton()
    {
        _rulesMenu.SetActive(true);
    }
}
