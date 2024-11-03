using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class OpenGLRenderer
    {
        private VertexArrayObject _vertexArrayObject;
        private float[] _vertexData = {
            -0.5f, -0.5f,
             0.5f, -0.5f,
             0.8f,  0.5f,
            -0.5f, -0.5f,
             0.8f,  0.5f,
            -0.2f,  0.5f
        };

        public OpenGLRenderer()
        {
            GL.ClearColor(System.Drawing.Color.Black);
            _vertexArrayObject = new VertexArrayObject(_vertexData);
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1);

            _vertexArrayObject.Bind();
            GL.Color3(System.Drawing.Color.Blue);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
        }
    }
}
