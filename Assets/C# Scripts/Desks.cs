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

    public static Desks StringToDesk(string input)
    {
        return DictStringToDesk[input];
    }
    
    public static string DeskToString(Desks input)
    {
        return DictDeskToString[input];
    }




}