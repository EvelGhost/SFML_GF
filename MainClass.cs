using SFML.Graphics;
using SFML.System;

namespace SFML_GF
{
    class MainClass
    {
        const int H = 800;
        const int W = 800;
        public static void Main()
        {
            try
            {
                //Базовые настройки
                RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(W, H), "Console");
                window.SetVerticalSyncEnabled(true);

                float xCeneter = W / 2;
                float yCeneter = H / 2;

                CircleShape BluePoint = new CircleShape(2f);
                BluePoint.FillColor = Color.Blue;
                CircleShape RedPoint = new CircleShape(2f);
                RedPoint.FillColor = Color.Red;

                int startCoord = -10;
                int endCoord = 10;
                float c = 500;
                int pointsNum = (int)((startCoord * -1 + endCoord) * c + 1);
                int scale = 38;

                Texture t = new Texture("m.jpg");
                Sprite pic = new Sprite(t);

                int animation = 0;

                //Рисование
                while (window.IsOpen)
                {
                    if (animation < pointsNum)
                        animation += 80;//скорость анимации

                    window.DispatchEvents();
                    window.Clear(Color.White);
                    window.Draw(pic);
                    for (int i = 0; i < animation; i++)
                    {
                        double x = startCoord + i / c;

                        double by = -x;// Функция 1 здесь!
                        double ry = x;//Функция 2 здесь!

                        double x1 = xCeneter + x * scale;
                        double y1 = yCeneter - by * scale;
                        double x2 = xCeneter + x * scale;
                        double y2 = yCeneter - ry * scale;

                        BluePoint.Position = new Vector2f((float)x1 - 2f, (float)y1 - 2f);
                        RedPoint.Position = new Vector2f((float)x2 - 2f, (float)y2 - 2f);
                        window.Draw(BluePoint);
                        window.Draw(RedPoint);
                    }
                    window.Display();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}
