﻿using CloudPoints.Clases;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CloudPoints
{
    public class Controller
    {

        int NumPoints;

        public MainWindow GUI { get; set; }
        public Escenario escenario;

        public Controller(int numPoints, MainWindow mainWindow)
        {
            NumPoints = numPoints;
            GUI = mainWindow;

        }

        public async Task Init(double width, double height)
        {
            escenario = new Escenario(NumPoints, width, height);
            await Paint(escenario);
        }

        public async Task Paint(Escenario e)
        {
            await Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => GUI.InitEnvironment(e)), DispatcherPriority.Background);
        }

        internal async void getNxN()
        {
            Punto[] result = escenario.getNxN();
            await Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => GUI.PaintResult(result, "NxN")), DispatcherPriority.Background);
        }


        internal async void getNxlogN()
        {
            Punto[] result = escenario.getNxlogN();
            await Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => GUI.PaintResult(result, "NxlogN")), DispatcherPriority.Background);
        }




    }
}
