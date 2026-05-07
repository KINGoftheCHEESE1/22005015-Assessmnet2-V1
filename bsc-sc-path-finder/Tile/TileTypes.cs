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


    /// <summary>
    /// details for the check botanist tile type, used to draw job on map
    /// </summary>
    public class CheckBotanist : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_botanist; } }
        public bool IsWalkable { get { return true; } }

    }

    /// <summary>
    /// details for the check Footprints tile type, used to draw job on map
    /// </summary>
    public class CheckFootprint : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_footprint; } }
        public bool IsWalkable { get { return true; } }
    }

    /// <summary>
    /// details for the check radiation tile type, used to draw job on map
    /// </summary>
    public class CheckRadiation : ITileType
    {
        public Image Sprite { get { return Properties.Resources.check_radiation; } }
        public bool IsWalkable { get { return true; } }
    }

    /// <summary>
    /// details for the flag tile type, used to draw job on map
    /// </summary>
    public class Flag : ITileType
    {
        public Image Sprite { get { return Properties.Resources.flag; } }
        public bool IsWalkable { get { return true; } }

    }

    /// <summary>
    /// details for the get toolbox tile type, used to draw job on map
    /// </summary>
    public class GetToolbox : ITileType
    {
        public Image Sprite { get { return Properties.Resources.get_toolbox; } }
        public bool IsWalkable { get { return true; } }
    }

    /// <summary>
    /// details for the Panel Dust tile type, used to draw job on map
    /// </summary>
    public class PanelDust : ITileType
    {
        public Image Sprite { get { return Properties.Resources.panel_dust; } }
        public bool IsWalkable { get { return true; } }
    }

    /// <summary>
    /// details for the Soil Sample tile type, used to draw job on map
    /// </summary>
    public class SoilSample : ITileType
    {
        public Image Sprite { get { return Properties.Resources.soil_sample; } }
        public bool IsWalkable { get { return true; } }

    }
}
