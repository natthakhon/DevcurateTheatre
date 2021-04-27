using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Devcurate
{
    public class Row
    {
        private List<Seat> seats;
        private int rowNo;

        public Row(List<Seat> seats)
        {
            this.seats = seats;
            OrganizeSeat();
        }

        public int RowNo 
        {
            set
            {
                this.rowNo = value;
                foreach(var seat in this.seats)
                {
                    seat.Row = this.rowNo;
                }
            }
            get { return this.rowNo; } 
        }
        
        public Seat Book()
        {
            for(int i = this.MiddleSeatNo; i <= this.seats.Count; i++)
            {
                if (this.seats.FirstOrDefault(p=>p.SeatNo == i && !p.IsSeated) != null)
                {
                    this.seats[i-1].IsSeated = true;
                    return this.seats[i-1];
                }
            }
            for (int i = this.MiddleSeatNo-1; i >=1; i--)
            {
                if (this.seats.FirstOrDefault(p => p.SeatNo == i && !p.IsSeated) != null)
                {
                    this.seats[i-1].IsSeated = true;
                    return this.seats[i-1];
                }
            }
            return null;
        }

        private void OrganizeSeat()
        {
            var queue = new Queue<Seat>(this.seats);
            int i = 1;

            foreach (var q in queue)
            {
                q.SeatNo = i;
                q.IsSeated = false;

                i++;
            }
        }

        public int MiddleSeatNo
        {
            get 
            {
                return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(this.seats.Count) / 2)); 
            }    
        }
    }
}
