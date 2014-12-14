using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baravord.DAL;
using Baravord.OBJECTS;

namespace Baravord.BLL
{
    class ChannelBll
    {
        public List<ChannelObj> Select_All_Channel()
        {
            ChannelDAl Ch_Dal = new ChannelDAl();
            List<ChannelObj> Ch_Lst = Ch_Dal.Select_All_Channels();
            return Ch_Lst;
        }
        public static ChannelObj Select_Current_Channel(int ChannelId)
        {
             ChannelDAl Ch_Dal = new ChannelDAl();
             return Ch_Dal.Select_Current_Channel(ChannelId);
        }
        public static bool UPDATE_CURRENT_CHANNEL(ChannelObj Chn)
        {
             ChannelDAl Ch_Dal = new ChannelDAl();
             return Ch_Dal.UPDATE_CURRENT_CHANNEL(Chn);
        }
        public static bool INSERT_CHANNEL(ChannelObj Chn)
        {
              ChannelDAl Ch_Dal = new ChannelDAl();
              return Ch_Dal.INSERT_CHANNEL(Chn);
        }
    }
}
