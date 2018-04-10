using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model
{
    public class RoomTypes : IDisposable
    {
        private List<RoomType> listRoomTypes;
        //private int intKey = 0;

        public List<RoomType> ListRoomTypes { get => listRoomTypes; set => listRoomTypes = value; }

        public RoomTypes()
        {
            this.ListRoomTypes = new List<RoomType>();
        }

        public void Add(RoomType clientToAdd)
        {
            this.ListRoomTypes.Add(clientToAdd);
            //intKey++;
        }

        public int Count()
        {
            return this.ListRoomTypes.Count();
        }

        public RoomType this[int index]
        {
            get { return this.ListRoomTypes[index]; }
            set { this.ListRoomTypes[index] = value; }
        }

        public void Clear()
        {
            this.ListRoomTypes.Clear();
            //intKey = 0;
        }

        public void Sort()
        {
            //List<RoomType> sortedList = DictRoomTypes.Values.ToList();
            //sortedList.Sort();
            //int i = 0;
            //foreach (var key in this.DictRoomTypes.Keys.ToList())
            //{
            //    this.DictRoomTypes[key] = sortedList[i];
            //    i++;
            //}

            listRoomTypes.Sort();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
