using System.Windows;
using GraphicsEngine;
using System.IO;
using System.Reflection;

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
            // Creating Renderer:
            IRenderer renderer = factory.CreateRenderer();

            // Creating Scene:
            Scene scene = new Scene();
            scene.Camera = new Camera() { PositionX = 0.0f, PositionY = 0.0f, PositionZ = -5.0f, Fov = (float)System.Math.PI / 2.0f, NearPlane = 0.5f, FarPlane = 200.0f };
            scene.Model = renderer.ContentManager.LoadCube(2.0f);
            scene.Model.Effect = renderer.ContentManager.LoadEffect(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Content\\Effect.fx"));

            // Setting up Renderer and Scene to the DirectX Element:
            this.screen.Renderer = renderer;
            this.screen.Scene = scene;
        }

    }
}
