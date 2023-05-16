using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;

namespace Matador
{
    public partial class MainPage : ContentPage
    {
        public static Grid Board { get; private set; }
        public static List<Player> playerList = new List<Player>();
        public static List<Player> playerOrder = new List<Player>();
        public static List<Property> properties = new List<Property>();
        public static Player bank = new Player(Colors.Orange);

        public MainPage()
        {
            InitializeComponent();
            Board = board;

            LineMan();
            InitPropiteis();

        }
        public static void LineMan()
        {
            int centerPoint = 375;
            int bigRadius = 375, smalRadius = 250;
            for (int i = 40 - 1; i >= 0; i--)
            {
                double angle = 45 - i * 9;

                Line theLine = new Line
                {
                    X1 = centerPoint + (bigRadius * Math.Cos(DegToRad(angle))),
                    Y1 = centerPoint + (bigRadius * Math.Sin(DegToRad(angle))),
                    X2 = centerPoint + (smalRadius * Math.Cos(DegToRad(angle))),
                    Y2 = centerPoint + (smalRadius * Math.Sin(DegToRad(angle))),
                    Stroke = Colors.Black,
                    StrokeThickness = 2,
                    ZIndex = 30,
                };
                Board.Children.Add(theLine);

                Button theButton = new Button
                {
                    TranslationX = (smalRadius + 0.5 * (bigRadius - smalRadius)) * Math.Cos(DegToRad(angle - 4.5f)),
                    TranslationY = (smalRadius + 0.5 * (bigRadius - smalRadius)) * Math.Sin(DegToRad(angle - 4.5f)),
                    HeightRequest = (bigRadius * Math.Sin(DegToRad(angle))) - (bigRadius * Math.Sin(DegToRad(angle))),
                    WidthRequest = bigRadius - smalRadius,
                    Rotation = angle - 4.5f,
                    ZIndex = 50,
                    Opacity = 0,
                    ClassId = (39 - i).ToString(),
                };
                theButton.Clicked += BoardTile_Clicked;
                Board.Children.Add(theButton);

            }
        }
        private static void BoardTile_Clicked(object sender, EventArgs e)
        {
            //setup 
            var button = sender as Button;
            int id = int.Parse(button.ClassId);

            Debug.WriteLine(id);

        }
        public static void InitPlayers()
        {

        }


        public static double DegToRad(double angle)
        {
            return angle * Math.PI / 180d;
        }
        public static void InitPropiteis()
        {
            properties.Add(new Property(0, false, -1, -1, new Design("Start", Colors.Red, Group.start)));
            properties.Add(new Property(1, true, 1000, 1200, new Design("Rødovervej", Colors.LightBlue, Group.blue)));
            properties.Add(new Property(2, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(3, true, 1000, 1200, new Design("Hvidovervej", Colors.LightBlue, Group.blue)));
            properties.Add(new Property(4, false, -1, -1, new Design("TAX:4000", Colors.Green, Group.skat, "4000")));
            properties.Add(new Property(5, true, -1, 4000, new Design("firstplaceholder", Colors.Blue, Group.boat)));
            properties.Add(new Property(6, true, 1000, 2000, new Design("Roskildevej", Colors.Orange, Group.orange)));
            properties.Add(new Property(7, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(8, true, 1000, 2000, new Design("Valby Langgade", Colors.Orange, Group.orange)));
            properties.Add(new Property(9, true, 1000, 2400, new Design("Allegade", Colors.Orange, Group.orange)));
            properties.Add(new Property(10, false, -1, -1, new Design("Prison", Colors.Black, Group.prison, "Cell")));
            properties.Add(new Property(11, true, 2000, 2800, new Design("FrediksBerg Alle", Colors.Green, Group.green)));
            properties.Add(new Property(12, true, -1, 3000, new Design("Squash", Colors.Orange, Group.soda)));
            properties.Add(new Property(13, true, 2000, 2800, new Design("Büllovsvej", Colors.Green, Group.green)));
            properties.Add(new Property(14, true, 2000, 3200, new Design("Gl. Kongevej", Colors.Green, Group.green)));
            properties.Add(new Property(15, true, -1, 4000, new Design("MolsLinjen", Colors.Red, Group.boat)));
            properties.Add(new Property(16, true, 2000, 3600, new Design("Bernstofsvej", Colors.Gray, Group.gray)));
            properties.Add(new Property(17, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(18, true, 2000, 3600, new Design("Hellerupsvej", Colors.Gray, Group.gray)));
            properties.Add(new Property(19, true, 2000, 4000, new Design("Strandvej", Colors.Gray, Group.gray)));
            properties.Add(new Property(20, false, -1, -1, new Design("Parking", Colors.AliceBlue, Group.parking)));
            properties.Add(new Property(21, true, 3000, 4400, new Design("Trianglen", Colors.Red, Group.red)));
            properties.Add(new Property(22, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(23, true, 3000, 4400, new Design("Østergade", Colors.Red, Group.red)));
            properties.Add(new Property(24, true, 3000, 4800, new Design("Grøningen", Colors.Red, Group.red)));
            properties.Add(new Property(25, true, -1, 4000, new Design("thirdplaceholder", Colors.Blue, Group.boat)));
            properties.Add(new Property(26, true, 3000, 5200, new Design("Bredgade", Colors.White, Group.white)));
            properties.Add(new Property(27, true, 3000, 5200, new Design("Kgs Nytorv", Colors.White, Group.white)));
            properties.Add(new Property(28, true, -1, 3000, new Design("Cola", Colors.DarkRed, Group.soda)));
            properties.Add(new Property(29, true, 3000, 5600, new Design("Østergade", Colors.White, Group.white)));
            properties.Add(new Property(30, false, -1, -1, new Design("GotoPrison", Colors.Black, Group.prison, "gotoPrison")));
            properties.Add(new Property(31, true, 4000, 6000, new Design("Amergertorv", Colors.Yellow, Group.yellow)));
            properties.Add(new Property(32, true, 4000, 6000, new Design("Vimmelskaftet", Colors.Yellow, Group.yellow)));
            properties.Add(new Property(33, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(34, true, 4000, 6400, new Design("Nygade", Colors.Yellow, Group.yellow)));
            properties.Add(new Property(35, true, -1, 4000, new Design("fourthplaceholder", Colors.Blue, Group.boat)));
            properties.Add(new Property(36, false, -1, -1, new Design("Chance", Colors.Black, Group.chance)));
            properties.Add(new Property(37, true, 4000, 7000, new Design("Frediksberg gade", Colors.Purple, Group.purple)));
            properties.Add(new Property(38, false, -1, -1, new Design("TAX:2000", Colors.Green, Group.skat, "2000")));
            properties.Add(new Property(39, true, 4000, 8000, new Design("Rådhuspladsen", Colors.Purple, Group.purple)));
        }
    }
}