using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model
{
    class RoomList
    {
        ObservableCollection<Room> dictRoom;

        public ObservableCollection<Room> DictRoom { get => dictRoom; set => dictRoom = value; }

        public RoomList()
        {
            this.DictRoom = new ObservableCollection<Room>();
        }


    }
}
