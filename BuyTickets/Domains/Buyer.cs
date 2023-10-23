using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets.Domains
{
    public class Buyer
    {
        public Buyer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        
        public Guid Id { get; }

        public string Name { get; }


    }
}
