using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;

namespace Matador
{
    public partial class MainPage : ContentPage
    {
        public static Grid Board { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            Board = board;

            LineMan();

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
        public static void InitPropiteis()
        {

        }
        

        public static double DegToRad(double angle)
        {
            return angle * Math.PI / 180d;
        }
    }
}


