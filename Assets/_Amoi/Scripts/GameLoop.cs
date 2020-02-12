using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public PlayerClass Player1;

    private int _phase;
    private GameObject _renforcements;
    private GameObject _region;
    private GameObject _magicRed;
    private GameObject _magisGreen;

    private Text _numberUnitsHUD;
    private Text _numberShipsHUD;
    private Text _numberRegionsHUD;
    private Text _numberCapitalsHUD;

    // Start is called before the first frame update
    void Start()
    {
        _phase = 0;
        Player1 = new PlayerClass();
        Player1.Init();
        _renforcements = GameObject.Find("Renforcements");
        _region = GameObject.Find("Region");
        _magicRed = GameObject.Find("MagicRed");
        _magicRed.SetActive(false);
        _magisGreen = GameObject.Find("MagicGreen");
        _magisGreen.SetActive(false);

        _numberUnitsHUD = GameObject.Find("NumberUnits").GetComponent<Text>();
        _numberShipsHUD = GameObject.Find("NumberShips").GetComponent<Text>();
        _numberRegionsHUD = GameObject.Find("NumberRegions").GetComponent<Text>();
        _numberCapitalsHUD = GameObject.Find("NumberCapitals").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if (_phase == 0)
        {
            if (_region.transform.childCount <= 0 && _renforcements.transform.childCount <= 0)
            {
                _phase = 1;
                GameObject.Find("HoldCamera").GetComponent<MoveCamera>().inGame = true;
                GameObject.Find("HoldCardBlue").SetActive(false);
                _renforcements.SetActive(false);
                _region.SetActive(false);
                _magicRed.SetActive(true);
                _magisGreen.SetActive(true);
            }
        }
        else if (_phase == 1)
        {

        }
        else if (_phase == 2)
        {

        }
    }

    public void UpdateHUD()
    {
        Debug.Log(Player1.NbUnitAvailable);
        _numberUnitsHUD.text = Player1.NbUnitAvailable.ToString();
        _numberShipsHUD.text = Player1.NbShips.ToString();
        _numberRegionsHUD.text = Player1.NbTerritoryOwn(false).ToString();
        _numberCapitalsHUD.text = Player1.NbTerritoryOwn(true).ToString();
    }
}
