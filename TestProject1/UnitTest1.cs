using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.MessageParser;

namespace TestProject1
{

     [TestClass]
     public class UnitTest1
     {
          MessageParser parser = new();

          [TestMethod]
          public void TestLoginsucceeded()
          {
               var InputLog = "Login succeeded, address: 31.41.92.178, user name: TSAdmin, source: RDP"; 
            var expectedLog = "Успішний вхід за IP адресою: 31.41.92.178, Ім'я користувача: TSAdmin";
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          
          //public void TestLoginfailure()
          //{
          //     var InputLog = "Login failure: 149.50.98.117, , RDP, 2, 14"; //Те що отримала програма
          //     var expectedLog = "Невдала спроба входу: 149.50.98.117"; //Те що ми мали отримати в результаті
          //     var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

          //     Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          //}
        //[TestMethod]
        //public void TestLoginfailure_WhenUser()
        //{
        //    var InputLog = "Login failure: 32.123.2.2, ADMINISTRATOR, RDP, 4, 4625";  //Те що отримала програма
        //    var expectedLog = "Невдала спроба входу за IP адресою: 32.123.2.2, Ім'я користувача: ADMINISTRATOR"; //Те що ми мали отримати в результаті
        //    var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

        //    Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        //}
        //[TestMethod]
        //public void TestLoginfailure_WhenUserEmpty()
        //{
        //    var InputLog = "Login failure: 22.3.200.31, , RDP, 6, 14"; //Те що отримала програма
        //    var expectedLog = "Невдала спроба входу за IP адресою: 22.3.200.31, Ім'я користувача неправильного формату"; //Те що ми мали отримати в результаті
        //    var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

        //    Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        //}


        [TestMethod]
          public void TestForgettingfailed()
          {
               var InputLog = "Forgetting failed login ip address 87.236.176.76, time expired\r\n"; //Те що отримала програма
               var expectedLog = "Забуто невдалу спробу входу: 87.236.176.76"; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestBanningip()
          {
               var InputLog = "Banning ip address: 185.16.39.70, user name: , config blacklisted: False, count: 3, extra info: , duration: 00:05:00"; //Те що отримала програма
               var expectedLog = "Заблоковано IP адресу: 185.16.39.70, Спроб входу: 3, Час блокування: 00:05:00"; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestUnbannip()
          {
               var InputLog = "Un-banning ip address 193.34.213.119, ban expired"; //Те що отримала програма
               var expectedLog = "Розблоковано IP адресу: 193.34.213.119"; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
          [TestMethod]
          public void TestFirewallentries()
          {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194"; //Те що отримала програма
               var expectedLog = "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194"; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті
            
               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
        [TestMethod]
        public void TestUpdatingFirewallEntries1()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119";//Те що отримала програма
            var expectedLog = "Оновлені записи брандмауера: 193.34.213.119";//Те що ми мали отримати в результаті
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries2()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194";//Те що отримала програма
            var expectedLog = "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194";//Те що ми мали отримати в результаті
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries3()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29";//Те що отримала програма
            var expectedLog = "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194,2.34.3.29";//Те що ми мали отримати в результаті
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries4()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144";//Те що отримала програма
            var expectedLog = "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144";//Те що ми мали отримати в результаті
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries5()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144,196.14.211.104";//Те що отримала програма
            var expectedLog = "Оновлені записи брандмауера: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144,196.14.211.104";//Те що ми мали отримати в результаті
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
        }

        [TestMethod]
          public void TestUpdatingfirewall()
          {
               var InputLog = "Updating firewall with 2 entries..."; //Те що отримала програма
               var expectedLog = "Оновлення брандмауера з 2 записами..."; //Те що ми мали отримати в результаті
               var parsedLog = parser.MainMessageParser(InputLog); //Те що ми отримали в результаті

               Assert.AreEqual(expectedLog, parsedLog); // Перевірка чи правильний результат ми отримали
          }
     }
}