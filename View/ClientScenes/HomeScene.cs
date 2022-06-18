using System.Diagnostics;
using Umbra_Mod_Menu.Model;
using Umbra_Mod_Menu.Model.Controls;

namespace Umbra_Mod_Menu.View.ClientScenes;

internal class HomeScene : Scene
{
    private System.Windows.Forms.Timer _gameRunning;
    private byte[] _umbraClientDll;
    public HomeScene(Menu owner, Point location, Size size) : base(owner, location, size)
    {
        // _umbraClientDll = Properties.Resources.NewVersion
        var umbraLogo = new PictureBox();
        umbraLogo.Image = Properties.Resources.UmbraROR2_logo;
        umbraLogo.Location = new Point(owner.Width / 2 - 45, owner.Height / 2 - 130);
        umbraLogo.Size = new Size(150, 150);
        umbraLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        Controls.Add(umbraLogo);
        
        // Inject button
        var injectButton = new Button
        {
            Text = "Open game to inject...",
            Enabled = false,
            FlatStyle = Styles.DefaultMainNavButtonStyle.FlatStyle,
            ForeColor = Color.Gray,
            BackColor = Color.SteelBlue,
            Size = new Size(150, 50),
            Location = new Point(umbraLogo.Left, owner.Height - 127),
        };

        injectButton.EnabledChanged += (sender, e) =>
        {
            if (injectButton.Enabled)
            {
                injectButton.BackColor = Styles.DefaultMainNavButtonStyle.BackColor;
                injectButton.ForeColor = Styles.DefaultMainNavButtonStyle.ForeColor;
                injectButton.Text = "Inject";
            } else
            {
                injectButton.BackColor = Color.SteelBlue;
                injectButton.ForeColor = Color.Gray;
                injectButton.Text = "Open game to inject...";
            }
        };
        Controls.Add(injectButton);

        _gameRunning = new System.Windows.Forms.Timer();
        _gameRunning.Interval = 1500;
        _gameRunning.Tick += (sender, e) =>
        {
            var processes = Process.GetProcessesByName("Risk of Rain 2");
            if (processes.Length > 0)
            {
                injectButton.Enabled = true;
            } else
            {
                injectButton.Enabled = false;
            }
        };
        _gameRunning.Start();


        injectButton.Click += (sender, e) => Inject();
        
        // Version Drop Down Logic
        var versionSelect = new FlatComboBox 
        {
            Location = new Point(injectButton.Left, injectButton.Top - 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
            BackColor = owner.BackColor,
            ForeColor = Color.SteelBlue,
            DisplayMember = "Text",
            ValueMember = "ID",
            Size = new Size(injectButton.Width, 25),
            FlatStyle = FlatStyle.Popup,
            BorderColor = Color.SteelBlue,
            ButtonColor = Styles.DefaultMainNavButtonStyle.CheckedBack,
        };
        versionSelect.Items.Add(new ComboItem(0, "v3.0.0"));
        versionSelect.Items.Add(new ComboItem(1, "Legacy"));
        versionSelect.SelectionChangeCommitted += (sender, e) =>
        {
            if (versionSelect.SelectedIndex == 0)
            {
                // _umbraClientDll = Properties.Resources.NewVersion
            }
            else if (versionSelect.SelectedIndex == 1)
            {
                _umbraClientDll = Properties.Resources.UmbraMenuLegacy;
            }
        };
        versionSelect.SelectedIndex = 0;
        Controls.Add(versionSelect);

        versionSelect.BringToFront();
    }
    
    private void Inject()
    {
        var injector = new SharpMonoInjector.Injector("Risk of Rain 2");
        try { injector.Inject(_umbraClientDll, "UmbraMenu", "Loader", "Load"); } catch { /* Log error */ }
        _gameRunning.Stop();
        // Start Server, listen for injection complete
        // Start MainMenu
        Owner.Close();
    }
}