namespace Matador
{
    internal class Construction
    {
    }
    public class Player
    {
        public List<Property> Properties { get; set; }
        public int Money { get; set; }
        public bool IsBankrupt { get; set; }
        public Color Color { get; set; }
        public int Position { get; set; }

        public Player(Color color)
        {
            Properties = new List<Property>();
            Money = 0;
            IsBankrupt = false;
            Color = color;
            Position = 0;
        }
        public int GetTotalValue()
        {
            int value = Money;
            for (int i = 0; i < Properties.Count; i++)
                value += Properties[i].GetValue();

            return value;
        }
    }
    public class Design
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Group Group { get; set; }
        public string Special { get; set; }

        public Design(string name, Color color, Group group)
        {
            Name = name;
            Color = color;
            Group = group;
            Special = "empty";
        }
        public Design(string name, Color color, Group group, string special)
        {
            Name = name;
            Color = color;
            Group = group;
            Special = special;
        }
    }
    public enum Group
    {
        start,
        blue,
        chance,
        skat,
        boat,
        orange,
        soda,
        green,
        gray,
        red,
        white,
        prison,
        parking,
        yellow,
        purple,
    }
    public class Property
    {
        public int Level { get; set; }
        public int Position { get; private set; }
        public Player Owner { get; private set; }
        public bool IsPurchasable { get; set; }
        public int LevelCost { get; private set; }
        public int PurchaseCost { get; private set; }
        public bool IsPansat { get; set; }
        public Design Design { get; set; }
        public Property(int position, bool isPurchaseable, int levelCost, int purchaseCost, Design design)
        {
            Level = 0;
            Position = position;
            Owner = MainPage.bank;
            IsPurchasable = isPurchaseable;
            LevelCost = levelCost;
            PurchaseCost = purchaseCost;
            IsPansat = false;
            Design = design;
        }

        public void UnPansæt(Player player)
        {
            int value = GetPansatValue();
            if (player.Money >= value && IsPansat == true)
            {
                player.Money -= value;
                IsPansat = false;
            }
        }
        public void Pansæt(Player player)
        {
            if (Level != 0)
                LevelDown(player, Level);

            if (IsPansat == false)
            {
                player.Money += GetPansatValue();
                IsPansat = true;
            }
        }
        public int GetPansatValue()
        {
            return PurchaseCost / 2;
        }
        public int GetValue()
        {
            return PurchaseCost + LevelCost * Level;
        }
        public bool LevelUp(Player player) // returns wheter it was succesful or not
        {
            bool isSuccesfull = false;
            if (player.Money >= LevelCost && Level < 5)
            {
                player.Money -= LevelCost;
                Level++;
                isSuccesfull = true;
            }
            return isSuccesfull;
        }
        public bool LevelDown(Player player) // returns the value of the freed up money
        {
            bool isSuccesfull = false;
            if (Level > 0)
            {
                player.Money += LevelCost;
                Level--;
                isSuccesfull = true;
            }

            return isSuccesfull;
        }
        public bool LevelDown(Player player, int byHowMuch) // returns the value of the freed up money
        {
            bool isSuccesfull = false;
            for (int i = 0; i < byHowMuch; i++)
            {
                if (Level > 0)
                {
                    player.Money += LevelCost;
                    Level--;
                    isSuccesfull = true;
                }
                else
                    break;
            }
            return isSuccesfull;
        }
    }
}
