using UnityEngine;

namespace TypeExpand._Uint_Uint_
{
    public static class EUintUint
    {
        public static uint RandomUint(this (uint,uint) input)
        {
            // retour une uint random entre les deux uint
            return (uint)Random.Range(input.Item1, input.Item2);
        }
    }
}