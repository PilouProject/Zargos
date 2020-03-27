﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonInteractions : MonoBehaviour
{
    public Sprite Box;
    public Sprite CheckBox;
    public GameLoop GameLoop;

    private GameObject _optionMenu;
    private GameObject _rulesMenu;
    private GameObject _principalMenu;
    private GameObject _startMenu;
    private GameObject _pauseMenu;
    private GameObject _newgameMenu;
    private GameObject _inGameHUD;

    private GameObject _lowButton;
    private GameObject _mediumButton;
    private GameObject _highButton;
    private GameObject _ultraButton;
    private GameObject _ZQSDButton;
    private GameObject _cursorButton;

    private GameObject[] _races;
    private GameObject[] _AIPlayers;

    private MoveCamera _moveCamera;

    private bool _checkNbAIPlayers;
    private bool _checkRace;

    private AudioSource _buttonSong;

    private bool _pause;

    private void Start()
    {
        _optionMenu = GameObject.Find("OptionMenu");
        _rulesMenu = GameObject.Find("RulesMenu");
        _principalMenu = GameObject.Find("PrincipalMenu");
        _startMenu = GameObject.Find("StartMenu");
        _pauseMenu = GameObject.Find("PauseMenu");
        _newgameMenu = GameObject.Find("NewGameMenu");
        _inGameHUD = GameObject.Find("InGameHUD");

        _lowButton = GameObject.Find("LowButton");
        _mediumButton = GameObject.Find("MediumButton");
        _highButton = GameObject.Find("HighButton");
        _ultraButton = GameObject.Find("UltraButton");
        _ZQSDButton = GameObject.Find("ZqsdCommand");
        _cursorButton = GameObject.Find("CursorCommand");

        _races = GameObject.FindGameObjectsWithTag("Races");
        _AIPlayers = GameObject.FindGameObjectsWithTag("NbAiPlayers");

        _moveCamera = GameObject.Find("HoldCamera").GetComponent<MoveCamera>();

        _buttonSong = GameObject.Find("ButtonSong").GetComponent<AudioSource>();

        _optionMenu.SetActive(false);
        _rulesMenu.SetActive(false);
        _startMenu.SetActive(false);
        _pauseMenu.SetActive(false);

        _checkRace = false;
        _checkNbAIPlayers = false;

        _pause = false;
    }

    private void Update()
    {
        if (GameLoop.Phase >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_pause == false)
                {
                    OnKeyOpenPauseMenuButton();
                    _pause = true;
                }
                else
                {
                    OnKeyClosePauseMenuButton();
                    _pause = false;
                }
            }
        }
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

    public void OnCreateGameButton()
    {
        if (_checkNbAIPlayers == true && _checkRace == true)
        {
            _optionMenu.SetActive(false);
            _rulesMenu.SetActive(false);
            _startMenu.SetActive(false);
            _pauseMenu.SetActive(false);
            _principalMenu.SetActive(false);
            _inGameHUD.SetActive(true);
            GameLoop.Phase = 0;
        }
    }

    public void OnChooseRacesButton()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable == true)
        {
            for (int i = 0; i < _races.Length; i++)
            {
                _races[i].GetComponent<Button>().interactable = true;
            }
            EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable = false;

            for (int i = 0; i < _races.Length; i++)
            {
                if (_races[i].GetComponent<Button>().interactable == false)
                {
                    GameLoop.Player1.Race = _races[i].name;
                    Debug.Log(GameLoop.Player1.Race);
                }
            }
            _checkRace = true;
        }
    }

    public void OnNbAiPlayersButton()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable == true)
        {
            for (int i = 0; i < _AIPlayers.Length; i++)
            {
                _AIPlayers[i].GetComponent<Button>().interactable = true;
            }
            EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable = false;

            for (int i = 0; i < _AIPlayers.Length; i++)
            {
                if (_AIPlayers[i].GetComponent<Button>().interactable == false)
                {
                    string numbersOnly = Regex.Replace(_AIPlayers[i].name, "[^0-9]", "");
                    int nbAiPlayer = Convert.ToInt32(numbersOnly);
                    Debug.Log(nbAiPlayer);
                }
            }
            _checkNbAIPlayers = true;
        }
    }



    #endregion

    #region PAUSE

    public void OnKeyOpenPauseMenuButton()
    {
        _pauseMenu.SetActive(true);
        _inGameHUD.SetActive(false);
    }

    public void OnKeyClosePauseMenuButton()
    {
        _pauseMenu.SetActive(false);
        _inGameHUD.SetActive(true);
    }

    public void OnRestartButton()
    {
        //Reset Scene
        GameLoop.CleanClones();
        GameLoop.InitGameLoop();

        _newgameMenu.SetActive(true);
        _startMenu.SetActive(true);
        _pauseMenu.SetActive(false);
        _pause = false;
    }

    #endregion

    public void OnGoMenuButton()
    {
        _optionMenu.SetActive(false);
        _rulesMenu.SetActive(false);
        _startMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _principalMenu.SetActive(true);
        _moveCamera.inGame = false;
        _pause = false;

        //Reload Scene !!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnButtonSong()
    {
        _buttonSong.Play();
    }
}
