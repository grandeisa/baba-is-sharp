using Raylib_cs;

public class GridScene : IScene
{
    private static GridVector2[] ValidLogicDirections = [GridVector2.RIGHT, GridVector2.DOWN];

    private List<Actor> actors = [
      new Actor("text", "bobo", new(1, 0)),
      new Actor("text", "is", new(1, 1)),
      new Actor("text", "you", new(1, 2)),
      new Actor("thing", "bobo", new(16, 16)),

    ];

    private Dictionary<string, List<string>> adjectives = [];
    public void Start()
    {
        foreach(Actor actor in actors)
        {
            actor.Start();
        }
    }

    public void Update()
    {
        int keycode = Raylib.GetKeyPressed();
        if(keycode != 0)
        {
            adjectives = [];
            CheckTextActors();
            HandleLogic();
        }
    }

    void CheckTextActors()
    {
        foreach(Actor actor in actors)
        {
            if(actor.type == "text" && actor.name != "is")
            {
                if(!adjectives.ContainsKey(actor.name))
                {
                    adjectives.Add(actor.name, []);
                }

                foreach(GridVector2 direction in ValidLogicDirections)
                {
                    foreach(Actor text in GetTextInCell(actor.position + direction))
                    {
                        if(text.name == "is")
                        {
                            foreach(Actor finalText in GetTextInCell(actor.position + direction * 2))
                            {
                                adjectives[actor.name].Add(finalText.name);
                            }
                        }
                    }
                }
            }
        }
    }

    void HandleLogic()
    {
        foreach(KeyValuePair<string, List<string>> logic in adjectives)
        {
            List<Actor> things = GetThingOfName(logic.Key);

            foreach(string adjective in logic.Value)
            {
                switch(adjective)
                {
                    case "you":
                        if(Raylib.IsKeyPressed(KeyboardKey.Up))
                        {
                            MoveActors(things, GridVector2.UP);
                        }else if(Raylib.IsKeyPressed(KeyboardKey.Down))
                        {
                            MoveActors(things, GridVector2.DOWN);
                        }else if(Raylib.IsKeyPressed(KeyboardKey.Left))
                        {
                            MoveActors(things, GridVector2.LEFT);
                        }else if(Raylib.IsKeyPressed(KeyboardKey.Right))
                        {
                            MoveActors(things, GridVector2.RIGHT);
                        }
                    break;
                }
            }
        }
    }

    public void Render()
    {
        foreach(Actor actor in actors)
        {
            actor.Render();
        }
    }

    List<Actor> GetActorsInCell(GridVector2 position)
    {
        List<Actor> cell = [];
        foreach(Actor actor in actors)
        {
            if(actor.position == position)
            {
                cell.Add(actor);
            }
        }
        return cell;
    }

    List<Actor> GetTextInCell(GridVector2 position)
    {
        List<Actor> cell = [];
        foreach(Actor actor in actors)
        {
            if(actor.position == position && actor.type == "text")
            {
                cell.Add(actor);
            }
        }
        return cell;
    }

    List<Actor> GetThingOfName(string name)
    {
        List<Actor> things = [];

        foreach(Actor actor in actors)
        {
            if(actor.type == "thing" && actor.name == name)
            {
                things.Add(actor);
            }
        }

        return things;
    }

    void MoveActors(List<Actor> actors, GridVector2 direction)
    {
        foreach(Actor actor in actors)
        {
            actor.position += direction;
        }
    }
}