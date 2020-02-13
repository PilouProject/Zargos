using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameLoop GameLoop;

    private Transform _spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.GetChild(0);
        //Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
