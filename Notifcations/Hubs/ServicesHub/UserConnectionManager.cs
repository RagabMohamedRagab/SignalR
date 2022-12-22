namespace Notifcations.Hubs.ServicesHub {
    public class UserConnectionManager : IUserConnectionManager {
        private static  Dictionary<string,List<string>> userConnectionMap=new Dictionary<string,List<string>>();
        private static string userConnectionMapLocker = string.Empty;
       
        /*
         *   {"UserId",List<string>ConnectionId}
         * 
         */
        // Keep User Connection 
        // If User Connect Add connection Id To user in his connection
        // If user Not Connect Add new Connection.
        public void KeepUserConnection(string userId, string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                if(!userConnectionMap.ContainsKey(userId))
                {
                    userConnectionMap[userId]=new List<string>();
                }
                userConnectionMap[userId].Add(connectionId);
            }
            
        }
        // Specify UserId And remove his connection List
        public void RemoveUserConnection(string connectionId)
        {
            lock (userConnectionMapLocker) {

                foreach (var userId in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userId))
                    {
                        if (userConnectionMap[userId].Contains(connectionId)){
                            userConnectionMap[userId ].Remove(connectionId);
                            break;
                        }
                    }
                }
            
            }
        }
        // Get All ConnectionId For this user by userId
        public List<string> GetUserConnections(string userId)
        {
            var con=new List<string>();
            lock (userConnectionMapLocker)
            {
                con = userConnectionMap[userId];
            }
            return con;
        }
    }
}
