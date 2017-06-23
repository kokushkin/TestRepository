using System;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Transactions;

namespace EssentialWCF
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        double GetBalance(string AccountName);
        [OperationContract]
        void Transfer(string From, string To, double amount);
    }

    public class BankService : IBankService
    {
        [OperationBehavior(TransactionScopeRequired = false)]
        public double GetBalance(string AccountName)
        {
            DBAccess dbAccess = new DBAccess();
            double amount = dbAccess.GetBalance(AccountName);
            dbAccess.Audit(AccountName, "Query", amount);
            return amount;
        }
        [OperationBehavior(TransactionScopeRequired = true,
        TransactionAutoComplete = true)]
        public void Transfer(string From, string To, double amount)
        {
            try
            {
                Withdraw(From, amount);
                Deposit(To, amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Withdraw(string AccountName, double amount)
        {
            DBAccess dbAccess = new DBAccess();
            dbAccess.Withdraw(AccountName, amount);
            dbAccess.Audit(AccountName, "Withdraw", amount);
        }
        private void Deposit(string AccountName, double amount)
        {
            DBAccess dbAccess = new DBAccess();
            dbAccess.Deposit(AccountName, amount);
            dbAccess.Audit(AccountName, "Deposit", amount);
        }
    }



    class DBAccess
    {
        private SqlConnection conn;
        public DBAccess()
        {
            string cs = ConfigurationManager.ConnectionStrings["sampleDB"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }
        public void Deposit(string AccountName, double amount)
        {
            string sql = string.Format("Deposit {0}, {1}, “{2}”",
            AccountName, amount.ToString(),
            System.DateTime.Now.ToString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public void Withdraw(string AccountName, double amount)
        {
            string sql = string.Format("Withdraw {0}, {1}, “{2}”",
            AccountName, amount.ToString(),
            System.DateTime.Now.ToString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public double GetBalance(string AccountName)
        {

            SqlCommand cmd = new SqlCommand("GetBalance " +
AccountName, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            double amount = System.Convert.ToDouble(reader["Balance"].ToString());
            reader.Close();
            return amount;
        }

        public void Audit(string AccountName, string Action, double amount)
        {
            Transaction txn = Transaction.Current;
            if (txn != null)
                Console.WriteLine("{0} | {1} Audit:{2}",
                txn.TransactionInformation.DistributedIdentifier,
                txn.TransactionInformation.LocalIdentifier, Action);
            else
                Console.WriteLine("<no transaction> Audit:{0}",
                Action);
            string sql = string.Format("Audit {0}, {1}, {2}, “{3}”",
            AccountName, Action, amount.ToString(),
            System.DateTime.Now.ToString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }

    public class Service
    {
        public static void Main()
        {
            ServiceHost serviceHost = new ServiceHost((typeof(BankService)));
            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>.\n\n"); Console.ReadLine();
            serviceHost.Close();
        }
    }
}
