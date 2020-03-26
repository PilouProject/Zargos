using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int NbUnitAvailable;
    public Dictionary<string, int> TerritoryOwn;
    public Dictionary<string, List<GameObject>> UnitsInTerritoryOwn;
    public List<string> MagicCard;
    public int NbShips;
    public string Race;
    public bool DrawMagicCard;



    //fonction hilight des regions possédé TerritoryOwn[Name] = 0;

    public void AddMagicCard(string NameCard)
    {
        if (MagicCard.Count < 3)
            MagicCard.Add(NameCard);
        //else le mec se défausse d'une des 3 trois carte en main
    }

    public void EndTurnUnitCount()
    {
        int tmp;

        tmp = 0;
        foreach (var item in TerritoryOwn)
        {
            if (item.Value >= 0)
            {
                string[] tmpString = item.Key.Split("_"[0]);
                if (tmpString[0] == "Zargos" && tmpString.Length <= 1)
                    tmp += 3;
                else if (tmpString[0] == "Zargos")
                    tmp += 7;
                else if (tmpString.Length > 1)
                    tmp += 1;
                else
                    tmp += 2;
            }
        }
        NbUnitAvailable = tmp;
    }

    public int NbTerritoryOwn(bool TypeTerritory)
    {
        int tmp;
        string[] tmpString;

        tmp = 0;
        if (TypeTerritory == true)
        {
            foreach (KeyValuePair<string, int> i in TerritoryOwn)
            {
                tmpString = i.Key.Split("_"[0]);
                if (i.Value >= 0 && tmpString.Length <= 1)
                    tmp += 1;
            }
        }
        else
            foreach (KeyValuePair<string, int> i in TerritoryOwn)
            {
                tmpString = i.Key.Split("_"[0]);
                if (i.Value >= 0 && tmpString.Length > 1)
                    tmp += 1;
            }

        return (tmp);
    }

    public void Init()
    {
        //if le nb je joueur
        DrawMagicCard = false;
        List<GameObject> tmp = new List<GameObject>();
        NbShips = 0;
        MagicCard = new List<string>();
        NbUnitAvailable = 35;
        UnitsInTerritoryOwn = new Dictionary<string, List<GameObject>>();
        TerritoryOwn = new Dictionary<string, int>();
        TerritoryOwn.Add("Ohms", -1);
        TerritoryOwn.Add("Ohms_1", -1);
        TerritoryOwn.Add("Ohms_2", -1);
        TerritoryOwn.Add("Ohms_3", -1);
        TerritoryOwn.Add("Ohms_4", -1);
        TerritoryOwn.Add("Ohms_5", -1);
        TerritoryOwn.Add("Ohms_6", -1);
        TerritoryOwn.Add("Zargos", -1);
        TerritoryOwn.Add("Zargos_1", -1);
        TerritoryOwn.Add("Zargos_2", -1);
        TerritoryOwn.Add("Zargos_3", -1);
        TerritoryOwn.Add("Zargos_4", -1);
        TerritoryOwn.Add("Zargos_5", -1);
        TerritoryOwn.Add("Zargos_6", -1);
        TerritoryOwn.Add("Zargos_7", -1);
        TerritoryOwn.Add("Zargos_8", -1);
        TerritoryOwn.Add("Zargos_9", -1);
        TerritoryOwn.Add("Itak", -1);
        TerritoryOwn.Add("Itak_1", -1);
        TerritoryOwn.Add("Itak_2", -1);
        TerritoryOwn.Add("Akilon", -1);
        TerritoryOwn.Add("Akilon_1", -1);
        TerritoryOwn.Add("Akilon_2", -1);
        TerritoryOwn.Add("Akilon_3", -1);
        TerritoryOwn.Add("Palmyr", -1);
        TerritoryOwn.Add("Palmyr_1", -1);
        TerritoryOwn.Add("Palmyr_2", -1);
        TerritoryOwn.Add("Palmyr_3", -1);
        TerritoryOwn.Add("Palmyr_4", -1);
        TerritoryOwn.Add("Tairo", -1);
        TerritoryOwn.Add("Tairo_1", -1);
        TerritoryOwn.Add("Tairo_2", -1);
        TerritoryOwn.Add("Tairo_3", -1);
        TerritoryOwn.Add("Tairo_4", -1);
        TerritoryOwn.Add("Oz", -1);
        TerritoryOwn.Add("Oz_1", -1);
        TerritoryOwn.Add("Banzol", -1);
        TerritoryOwn.Add("Banzol_1", -1);
        TerritoryOwn.Add("Banzol_2", -1);
        TerritoryOwn.Add("Banzol_3", -1);
        TerritoryOwn.Add("Banzol_4", -1);
        TerritoryOwn.Add("Banzol_5", -1);
        TerritoryOwn.Add("Kori", -1);
        TerritoryOwn.Add("Kori_1", -1);
        TerritoryOwn.Add("Kori_2", -1);
        TerritoryOwn.Add("Kori_3", -1);
        TerritoryOwn.Add("Ludos", -1);
        TerritoryOwn.Add("Ludos_1", -1);
        TerritoryOwn.Add("Ludos_2", -1);
        TerritoryOwn.Add("Ludos_3", -1);
        TerritoryOwn.Add("Ludos_4", -1);
        TerritoryOwn.Add("Kahil", -1);
        TerritoryOwn.Add("Kahil_1", -1);
        TerritoryOwn.Add("Kahil_2", -1);
        TerritoryOwn.Add("Kahil_3", -1);
        TerritoryOwn.Add("Kahil_4", -1);
        TerritoryOwn.Add("Kahil_5", -1);

        UnitsInTerritoryOwn.Add("Ohms", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_5", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ohms_6", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_5", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_6", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_7", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_8", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Zargos_9", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Itak", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Itak_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Itak_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Akilon", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Akilon_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Akilon_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Akilon_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Palmyr", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Palmyr_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Palmyr_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Palmyr_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Palmyr_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Tairo", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Tairo_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Tairo_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Tairo_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Tairo_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Oz", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Oz_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Banzol_5", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kori", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kori_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kori_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kori_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ludos", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ludos_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ludos_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ludos_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Ludos_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil_1", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil_2", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil_3", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil_4", new List<GameObject>());
        UnitsInTerritoryOwn.Add("Kahil_5", new List<GameObject>());


    }

    public void CardTreatmentPhase0(string NameCard)
    {
        if (NameCard == "Renforcement")
        {
            NbUnitAvailable += 3;
        }
        else if (NameCard == "Ship")
        {
            NbShips += 1;
        }
        else
            TerritoryOwn[NameCard] = 0;
    }
}
