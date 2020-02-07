using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClicked : MonoBehaviour
{
    public GameLoop GameLoop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //gestion d'erreur s'il n'y a plus d'enfant
        Debug.Log(gameObject.name);
        if (gameObject.name == "MagicRed" || gameObject.name == "MagicGreen")
        {
            GameLoop.Player1.AddMagicCard(transform.GetChild(0).name);
        }
        else
        {
            //Debug.Log(transform.GetChild(0).name);
            GameLoop.Player1.CardTreatmentPhase0(transform.GetChild(0).name);
            GameLoop.Player1.EndTurnUnitCount();
        }
        Destroy(transform.GetChild(0).gameObject);
    }
}
