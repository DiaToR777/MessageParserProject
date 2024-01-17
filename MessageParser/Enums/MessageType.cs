using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogEventBuilder.Enums;

public enum MessageType
{
    SuccedLogin,
    FailureLogin,
    ForgettingFeiledLogin,
    BanIp,
    UnBanIp,
    FirewallEntrUpd,
    UpdatingFirewall,
    None
}
