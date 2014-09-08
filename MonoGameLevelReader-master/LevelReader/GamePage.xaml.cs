using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;


namespace LevelReader
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly LevelReaderTestGame _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<LevelReaderTestGame>.Create(launchArguments, Window.Current.CoreWindow, this);
        }
    }
}
