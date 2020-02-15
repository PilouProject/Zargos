using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameLoop GameLoop;

    private Transform _spawnPoint;

    private GameObject _ownGroundHighlight;
    private Renderer _rendererHighlight;
    private Color _colorStart;
    private Color _colorEnd;
    private float t;


    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.GetChild(0);

        //_ownGroundHighlight = transform.GetChild(1).gameObject;
        _ownGroundHighlight = GameObject.Find("Ground");
        _rendererHighlight = _ownGroundHighlight.GetComponent<Renderer>();
        //ColorUtility.TryParseHtmlString("#55FF70", out _colorStart);
        //ColorUtility.TryParseHtmlString("#30A242", out _colorEnd);
        //_colorStart = new Color(48, 161, 65);
        //_colorEnd = new Color(85, 255, 112);
        _colorStart = new Color(0, 0, 0);
        _colorEnd = new Color(255, 255, 255);

        //Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Color.Lerp(_colorStart, _colorEnd, t));
        //_rendererHighlight.material.SetColor("_LineColor", Color.Lerp(_colorStart, _colorEnd, Mathf.PingPong(Time.time, 1)));
        _rendererHighlight.material.color = Color.Lerp(_colorStart, _colorEnd, t);
        if (t < 1)
        {
            t += Time.deltaTime / 5;
        }
        else
            t = 0;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GameLoop.Player1.TerritoryOwn[name] > 1 && (GameLoop.Phase == 0 || GameLoop.Phase == 2))
            {
                GameLoop.Player1.NbUnitAvailable += 1;
                Destroy(GameLoop.Player1.UnitsInTerritoryOwn[name][GameLoop.Player1.UnitsInTerritoryOwn[name].Count - 1]);
                GameLoop.Player1.UnitsInTerritoryOwn[name].RemoveAt(GameLoop.Player1.UnitsInTerritoryOwn[name].Count - 1);
                GameLoop.Player1.TerritoryOwn[name] -= 1;
                //Debug.Log(name);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (GameLoop.Player1.TerritoryOwn[name] >= 0 && GameLoop.Player1.NbUnitAvailable > 0 && (GameLoop.Phase == 0 || GameLoop.Phase == 2))
            {
                GameLoop.Player1.NbUnitAvailable -= 1;
                GameObject tmp = Instantiate(GameObject.Find(GameLoop.Player1.Race + "Units"), _spawnPoint.position, _spawnPoint.rotation);
                GameLoop.Player1.UnitsInTerritoryOwn[name].Add(tmp);
                GameLoop.Player1.TerritoryOwn[name] += 1;
                Debug.Log(GameLoop.Player1.UnitsInTerritoryOwn[name].Count + ".." + GameLoop.Player1.TerritoryOwn[name] + ".." + name);
            }
        }
    }
}
