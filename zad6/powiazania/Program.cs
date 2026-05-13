using System;

namespace PaywallGame
{
    enum AccessType
    {
        Free,
        Premium,
        Level,
        Dlc
    }

    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsPremium { get; set; }
        public bool HasDlc { get; set; }
    }

    public interface IAccessStrategy
    {
        bool CanAccess(Player player);
        string GetInfo();
    }

    class FreeAccessStrategy : IAccessStrategy
    {
        public bool CanAccess(Player player)
        {
            return true;
        }

        public string GetInfo()
        {
            return "Dostęp darmowy";
        }
    }

    class PremiumAccessStrategy : IAccessStrategy
    {
        public bool CanAccess(Player player)
        {
            return player.IsPremium;
        }

        public string GetInfo()
        {
            return "Dostęp premium";
        }
    }

    class LevelAccessStrategy : IAccessStrategy
    {
        private int requiredLevel;

        public LevelAccessStrategy(int requiredLevel)
        {
            this.requiredLevel = requiredLevel;
        }

        public bool CanAccess(Player player)
        {
            return player.Level >= requiredLevel;
        }

        public string GetInfo()
        {
            return $"Dostęp od poziomu {requiredLevel}";
        }
    }

    class DlcAccessStrategy : IAccessStrategy
    {
        public bool CanAccess(Player player)
        {
            return player.HasDlc;
        }

        public string GetInfo()
        {
            return "Dostęp tylko z DLC";
        }
    }

    class AccessStrategyFactory
    {
        public static IAccessStrategy CreateStrategy(AccessType type)
        {
            switch (type)
            {
                case AccessType.Free:
                    return new FreeAccessStrategy();

                case AccessType.Premium:
                    return new PremiumAccessStrategy();

                case AccessType.Level:
                    return new LevelAccessStrategy(10);

                case AccessType.Dlc:
                    return new DlcAccessStrategy();

                default:
                    return new FreeAccessStrategy();
            }
        }
    }

    class PaywallService
    {
        private IAccessStrategy strategy;

        public PaywallService(IAccessStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void CheckAccess(Player player)
        {
            Console.WriteLine(strategy.GetInfo());

            if (strategy.CanAccess(player))
            {
                Console.WriteLine("Gracz ma dostęp");
            }
            else
            {
                Console.WriteLine("Gracz nie ma dostępu");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player
            {
                Name = "Jeremi",
                Level = 5,
                IsPremium = false,
                HasDlc = true
            };

            Console.WriteLine("1 - Free");
            Console.WriteLine("2 - Premium");
            Console.WriteLine("3 - Level");
            Console.WriteLine("4 - DLC");

            Console.Write("Wybierz typ dostępu: ");

            int wybor = int.Parse(Console.ReadLine());

            AccessType type = AccessType.Free;

            switch (wybor)
            {
                case 1:
                    type = AccessType.Free;
                    break;

                case 2:
                    type = AccessType.Premium;
                    break;

                case 3:
                    type = AccessType.Level;
                    break;

                case 4:
                    type = AccessType.Dlc;
                    break;
            }

            IAccessStrategy strategy = AccessStrategyFactory.CreateStrategy(type);

            PaywallService service = new PaywallService(strategy);

            service.CheckAccess(player);
        }
    }
}