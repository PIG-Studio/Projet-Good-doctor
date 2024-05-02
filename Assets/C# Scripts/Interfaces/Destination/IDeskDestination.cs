using System.Collections.Generic;
using Desks;
using Interfaces.Entites;
using UnityEngine;

namespace Interfaces.Destination
{
    public interface IDeskDestination : IDestination
    {
        public Desk Bureau { get; }
        
        public Queue<ICanGoInDesk> DeskQueue { get; set; }

        public uint Add(ICanGoInDesk patient);
        public ICanGoInDesk Pop();

    }
}