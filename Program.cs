using Raylib_cs;

public static class Game
{

#region window-variables
    const int WIDTH = 400, HEIGHT = 400;
    const int TARGET_FPS = 60;

    static readonly string Title = "Baba is #";
#endregion


    static void Main()
    {
        Raylib.InitWindow(WIDTH, HEIGHT, Title);

        Raylib.SetTargetFPS(TARGET_FPS);

        while(!Raylib.WindowShouldClose())
        {
            Render();
        }

        Raylib.CloseWindow();
    }

    static void Render()
    {
        Raylib.ClearBackground(Color.Black);

        Raylib.BeginDrawing();
            Raylib.DrawFPS(0, 0);


        Raylib.EndDrawing();
    }
}