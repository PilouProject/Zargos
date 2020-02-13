using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public PlayerClass Player1;

    public int Phase;

    private GameObject _renforcements;
    private GameObject _region;
    private GameObject _magicRed;
    private GameObject _magisGreen;
    private GameObject _dices;

    private Text _numberUnitsHUD;
    private Text _numberShipsHUD;
    private Text _numberRegionsHUD;
    private Text _numberCapitalsHUD;

    private bool InitGame;

    // Start is called before the first frame update
    void Start()
    {
        InitGame = true;

        Phase = 0;
        Player1 = new PlayerClass();
        Player1.Init();
        _renforcements = GameObject.Find("Renforcements");
        _region = GameObject.Find("Region");
        _magicRed = GameObject.Find("MagicRed");
        _magicRed.SetActive(false);
        _magisGreen = GameObject.Find("MagicGreen");
        _magisGreen.SetActive(false);
        _dices = GameObject.Find("Dices");
        _dices.SetActive(false);

        _numberUnitsHUD = GameObject.Find("NumberUnits").GetComponent<Text>();
        _numberShipsHUD = GameObject.Find("NumberShips").GetComponent<Text>();
        _numberRegionsHUD = GameObject.Find("NumberRegions").GetComponent<Text>();
        _numberCapitalsHUD = GameObject.Find("NumberCapitals").GetComponent<Text>();
        

        Transform tmp = _numberCapitalsHUD.transform.parent;
        tmp.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if (Phase == 0)
        {
            if (_region.transform.childCount <= 0 && _renforcements.transform.childCount <= 0)
            {
                Phase = 2;
                GameObject.Find("HoldCamera").GetComponent<MoveCamera>().inGame = true;
                GameObject.Find("HoldCardBlue").SetActive(false);
                _renforcements.SetActive(false);
                _region.SetActive(false);
                _magicRed.SetActive(true);
                _magisGreen.SetActive(true);
                _dices.SetActive(true);
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

}
