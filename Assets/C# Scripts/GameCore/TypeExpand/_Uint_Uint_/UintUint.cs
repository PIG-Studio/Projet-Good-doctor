using UnityEngine;

namespace GameCore.TypeExpand._Uint_Uint_
{
    public static class UintUint
    {
        public static uint RandomUint(this (uint,uint) input)
        {
            // retour une uint random entre les deux uint
            return (uint)Random.Range(input.Item1, input.Item2);
        }
    }
}