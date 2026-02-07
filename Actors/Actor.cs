using Raylib_cs;

public class Actor
{
    public static readonly GridVector2 SIZE = new(32, 32);
    private static Texture2D ThingSpritesheet;
    private static readonly Dictionary<string, GridVector2> ThingSpritePosition = new()
    {
        {"bobo", new(0, 0)}
    };
    
    private static Texture2D TextSpritesheet;
    private static readonly Dictionary<string, GridVector2> TextSpritePosition = new()
    {
        {"bobo", new(0, 0)},
        {"is", new(1, 0)},
        {"you", new(2, 0)}
    };
    private Texture2D texture;
    private Rectangle textureRec;

    public GridVector2 position;
    public string type, name;

    public Actor(string type, string name, GridVector2 position)
    {
        this.type = type;
        this.name = name;
        this.position = position;

        

    }


    public static void LoadSpritesheets()
    {
        ThingSpritesheet = Raylib.LoadTexture("Sprites/thing.png");
    
        TextSpritesheet = Raylib.LoadTexture("Sprites/text.png");
    }
    public void Start()
    {
        if(type == "thing")
        {
            texture = ThingSpritesheet;
            textureRec = new(ThingSpritePosition[name], SIZE);
        }else if(type == "text")
        {
            texture = TextSpritesheet;
            textureRec = new(TextSpritePosition[name], SIZE);
        }
    }

    public void Render()
    {
        //Raylib.DrawTexture(Spritesheet, position.x, position.y, Color.White);
        Raylib.DrawTextureRec(texture, textureRec, position * SIZE, Color.White);
    }
}