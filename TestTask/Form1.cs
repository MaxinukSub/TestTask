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

            // Генерируем массив вершин и буфер для параллелограмма
            _vertexArray = GL.GenVertexArray();
            _vertexBuffer = GL.GenBuffer();

            GL.BindVertexArray(_vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);

            // Массив данных для двух треугольников, которые формируют параллелограмм
            float[] vertexData = {
                // Первый треугольник
                -0.5f, -0.5f, // Левая нижняя точка
                 0.5f, -0.5f, // Правая нижняя точка
                 0.8f,  0.5f, // Правая верхняя точка (сдвинута)
                
                // Второй треугольник
                -0.5f, -0.5f, // Левая нижняя точка
                 0.8f,  0.5f, // Правая верхняя точка (сдвинута)
                -0.2f,  0.5f  // Левая верхняя точка (сдвинута)
            };

            // Заполняем буфер данными
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);

            // Устанавливаем указатель на вершину (0 - это индекс атрибута вершины)
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            // Очищаем экран
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Настраиваем проекцию
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1); // Ортогональная проекция

            // Включаем массивы вершин и рисуем параллелограмм
            GL.BindVertexArray(_vertexArray);
            GL.Color3(System.Drawing.Color.Blue); // Устанавливаем цвет

            // Рисуем два треугольника, которые составляют параллелограмм
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

            // Обновляем экран
            glControl1.SwapBuffers();
        }
    }
}
