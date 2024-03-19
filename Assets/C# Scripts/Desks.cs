using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Desks 
{
    BaseDesk = 0,
    ChirDesk = 1
}

public static class DesksConvert
{
    private static Desks value { get; set; }
    private static Dictionary<string, Desks> DictStringToDesk { get; set; } =
        new Dictionary<string, Desks>()
        {
            { "DESK_Base", Desks.BaseDesk },
            { "DESK_Chirurgien", Desks.ChirDesk }
        };

    private static Dictionary<Desks, string> DictDeskToString { get; set; } =
        new Dictionary<Desks, string>()
        {
            { Desks.BaseDesk, "DESK_Base" },
            { Desks.ChirDesk, "DESK_Chirurgien" }
        };
    
    public static bool ValidString(string input)
    {
        if (input == null)
        {
            return false;
        }
        return DictStringToDesk.ContainsKey(input);
    }

    public static Desks ToDesk(string input)
    {
        var retour = DictStringToDesk[input];
        Debug.Log("Desk.ToDesk : " + retour);
        return retour;
    }
    
    public new static string ToString(Desks desk)
    {
        return DictDeskToString[desk];
    }

}   