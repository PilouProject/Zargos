using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameLoop GameLoop;

    private Transform _spawnPoint;

    private GameObject _ownGroundHighlight;
    private Renderer _ground;
    private Renderer _rendererHighlight;
    private Color _colorStart;
    private Color _colorEnd;
    private float t;
    private float h, s, v;
    private bool _onMouseOver;



    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.GetChild(0);

        _onMouseOver = false;
        t = 2.0f;
        _ground = transform.GetChild(2).GetComponent<Renderer>();
        _ownGroundHighlight = transform.GetChild(1).gameObject;
        _rendererHighlight = _ownGroundHighlight.GetComponent<Renderer>();
        _colorStart = new Color32(48, 161, 65, 0);
        _colorEnd = new Color32(85, 255, 112, 0);

        _ownGroundHighlight.SetActive(false);

        //Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLoop.Player1.TerritoryOwn[name] >= 0)
            _ownGroundHighlight.SetActive(true);
        _rendererHighlight.material.SetColor("_LineColor", Color.Lerp(_colorStart, _colorEnd, Mathf.PingPong(Time.time, t) / t));

    }

    private void OnMouseOver()
    {
        if (_onMouseOver == false)
        {
            Color.RGBToHSV(_ground.material.color, out float h, out float s, out float v);
            s -= 0.4f;
            if (s < 0)
                s = 0;
            _ground.material.color = Color.HSVToRGB(h, s, v);
            _onMouseOver = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (GameLoop.Player1.TerritoryOwn[name] > 1)// && (GameLoop.Phase == 0 || GameLoop.Phase == 2))
            {
                GameLoop.Player1.NbUnitAvailable += 1;
                Destroy(GameLoop.Player1.UnitsInTerritoryOwn[name][GameLoop.Player1.UnitsInTerritoryOwn[name].Count - 1]);
                GameLoop.Player1.UnitsInTerritoryOwn[name].RemoveAt(GameLoop.Player1.UnitsInTerritoryOwn[name].Count - 1);
                GameLoop.Player1.TerritoryOwn[name] -= 1;
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
            }
        }
    }

    private void OnMouseExit()
    {
        if (_onMouseOver == true)
        {
            Color.RGBToHSV(_ground.material.color, out float h, out float s, out float v);
            s += 0.4f;
            _ground.material.color = Color.HSVToRGB(h, s, v);
            _onMouseOver = false;
        }
    }
}
