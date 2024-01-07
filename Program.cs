


// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Threading.Channels;





class first_step
{
    static Dictionary<String, String> userdatabase = new Dictionary<string, string>();// creating a collection similar as  java
                                                                                      // dictionary is one collection in c# which takes data in key value pair
    public static int GetChoice()// in this method we are trying to check whether user enter vaild entry ot not
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        return choice;
    }


    public static void register()
    {
        Console.WriteLine("Enter details for registration");

        Console.WriteLine("Enter your username");
        String username = Console.ReadLine();

        if (userdatabase.ContainsKey(username))// containskey is method of dictionary collection which checks entered data is present in collection or not
        {
            Console.WriteLine("username already exist.please go with other name");
            register();
            return;
        }


        Console.WriteLine("Enter your password");
        String password = Console.ReadLine();

        userdatabase.Add(username, password);// add method is use to add data in collection

        Console.WriteLine("registration sucesfully");
        Console.WriteLine("==========**********============");
        login();

    }
    public static void login()
    {

        Console.WriteLine("Enter details for login");

        Console.WriteLine("enter username");
        String username = Console.ReadLine();

        if (userdatabase.TryGetValue(username, out String storedPassword))//
        {
            Console.WriteLine("enter password");
            String password = Console.ReadLine();

            if (password == storedPassword)// here we are checking entered password and password stored in collection is same or not
            {
                Console.WriteLine("login succesfully");
                Console.WriteLine("==========**********============");
            }
            else
            {
                Console.WriteLine("login failed password does not match");
                Console.WriteLine("Try again with vaild details");
                Console.WriteLine("==========**********============");
                login();
            }
        }
        else
        {
            Console.WriteLine("username not found ,please register first");
            Console.WriteLine("==========**********============");
            register();
        }


    }


}








class Bank_Application
{
    //static Dictionary<String, String> userdatabase = new Dictionary<string, string>();// creating a collection similar as  java
    // dictionary is one collection in c# which takes data in key value pair
    static void Main()
    {
        Console.WriteLine("Welcome to the Bank Application");
        Console.WriteLine("======**======");

        Console.WriteLine("Enter 1. for Register");
        Console.WriteLine("Enter 2. for Login");
        Console.WriteLine("Enter 3. forExit");

        //first_step f1 = new first_step();

        int choice = first_step.GetChoice();

        switch (choice)
        {
            case 1:
                first_step.register();
                break;

            case 2:
                first_step.login();
                break;

            case 3:
                Environment.Exit(0);
                break;


            default:
                Console.WriteLine("enter vaild input");
                break;

        }



        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("=========== welcome to bank ============");

            Console.WriteLine(" press 1. for create bank acc");
            Console.WriteLine(" press 2. for deposit");
            Console.WriteLine(" press 3. for withdraw");
            Console.WriteLine(" press 4. display account information");
            Console.WriteLine(" press 5. get account balance");
            Console.WriteLine(" press 6. apply for loan");
            Console.WriteLine(" press 7. transfer money");
            Console.WriteLine(" enter exit to euit /n or press any key to continue");

            String ip = Console.ReadLine();
            if (ip.ToLower() == "exit")
            {
                exit = true;
                break;
            }




            //Console.WriteLine("enter a chioce"); extra 

            // String num = Console.ReadLine(); extraa

            switch (ip)
            {
                case "1":
                    sec_step.CreateAccount();
                    break;


                case "2":
                    sec_step.Deposit();
                    break;


                case "3":
                    sec_step.Withdraw();
                    break;


                case "4":
                    sec_step.DisplayAccInfo();
                    break;


                case "5":
                    sec_step.GetAccBalance();
                    break;


                case "6":
                    sec_step.ApplyLoan();
                    break;

                case "7":
                    sec_step.TransferMoney();
                    break;


                default:
                    Console.WriteLine("enter vaild input");
                    break;



            }

        }
        Console.WriteLine("out of while loop");

    }


}







class sec_step
{
    public static void CreateAccount()

    {

        Console.WriteLine("enter account number: ");
        string accno = Console.ReadLine();

        Console.WriteLine("enter account holder's name");
        string accholdname = Console.ReadLine();

        Console.WriteLine(" enter min balance to initailize acc");
        double initialbalance;

        if (double.TryParse(Console.ReadLine(), out initialbalance))//**********
        {
            mainBank.createAcc(accno, accholdname, initialbalance);
        }
        else
        {
            Console.WriteLine("invalid input for initial balance for acc creation");
        }

    }

    public static void Deposit()
    {
        Console.WriteLine("enter account number");
        string acno = Console.ReadLine();

        Bankacc b1 = mainBank.getacc(acno);

        if (b1 != null)
        {
            Console.WriteLine("enter amount that want to depsite");
            double amount;
            if (double.TryParse(Console.ReadLine(), out amount))
            {
                b1.deposite(amount);
            }
        }





    }

    public static void Withdraw()
    {
        Console.WriteLine("enter a amount no");
        String accno = Console.ReadLine();


        Bankacc b1 = mainBank.getacc(accno);
        if (b1 != null)
        {
            Console.WriteLine("enter amount that want to witdraw: ");
            double amount;
            if (double.TryParse(Console.ReadLine(), out amount))
            {
                b1.withdraw(amount);
            }
            else
            {
                Console.WriteLine("invalid input for withdrawal amount");
            }
        }
    }


    public static void DisplayAccInfo()
    {

        Console.WriteLine("enter account number");
        string acc = Console.ReadLine();
        Bankacc b1 = mainBank.getacc(acc);
        if (b1 != null)
        {
            b1.displayinfo();
        }




    }


    public static void GetAccBalance()
    {

    }

    public static void ApplyLoan()
    {

    }

    public static void TransferMoney()
    {

    }


}



class mainBank
{
    private static List<Bankacc> l1 = new List<Bankacc>();
    public static void createAcc(string accno, string accHoldName, double itialbalance)
    {
        Bankacc newacc = new Bankacc(accno, accHoldName, itialbalance);
        l1.Add(newacc);//+++++++++++++++
        Console.WriteLine("account created succesfully!!!!!");
    }

    public static Bankacc getacc(string accno)
    {
        return l1.Find(acc => acc.ACCNO == accno);
    }

}



class Bankacc
{
    public string ACCNO { get; }
    public string ACCHOLDNAME { get; set; }
    public double BALANCE { get; set; }

    public Bankacc(string accno, string accholdname, double bal)
    {
        ACCNO = accno;
        ACCHOLDNAME = accholdname;
        BALANCE = bal;
    }
    public void deposite(double amount)
    {
        BALANCE = BALANCE + amount;


    }

    public void withdraw(double amount)
    {
        if (amount > BALANCE)
        {
            Console.WriteLine("insufficient fund , you can not withdraw");
        }
        else
        {
            BALANCE = BALANCE - amount;
            Console.WriteLine("withdraw $(amount)./n" +
                "new balnace after withdrawal $(BALANCE) ");
        }
    }

    public void displayinfo()
    {
        Console.WriteLine("account number :{ACCNo}");
        Console.WriteLine(" Account holder : {ACCHOLDNAME}");
        Console.WriteLine(" balance : {BALANCE}");
    }


}



