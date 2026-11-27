using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : Prototype
{
    public Enemy SetColor(Color col)
    {
        GetComponent<Renderer>().material.color = col;
        return this;
    }

    public Enemy SetPosition(float x = 0, float y = 0, float z = 0)
    {
        transform.position = new Vector3(x, y, z);
        return this;
    }

    public Enemy SetScale(float x = 1, float y = 1, float z = 1)
    {
        transform.localScale = new Vector3(x, y, z);
        return this;
    }

    public override Prototype Clone()
    {
        var res = Instantiate(this);
        res.SetColor(UnityEngine.Random.ColorHSV(0, 1)).
            SetPosition(Random.Range(-10, 10), Random.Range(-5, 5), Random.Range(-10, 10)).
            SetScale(Random.Range(0.1f, transform.localScale.x), Random.Range(0.1f, transform.localScale.y), Random.Range(0.1f, transform.localScale.z));
        return res;
    }

    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Clone();
        }    
    }
}
