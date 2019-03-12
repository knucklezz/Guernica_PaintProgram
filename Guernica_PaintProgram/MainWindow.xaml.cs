using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Guernica_PaintProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _btn1Text;
        private string _btn2Text;
        private string _btn3Text;
        private string _btn4Text;
        private string _strokeColor;
        private string _fillColor;
        public string Btn1Text { get { return _btn1Text; } set { _btn1Text = value; } }
        public string Btn2Text { get { return _btn2Text; } set { _btn2Text = value; } }
        public string Btn3Text { get { return _btn3Text; } set { _btn3Text = value; } }
        public string Btn4Text { get { return _btn4Text; } set { _btn4Text = value; } }
        public string StrokeColor { get { return _strokeColor; } set { _strokeColor = value; } }
        public string FillColor { get { return _fillColor; } set { _fillColor = value; } }
        public Line line = new Line();


        public string DrawObject;
        public Point p1;
        public Point p2;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Btn1Text = "Circle";
            Btn2Text = "Rectangle";
            Btn3Text = "Line";
            Btn4Text = "Free Draw";

            DrawObject = Btn1Text.ToLower().ToString();

            this.MouseDown += drawCanvas_MouseDown;
            this.MouseMove += drawCanvas_MouseMove;

        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn1Text.ToLower().ToString();

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn2Text.ToLower().ToString();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void drawCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                p1 = e.GetPosition(this);

            

        }
        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            
           
            drawCanvas.Children.Clear();

            if (e.LeftButton == MouseButtonState.Pressed)
            {

                line.Stroke = System.Windows.Media.Brushes.Black;
                line.X1 = p1.X;
                line.Y1 = p1.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                p2 = e.GetPosition(this);

                drawCanvas.Children.Add(line);
            }
        }
    }
}

