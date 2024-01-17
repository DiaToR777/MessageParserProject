using LogEventBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.MessageParser;

public class MessageParser
{
    public string MainMessageParser(string logMessage)
    {
        string message_;

        switch (EnumParser(logMessage))
        {
            case MessageType.SuccedLogin:
                message_ = SuccedLoginParser(logMessage);
                break;

            case MessageType.FailureLogin:
                message_ = FailureLoginParser(logMessage);
                break;

            case MessageType.ForgettingFeiledLogin:
                message_ = ForgetFeiledLoginParser(logMessage);
                break;

            case MessageType.BanIp:
                message_ = BanIPParser(logMessage);
                break;

            case MessageType.UnBanIp:
                message_ = UnBanIPParser(logMessage);
                break;

            case MessageType.FirewallEntrUpd:
                message_ = FirewalEntrlUpdateParser(logMessage);
                break;

            case MessageType.UpdatingFirewall:
                message_ = FirewallUpdatedParser(logMessage);
                break;

            default:
                message_ = "N/a";
                break;
        }
        return message_;
    }

    private string FailureLoginParser(string logMessager)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";

        string adress = GetMatchValue(logMessager, addressPattern);

        var message = $"Невдала спроба входу: {adress}";
        return message;
    }
    private string SuccedLoginParser(string message)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";
        var userNamePattern = @"user name: (\w+)";

        string address = GetMatchValue(message, addressPattern);
        string userName = GetMatchValue(message, userNamePattern);

        var result = $"Успішний вхід за IP адресою: {address}, Ім'я користувача: {userName}";
        return result;
    }
    private string ForgetFeiledLoginParser(string message)
    {
        var adressPattern = @"ip address (\d+\.\d+\.\d+\.\d+)";

        var adress = GetMatchValue(message, adressPattern);

        var result = $"Забуто невдалу спробу входу: {adress}";
        return result;
    }
    private string BanIPParser(string message)
    {
        var adressPattern = @"(\d+\.\d+\.\d+\.\d+)";
        var loginAttemptsPattern = @"count: (\d+)";
        var durationPattern = @"duration: ([\d:]+)";

        var adress = GetMatchValue(message, adressPattern);
        var loginAttempts = GetMatchValue(message, loginAttemptsPattern);
        var duration = GetMatchValue(message, durationPattern);

        var result = $"Заблоковано IP адресу: {adress}, Спроб входу: {loginAttempts}, Час блокування: {duration}";
        return result;
    }
    private string UnBanIPParser(string message)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";

        string address = GetMatchValue(message, addressPattern);

        var result = $"Розблоковано IP адресу: {address}";
        return result;
    }
    private string FirewalEntrlUpdateParser(string message)
    {
        var adressesPattern = @"(.+)";

        string adresses = GetMatchValue(message, adressesPattern);

        var result = $"Оновлені записи брандмауера: {adresses}";
        return result;
    }
    private string FirewallUpdatedParser(string message)
    {
        var attemptsPattern = @"(\d+)";

        string attempts = GetMatchValue(message, attemptsPattern);

        var result = $"Оновлення брандмауера з {attempts} записами...";
        return result;
    }

    static string GetMatchValue(string input, string pattern)
    {
        Match match = Regex.Match(input, pattern);
        return match.Groups[1].Value;
    }

    private MessageType EnumParser(string logMessanger)
    {
        if (logMessanger.Contains("Login succeeded"))
            return MessageType.SuccedLogin;

        else if (logMessanger.Contains("Login failure:"))
            return MessageType.FailureLogin;

        else if (logMessanger.Contains("Forgetting failed login"))
            return MessageType.ForgettingFeiledLogin;

        else if (logMessanger.Contains("Banning ip"))
            return MessageType.BanIp;

        else if (logMessanger.Contains("Un-banning ip"))
            return MessageType.UnBanIp;

        else if (logMessanger.Contains("Firewall entries updated"))
            return MessageType.FirewallEntrUpd;

        else if (logMessanger.Contains("Updating firewall"))
            return MessageType.UpdatingFirewall;

        else
            return MessageType.None;
    }




}
