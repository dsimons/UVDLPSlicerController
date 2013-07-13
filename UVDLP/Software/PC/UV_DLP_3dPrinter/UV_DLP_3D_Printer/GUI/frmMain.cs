using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
//using OpenTK.Graphics.OpenGL;
using System.IO.Ports;
using System.IO;
using System.Collections;
using UV_DLP_3D_Printer.GUI;

namespace UV_DLP_3D_Printer
{
    public partial class frmMain : Form
    {
        private enum eMOUSEMODE 
        {
            eView,
            eModelMove,
            eModelRotate,
            eModelScale
        }
        bool loaded = false;               
        //Engine3d UVDLPApp.Instance().Engine3D = new Engine3d();              
        frmDLP m_frmdlp = new frmDLP();
        frmSliceOptions m_frmsliceopt = new frmSliceOptions();
        frmControl m_frmcontrol = new frmControl();
        frm3DLPrinterControl m_frm3DLPControl = new frm3DLPrinterControl();
        frmSlice m_frmSlice = new frmSlice();
        frmGCodeRaw m_sendgcode = new frmGCodeRaw();
        frmMachineProfileManager m_machineprofilemanager = new frmMachineProfileManager();
        eMOUSEMODE m_mousemode = eMOUSEMODE.eView;
        Bitmap m_curslice = null; // this is used only for re-displaying the current slice.

        private bool lmdown, rmdown, mmdown;
        private int mdx, mdy;
        float orbitypos = 0;
        float orbitxpos = -80;
        float orbitdist = -200;
        float yoffset = -10.0f;
        float xoffset = 0.0f;
        public frmMain()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UVDLPApp.Instance().Engine3D.AddGrid();
            UVDLPApp.Instance().Engine3D.AddPlatCube();
            UVDLPApp.Instance().Engine3D.CameraReset();
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            UVDLPApp.Instance().m_buildmgr.PrintStatus += new delPrintStatus(PrintStatus);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            DebugLogger.Instance().LoggerStatusEvent += new LoggerStatusHandler(LoggerStatusEvent);
            UVDLPApp.Instance().m_deviceinterface.StatusEvent += new DeviceInterface.DeviceInterfaceStatus(DeviceStatusEvent);
            SetButtonStatuses();            
            SetMouseModeChecks();
            PopulateMachinesMenu();
            SetupSceneTree();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            // e.Graphics =  current slice graphics
        }

        private void PopulateMachinesMenu() 
        {
            //remove all items except the first 2
            for (int c = machineToolStripMenuItem.DropDownItems.Count; c > 3; c--) 
            {
                machineToolStripMenuItem.DropDownItems.RemoveAt(c-1);
            }
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
            string curprof = Path.GetFileNameWithoutExtension(UVDLPApp.Instance().m_printerinfo.m_filename);
            //create a new menu item for all machine profiles
            foreach (String profile in filePaths)
            {
                String pn = Path.GetFileNameWithoutExtension(profile);
                ToolStripMenuItem it = new ToolStripMenuItem(pn);
                it.Click += new EventHandler(mnuMachine_Click);
                machineToolStripMenuItem.DropDownItems.Add(it);
                if (curprof.Equals(pn)) // if this is the current profile, show as checked
                {
                    it.Checked = true;
                }

            }
        }

        private void SetTimeMessage(String message) 
        {
            lblTime.Text = message;
        }
        private void SetMainMessage(String message) 
        {
            lblMainMessage.Text = message;
        }
        /*
         This handles specific events triggered by the app
         */
        private void AppEventDel(eAppEvent ev, String Message) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
            }
            else
            {
                switch (ev) 
                {
                    case eAppEvent.eModelRemoved: 
                        //the current model was removed
                        ShowObjectInfo();
                        DisplayFunc();
                        break;
                    case eAppEvent.eGCodeLoaded:
                        break;
                    case eAppEvent.eGCodeSaved:
                        break;
                    case eAppEvent.eModelLoaded:
                        ShowObjectInfo();
                        DisplayFunc();
                        break;
                }
            }
        }
        private void SetButtonStatuses() 
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected)
            {
                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;
                cmdControl.Enabled = true;


                if (UVDLPApp.Instance().m_buildmgr.IsPrinting)
                {
                    if (UVDLPApp.Instance().m_buildmgr.IsPaused())
                    {
                        cmdBuild.Enabled = true;
                        cmdStop.Enabled = true;
                        cmdPause.Enabled = false;
                    }
                    else
                    {
                        cmdBuild.Enabled = false;
                        cmdStop.Enabled = true;
                        cmdPause.Enabled = true;
                    }
                }
                else
                {
                    cmdBuild.Enabled = true;
                    cmdStop.Enabled = false;
                    cmdPause.Enabled = false;
                }
            }
            else 
            {
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
                cmdControl.Enabled = false;
                cmdBuild.Enabled = false;
                cmdStop.Enabled = false;
                cmdPause.Enabled = false; // disable

            }
        }

        private void SetupSceneTree() 
        {
            treeScene.Nodes.Clear();//clear the old

            TreeNode scenenode = new TreeNode("Scene");
            treeScene.Nodes.Add(scenenode);
            foreach (Object3d obj in UVDLPApp.Instance().Engine3D.m_objects) 
            {
                obj.FindMinMax();
                TreeNode objnode = new TreeNode(obj.Name);
                objnode.Tag = obj;
                scenenode.Nodes.Add(objnode);
                //String minmax = "Nu
                String Numpoints = "Num Points = " + obj.NumPoints.ToString();
                objnode.Nodes.Add(Numpoints);
                String Numpolys = "Num Polys = " + obj.NumPolys.ToString();
                objnode.Nodes.Add(Numpolys);
                objnode.Nodes.Add("Min points = (" + String.Format("{0:0.00}", obj.m_min.x) + "," + String.Format("{0:0.00}", obj.m_min.y) + "," + String.Format("{0:0.00}", obj.m_min.z) + ")");
                objnode.Nodes.Add("Max points = (" + String.Format("{0:0.00}", obj.m_max.x) + "," + String.Format("{0:0.00}", obj.m_max.y) + "," + String.Format("{0:0.00}", obj.m_max.z) + ")");
                double xs, ys, zs;
                xs = obj.m_max.x - obj.m_min.x;
                ys = obj.m_max.y - obj.m_min.y;
                zs = obj.m_max.z - obj.m_min.z;                
                objnode.Nodes.Add("Size = (" + String.Format("{0:0.00}", xs) + "," + String.Format("{0:0.00}", ys) + "," + String.Format("{0:0.00}", zs) + ")");
                objnode.Nodes.Add("Wireframe = " + obj.m_wireframe.ToString());
                if (obj == UVDLPApp.Instance().m_selectedobject)  // expand this node
                {
                    objnode.Expand();
                    objnode.BackColor = Color.LightBlue;
                    treeScene.SelectedNode = objnode;
                }

            }
            scenenode.Expand();
             
        }
        /*
         This function is called when the device status changes
         * most of this is for display purposes only,
         * the real business logic should be held in the app class
         */
        void DeviceStatusEvent(ePIStatus status, String Command) 
        {
            switch (status) 
            {
                case ePIStatus.eConnected:
                    SetButtonStatuses();
                    DebugLogger.Instance().LogRecord("Device Connected");
                    break;
                case ePIStatus.eDisconnected:
                    SetButtonStatuses();
                    DebugLogger.Instance().LogRecord("Device Disconnected");
                    break;
                case ePIStatus.eError:
                    break;
                case ePIStatus.eReady:
                    break;
                case ePIStatus.eTimedout:
                    break;
            }
        }

        void LoggerStatusEvent(Logger o, eLogStatus status, string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LoggerStatusEvent(o, status, message); }));
            }
            else
            {                
                switch (status)
                {
                    case eLogStatus.eLogWroteRecord:
                        txtLog.Text = message + "\r\n" + txtLog.Text;
                        break;
                }
            }
        }

        void PrintStatus(ePrintStat printstat) 
        {
         // displays the print status
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintStatus(printstat); }));
            }
            else
            {
                String message = "";
                switch (printstat)
                {
                    case ePrintStat.ePrintPaused:
                        message = "Print Paused";
                        SetButtonStatuses();
                        break;
                    case ePrintStat.ePrintResumed:
                        message = "Print Resumed";
                        SetButtonStatuses();
                        break;
                    case ePrintStat.ePrintCancelled:
                        message = "Print Cancelled";
                        SetButtonStatuses();
                        break;
                    case ePrintStat.eLayerCompleted:
                        message = "Layer Completed";
                        break;
                    case ePrintStat.ePrintCompleted:
                        message = "Print Completed";
                        SetButtonStatuses();
                        MessageBox.Show("Build Completed");
                        break;
                    case ePrintStat.ePrintStarted:
                        message = "Print Started";
                        SetButtonStatuses();
                        if (!ShowDLPScreen()) 
                        {
                            MessageBox.Show("Monitor " + UVDLPApp.Instance().m_printerinfo.Monitorid + " not found, cancelling build","Error");
                            UVDLPApp.Instance().m_buildmgr.CancelPrint();
                        }
                        break;
                }
                SetMainMessage(message);
                DebugLogger.Instance().LogRecord(message);
            }
        }

        //This delegate is called when the print manager is printing a new layer
        void PrintLayer(Bitmap bmp, int layer,int layertype) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintLayer(bmp, layer,layertype); }));
            }
            else
            {
                ViewLayer(layer,bmp,layertype);
                // display info only if it's a normal layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    
                    String txt = "Printing layer " + (layer + 1) + " of " + UVDLPApp.Instance().m_slicefile.m_slices.Count;
                    DebugLogger.Instance().LogRecord(txt);
                }

            }
        }

        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev,layer, totallayers); }));
            }
            else
            {
                switch (ev)
                {
                    case Slicer.eSliceEvent.eSliceStarted:
                        SetMainMessage("Slicing Started");
                        break;
                    case Slicer.eSliceEvent.eLayerSliced:
                        break;
                    case Slicer.eSliceEvent.eSliceCompleted:
                        //show the gcode
                        txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                        vScrollBar1.Maximum = totallayers;
                        vScrollBar1.Value = 0;
                        SetMainMessage("Slicing Completed");
                        String timeest = BuildManager.EstimateBuildTime(UVDLPApp.Instance().m_gcode);
                        SetTimeMessage("Estimated Build Time: " + timeest);
                        break;
                }
            }
        }

        private void ShowObjectInfo() 
        {
            try
            {
                
                //UVDLPApp.Instance().m_selectedobject.FindMinMax();
                SetupSceneTree();
            }
            catch (Exception) { }
        
        }
        /*
         Load Stl
         */
        private void LoadSTLModel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                if (UVDLPApp.Instance().LoadModel(openFileDialog1.FileName) == false)
                {
                    MessageBox.Show("Error loading file " + openFileDialog1.FileName);
                }
                else 
                {
                    chkWireframe.Checked = false;
                    //DisplayFunc();
                    vScrollBar1.Maximum = 1;
                    vScrollBar1.Value = 0;
                    //ShowObjectInfo();
                }
            }
        }

        
        private void ViewLayer(int layer, Bitmap image, int layertype) 
        {
            try
            {
                // if this is a normal slice that is specified, move to the correct 3d view of the layer, 
                // otherwise, keep showing the current 3d layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    Slice sl = (Slice)UVDLPApp.Instance().m_slicefile.m_slices[layer];
                    UVDLPApp.Instance().Engine3D.RemoveAllLines();
                    UVDLPApp.Instance().Engine3D.AddGrid();
                    UVDLPApp.Instance().Engine3D.AddPlatCube();

                    foreach (PolyLine3d ln in sl.m_segments)
                    {
                        ln.m_color = Color.Red;
                        UVDLPApp.Instance().Engine3D.AddLine(ln);
                    }
                    DisplayFunc();
                }
                //render the 2d slice
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    bmp = UVDLPApp.Instance().m_slicefile.RenderSlice(layer);
                }
                else // the image was specified from the build manager
                {
                    bmp = image;
                }

                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    m_curslice = bmp;
                }

                //this bmp could be a normal, blank, or calibration image
                picSlice.Image = bmp;//now show the 2d slice
                m_frmdlp.ShowImage(bmp);
                
                //lblCurSlice.Text = "Layer = " +layer;
            }
            catch (Exception) { }
        
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int vscrollval = vScrollBar1.Value;
            ViewLayer(vscrollval,null,BuildManager.SLICE_NORMAL);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            SetupViewport();
        }

        private void SetupViewport()
        {
            if (!loaded)
                return;
            float aspect = 1.0f;
            try
            {
                int w = glControl1.Width;
                int h = glControl1.Height;
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                // Glu
                //GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
                GL.Ortho(0, w, 0, h, 1, 2000); // Bottom-left corner pixel has coordinate (0, 0)
                GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                aspect = ((float)glControl1.Width) / ((float)glControl1.Height);

                //GL.Matr
                GL.Enable(EnableCap.DepthTest); // for z buffer
                OpenTK.Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(0.55f, aspect, 1,2000);
                //GL.DepthRange(0, 2000);
                OpenTK.Matrix4 modelView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(5, 0, -5), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 0, 1));

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.LoadMatrix(ref projection);

                GL.ShadeModel(ShadingModel.Smooth);
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                float []mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float []mat_shininess = { 50.0f };
                GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
                GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);

               // GL.Enable(EnableCap.Blend); // alpha blending
                //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                
                float[] lightpos = new float[4];
                lightpos[0] = 5.0f;
                lightpos[1] = 15.0f;
                lightpos[2] = 10.0f;
                lightpos[3] = 1.0f;
                float []light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
                GL.Light(LightName.Light0, LightParameter.Position, light_position);
                
                
                GL.Enable(EnableCap.LineSmooth);
//glEnable(GL_LINE_SMOOTH);


                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.LoadMatrix(ref modelView);
            }
            catch (Exception ex) 
            {
                String s = ex.Message;
                // the create perspective function blows up on certain ratios
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            DisplayFunc();
        }


        private void DisplayFunc() 
        {
      
          /* Clear the buffer, clear the matrix */
          GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
          GL.LoadIdentity();

          GL.Translate(xoffset, yoffset, orbitdist);
          GL.Rotate(orbitypos, 0, 1, 0);
          GL.Rotate(orbitxpos, 1, 0, 0);

          UVDLPApp.Instance().Engine3D.RenderGL();
            
          GL.Flush();
           // glControl1.
          glControl1.SwapBuffers();                                    
        }

        
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;

            GL.ClearColor(Color.FromArgb(20, Color.LightBlue));
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
            SetupViewport();
        }

        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            switch (m_mousemode) 
            {
                case eMOUSEMODE.eView:
                    orbitdist += e.Delta/10;
                    break;
            }
            DisplayFunc();
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mdx = e.X;
            mdy = e.Y;
            if (e.Button == MouseButtons.Middle)
            {
                mmdown = true;
                // try to hit-test objects in scene here.
                HitTestScene(mdx, mdy);
            }
            
            if (e.Button == MouseButtons.Left)
            {
                lmdown = true;

            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = true;
            }
        }
        // functions:
        public Point convertScreenToWorldCoords(int x, int y)
        {
            int[] viewport = new int[4];
            Matrix4 modelViewMatrix, projectionMatrix;
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            GL.GetFloat(GetPName.ProjectionMatrix, out projectionMatrix);
            GL.GetInteger(GetPName.Viewport, viewport);
            Vector2 mouse;
            mouse.X = x;
            //mouse.Y = viewport[3] - y;
            mouse.Y = y + (ClientRectangle.Height - glControl1.Size.Height);
            Vector4 vector = UnProject(ref projectionMatrix, modelViewMatrix, new Size(viewport[2], viewport[3]), mouse);
            Point coords = new Point((int)vector.X, (int)vector.Y);
            return coords;
        }
        public Vector4 UnProject(ref Matrix4 projection, Matrix4 view, Size viewport, Vector2 mouse)
        {
            Vector4 vec;

            vec.X = 2.0f * mouse.X / (float)viewport.Width - 1;
            vec.Y = -(2.0f * mouse.Y / (float)viewport.Height - 1);
            vec.Z = 0;
            vec.W = 1.0f;

            Matrix4 viewInv = Matrix4.Invert(view);
            Matrix4 projInv = Matrix4.Invert(projection);

            Vector4.Transform(ref vec, ref projInv, out vec);
            Vector4.Transform(ref vec, ref viewInv, out vec);

            if (vec.W > float.Epsilon || vec.W < float.Epsilon)
            {
                vec.X /= vec.W;
                vec.Y /= vec.W;
                vec.Z /= vec.W;
            }

            return vec;
        }
        private void HitTestScene(int x, int y) 
        {
            //GL.u
            Point pnt = convertScreenToWorldCoords(x, y);
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                mmdown = false;
            }
            if (e.Button == MouseButtons.Left)
            {
                lmdown = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = false;
            }

        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            double dx = 0, dy = 0;
            if (lmdown || rmdown || mmdown)
            {
                dx = e.X - mdx;
                dy = e.Y - mdy;
                mdx = e.X;
                mdy = e.Y;
            }
            dx /= 2;
            dy /= 2;

            switch (m_mousemode) 
            {
                case eMOUSEMODE.eView:
                    if (lmdown)
                    {
                        orbitypos += (float)dx;
                        orbitxpos += (float)dy;
                    }else if (mmdown)
                    {
                        orbitdist += (float)dy;                        
                    }
                    else if (rmdown)
                    {
                        yoffset += (float)dy/2;
                        xoffset += (float)dx/2;
                    }
                    break;
                case eMOUSEMODE.eModelMove:
                    dx /= 3;
                    dy /= 3;
                    Object3d obj = UVDLPApp.Instance().m_selectedobject;
                    if (obj != null) 
                    {
                        obj.Translate((float)dx, (float)-dy, 0);                     
                    }
                    break;
                case eMOUSEMODE.eModelScale:
                    dx /= 20;
                    dy /= 6;
                    dx += 1.0;
                    Object3d obj3 = UVDLPApp.Instance().m_selectedobject;                   
                    if (obj3 != null && dx != 0.0)
                    {
                        obj3.Scale((float)dx);
                    }
                    break;
                case eMOUSEMODE.eModelRotate:
                    dx /= 3;
                    dy /= 3;
                    Object3d obj2 = UVDLPApp.Instance().m_selectedobject;
                    if (obj2 != null) 
                    {
                        if (lmdown)
                        {
                            obj2.Rotate((float)dx * 0.0174532925f, 0, 0);
                        }
                        else if (mmdown)
                        {
                            obj2.Rotate(0,(float)dx * 0.0174532925f, 0);
                        }
                        else if (rmdown)
                        {
                            obj2.Rotate(0,0,(float)dx * 0.0174532925f);
                        }

                    }
                    break;
            }
            DisplayFunc();
        }

        private void glControl1_MouseLeave(object sender, EventArgs e)
        {
            //should cancel any move commands
        }

        private void chkWireframe_CheckedChanged(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_selectedobject == null) return;
            UVDLPApp.Instance().m_selectedobject.m_wireframe = chkWireframe.Checked;
            DisplayFunc();
        }

        private void cmdCenter_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_selectedobject == null) return;
            Point3d center = UVDLPApp.Instance().m_selectedobject.CalcCenter();
            UVDLPApp.Instance().m_selectedobject.Translate((float)-center.x, (float)-center.y,(float) -center.z);
            ShowObjectInfo();
            DisplayFunc();
        }

        private void cmdStartPrint_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_buildmgr.IsPaused())
            {
                UVDLPApp.Instance().m_buildmgr.ResumePrint();
            }
            else
            {
                UVDLPApp.Instance().m_buildmgr.StartPrint(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_gcode);
            }
        }
        private void cmdPause_Click(object sender, EventArgs e)
        {
            //UVDLPApp.Instance().m_buildmgr.StartPrint(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_gcode);
        }
        private void cmdPlace_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_selectedobject == null) 
                return;
            Point3d center = UVDLPApp.Instance().m_selectedobject.CalcCenter();
            UVDLPApp.Instance().m_selectedobject.FindMinMax();
            float zlev = (float)UVDLPApp.Instance().m_selectedobject.m_min.z;

            UVDLPApp.Instance().m_selectedobject.Translate((float)0, (float)0, (float)-zlev);
            ShowObjectInfo();
            DisplayFunc();
        }

        private void cmdScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null) 
                    return;
                float sf = Single.Parse(txtScale.Text);
                UVDLPApp.Instance().m_selectedobject.Scale(sf);
                ShowObjectInfo();
                DisplayFunc();

            }
            catch (Exception) 
            {
            
            }
        }



        private void cmdSliceOptions_Click(object sender, EventArgs e)
        {
            m_frmsliceopt.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadBinarySTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSTLModel_Click(this, null);
        }

        private void slicingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdSliceOptions_Click(this, null);
        }

        private void machinePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMachineConfig mf = new frmMachineConfig(ref UVDLPApp.Instance().m_printerinfo);
            mf.ShowDialog();
            UVDLPApp.Instance().Engine3D.RemoveAllLines();
            UVDLPApp.Instance().Engine3D.AddGrid();
            UVDLPApp.Instance().Engine3D.AddPlatCube();
            DisplayFunc();
            //
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildmgr.CancelPrint();
        }

        

        private void cmdConnect1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UVDLPApp.Instance().m_deviceinterface.Connected) // 
                {
                    UVDLPApp.Instance().m_deviceinterface.Configure(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection);
                    String com = UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.comname;
                    DebugLogger.Instance().LogRecord("Connecting to Printer on " + com + " using " + UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_drivertype.ToString());
                    if (!UVDLPApp.Instance().m_deviceinterface.Connect()) 
                    {
                        DebugLogger.Instance().LogRecord("Cannot connect printer driver on " + com);
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected) // disconnect
            {
                DebugLogger.Instance().LogRecord("Disconnecting from Printer");
                UVDLPApp.Instance().m_deviceinterface.Disconnect();
            }
        }

        private void cmdControl_Click(object sender, EventArgs e)
        {
            switch (UVDLPApp.Instance().m_deviceinterface.Driver.DriverType) 
            {
                case Drivers.eDriverType.eGENERIC:
                case Drivers.eDriverType.eNULL_DRIVER:
                    if (m_frmcontrol.IsDisposed)
                    {
                        m_frmcontrol = new frmControl();
                    }
                    m_frmcontrol.Show();
                    break;
                case Drivers.eDriverType.eRF_3DLPRINTER:
                    if (m_frm3DLPControl.IsDisposed) 
                    {
                        m_frm3DLPControl = new frm3DLPrinterControl();
                    }
                    m_frm3DLPControl.Show();
                    break;
            }

        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnection frmconnect = new frmConnection();
            frmconnect.ShowDialog();
        }

        private void cmdSlice1_Click(object sender, EventArgs e)
        {
            if (m_frmSlice.IsDisposed) 
            {
                m_frmSlice = new frmSlice();
            }
            m_frmSlice.Show();
        }

        private void sendGCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_sendgcode.IsDisposed) 
            {
                m_sendgcode = new frmGCodeRaw();
            }
            m_sendgcode.Show();
        }
        #region Save/Load GCode
        private void cmdSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                // get the gcode from the textbox, save it...
                UVDLPApp.Instance().m_gcode.RawGCode = txtGCode.Text;
                UVDLPApp.Instance().SaveGCode();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdReloadGCode_Click(object sender, EventArgs e)
        {
            try
            {
                UVDLPApp.Instance().LoadGCode();
                txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;                
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        #endregion Save/ Load GCode
        /*
         This function does 2 things,
         * when a node is click that is an object node, it sets
         * the App current object to be the clicked object
         * when an obj in the tree view is right clicked, it shows the context menu
         */
        private void treeScene_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    UVDLPApp.Instance().m_selectedobject = (Object3d)e.Node.Tag;
                    SetupSceneTree();
                }
                
                if (e.Button == System.Windows.Forms.MouseButtons.Right)  // we right clicked a menu item, check and see if it has a tag
                {
                    contextMenuStrip1.Show(treeScene,e.Node.Bounds.Left, e.Node.Bounds.Top);
                }            
            }
        }

        private void cmdRemoveObject_Click(object sender, EventArgs e)
        {
            // delete the current selected object
            if (UVDLPApp.Instance().m_selectedobject != null) 
            {
                UVDLPApp.Instance().RemoveCurrentModel();

            }

        }
        #region Move functions
        private void cmdXDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtXTrans.Text);
                val *= -1;
                UVDLPApp.Instance().m_selectedobject.Translate(val, 0, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdXInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtXTrans.Text);
                UVDLPApp.Instance().m_selectedobject.Translate(val, 0, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtYTrans.Text);
                val *= -1;
                UVDLPApp.Instance().m_selectedobject.Translate(0, val, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtYTrans.Text);
                val *= 1;
                UVDLPApp.Instance().m_selectedobject.Translate(0, val, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZdec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtZTrans.Text);
                val *= -1;
                UVDLPApp.Instance().m_selectedobject.Translate(0, 0,val);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                float val = float.Parse(txtZTrans.Text);
                val *= 1;
                UVDLPApp.Instance().m_selectedobject.Translate(0, 0,val);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        #endregion Move functions

        #region Rotate functions
        private void cmdXRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                
                UVDLPApp.Instance().m_selectedobject.Rotate(-(90 * 0.0174532925f), 0, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdXRInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                UVDLPApp.Instance().m_selectedobject.Rotate((90 * 0.0174532925f), 0, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                UVDLPApp.Instance().m_selectedobject.Rotate(0,-(90*0.0174532925f), 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdYRInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                UVDLPApp.Instance().m_selectedobject.Rotate(0, 90 * 0.0174532925f, 0);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZRDec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                UVDLPApp.Instance().m_selectedobject.Rotate(0, 0, -(90*0.0174532925f));
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdZRInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_selectedobject == null)
                    return;
                UVDLPApp.Instance().m_selectedobject.Rotate(0, 0, 90 * 0.0174532925f);
                ShowObjectInfo();
                DisplayFunc();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        #endregion

        #region Mouse Move/Scale/Rotate/View
        private void mnuView_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eView;
            SetMouseModeChecks();
        }

        private void mnuMove_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelMove;
            SetMouseModeChecks();
        }

        private void mnuRotate_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelRotate;
            SetMouseModeChecks();
        }

        private void mnuScale_Click(object sender, EventArgs e)
        {
            m_mousemode = eMOUSEMODE.eModelScale;
            SetMouseModeChecks();
        }
        private void SetMouseModeChecks()
        {
            mnuMove.Checked = false;
            mnuView.Checked = false;
            mnuScale.Checked = false;
            mnuRotate.Checked = false;
            switch (m_mousemode)
            {
                case eMOUSEMODE.eModelMove:
                    mnuMove.Checked = true;
                    break;
                case eMOUSEMODE.eModelRotate:
                    mnuRotate.Checked = true;
                    break;
                case eMOUSEMODE.eModelScale:
                    mnuScale.Checked = true;
                    break;
                case eMOUSEMODE.eView:
                    mnuView.Checked = true;
                    break;
            }

        }
        #endregion 

        private void manageMachinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_machineprofilemanager.IsDisposed) 
            {
                m_machineprofilemanager = new frmMachineProfileManager();
            }
            m_machineprofilemanager.ShowDialog();
            // update just in case.
            UVDLPApp.Instance().Engine3D.RemoveAllLines();
            UVDLPApp.Instance().Engine3D.AddGrid();
            UVDLPApp.Instance().Engine3D.AddPlatCube();
            DisplayFunc();
            PopulateMachinesMenu();
        }

        // one of the populated machines in the machine menu was clicked
        private void mnuMachine_Click(object sender, EventArgs e)
        {
            String newprof = sender.ToString();

            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
            int idx = 0;
            foreach (String profile in filePaths)
            {
                String pn = Path.GetFileNameWithoutExtension(profile);
                if (pn.Equals(newprof)) 
                {
                    UVDLPApp.Instance().LoadMachineConfig(filePaths[idx]);
                    UVDLPApp.Instance().SetupDriver();
                    PopulateMachinesMenu();
                    break;
                }
                idx++;
            }
        }
        #region DLP Screen Controls
        private void showBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDLPScreen();
            Screen dlpscreen = GetDLPScreen();
            UVDLPApp.Instance().m_buildmgr.ShowBlank(dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
        }

        private void showCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildparms.UpdateFrom(UVDLPApp.Instance().m_printerinfo);
            ShowDLPScreen();
            Screen dlpscreen = GetDLPScreen();
            UVDLPApp.Instance().m_buildmgr.ShowCalibration(dlpscreen.Bounds.Width,dlpscreen.Bounds.Height,UVDLPApp.Instance().m_buildparms);
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmdlp.Hide();    
        }

        private Screen GetDLPScreen() 
        {
            Screen dlpscreen = null;
            foreach (Screen s in Screen.AllScreens)
            {
                if (s.DeviceName.Equals(UVDLPApp.Instance().m_printerinfo.Monitorid))
                {
                    dlpscreen = s;
                    break;
                }
            }
            if (dlpscreen == null)
            {
                dlpscreen = Screen.AllScreens[0]; // default to the first if we can't find it
                DebugLogger.Instance().LogRecord("Can't find screen " + UVDLPApp.Instance().m_printerinfo.Monitorid);
            }
            return dlpscreen;
        }
        private bool ShowDLPScreen()
        {
            try
            {
                Screen dlpscreen = GetDLPScreen();
                if (m_frmdlp.IsDisposed)
                {
                    m_frmdlp = new frmDLP();//recreate
                }
                m_frmdlp.Show();
                m_frmdlp.SetDesktopBounds(dlpscreen.Bounds.X, dlpscreen.Bounds.Y, dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
                m_frmdlp.WindowState = FormWindowState.Maximized;
                m_frmdlp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        #endregion DLP screen controls

        private void showCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_curslice != null) 
            {
                ShowDLPScreen();
                m_frmdlp.ShowImage(m_curslice);
            }
        }

        private void cmdPause_Click_1(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildmgr.PausePrint();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Allow the user to choose the page range he or she would
            // like to print.
            printDialog1.AllowSomePages = true;

            // Show the help button.
            printDialog1.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 

            //printDialog1.Document = docToPrint;

            DialogResult result = printDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                //docToPrint.Print();
                printDocument1.Print();
            }

        }

        private void saveSceneSTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //save the scene object
                    UVDLPApp.Instance().CalcScene();
                    UVDLPApp.Instance().Scene.SaveSTL_Binary(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void addManualSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().AddSupport();
        }

        private void addAutomaticSupportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().AddAutoSupports();
        }
    }
}
