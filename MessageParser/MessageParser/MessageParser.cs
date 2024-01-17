using MessageParser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageParser.MessageParser;

public class MessageParser
{
    private string MessageParser(string logMessage, MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.SuccedLogin:
                SuccedLoginParser(logMessage);
                break;
            case MessageType.FailureLogin:
                FailureLoginParser(logMessage);
                break;
            case MessageType.ForgettingFeiledLogin:
                ForgetFeiledLoginParser(logMessage);
                break;
            case MessageType.BanIp:
                BanIPParser(logMessage);
                break;
            case MessageType.UnBanIp:
                UnBanIPParser(logMessage);
                break;
            case MessageType.FirewallEntrUpd:
                FirewalEntrlUpdateParser(logMessage);
                break;
            case MessageType.UpdatingFirewall:
                FirewallUpdatedParser(logMessage);
                break;
            default:
                break;
        }
    }

    private string FailureLoginParser(string logMessager)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";

        string adress = GetMatchValue(logMessager, addressPattern);

        var message = $"Невдала спроба входу: {adress}";
        return message;
    }
    private string SuccedLoginParser(string logMessager)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";
        var userNamePattern = @"user name: (\w+)";

        string address = GetMatchValue(logMessager, addressPattern);
        string userName = GetMatchValue(logMessager, userNamePattern);

        var result = $"Успішний вхід за IP адресою: {address}, Ім'я користувача: {userName}";
        return result;
    }
    private string ForgetFeiledLoginParser(string logMessager)
    {
        var adressPattern = @"ip address (\d+\.\d+\.\d+\.\d+)";

        var adress = GetMatchValue(logMessager, adressPattern);

        var result = $"Забуто невдалу спробу входу: {adress}";
        return result;
    }
    private string BanIPParser(string logMessager)
    {
        var adressPattern = @"(\d+\.\d+\.\d+\.\d+)";
        var loginAttemptsPattern = @"count: (\d+)";
        var durationPattern = @"duration: ([\d:]+)";

        var adress = GetMatchValue(logMessager, adressPattern);
        var loginAttempts = GetMatchValue(logMessager, loginAttemptsPattern);
        var duration = GetMatchValue(logMessager, durationPattern);

        var result = $"Заблоковано IP адресу: {adress}, Спроб входу: {loginAttempts}, Час блокування: {duration}";
        return result;
    }
    private string UnBanIPParser(string logMessanger)
    {
        var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";

        string address = GetMatchValue(logMessanger, addressPattern);

        var result = $"Розблоковано IР адресу: {address}";
        return result;
    }
    private string FirewalEntrlUpdateParser(string logMessanger)
    {
        var adressesPattern = @"(.+)";

        string adresses = GetMatchValue(logMessanger, adressesPattern);

        var result = $"Оновлені записи брандмауера: {adresses}";
        return result;
    }
    private string FirewallUpdatedParser(string logMessanger)
    {
        var attemptsPattern = @"(\d+)";

        string attempts = GetMatchValue(logMessanger, attemptsPattern);

        var result = $"Оновлення брандмауера з {attempts} записами...";
        return result;
    }

    static string GetMatchValue(string input, string pattern)
    {
        Match match = Regex.Match(input, pattern);
       
        return match.Groups[1].Value;
    }


}
