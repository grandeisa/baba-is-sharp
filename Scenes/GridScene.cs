public class GridScene : IScene
{
    private List<Actor> actors = [
      new Actor("thing", "bobo", new(0, 0))  
    ];
    public void Start()
    {
        foreach(Actor actor in actors)
        {
            actor.Start();
        }
    }

    public void Update()
    {
        
    }

    public void Render()
    {
        foreach(Actor actor in actors)
        {
            actor.Render();
        }
    }
}