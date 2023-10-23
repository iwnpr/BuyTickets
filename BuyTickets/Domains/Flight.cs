using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets.Domains
{
    public class Flight
    {
        public Flight(Cities from, Cities to, DateTime dateAndTime)
        {
            From = from;
            To = to;
            DateAndTime = dateAndTime;
        }
        public Cities From { get; }

        public Cities To { get; }

        public DateTime DateAndTime { get; }
    }
}
