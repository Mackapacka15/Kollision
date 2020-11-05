using System;
using Raylib_cs;
namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            float ypos = 10;
            float xpos = 10;
            string state = "menu";

            Raylib.InitWindow(800, 600, "Test");

            int height = Raylib.GetScreenHeight();
            int width = Raylib.GetScreenWidth();

            while (!Raylib.WindowShouldClose())
            {

                Rectangle player = new Rectangle(xpos, ypos, 30, 30);
                Rectangle enemy = new Rectangle(100, 305, 20, 20);
                //rörelse
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && xpos >= 0)
                {
                    xpos -= 0.1f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && xpos <= width - 30)
                {
                    xpos += 0.1f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && ypos <= height - 30)
                {
                    ypos += 0.1f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && ypos >= 0)
                {
                    ypos -= 0.1f;
                }

                //Rita upp
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                if (state == "menu")
                {

                    Raylib.DrawText("Press S to start", 30, height / 2, 50, Color.RED);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                    {
                        state = "game";
                    }
                }
                if (state == "game")
                {
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawRectangleRec(player, Color.ORANGE);
                    Raylib.DrawRectangleRec(enemy, Color.RED);
                    if (Raylib.CheckCollisionRecs(player, enemy))
                    {
                        state = "game over";
                    }
                }
                if (state == "game over")
                {
                    Raylib.ClearBackground(Color.ORANGE);
                    Raylib.DrawText("Game Over", 30, height / 2 - 5, 100, Color.BLACK);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_X))
                    {
                        state = "game";
                        xpos=10;
                        ypos=10;
                    }
                }

                Raylib.EndDrawing();

            }

        }


    }
}
