using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public PlayerClass Player1; 

    // Start is called before the first frame update
    void Start()
    {
        Player1 = new PlayerClass();
        Player1.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player1.NbUnitAvailable);
    }
}
