using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using static MouseColorIndicator.ImageProcessor;

namespace MouseColorIndicator
{
    public partial class Form1 : Form
    {
        // Eliref: https://github.com/andywu188/globalmousekeyhook
        private IKeyboardMouseEvents? m_GlobalHook;
        private bool hookState;
        private int matchCount;
        private Mat imgtemp = new Mat(@"D:\ProjectEli\MouseColorIndicator\imim.png");
        private double threshold;
        private Pen redPen = new Pen(Brushes.Red, 1);
        private List<(int,int)>? boxpoints;

        private (int X,int Y) mouseLocation = (0,0);

        // Timer in UI thread. Possibility of UI hang for long work
        // ref: https://www.csharpstudy.com/Threads/timer.aspx
        // for dispatchertimer, use WPF instead of winForms
        // for elegant queueing, https://stackoverflow.com/questions/10543422/windows-forms-loops-and-threading
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            matchCount= 0;
            threshold = 0.99;

            timer.Enabled= false;
            timer.Interval= 10; // ms
            timer.Tick += new EventHandler(OnTimedEvent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hookState = false;
        }

        private void GlobalHookMouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = (e.X, e.Y);
            mousePosLabel.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y); // waiting for GC
            //mousePosLabel.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hookState) {
                Unsubscribe();
                hookState= false;
                hookStateLabel.Text = "Off";
               
            } 
            else {
                Subscribe();
                hookState = true;
                hookStateLabel.Text = "On";
            }
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseMove += GlobalHookMouseMove;
            
            timer.Enabled= true;
            timer.Start();
        }

        public void Unsubscribe()
        {
            if (m_GlobalHook != null)
            {
                m_GlobalHook.MouseMoveExt -= GlobalHookMouseMove;
                m_GlobalHook.Dispose();
                //redPen.Dispose();
                mousePosLabel.Text = "unidentified";

                timer.Enabled= false;
            }            
        }

        

        private void OnTimedEvent(Object sender, EventArgs e)
        {
            FindImage();
        }

        private void FindImage()
        {
            matchCount = 0;
            boxpoints = new List<(int, int)>();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }

            Bitmap img = CaptureMouseRegion(mouseLocation.X, mouseLocation.Y);
            //Bitmap img = CaptureScreen();
            Graphics graphics = Graphics.FromImage(img); // disposing this is important (memory leak)

            // img to mat using opencvsharp
            // ref: https://kanais2.tistory.com/307
            Mat mimg = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);

            // convert matrix without memory violation
            // ref: https://answers.opencv.org/question/4811/convertto-from-cv_32f-to-cv_8u/
            // Todo: pull out conversion process from event loop and reduce duplication
            Mat imgtemp_8UC3 = new Mat();
            imgtemp.ConvertTo(imgtemp_8UC3, MatType.CV_8UC3);
            Mat imgtemp_8UC4 = new Mat();
            Cv2.CvtColor(imgtemp_8UC3, imgtemp_8UC4, ColorConversionCodes.BGR2BGRA);
            imgtemp_8UC3.Dispose();

            // template matching to result
            Mat result = new Mat();
            Cv2.MatchTemplate(mimg, imgtemp_8UC4, result, TemplateMatchModes.CCorrNormed);
            mimg.Dispose();
            imgtemp_8UC4.Dispose();

            // loop to match result
            // Type specific Mat method
            // ref: https://github.com/shimat/opencvsharp/wiki/Accessing-Pixel
            var mat3 = new Mat<float>(result);
            var indexer = mat3.GetIndexer();
            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    double value = indexer[y, x];
                    if (value >= threshold)
                    {
                        Rectangle rect = new Rectangle(x, y, imgtemp.Width, imgtemp.Height);
                        graphics.DrawRectangle(redPen, rect);
                        matchCount++;
                        //boxpoints.Add((x,y));
                    }
                }
            }
            mat3.Dispose();
            result.Dispose();

            //matchCount = boxpoints.Count;

            //foreach ((int,int) boxpoint in boxpoints)
            //{
            //    boxpoint = (null, null);
            //}

            pictureBox1.Image = img;

            graphics.Dispose();
            //pictureBox1.Refresh();


            //pictureBox1.Image = img;
            //graphics.Dispose();
            //mat.Dispose();
            //result.Dispose();

            imageCountsLabel.Text = string.Format("{0}", matchCount);


            
            //imageCountsLabel.Refresh();

            //pictureBox1.Image.Dispose();
            //GC.Collect();
        }
    }
}