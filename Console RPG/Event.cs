using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Event
    {
        public bool isResolved;

        public Event(bool isResolved)
        {
            this.isResolved = isResolved;
        }

        public abstract void Resolve(List<Player> players);
    }
}
