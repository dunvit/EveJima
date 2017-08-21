using System;
using Server.Tools;

namespace Server.BLL
{
    public static class MapEventsAPI
    {
        public static string AddSolarSystemEnter(string MapKey, string PilotName, string SystemFrom, string SystemTo)
        {
            try
            {
                /*
                 * 
                    TABLE [dbo].[StarSystemEnters]
                    (
	                    [EnterId] [int] IDENTITY(1,1) NOT NULL,
	                    [MapKey] [varchar](50) NULL,
	                    [PilotName] [varchar](50) NULL,
	                    [SystemFrom] [varchar](50) NULL,
	                    [SystemTo] [varchar](50) NULL,
	                    [EnterDate] [datetime2](7) NOT NULL
                    )
                 * 
                 */
                var sql = "INSERT INTO StarSystemEnters ( MapKey, PilotName, SystemFrom, SystemTo, EnterDate) VALUES ('"
                    + MapKey + "','" + PilotName + "','" + SystemFrom + "','" + SystemTo + "', SYSDATETIME())";
                SqlComm.SqlExecute(sql);

                return "Solar System success added to global list.";
            }
            catch (Exception)
            {
                return "Error in adding Solar System to global list.";
            }



        }
    }
}