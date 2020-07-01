using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_Videos.Models
{
    class Entity
    {
        public Guid Id;

        // Constructor
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
