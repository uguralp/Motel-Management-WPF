using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model
{
    public class QueenRoom : RoomType
    {
        public QueenRoom()
        {
            this.Rooms = new List<Room>();
        }

        public override void DryCleaning()
        {
            throw new NotImplementedException();
        }

        public override void Fitness()
        {
            throw new NotImplementedException();
        }

        public override void Laundry()
        {
            throw new NotImplementedException();
        }
    }
}
