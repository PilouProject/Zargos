using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public PlayerClass Player1;

    private int _phase;
    private GameObject _renforcements;
    private GameObject _region;
    private GameObject _magicRed;
    private GameObject _magisGreen;

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
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
