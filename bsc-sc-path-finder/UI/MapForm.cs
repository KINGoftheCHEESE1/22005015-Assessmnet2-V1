using bsc_sc_path_finder.Jobs;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bsc_sc_path_finder
{
    public partial class MapForm : Form
    {
        private GridRenderer gridRenderer;
        private Grid grid;
        private Robot robot;
        private DumbPathFinder dumbPathFinder;
        private PathAnimator pathAnimator;
        private int task;
        private Point JobLocation;
        private JobManager jobManager;

        public MapForm()
        {
            InitializeComponent();

            jobManager = new JobManager();

            // Enable double buffering to avoid flicker on panel paint
            Panel_Map.GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(Panel_Map, true, null);
        }

        private void Btn_LoadMap_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text Files|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                InitGridFromFile(dialog.FileName);
            }
        }

        private void InitGridFromFile(string filePath)
        {
            try
            {
                // Call to parse map file returning formed Grid object and robot starting position
                Point robotStart = new Point();
                (grid, robotStart) = GridLoader.LoadFromFile(filePath);
                robot = new Robot(robotStart);

                // Setup renderer, dumb path finder and animator to use this new map
                gridRenderer = new GridRenderer(grid);
                dumbPathFinder = new DumbPathFinder();
                pathAnimator = new PathAnimator(robot, Panel_Map);

                Lbl_RobotStatus.Text = "> New map loaded";
                Panel_Map.Invalidate(); // Force re-draw
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Map load failed: {ex.Message}");
            }
        }

        private void Panel_Map_Paint(object sender, PaintEventArgs e)
        {            
            if (gridRenderer != null) gridRenderer.Draw(e.Graphics, robot);            
        }

        private void Panel_Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (grid == null) return;

            int tileX = e.X / gridRenderer.TileSize;
            int tileY = e.Y / gridRenderer.TileSize;

            // Check bounds
            if (tileX < 0 || tileX >= grid.Width || tileY < 0 || tileY >= grid.Height) return;

            Tile clickedTile = grid.GetTile(tileX, tileY);

            // Animate to clicked cell using dumb path finder
            try
            {
                var path = dumbPathFinder.FindPath(robot.Position, new Point(clickedTile.X, clickedTile.Y));
                pathAnimator.Start(path);
                Lbl_RobotStatus.Text = $"Moving to {clickedTile.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load grid: {ex.Message}");
            }
        }

        public static void OnPathAnimationComplete()
        {
            MessageBox.Show("Move operation complete");
        }

        private void Btn_ExecuteJob_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_RobotStatus_Click(object sender, EventArgs e)
        {

        }

        private void CB_Implementation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Implementation.SelectedIndex == 0)
            {
                task = 0;
            }

            if (CB_Implementation.SelectedIndex == 1)
            {
                task = 1;
            }

            if (CB_Implementation.SelectedIndex == 2)
            {
                task = 2;
            }

            if (CB_Implementation.SelectedIndex == 3)
            {
                task = 3;
            }

            if (CB_Implementation.SelectedIndex == 4)
            {
                task = 4;
            }

            if (CB_Implementation.SelectedIndex == 5)
            {
                task = 5;
            }

            if (CB_Implementation.SelectedIndex == 6)
            {
                task = 6;
            }
        }

        private void btn_CreateJob_Click(object sender, EventArgs e)
        {
            if(task == 0)
            { 
                JobLocation = new Point(2, 2);

                Job Botanist = new Job(1, JobLocation, "check-botanist");

                jobManager.AddJob(Botanist, Botanist.Priority);

                MessageBox.Show("Check botanist job added");

            }

            if (task == 1)
            {
                JobLocation = new Point(4, 6);

                Job Footprints = new Job(2, JobLocation, "check-Footprint");

                jobManager.AddJob(Footprints, Footprints.Priority);

                MessageBox.Show("Check footprints job added");
            }

            if (task == 2)
            {
                JobLocation = new Point(7, 4);

                Job Radtiation = new Job(3, JobLocation, "check-radiation");

                jobManager.AddJob(Radtiation, Radtiation.Priority);

                MessageBox.Show("Check radiation job added");
            }

            if (task == 3)
            {
                JobLocation = new Point(9, 1);

                Job Flag = new Job(4, JobLocation, "flag");

                jobManager.AddJob(Flag, Flag.Priority);

                MessageBox.Show("view flag job added");
            }

            if (task == 4)
            {
                JobLocation = new Point(4, 4);

                Job Toolbox = new Job(5, JobLocation, "get-toolbox");

                jobManager.AddJob(Toolbox, Toolbox.Priority);

                MessageBox.Show("Gather toolbox job added");
            }

            if (task == 5)
            {
                JobLocation = new Point(7, 7);

                Job Panel = new Job(6, JobLocation, "panel-dust");

                jobManager.AddJob(Panel, Panel.Priority);

                MessageBox.Show("Dust Panel job added");
            }

            if (task == 6)
            {
                JobLocation = new Point(5, 9);

                Job Soil = new Job(7, JobLocation, "soil-sample");

                jobManager.AddJob(Soil, Soil.Priority);

                MessageBox.Show("Sample Soil job added");
            }
        }
    }
}
