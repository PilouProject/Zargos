using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClicked : MonoBehaviour
{
    public GameLoop GameLoop;

    private AudioSource _drawCardSong;

    // Start is called before the first frame update
    void Start()
    {
        _drawCardSong = GameObject.Find("DrawCardSong").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (transform.childCount != 0 && GameLoop.Phase >= 0)
        {
            if (gameObject.name == "MagicRed" || gameObject.name == "MagicGreen")
            {
                if (GameLoop.Player1.DrawMagicCard == true)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        if (transform.GetChild(i).gameObject.activeSelf == true)
                        {
                            Debug.Log(transform.GetChild(i));
                            GameLoop.Player1.AddMagicCard(transform.GetChild(i).name);
                            transform.GetChild(i).gameObject.SetActive(false);
                            _drawCardSong.Play();
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).gameObject.activeSelf == true)
                    {
                        Debug.Log(transform.GetChild(i));
                        GameLoop.Player1.CardTreatmentPhase0(transform.GetChild(i).name);
                        transform.GetChild(i).gameObject.SetActive(false);
                        _drawCardSong.Play();
                        break;
                    }
                }
            }
        }
    }
}
