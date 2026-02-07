using Raylib_cs;

public static class Game
{

#region window-variables
    const int WIDTH = 600, HEIGHT = 600;
    const int TARGET_FPS = 60;

    static readonly string Title = "Baba is #";
#endregion

    static IScene current_scene = new GridScene();

    static void Main()
    {
        Raylib.InitWindow(WIDTH, HEIGHT, Title);

        Raylib.SetTargetFPS(TARGET_FPS);

        Actor.LoadSpritesheets();

        current_scene.Start();

        while(!Raylib.WindowShouldClose())
        {
            current_scene.Update();
            Render();
        }

        Raylib.CloseWindow();
    }

    static void Render()
    {
        Raylib.ClearBackground(Color.Black);

        Raylib.BeginDrawing();
            current_scene.Render();

            //Raylib.DrawFPS(0, 0);
        Raylib.EndDrawing();
    }
}