using System;
using System.Collections.Generic;
using System.Text;

namespace Devcurate
{
    public class Rows
    {
        private List<Row> rows;
        public Rows(List<Row> rows)
        {
            this.rows = rows;
            OrganizeRow();
        }

        public Seat Book()
        {
            for(int i = 1; i <= this.rows.Count; i++)
            {
                var seat = this.rows[i-1].Book();
                if (seat != null)
                {
                    return seat;
                }
            }
            throw new Exception("All seats taken");
        }

        private void OrganizeRow() 
        {
            var queue = new Queue<Row>(this.rows);
            int i = 1;

            foreach (var q in queue)
            {
                q.RowNo = i;

                i++;
            }
        }
    }
}
