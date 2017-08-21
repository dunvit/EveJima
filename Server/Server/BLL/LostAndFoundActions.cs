using System;
using System.Collections.Generic;
using System.Data;
using Server.Tools;

namespace Server.BLL
{
    public static class LostAndFoundActions
    {
        public static List<LostSolarSystem> List()
        {
            var result = new List<LostSolarSystem>();

            var sql = "SELECT PublisherName, WormholeName, Reward, LoginDate FROM LostAndFoundWormholes ORDER BY LoginDate DESC";

            var data = SqlComm.SqlDataTable(sql);

            foreach (DataRow row in data.Rows)
            {
                result.Add(new LostSolarSystem
                {
                    Publisher = row["PublisherName"].ToString(),
                    Reward = row["Reward"].ToString(),
                    Name = row["WormholeName"].ToString(),
                    Date = row["LoginDate"] is DateTime ? (DateTime)row["LoginDate"] : new DateTime()
                });
            }

            return result;
        }

        public static string Add(string action, string publisher, string wormholeName, string reward)
        {
            try
            {
                var sql = "INSERT INTO LostAndFoundWormholes ( WormholeName, PublisherName, Reward, LoginDate) VALUES ('" + wormholeName + "','" + publisher + "','" + reward + "', SYSDATETIME())";
                SqlComm.SqlExecute(sql);

                return "Wormhole success added to global search list.";
            }
            catch (Exception)
            {
                return "Error in adding wormhole to global search list.";
            }
            

            
        }

        public static string Delete(string action, string publisher, string wormholeName)
        {
            try
            {
                var sql = "DELETE LostAndFoundWormholes WHERE WormholeName = '" + wormholeName + "' AND PublisherName = '" + publisher + "'";
                SqlComm.SqlExecute(sql);

                return "Wormhole success deleted from global search list.";
            }
            catch (Exception)
            {
                return "Error in deleting wormhole from global search list.";
            }
        }
    }
}