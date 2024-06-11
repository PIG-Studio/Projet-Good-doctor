using System;

namespace Super.Interfaces.GameObjects
{
    public interface IConditionAffichage
    {
        Func<bool> ConditionAffichage { get; } 
    }
}