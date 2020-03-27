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
    private GameObject _holdCardsRed;
    private GameObject _holdCardsBlue;

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

    private GameObject[] _cleanClones;

    // Start is called before the first frame update
    void Start()
    {
        InitGame = true;

        InitGameLoop();
    }

    public void InitGameLoop()
    {
        Phase = -1;
        Player1 = new PlayerClass();
        Player1.Init();
        if (GameObject.Find("Renforcements") != null)
            _renforcements = GameObject.Find("Renforcements");
        _renforcements.SetActive(true);
        if (GameObject.Find("Regions") != null)
            _regions = GameObject.Find("Regions");
        _regions.SetActive(true);
        if (GameObject.Find("MagicRed") != null)
        {
            _magicRed = GameObject.Find("MagicRed");
            _magicRed.SetActive(false);
        }
        if (GameObject.Find("MagicGreen") != null)
        {
            _magicGreen = GameObject.Find("MagicGreen");
            _magicGreen.SetActive(false);
        }
        if (GameObject.Find("Dices") != null)
        {
            _dices = GameObject.Find("Dices");
            _dices.SetActive(false);
        }

        if (GameObject.Find("HoldCardBlue") != null)
            _holdCardsBlue = GameObject.Find("HoldCardBlue");
        _holdCardsBlue.SetActive(true);
        if (GameObject.Find("HoldCardRed") != null)
            _holdCardsRed = GameObject.Find("HoldCardRed");
        _holdCardsRed.SetActive(false);

        if (GameObject.Find("NumberUnits") != null)
            _numberUnitsHUD = GameObject.Find("NumberUnits").GetComponent<Text>();
        if (GameObject.Find("NumberShips") != null)
            _numberShipsHUD = GameObject.Find("NumberShips").GetComponent<Text>();
        if (GameObject.Find("NumberRegions") != null)
            _numberRegionsHUD = GameObject.Find("NumberRegions").GetComponent<Text>();
        if (GameObject.Find("NumberCapitals") != null)
            _numberCapitalsHUD = GameObject.Find("NumberCapitals").GetComponent<Text>();

        _menuSong = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        _inGameSong = GameObject.Find("InGameSong").GetComponent<AudioSource>();

        Transform tmp = _numberCapitalsHUD.transform.parent;
        tmp.parent.gameObject.SetActive(false);

        if (_magicGreen.transform.childCount > 0)
            _magicGreenCards = GetCards(_magicGreen);
        if (_magicRed.transform.childCount > 0)
            _magicRedCards = GetCards(_magicRed);
        if (_renforcements.transform.childCount > 0)
            _renforcementCards = GetCards(_renforcements);
        if (_regions.transform.childCount > 0)
            _regionCards = GetCards(_regions);
        RepopCards();
        _magicGreenCards = RandomizeCards(_magicGreenCards);
        _magicRedCards = RandomizeCards(_magicRedCards);
        _renforcementCards = RandomizeCards(_renforcementCards);
        _regionCards = RandomizeCards(_regionCards);
    }

    public void RepopCards()
    {
        foreach (GameObject childTmp in _magicRedCards)
        {
            childTmp.SetActive(true);
        }

        foreach (GameObject i in _magicGreenCards)
        {
            i.SetActive(true);
        }

        foreach (GameObject j in _renforcementCards)
        {
            j.SetActive(true);
        }

        foreach (GameObject x in _regionCards)
        {
            x.SetActive(true);
        }
    }

    public void CleanClones()
    {
        
        _cleanClones = GameObject.FindGameObjectsWithTag("Clones");
        foreach (GameObject tmp in _cleanClones)
        {
            Destroy(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if (Phase == 0)
        {
            if (CountChildActive(_regions.transform) == true && CountChildActive(_renforcements.transform) == true)
            {
                Phase = 2;
                GameObject.Find("HoldCamera").GetComponent<MoveCamera>().inGame = true;
                _holdCardsBlue.SetActive(false);
                _holdCardsRed.SetActive(true);
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

    public bool CountChildActive(Transform tmp)
    {
        for (int i = 0; i < tmp.childCount; i++)
        {
            if (tmp.GetChild(i).gameObject.activeSelf == true)
            {
                return (false);
            }
        }
        return (true);
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
