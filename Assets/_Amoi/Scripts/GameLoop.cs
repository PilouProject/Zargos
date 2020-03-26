using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public PlayerClass Player1;

    public int Phase;

    private GameObject _renforcements;
    private GameObject _regions;
    private GameObject _magicRed;
    private GameObject _magicGreen;
    private GameObject _dices;

    private Text _numberUnitsHUD;
    private Text _numberShipsHUD;
    private Text _numberRegionsHUD;
    private Text _numberCapitalsHUD;

    private AudioSource _menuSong;
    private AudioSource _inGameSong;

    private bool InitGame;

    private int i;
    private int _tmpSiblingIndex;
    private Vector3 _tmpPosition;
    private List<GameObject> _children;
    private List<GameObject> _childrenRandomize;
    private List<GameObject> _magicRedCards;
    private List<GameObject> _magicGreenCards;
    private List<GameObject> _renforcementCards;
    private List<GameObject> _regionCards;

    // Start is called before the first frame update
    void Start()
    {
        InitGame = true;

        Phase = -1;
        Player1 = new PlayerClass();
        Player1.Init();
        _renforcements = GameObject.Find("Renforcements");
        _regions = GameObject.Find("Region");
        _magicRed = GameObject.Find("MagicRed");
        _magicRed.SetActive(false);
        _magicGreen = GameObject.Find("MagicGreen");
        _magicGreen.SetActive(false);
        _dices = GameObject.Find("Dices");
        _dices.SetActive(false);

        _numberUnitsHUD = GameObject.Find("NumberUnits").GetComponent<Text>();
        _numberShipsHUD = GameObject.Find("NumberShips").GetComponent<Text>();
        _numberRegionsHUD = GameObject.Find("NumberRegions").GetComponent<Text>();
        _numberCapitalsHUD = GameObject.Find("NumberCapitals").GetComponent<Text>();

        _menuSong = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        _inGameSong = GameObject.Find("InGameSong").GetComponent<AudioSource>();

        Transform tmp = _numberCapitalsHUD.transform.parent;
        tmp.parent.gameObject.SetActive(false);

        _magicGreenCards = GetCards(_magicGreen);
        _magicRedCards = GetCards(_magicRed);
        _renforcementCards = GetCards(_renforcements);
        _regionCards = GetCards(_regions);
        _magicGreenCards = RandomizeCards(_magicGreenCards);
        _magicRedCards = RandomizeCards(_magicRedCards);
        _renforcementCards = RandomizeCards(_renforcementCards);
        _regionCards = RandomizeCards(_regionCards);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if (Phase == 0)
        {
            if (_regions.transform.childCount <= 0 && _renforcements.transform.childCount <= 0)
            {
                Phase = 2;
                GameObject.Find("HoldCamera").GetComponent<MoveCamera>().inGame = true;
                GameObject.Find("HoldCardBlue").SetActive(false);
                _renforcements.SetActive(false);
                _regions.SetActive(false);
                _magicRed.SetActive(true);
                _magicGreen.SetActive(true);
                _dices.SetActive(true);

                _menuSong.Stop();
                _inGameSong.Play();
            }
        }
        else if (Phase == 1)
        {

        }
        else if (Phase == 2)
        {
            if (InitGame == true)
            {
                //next Phase = 1;
            }
        }
    }

    public void UpdateHUD()
    {
        _numberUnitsHUD.text = Player1.NbUnitAvailable.ToString();
        _numberShipsHUD.text = Player1.NbShips.ToString();
        _numberRegionsHUD.text = Player1.NbTerritoryOwn(false).ToString();
        _numberCapitalsHUD.text = Player1.NbTerritoryOwn(true).ToString();
    }

    public List<GameObject> GetCards(GameObject tmp)
    {
        _children = new List<GameObject>();
        foreach (Transform childTmp in tmp.transform)
        {
            _children.Add(childTmp.gameObject);
        }
        return (_children);
    }

    public List<GameObject> RandomizeCards(List<GameObject> tmp)
    {
        _childrenRandomize = new List<GameObject>();
        foreach (GameObject childTmp in tmp)
        {
            i = Random.Range(0, tmp.Count);

            _tmpPosition = tmp[i].transform.localPosition;
            _tmpSiblingIndex = tmp[i].transform.GetSiblingIndex();

            tmp[i].transform.localPosition = childTmp.transform.localPosition;
            tmp[i].transform.SetSiblingIndex(childTmp.transform.GetSiblingIndex());

            childTmp.transform.localPosition = _tmpPosition;
            childTmp.transform.SetSiblingIndex(_tmpSiblingIndex);

            _childrenRandomize.Add(childTmp.gameObject);
        }
        return (_children);
    }
}
