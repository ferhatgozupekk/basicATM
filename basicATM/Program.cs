using System;

// i randomly generated all card numbers ,pin and names
// tüm kart numaralarını pinleri ve isimleri rastgele ürettim
public class cardHolder
{
    string cardNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
        this.pin = pin;
        this.cardNumber = cardNumber;

    }

    public String getCardNumber()
    {
        return cardNumber;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance() { return balance; }

    public void setNum(string newCardNum)
    {
        cardNumber = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double setBalance)
    {
        balance = setBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("lütfen gelen seçeneklerden birini seçiniz.");
            Console.WriteLine("1. Para Yatırma");
            Console.WriteLine("2. Para çekme");
            Console.WriteLine("3. Bakiye Göster");
            Console.WriteLine("4. Çıkış");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Lütfen ne kadar $$ para yatırmak istediğinizi giriniz.");
            double deposit = Double.Parse(Console.ReadLine()); // girilen string değeri int değerine çevirmek için parse metodu 
            currentUser.setBalance(currentUser.getBalance() + deposit); // yukarıda oluşturduğum setBalance metodu ile mevcut bakiyeyi güncelliyorum
            Console.WriteLine("İşleminiz için teşekür ederiz. Mevcut bakiyeniz" + currentUser.getBalance()); // $"{}" da kullanılabilirdi

        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Lütfen ne kadar $$ çekmek istediğinizi giriniz.");
            double withdrawl = Double.Parse(Console.ReadLine());  //aynı işlemler buradada kullanıyolar

            if (currentUser.getBalance() < withdrawl) // güncel bakiye çekilmek istenen bakiyeden küçük ise 
            {
                Console.WriteLine("Yetersiz bakiye");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("Para çekme işleminiz gerçekleşmiştir. İyi günler Dileriz. Mevcut bakiyeniz:" + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Mevcut bakiyeniz :" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>(); // oluşturduğum class elementlerini liste elemanlarıyla dolduruyorum
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "Banu", "Eroğlu", 195.54));
        cardHolders.Add(new cardHolder("2345672328971243", 2345, "Pınar", "Pınar", 479.23));
        cardHolders.Add(new cardHolder("2198034721846723", 9812, "Necmi", "Yılmaz", 89.23));
        cardHolders.Add(new cardHolder("2187346213412345", 9201, "Tarık", "Güler", 392.43));
        cardHolders.Add(new cardHolder("1234125453634563", 8912, "İlkkan", "Çınar", 234.23));


        Console.WriteLine("BankF'e Hoşgeldiniz");
        Console.WriteLine("Lütfen kart numaranızı giriniz.");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine(); // string değer alıyorum
                //liste içindeki kart numralarıyla karşılaştır
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNum); // first or default ile currentuser'a card numarasının eşitliğiyle liste elemanlarının ataması yapılır
                if (currentUser != null) { break; }
                else Console.WriteLine("Kart numaranız eşleşmiyor. Lütfen tekrar deneyiniz.");
            }
            catch
            {
                Console.WriteLine("Kart numaranız eşleşmiyor. Lütfen tekrar deneyiniz.");


            }
        }

        Console.WriteLine("Lütfen kart şifrenizi giriniz.");
        int userPin = 0;


        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //girilen pini karşılaştır
                if (currentUser.getPin() == userPin) { break; } // yukarda atanan currentUser sayesinde pin kontrolü sağlanır
                else Console.WriteLine("Yanlış veya eksik pin girdiniz lütfen tekrar deneyiz.");
            }
            catch
            {
                Console.WriteLine("Yanlış veya eksik pin girdiniz lütfen tekrar deneyiz.");
            }
        }
        Console.WriteLine("Hoşgeldin " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }     // seçimler case yapısıylada oluşturulabilirdi değişkene değer alarak ifle kontrol ettim
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
        }
        while (option != 4);
        Console.WriteLine("Teşekkürler İyi günler");

    }
}
