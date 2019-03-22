using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
        private Brush _strokeColor;
        private Brush _fillColor;
        public string Btn1Text { get { return _btn1Text; } set { _btn1Text = value; } }
        public string Btn2Text { get { return _btn2Text; } set { _btn2Text = value; } }
        public string Btn3Text { get { return _btn3Text; } set { _btn3Text = value; } }
        public string Btn4Text { get { return _btn4Text; } set { _btn4Text = value; } }
        public Brush StrokeColor { get { return _strokeColor; } set { _strokeColor = value;} }
        public Brush FillColor { get { return _fillColor; } set { _fillColor = value; } }
        
        public Line line = new Line();
        public Rectangle rectangle = new Rectangle();
        public Ellipse ellipse = new Ellipse();
        public Polyline polyline = new Polyline();
        public PointCollection myPointCollection2 = new PointCollection();
        public string DrawObject;
        public Point p1;
        public Point p2;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Btn1Text = "circle";
            Btn2Text = "rectangle";
            Btn3Text = "line";
            Btn4Text = "free draw";
            StrokeColor = new SolidColorBrush(Colors.Black);
            
            drawCanvas.MouseDown += drawCanvas_MouseDown;
            drawCanvas.MouseMove += drawCanvas_MouseMove;
        }

        //Button Control
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

            //Checks which shape to draw, creates and sets the shapes values, and adds the to the canvas
            if (DrawObject == Btn1Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                ellipse = new Ellipse
                {
                    Fill = FillColor,
                    Stroke = StrokeColor,
                    StrokeThickness = 2
                };
                drawCanvas.Children.Add(ellipse);            
            }
            else if (DrawObject == Btn2Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                rectangle = new Rectangle()
               {
                    Fill = FillColor,
                    Stroke = StrokeColor,
                    StrokeThickness = 2
                };
                drawCanvas.Children.Add(rectangle);
            }
            else if (DrawObject == Btn3Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                line = new Line()
                {
                    Stroke = StrokeColor,
                    StrokeThickness = 2
                };
                drawCanvas.Children.Add(line);
            }
            else if (DrawObject == Btn4Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                polyline = new Polyline()
                {
                    Stroke = StrokeColor,
                    StrokeThickness = 2
                };
                drawCanvas.Children.Add(polyline);
            }
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            //Check which shape to draw, and then draw
            if (DrawObject == Btn1Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                p2 = e.GetPosition(drawCanvas);

                double minX = Math.Min(p2.X, p1.X);
                double minY = Math.Min(p2.Y, p1.Y);
                double maxX = Math.Max(p2.X, p1.X);
                double maxY = Math.Max(p2.Y, p1.Y);
                
                double height = Math.Abs(maxY - minY);
                double width = Math.Abs(maxX - minX);

                ellipse.Height = height;
                ellipse.Width = width;

                double left = p1.X - (width / 2);
                double top = p1.Y - (height / 2);
                double right = -1*(p1.X - (width / 2));
                double bottom = -1*(p1.Y - (height / 2));

                ellipse.Margin = new Thickness(left, top,right , bottom);
            }
            else if (DrawObject == Btn2Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                p2 = e.GetPosition(drawCanvas);

                double minX = Math.Min(p2.X, p1.X);
                double minY = Math.Min(p2.Y, p1.Y);
                double maxX = Math.Max(p2.X, p1.X);
                double maxY = Math.Max(p2.Y, p1.Y);
                
                double height = Math.Abs(maxY - minY);
                double width = Math.Abs(maxX - minX);

                rectangle.Height = height;
                rectangle.Width = width;

                double left = p1.X - (width / 2);
                double top = p1.Y - (height / 2);
                double right = -1 * (p1.X - (width / 2));
                double bottom = -1 * (p1.Y - (height / 2));

                rectangle.Margin = new Thickness(left, top, right, bottom);
            }
            else if (DrawObject == Btn3Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                line.X1 = p1.X;
                line.Y1 = p1.Y;
                line.X2 = e.GetPosition(drawCanvas).X;
                line.Y2 = e.GetPosition(drawCanvas).Y;
            }
            else if (DrawObject == Btn4Text.ToLower().ToString() && e.LeftButton == MouseButtonState.Pressed)
            {
                p2 = e.GetPosition(drawCanvas);
                polyline.Points.Add(p2);
            }

        }

        
        //To change the drawing colors and to set the display for which colors you are using.
        private void StrokeCol_1_Click(object sender, RoutedEventArgs e)
        {
            StrokeColor = new SolidColorBrush(Colors.Red);
            strokeRect.Fill = StrokeColor;
        }

        private void StrokeCol_2_Click(object sender, RoutedEventArgs e)
        {
            StrokeColor = new SolidColorBrush(Colors.Yellow);
            strokeRect.Fill = StrokeColor;
        }

        private void StrokeCol_3_Click(object sender, RoutedEventArgs e)
        {
            StrokeColor = new SolidColorBrush(Colors.Green);
            strokeRect.Fill = StrokeColor;
        }

        private void FillCol_1_Click(object sender, RoutedEventArgs e)
        {
            FillColor = new SolidColorBrush(Colors.Red);
            fillRect.Fill = FillColor;
        }

        private void FillCol_2_Click(object sender, RoutedEventArgs e)
        {
            FillColor = new SolidColorBrush(Colors.Yellow);
            fillRect.Fill = FillColor;
        }

        private void FillCol_3_Click(object sender, RoutedEventArgs e)
        {
            FillColor = new SolidColorBrush(Colors.Green);
            fillRect.Fill = FillColor;
        }
    }
}

