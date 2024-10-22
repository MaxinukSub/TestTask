using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;

namespace TestTask
{
    public partial class Form1 : Form
    {
        int _vertexArray;
        int _vertexBuffer;

        public Form1()
        {
            InitializeComponent();
            glControl1.Load += GlControl1_Load;
            glControl1.Paint += GlControl1_Paint;
        }

        private void GlControl1_Load(object sender, EventArgs e)
        {
            
            GL.ClearColor(System.Drawing.Color.Black); 

            // ���������� ������ ������ � ����� ��� ���������������
            _vertexArray = GL.GenVertexArray();
            _vertexBuffer = GL.GenBuffer();

            GL.BindVertexArray(_vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);

            // ������ ������ ��� ���� �������������, ������� ��������� ��������������
            float[] vertexData = {
                // ������ �����������
                -0.5f, -0.5f, // ����� ������ �����
                 0.5f, -0.5f, // ������ ������ �����
                 0.8f,  0.5f, // ������ ������� ����� (��������)
                
                // ������ �����������
                -0.5f, -0.5f, // ����� ������ �����
                 0.8f,  0.5f, // ������ ������� ����� (��������)
                -0.2f,  0.5f  // ����� ������� ����� (��������)
            };

            // ��������� ����� �������
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);

            // ������������� ��������� �� ������� (0 - ��� ������ �������� �������)
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            // ������� �����
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // ����������� ��������
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1); // ������������� ��������

            // �������� ������� ������ � ������ ��������������
            GL.BindVertexArray(_vertexArray);
            GL.Color3(System.Drawing.Color.Blue); // ������������� ����

            // ������ ��� ������������, ������� ���������� ��������������
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

            // ��������� �����
            glControl1.SwapBuffers();
        }
    }
}
