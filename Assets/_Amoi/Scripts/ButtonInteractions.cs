using System;
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
    public Sprite Amazon;
    public Sprite Knight;
    public Sprite Ailé;
    public Sprite Spider;
    public Sprite Monk;
    public Sprite Dragon;


    private GameObject _optionMenu;
    private GameObject _rulesMenu;
    private GameObject _principalMenu;
    private GameObject _startMenu;
    private GameObject _pauseMenu;
    private GameObject _newgameMenu;
    private GameObject _inGameHUD;

    private GameObject _InGameUiOnMouse;
    private Text _InGameUiOnMousePlayerName;
    private Image _InGameUiOnMouseRace;
    private Text _InGameUiOnMouseUnitsNumber;
    private PlayerClass _tmp;

    private GameObject _lowButton;
    private GameObject _mediumButton;
    private GameObject _highButton;
    private GameObject _ultraButton;
    private GameObject _ZQSDButton;
    private GameObject _cursorButton;

    private int _indexRaces;
    private List<GameObject[]> _races;
    private List<GameObject> _racesUI;
    private GameObject[] _AIPlayers;

    private MoveCamera _moveCamera;

    private bool _checkNbAIPlayers;
    private bool _checkRace;

    private AudioSource _buttonSong;

    private bool _pause;

    private AudioSource _menuSong;
    private AudioSource _inGameSong;
    private GameObject _scrollBarSong;

    private void Start()
    {
        _menuSong = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        _inGameSong = GameObject.Find("InGameSong").GetComponent<AudioSource>();
        _scrollBarSong = GameObject.Find("ScrollbarSong");

        _optionMenu = GameObject.Find("OptionMenu");
        _rulesMenu = GameObject.Find("RulesMenu");
        _principalMenu = GameObject.Find("PrincipalMenu");
        _startMenu = GameObject.Find("StartMenu");
        _pauseMenu = GameObject.Find("PauseMenu");
        _newgameMenu = GameObject.Find("NewGameMenu");
        _inGameHUD = GameObject.Find("InGameHUD");

        _InGameUiOnMouse = GameObject.Find("InGameUiOnMouse");
        _InGameUiOnMousePlayerName = GameObject.Find("InGameUiOnMousePlayerName").GetComponent<Text>();
        _InGameUiOnMouseRace = GameObject.Find("InGameUiOnMouseRace").GetComponent<Image>();
        _InGameUiOnMouseUnitsNumber = GameObject.Find("InGameUiOnMouseUnitsNumber").GetComponent<Text>();

        _lowButton = GameObject.Find("LowButton");
        _mediumButton = GameObject.Find("MediumButton");
        _highButton = GameObject.Find("HighButton");
        _ultraButton = GameObject.Find("UltraButton");
        _ZQSDButton = GameObject.Find("ZqsdCommand");
        _cursorButton = GameObject.Find("CursorCommand");

        _races = new List<GameObject[]>();
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ1"));
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ2"));
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ3"));
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ4"));
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ5"));
        _races.Add(GameObject.FindGameObjectsWithTag("RacesJ6"));
        _racesUI = new List<GameObject>();
        _racesUI.Add(GameObject.Find("J1Races"));
        _racesUI.Add(GameObject.Find("J2Races"));
        _racesUI[1].SetActive(false);
        _racesUI.Add(GameObject.Find("J3Races"));
        _racesUI[2].SetActive(false);
        _racesUI.Add(GameObject.Find("J4Races"));
        _racesUI[3].SetActive(false);
        _racesUI.Add(GameObject.Find("J5Races"));
        _racesUI[4].SetActive(false);
        _racesUI.Add(GameObject.Find("J6Races"));
        _racesUI[5].SetActive(false);
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
        SoundMangement();

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
                    if (_optionMenu.activeSelf == true || _rulesMenu.activeSelf == true)
                    {
                        _optionMenu.SetActive(false);
                        _rulesMenu.SetActive(false);
                    }
                    else
                    {
                        OnKeyClosePauseMenuButton();
                        _pause = false;
                    }
                }
            }

            if (GameLoop.Phase >= 2)
            {
                if (Input.GetKeyDown("n"))
                    GameLoop.NextPlayer();
            }
        }
        else
            CheckRace();
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
            _InGameUiOnMouse.SetActive(false);
            GameLoop.Phase = 0;
            GameLoop.NextPlayer();
            GameLoop.InitPowerRaces();
        }
    }

    public void OnNextPlayerRaces()
    {
        _indexRaces++;
        if (_indexRaces > 5)
            _indexRaces = 0;

        if (_indexRaces == 0)
        {
            _racesUI[0].SetActive(true);
            _racesUI[5].SetActive(false);
        }
        else if (_indexRaces == 1)
        {
            _racesUI[1].SetActive(true);
            _racesUI[0].SetActive(false);
        }
        else if (_indexRaces == 2)
        {
            _racesUI[2].SetActive(true);
            _racesUI[1].SetActive(false);
        }
        else if (_indexRaces == 3)
        {
            _racesUI[3].SetActive(true);
            _racesUI[2].SetActive(false);
        }
        else if (_indexRaces == 4)
        {
            _racesUI[4].SetActive(true);
            _racesUI[3].SetActive(false);
        }
        else if (_indexRaces == 5)
        {
            _racesUI[5].SetActive(true);
            _racesUI[4].SetActive(false);
        }
    }

    public void OnPreviusPlayerRaces()
    {
        _indexRaces--;
        if (_indexRaces < 0)
            _indexRaces = 5;

        if (_indexRaces == 0)
        {
            _racesUI[0].SetActive(true);
            _racesUI[1].SetActive(false);
        }
        else if (_indexRaces == 1)
        {
            _racesUI[1].SetActive(true);
            _racesUI[2].SetActive(false);
        }
        else if (_indexRaces == 2)
        {
            _racesUI[2].SetActive(true);
            _racesUI[3].SetActive(false);
        }
        else if (_indexRaces == 3)
        {
            _racesUI[3].SetActive(true);
            _racesUI[4].SetActive(false);
        }
        else if (_indexRaces == 4)
        {
            _racesUI[4].SetActive(true);
            _racesUI[5].SetActive(false);
        }
        else if (_indexRaces == 5)
        {
            _racesUI[5].SetActive(true);
            _racesUI[0].SetActive(false);
        }
    }

    public void OnChooseRacesButton()
    {
        if (EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable == true)
        {
            for (int i = 0; i < _races[_indexRaces].Length; i++)
            {
                _races[_indexRaces][i].GetComponent<Button>().interactable = true;
            }
            EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable = false;

            for (int i = 0; i < _races[_indexRaces].Length; i++)
            {
                if (_races[_indexRaces][i].GetComponent<Button>().interactable == false)
                {
                    GameLoop.Players[_indexRaces].Race = _races[_indexRaces][i].name;
                    Debug.Log(GameLoop.Players[_indexRaces].Race);
                }
            }
        }
    }

    public void CheckRace()
    {
        foreach (PlayerClass tmp in GameLoop.Players)
        {
            if (tmp.Race != "None")
            {
                _checkRace = true;
                break;
            }
            else
                _checkRace = false;
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
        _pause = false;
    }

    public void OnRestartButton()
    {
        //Reset Scene
        GameLoop.CleanClones();
        GameLoop.InitGameLoop();
        _moveCamera.ResetCameraPosition();

        _checkRace = false;
        _newgameMenu.SetActive(true);
        _startMenu.SetActive(true);
        _pauseMenu.SetActive(false);
        _pause = false;
        _inGameSong.Stop();
        _menuSong.Play();
        Dice.Clear();
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
    }

    public void OnGoMenuButtonReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnButtonSong()
    {
        _buttonSong.Play();
    }

    public void SoundMangement()
    {
        _menuSong.volume = _scrollBarSong.GetComponent<Scrollbar>().value;
        _inGameSong.volume = _scrollBarSong.GetComponent<Scrollbar>().value;
        _scrollBarSong.transform.GetChild(0).gameObject.GetComponent<Text>().text = _menuSong.volume.ToString("N");
    }

    public void InGameOnMouseInfoOn(string tmp)
    {
        _tmp = GameLoop.GetPlayerWithRegionName(tmp);
        if (_tmp != null)
        {
            _InGameUiOnMouse.SetActive(true);
            _InGameUiOnMousePlayerName.text = _tmp.Name;
            _InGameUiOnMousePlayerName.color = _tmp.ColorName;
            _InGameUiOnMouseUnitsNumber.text = _tmp.TerritoryOwn[tmp].ToString();
            if (Ailé.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Ailé;
            else if (Knight.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Knight;
            else if (Spider.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Spider;
            else if (Monk.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Monk;
            else if (Amazon.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Amazon;
            else if (Dragon.name == _tmp.Race)
                _InGameUiOnMouseRace.sprite = Dragon;
        }
    }

    public void InGameOnMouseInfoOff()
    {
        _InGameUiOnMouse.SetActive(false);
    }
}
