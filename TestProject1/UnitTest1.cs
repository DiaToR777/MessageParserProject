using MessageParser.MessageParser;

namespace TestProject1
{

     [TestClass]
     public class UnitTest1
     {
          string[] InputLogs = {
               "Login succeeded, address: 31.41.92.178, user name: TSAdmin, source: RDP",
               "Login failure: 149.50.98.117, , RDP, 2, 14\r\n",
               "Forgetting failed login ip address 87.236.176.76, time expired\r\n",
               "Banning ip address: 185.16.39.70, user name: , config blacklisted: False, count: 3, extra info: , duration: 00:05:00",
               "Un-banning ip address 193.34.213.119, ban expired",
               "Firewall entries updated: 193.34.213.119,195.3.221.194",
               "Updating firewall with 2 entries..." };

          string[] expectedLogs = {
               "Успішний вхід за IP адресою: 31.41.92.178, Ім'я користувача: TSAdmin",
               "Невдала спроба входу: 149.50.98.117",
               "Забуто невдалу спробу входу: 87.236.176.76",
               "Заблоковано IP адресу: 185.16.39.70, Спроб входу: 3, Час блокування: 00:05:00",
               "Розблоковано IP адресу: 193.34.213.119",
               "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194",
               "Оновлення брандмауера з 2 записами..." };

          MessageParser_ parser = new();

          [TestMethod]
          public void TestLoginsucceeded()
          {
               var InputLog = InputLogs[0]; //Те що отримала програма
               var expectedLog = expectedLogs[0]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestLoginfailure()
          {
               var InputLog = InputLogs[1]; //Те що отримала програма
               var expectedLog = expectedLogs[1]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestForgettingfailed()
          {
               var InputLog = InputLogs[2]; //Те що отримала програма
               var expectedLog = expectedLogs[2]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestBanningip()
          {
               var InputLog = InputLogs[3]; //Те що отримала програма
               var expectedLog = expectedLogs[3]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestUnbanninge()
          {
               var InputLog = InputLogs[4]; //Те що отримала програма
               var expectedLog = expectedLogs[4]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestFirewallentries()
          {
               var InputLog = InputLogs[5]; //Те що отримала програма
               var expectedLog = expectedLogs[5]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestUpdatingfirewall()
          {
               var InputLog = InputLogs[6]; //Те що отримала програма
               var expectedLog = expectedLogs[6]; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
     }
}