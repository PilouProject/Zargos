using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int NbUnitAvailable;
    public Dictionary<string, int> TerritoryOwn;
    public List<string> MagicCard;
    public int NbCapital;
    public int NbBoat;

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
                if (tmpString[0] == "Zargos" && tmpString.Length > 1)
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

    public int NbTerritoryOwn()
    {
        int tmp;

        tmp = 0;
        foreach (int i in TerritoryOwn.Values)
        {
            if (i >= 0)
                tmp += 1;
        }

        return (tmp);
    }

    public void Init()
    {
        //if le nb je joueur
        MagicCard = new List<string>();
        NbUnitAvailable = 0;
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
        TerritoryOwn.Add("Akilon_1", -1);
        TerritoryOwn.Add("Akilon_2", -1);
        TerritoryOwn.Add("Akilon_3", -1);
        TerritoryOwn.Add("Akilon_4", -1);
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


    }

    public void CardTreatmentPhase0(string NameCard)
    {
        if (NameCard == "Renforcement")
        {
            NbUnitAvailable += 3;
        }
        else if (NameCard == "Ship")
        {
            NbBoat += 1;
        }
        else
            TerritoryOwn[NameCard] = 0;
    }
}
