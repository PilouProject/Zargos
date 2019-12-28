using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteractions : MonoBehaviour
{
    public Sprite Box;
    public Sprite CheckBox;    

    private GameObject _optionMenu;
    private GameObject _rulesMenu;
    private GameObject _principalMenu;
    private GameObject _startMenu;
    private GameObject _pauseMenu;
    private GameObject _newgameMenu;

    private GameObject _lowButton;
    private GameObject _mediumButton;
    private GameObject _highButton;
    private GameObject _ultraButton;
    private GameObject _ZQSDButton;
    private GameObject _cursorButton;

    private MoveCamera _moveCamera;

    private int _numbersAIPlayer;

    void Start()
    {
        _optionMenu = GameObject.Find("OptionMenu");
        _rulesMenu = GameObject.Find("RulesMenu");
        _principalMenu = GameObject.Find("PrincipalMenu");
        _startMenu = GameObject.Find("StartMenu");
        _pauseMenu = GameObject.Find("PauseMenu");
        _newgameMenu = GameObject.Find("NewGameMenu");

        _lowButton = GameObject.Find("LowButton");
        _mediumButton = GameObject.Find("MediumButton");
        _highButton = GameObject.Find("HighButton");
        _ultraButton = GameObject.Find("UltraButton");
        _ZQSDButton = GameObject.Find("ZqsdCommand");
        _cursorButton = GameObject.Find("CursorCommand");

        _moveCamera = GameObject.Find("HoldCamera").GetComponent<MoveCamera>();

        _optionMenu.SetActive(false);
        _rulesMenu.SetActive(false);
        _startMenu.SetActive(false);
        _pauseMenu.SetActive(false);
    }


    #region QUIT 

    public void OnQuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnCloseWindow()
    {
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    #endregion

    #region OPTION MENU

    public void OnOptionButton()
    {
        _optionMenu.SetActive(true);
    }

    public void OnLowButton()
    {
        QualitySettings.SetQualityLevel(0);
        _mediumButton.GetComponent<Image>().sprite = Box;
        _highButton.GetComponent<Image>().sprite = Box;
        _ultraButton.GetComponent<Image>().sprite = Box;
        _lowButton.GetComponent<Image>().sprite = CheckBox;        
    }

    public void OnMediumButton()
    {
        QualitySettings.SetQualityLevel(2);
        _lowButton.GetComponent<Image>().sprite = Box;
        _highButton.GetComponent<Image>().sprite = Box;
        _ultraButton.GetComponent<Image>().sprite = Box;
        _mediumButton.GetComponent<Image>().sprite = CheckBox;
    }

    public void OnHighButton()
    {
        QualitySettings.SetQualityLevel(4);
        _lowButton.GetComponent<Image>().sprite = Box;
        _mediumButton.GetComponent<Image>().sprite = Box;
        _ultraButton.GetComponent<Image>().sprite = Box;
        _highButton.GetComponent<Image>().sprite = CheckBox;

    }

    public void OnUltraButton()
    {
        QualitySettings.SetQualityLevel(5);
        _lowButton.GetComponent<Image>().sprite = Box;
        _mediumButton.GetComponent<Image>().sprite = Box;
        _highButton.GetComponent<Image>().sprite = Box;
        _ultraButton.GetComponent<Image>().sprite = CheckBox;
    }

    public void OnZQSDCommand()
    {
        _moveCamera.movementCameraBind = true;
        _cursorButton.GetComponent<Image>().sprite = Box;
        _ZQSDButton.GetComponent<Image>().sprite = CheckBox;
    }

    public void OnCursorCommand()
    {
        _moveCamera.movementCameraBind = false;
        _ZQSDButton.GetComponent<Image>().sprite = Box;
        _cursorButton.GetComponent<Image>().sprite = CheckBox;
    }

    #endregion

    public void OnRulesButton()
    {
        _rulesMenu.SetActive(true);
    }

    #region START

    public void OnStartButton()
    {
        _startMenu.SetActive(true);
        _newgameMenu.SetActive(false);
        _principalMenu.SetActive(false);
    }

    public void OnNewGameButton()
    {
        _newgameMenu.SetActive(true);
    }

    public void OnNumber1Button()
    {
        _numbersAIPlayer = 1;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnNumber2Button()
    {
        _numbersAIPlayer = 2;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnNumber3Button()
    {
        _numbersAIPlayer = 3;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnNumber4Button()
    {
        _numbersAIPlayer = 4;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnNumber5Button()
    {
        _numbersAIPlayer = 5;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnNumber6Button()
    {
        _numbersAIPlayer = 6;
        Debug.Log(_numbersAIPlayer);
    }

    public void OnCreateGameButton()
    {
        if (_numbersAIPlayer != 0)
        {
            _optionMenu.SetActive(false);
            _rulesMenu.SetActive(false);
            _startMenu.SetActive(false);
            _pauseMenu.SetActive(false);
            _principalMenu.SetActive(false);
        }
    }

    #endregion

    public void OnPauseButton()
    {
        _startMenu.SetActive(true);
    }

    public void OnGoMenuButton()
    {
        _optionMenu.SetActive(false);
        _rulesMenu.SetActive(false);
        _startMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _principalMenu.SetActive(true);
    }
}
