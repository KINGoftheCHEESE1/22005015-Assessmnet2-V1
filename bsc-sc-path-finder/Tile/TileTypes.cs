using System.Drawing;

namespace bsc_sc_path_finder
{
    public class FloorTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.floor; } }
        public bool IsWalkable { get { return true; } }
    }

    public class RockTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.rock; } }
        public bool IsWalkable { get { return false; } }
    }

    public class CraterTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.crater; } }
        public bool IsWalkable { get { return false; } }
    }

    public class CheckBotanist : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_botanist; } }
        public bool IsWalkable { get { return true; } }

    }
    public class CheckFootprint : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_footprint; } }
        public bool IsWalkable { get { return true; } }
    }

    public class CheckRadiation : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_radiation; } }
        public bool IsWalkable { get { return true; } }
    }

    public class Flag : ITileType
    {
        public Image Sprite { get { return Properties.Resources.flag; } }
        public bool IsWalkable { get { return true; } }

    }
    public class GetToolbox : ITileType
    {
        public Image Sprite { get { return Properties.Resources.get_toolbox; } }
        public bool IsWalkable { get { return true; } }
    }

    public class PanelDust : ITileType
    {
        public Image Sprite { get { return Properties.Resources.panel_dust; } }
        public bool IsWalkable { get { return true; } }
    }

    public class SoilSample : ITileType
    {
        public Image Sprite { get { return Properties.Resources.soil_sample; } }
        public bool IsWalkable { get { return true; } }

    }
}
