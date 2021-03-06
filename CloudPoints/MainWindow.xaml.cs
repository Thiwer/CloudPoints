﻿using CloudPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CloudPoints
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Controller controller;


        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new Controller(200, this);
            await controller.Init(CanvasEscenario.ActualWidth, CanvasEscenario.ActualHeight);
        }

        private void PointsNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }


        public void InitEnvironment(Escenario e)
        {

            CanvasEscenario.Children.Clear();

            PointCollection pointsCol = new PointCollection();

            foreach (Punto punto in e.Puntos)
            {
                Ellipse currentDot = new Ellipse();
                currentDot.Stroke = new SolidColorBrush(Colors.Green);
                currentDot.StrokeThickness = 3;
                Canvas.SetZIndex(currentDot, 3);
                currentDot.Height = 5;
                currentDot.Width = 5;
                currentDot.Fill = new SolidColorBrush(Colors.Green);
                currentDot.Margin = new Thickness(punto.X, punto.Y, 0, 0); // Sets the position.
                CanvasEscenario.Children.Add(currentDot);
            }

        }

        public void PaintResult(Punto[] result, string algorythm)
        {
            Console.WriteLine(algorythm);
            Console.WriteLine(Escenario.distancia(result[0], result[1]));
            foreach (Punto punto in result)
            {
                Console.WriteLine(punto.ToString());
                Ellipse currentDot = new Ellipse();
                currentDot.Stroke = new SolidColorBrush(Colors.Red);
                currentDot.StrokeThickness = 3;
                Canvas.SetZIndex(currentDot, 3);
                currentDot.Height = 5;
                currentDot.Width = 5;
                currentDot.Fill = new SolidColorBrush(Colors.Red);
                currentDot.Margin = new Thickness(punto.X, punto.Y, 0, 0); // Sets the position.
                CanvasEscenario.Children.Add(currentDot);
            }
        }


        private void NxN_Click(object sender, RoutedEventArgs e)
        {
            controller.getNxN();
        }

        private void NxlogN_Click(object sender, RoutedEventArgs e)
        {
            controller.getNxlogN();
        }

        private async void PointsNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                controller = new Controller(Convert.ToInt32(PointsNumber.Text), this);
                await controller.Init(CanvasEscenario.ActualWidth, CanvasEscenario.ActualHeight);
            }
        }
    }
}
