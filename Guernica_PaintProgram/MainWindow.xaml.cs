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

        //enum  {ellipse, rectangle, line, freeHand}
        public Line line = new Line();
        public Rectangle rectangle = new Rectangle();
        public Ellipse ellipse = new Ellipse();
        
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

            drawCanvas.MouseDown += drawCanvas_MouseDown;
            drawCanvas.MouseUp += drawCanvas_MouseUp;
            drawCanvas.MouseMove += drawCanvas_MouseMove;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn1Text.ToLower().ToString();
            btn1.IsEnabled = false;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            
        }
        
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn2Text.ToLower().ToString();
            btn1.IsEnabled = true;
            btn2.IsEnabled = false;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn3Text.ToLower().ToString();
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = false;
            btn4.IsEnabled = true;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            DrawObject = Btn4Text.ToLower().ToString();

            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = false;
        }

        private void drawCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            p1 = e.GetPosition(drawCanvas);
            
            

            if (DrawObject == Btn1Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                ellipse = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Red),
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 4
                    
                };
                drawCanvas.Children.Add(ellipse);
                               
            }
            else if (DrawObject == Btn2Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
               rectangle = new Rectangle();
                
                
            }
            else if (DrawObject == Btn3Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {              
                    line = new Line();
                
                    drawCanvas.Children.Add(line);
            }
            else if (DrawObject == Btn4Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (DrawObject == Btn1Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                p2 = e.GetPosition(drawCanvas);

                double minX = Math.Min(p2.X, p1.X);
                double minY = Math.Min(p2.Y, p1.Y);
                double maxX = Math.Max(p2.X, p1.X);
                double maxY = Math.Max(p2.Y, p1.Y);

                
                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                double left = p1.X - (width /2);
                double top = p1.Y - (height /2);

                
                ellipse.Margin = new Thickness(left, top, 0, 0);

            }
            else if (DrawObject == Btn2Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {

            }
            else if (DrawObject == Btn3Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {

                line.Stroke = System.Windows.Media.Brushes.Black;
                line.X1 = p1.X;
                line.Y1 = p1.Y;
                line.X2 = e.GetPosition(drawCanvas).X;
                line.Y2 = e.GetPosition(drawCanvas).Y;
            }
            else if (DrawObject == Btn4Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {

            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }

        private void drawCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            if (DrawObject == Btn1Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Released)
            {
                
            }
            else if (DrawObject == Btn2Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Released)
            {

            }
            else if (DrawObject == Btn3Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Released)
            {
                line.Stroke = System.Windows.Media.Brushes.Black;
                line.X1 = p1.X;
                line.Y1 = p1.Y;
                p2 = e.GetPosition(drawCanvas);
                line.X2 = p2.X;
                line.Y2 = p2.Y;
            }
            else if (DrawObject == Btn4Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Released)
            {

            }
            


        }
        
    }
}

