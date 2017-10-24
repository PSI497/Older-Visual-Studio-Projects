using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDemo_Server
{
    public class Chatroom
    {
        public List<Client> Clients;
        public string ID;
        public Chatroom(List<Client> clients)
        {
            Clients = clients;
            ID = Guid.NewGuid().ToString();
        }
    }
}
