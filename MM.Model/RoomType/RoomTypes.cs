using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.Model
{
    public class RoomTypes : IDisposable
    {
        private List<RoomType> listRoomTypes;

        public List<RoomType> ListRoomTypes { get => listRoomTypes; set => listRoomTypes = value; }

        public RoomTypes()
        {
            this.ListRoomTypes = new List<RoomType>();
        }

        public void Add(RoomType clientToAdd)
        {
            this.listRoomTypes.Add(clientToAdd);
        }

        public int Count()
        {
            return this.listRoomTypes.Count();
        }

        public RoomType this[int index]
        {
            get { return this.ListRoomTypes[index]; }
            set { this.ListRoomTypes[index] = value; }
        }

        public void Clear()
        {
            this.ListRoomTypes.Clear();
        }

        public void Sort()
        {
            listRoomTypes.Sort();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
