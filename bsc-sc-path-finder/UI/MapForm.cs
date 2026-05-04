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

        public void OnPathAnimationComplete()
        {
            MessageBox.Show("Move operation complete");

            removeGridTask();
        }

        public void removeGridTask()
        {
            Job location = jobManager.GetJob();

            grid.GetTile(location.Location.X, location.Location.Y).Type = new FloorTileType();

            Panel_Map.Invalidate();

            jobManager.RemoveJob();

            Lbl_JobList.Text = jobManager.createList();
        }

        private void Btn_ExecuteJob_Click(object sender, EventArgs e)
        {
            Job location = jobManager.GetJob();

            Lbl_RobotStatus.Text = $"Moving to {location.Description}";

            var path = dumbPathFinder.FindPath(robot.Position, location.Location);
            pathAnimator.Start(path);
            
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

            Job newJob = new Job(0, JobLocation, " ");


            if (task == 0)
            {
                JobLocation = new Point(2, 2);

                newJob = new Job(1, JobLocation, "check-botanist");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new CheckBotanist();

            }

            if (task == 1)
            {
                JobLocation = new Point(4, 6);

                newJob = new Job(2, JobLocation, "check-Footprint");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new CheckFootprint();
            }

            if (task == 2)
            {
                JobLocation = new Point(7, 4);

                newJob = new Job(3, JobLocation, "check-radiation");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new CheckRadiation();
            }

            if (task == 3)
            {
                JobLocation = new Point(9, 1);

                newJob = new Job(4, JobLocation, "flag");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new Flag();
            }

            if (task == 4)
            {
                JobLocation = new Point(4, 4);

                newJob = new Job(5, JobLocation, "get-toolbox");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new GetToolbox();
            }

            if (task == 5)
            {
                JobLocation = new Point(7, 7);

                newJob = new Job(6, JobLocation, "panel-dust");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new PanelDust();
            }

            if (task == 6)
            {
                JobLocation = new Point(18, 19);

                newJob = new Job(7, JobLocation, "soil-sample");

                grid.GetTile(JobLocation.X, JobLocation.Y).Type = new SoilSample();
            }


            jobManager.AddJob(newJob, newJob.Priority);

            Panel_Map.Invalidate();

            Lbl_JobList.Text = jobManager.createList();
        }
        
        private void Lbl_RobotStatus_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void Lbl_JobList_Click(object sender, EventArgs e)
        {

        }

    }
}


