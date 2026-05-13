using System;

namespace KalkulatorRabatu
{
    interface IRabat
    {
        double Oblicz(double kwota);
    }

    class BrakRabatu : IRabat
    {
        public double Oblicz(double kwota)
        {
            return kwota;
        }
    }

    class RabatProcentowy : IRabat
    {
        private double procent;

        public RabatProcentowy(double procent)
        {
            this.procent = procent;
        }

        public double Oblicz(double kwota)
        {
            double wynik = kwota - (kwota * procent / 100);

            if (wynik < 0)
            {
                return 0;
            }

            return wynik;
        }
    }

    class RabatStaly : IRabat
    {
        private double kwotaRabatu;

        public RabatStaly(double kwotaRabatu)
        {
            this.kwotaRabatu = kwotaRabatu;
        }

        public double Oblicz(double kwota)
        {
            double wynik = kwota - kwotaRabatu;

            if (wynik < 0)
            {
                return 0;
            }

            return wynik;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double cena = PobierzCene();

            WyswietlMenu();

            int wybor = PobierzWybor();

            IRabat rabat = WybierzRabat(wybor);

            double nowaCena = rabat.Oblicz(cena);

            WyswietlWynik(nowaCena);
        }

        static double PobierzCene()
        {
            double cena;

            while (true)
            {
                Console.Write("Podaj cenę produktu: ");

                if (double.TryParse(Console.ReadLine(), out cena) && cena >= 0)
                {
                    return cena;
                }

                Console.WriteLine("Błąd! Podaj poprawną liczbę większą lub równą 0.");
            }
        }

        static void WyswietlMenu()
        {
            Console.WriteLine("\nWybierz rodzaj rabatu:");
            Console.WriteLine("1 - Brak rabatu");
            Console.WriteLine("2 - Rabat 10%");
            Console.WriteLine("3 - Rabat 20 zł");
        }

        static int PobierzWybor()
        {
            int wybor;

            while (true)
            {
                Console.Write("Twój wybór: ");

                if (int.TryParse(Console.ReadLine(), out wybor) &&
                    wybor >= 1 && wybor <= 3)
                {
                    return wybor;
                }

                Console.WriteLine("Błąd! Wybierz opcję od 1 do 3.");
            }
        }

        static IRabat WybierzRabat(int wybor)
        {
            switch (wybor)
            {
                case 1:
                    return new BrakRabatu();

                case 2:
                    return new RabatProcentowy(10);

                case 3:
                    return new RabatStaly(20);

                default:
                    return new BrakRabatu();
            }
        }

        static void WyswietlWynik(double wynik)
        {
            Console.WriteLine($"\nCena po rabacie: {wynik} zł");
        }
    }
}