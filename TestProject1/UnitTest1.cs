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
            var expectedLog = "������� ���� �� IP �������: 31.41.92.178, ��'� �����������: TSAdmin";
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          
          //public void TestLoginfailure()
          //{
          //     var InputLog = "Login failure: 149.50.98.117, , RDP, 2, 14"; //�� �� �������� ��������
          //     var expectedLog = "������� ������ �����: 149.50.98.117"; //�� �� �� ���� �������� � ���������
          //     var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

          //     Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          //}
        //[TestMethod]
        //public void TestLoginfailure_WhenUser()
        //{
        //    var InputLog = "Login failure: 32.123.2.2, ADMINISTRATOR, RDP, 4, 4625";  //�� �� �������� ��������
        //    var expectedLog = "������� ������ ����� �� IP �������: 32.123.2.2, ��'� �����������: ADMINISTRATOR"; //�� �� �� ���� �������� � ���������
        //    var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

        //    Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        //}
        //[TestMethod]
        //public void TestLoginfailure_WhenUserEmpty()
        //{
        //    var InputLog = "Login failure: 22.3.200.31, , RDP, 6, 14"; //�� �� �������� ��������
        //    var expectedLog = "������� ������ ����� �� IP �������: 22.3.200.31, ��'� ����������� ������������� �������"; //�� �� �� ���� �������� � ���������
        //    var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

        //    Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        //}


        [TestMethod]
          public void TestForgettingfailed()
          {
               var InputLog = "Forgetting failed login ip address 87.236.176.76, time expired\r\n"; //�� �� �������� ��������
               var expectedLog = "������ ������� ������ �����: 87.236.176.76"; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestBanningip()
          {
               var InputLog = "Banning ip address: 185.16.39.70, user name: , config blacklisted: False, count: 3, extra info: , duration: 00:05:00"; //�� �� �������� ��������
               var expectedLog = "����������� IP ������: 185.16.39.70, ����� �����: 3, ��� ����������: 00:05:00"; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestUnbannip()
          {
               var InputLog = "Un-banning ip address 193.34.213.119, ban expired"; //�� �� �������� ��������
               var expectedLog = "������������ IP ������: 193.34.213.119"; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestFirewallentries()
          {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194"; //�� �� �������� ��������
               var expectedLog = "������� ������ �����������: 193.34.213.119,195.3.221.194"; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������
            
               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
        [TestMethod]
        public void TestUpdatingFirewallEntries1()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119";//�� �� �������� ��������
            var expectedLog = "������� ������ �����������: 193.34.213.119";//�� �� �� ���� �������� � ���������
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries2()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194";//�� �� �������� ��������
            var expectedLog = "������� ������ �����������: 193.34.213.119,195.3.221.194";//�� �� �� ���� �������� � ���������
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries3()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29";//�� �� �������� ��������
            var expectedLog = "������� ������ �����������: 193.34.213.119,195.3.221.194,2.34.3.29";//�� �� �� ���� �������� � ���������
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries4()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144";//�� �� �������� ��������
            var expectedLog = "������� ������ �����������: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144";//�� �� �� ���� �������� � ���������
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        }

        [TestMethod]
        public void TestUpdatingFirewallEntries5()
        {
            var InputLog = "Firewall entries updated: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144,196.14.211.104";//�� �� �������� ��������
            var expectedLog = "������� ������ �����������: 193.34.213.119,195.3.221.194,2.34.3.29,196.54.222.144,196.14.211.104";//�� �� �� ���� �������� � ���������
            var parsedLog = parser.MainMessageParser(InputLog);

            Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
        }

        [TestMethod]
          public void TestUpdatingfirewall()
          {
               var InputLog = "Updating firewall with 2 entries..."; //�� �� �������� ��������
               var expectedLog = "��������� ����������� � 2 ��������..."; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
     }
}