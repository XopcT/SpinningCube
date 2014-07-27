using GraphicsEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace SpinningCube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles loading the Window.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GraphicsFactory factory = new GraphicsFactory();

            IRenderer renderer = factory.CreateRenderer();

            Scene scene = new Scene();
            scene.Camera = new Camera();
            scene.Model = renderer.ContentManager.LoadCube(2.0f);

            this.screen.Renderer = renderer;
            this.screen.Scene = scene;

        }


    }
}
