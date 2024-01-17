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
               "������� ���� �� IP �������: 31.41.92.178, ��'� �����������: TSAdmin",
               "������� ������ �����: 149.50.98.117",
               "������ ������� ������ �����: 87.236.176.76",
               "����������� IP ������: 185.16.39.70, ����� �����: 3, ��� ����������: 00:05:00",
               "������������ IP ������: 193.34.213.119",
               "������� ������ �����������: 193.34.213.119,195.3.221.194",
               "��������� ����������� � 2 ��������..." };

          MessageParser_ parser = new();

          [TestMethod]
          public void TestLoginsucceeded()
          {
               var InputLog = InputLogs[0]; //�� �� �������� ��������
               var expectedLog = expectedLogs[0]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestLoginfailure()
          {
               var InputLog = InputLogs[1]; //�� �� �������� ��������
               var expectedLog = expectedLogs[1]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestForgettingfailed()
          {
               var InputLog = InputLogs[2]; //�� �� �������� ��������
               var expectedLog = expectedLogs[2]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestBanningip()
          {
               var InputLog = InputLogs[3]; //�� �� �������� ��������
               var expectedLog = expectedLogs[3]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestUnbanninge()
          {
               var InputLog = InputLogs[4]; //�� �� �������� ��������
               var expectedLog = expectedLogs[4]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestFirewallentries()
          {
               var InputLog = InputLogs[5]; //�� �� �������� ��������
               var expectedLog = expectedLogs[5]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
          [TestMethod]
          public void TestUpdatingfirewall()
          {
               var InputLog = InputLogs[6]; //�� �� �������� ��������
               var expectedLog = expectedLogs[6]; //�� �� �� ���� �������� � ���������
               var parsedLog = parser.MainMessageParser(InputLog); //�� �� �� �������� � ���������

               Assert.AreEqual(expectedLog, parsedLog); // �������� �� ���������� ��������� �� ��������
          }
     }
}