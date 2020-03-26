using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDice : MonoBehaviour
{
    public bool attack_def;
    public int nbDice;

    private GameObject[] _attackDice;
    private GameObject[] _defenseDice;
    private GameObject _spawnPoint;

    private bool _throwingDice;
    private float _time;
    private bool _retry;

    private AudioSource _throwDiceSong;

    // Start is called before the first frame update
    void Start()
    {
        _attackDice = GameObject.FindGameObjectsWithTag("AttackDice");
        _defenseDice = GameObject.FindGameObjectsWithTag("DefenseDice");
        _spawnPoint = GameObject.Find("spawnPoint");
        _throwingDice = false;
        _retry = false;

        _throwDiceSong = GameObject.Find("ThrowDiceSong").GetComponent<AudioSource>();
    }

    private Vector3 Force()
    {
        Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
        return Vector3.Lerp(_spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        //if ton tour de jouer + canva qui dit lancer le des
        RollDice();

        if (_throwingDice == true && Dice.rolling == false)
        {
            _time += Time.deltaTime;

            if (_time > 5f)
            {
                _throwingDice = false;
                if (Dice.AsString("d6").IndexOf("?") == -1)
                    _retry = true;
                Dice.Clear();

                Debug.Log(Dice.AsString("d6"));
                Debug.Log(_retry);
                Debug.Log(Dice.Value("d6"));
            }
        }
    }

    public void RollDice()
    {
        if (Input.GetMouseButtonDown(Dice.MOUSE_RIGHT_BUTTON) && _throwingDice == false)
        {
            _throwDiceSong.PlayDelayed(3f);
            _retry = false;
            _throwingDice = true;
            if (attack_def == true)
            {
                Dice.Roll("1d6", "d6-" + "red", _spawnPoint.transform.position, Force());
                if (nbDice >= 2)
                    Dice.Roll("1d6", "d6-" + "red", _spawnPoint.transform.position, Force());
                if (nbDice >= 3)
                    Dice.Roll("1d6", "d6-" + "red", _spawnPoint.transform.position, Force());
            }
            else
            {
                Dice.Clear();

                Dice.Roll("1d6", "d6-" + "black", _spawnPoint.transform.position, Force());
                if (nbDice >= 2)
                    Dice.Roll("1d6", "d6-" + "black", _spawnPoint.transform.position, Force());
                if (nbDice >= 3)
                    Dice.Roll("1d6", "d6-" + "black", _spawnPoint.transform.position, Force());
            }
        }
    }
}
