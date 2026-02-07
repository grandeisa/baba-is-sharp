using System.Diagnostics.CodeAnalysis;
using System.Numerics;

public struct GridVector2
{
    public static readonly GridVector2 RIGHT = new(1, 0);
    public static readonly GridVector2 LEFT = new(-1, 0);
    public static readonly GridVector2 DOWN = new(0, 1);
    public static readonly GridVector2 UP = new(0, -1);
    public static readonly GridVector2 ZERO = new(0, 0);

    public int x;
    public int y;

    public GridVector2(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }

#region GridVector2 operators
    public static GridVector2 operator +(GridVector2 vec) => vec;
    public static GridVector2 operator -(GridVector2 vec) => new(-vec.x, -vec.y);
    
    // Sum and subtraction

    public static GridVector2 operator +(GridVector2 u, GridVector2 v) => new(u.x + v.x, u.y + v.y);
    public static GridVector2 operator -(GridVector2 u, GridVector2 v) => new(u.x - v.x, u.y - v.y);

    // Vector multiplication

    public static GridVector2 operator *(GridVector2 u, GridVector2 v) => new(u.x * v.x, u.y * v.y);

    // Scalar multiplication and division

    public static GridVector2 operator *(GridVector2 vec, int num) => new(vec.x * num, vec.y * num);
    public static GridVector2 operator /(GridVector2 vec, int num) => new(vec.x / num, vec.y / num);


    // Comparison
    public static bool operator ==(GridVector2 u, GridVector2 v) => u.x == v.x && u.y == v.y;
    public static bool operator !=(GridVector2 u, GridVector2 v) => u.x != v.x || u.y != v.y;

    // Conversion
    public static implicit operator Vector2(GridVector2 vec) => new(vec.x, vec.y);


    #endregion

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if(obj?.GetType() == typeof(GridVector2))
        {
            return this == (GridVector2) obj;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}