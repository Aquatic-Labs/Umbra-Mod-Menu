namespace Umbra_Mod_Menu.Model.Controls;

internal class Scene : Panel
{
    public Menu Owner { get; }
    public Scene(Menu owner, Point location, Size size)
    {
        Owner = owner;
        Location = PointToScreen(location);
        Size = size;
        Hide();
        owner.Controls.Add(this);
    }
}