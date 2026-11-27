using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBuilder
{
    private readonly Enemy _prototype;
    private Color _color;
    private Vector3 _position;
    private Vector3 _scale;
    private bool _hasColor;
    private bool _hasPosition;
    private bool _hasScale;

    public EnemyBuilder(Enemy prototype)
    {
        _prototype = prototype;
    }

    public EnemyBuilder SetColor(Color color)
    {
        _color = color;
        _hasColor = true;
        return this;
    }

    public EnemyBuilder SetPosition(float x = 0, float y = 0, float z = 0)
    {
        _position = new Vector3(x, y, z);
        _hasPosition = true;
        return this;
    }

    public EnemyBuilder SetScale(float x = 1, float y = 1, float z = 1)
    {
        _scale = new Vector3(x, y, z);
        _hasScale = true;
        return this;
    }

    public Enemy Build()
    {
        Enemy enemy = Object.Instantiate(_prototype);
        if (_hasColor) enemy.SetColor(_color);
        if (_hasPosition) enemy.SetPosition(_position.x, _position.y, _position.z);
        if (_hasScale) enemy.SetScale(_scale.x, _scale.y, _scale.z);
        return enemy;
    }
}
