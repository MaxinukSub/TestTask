using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;

namespace TestTask
{
    public partial class Form1 : Form
    {

        private OpenGLRenderer _renderer;

        public Form1()
        {
            InitializeComponent();
            glControl1.Load += GlControl1_Load;
            glControl1.Paint += GlControl1_Paint;
        }

        private void GlControl1_Load(object sender, EventArgs e)
        {
            _renderer = new OpenGLRenderer();
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            _renderer.Render();
            glControl1.SwapBuffers();
        }
    }
}