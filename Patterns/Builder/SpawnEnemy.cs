using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy enemyPref;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            // El builder acumula la configuración. Build() crea y devuelve
            // el Enemy recién cuando todos los pasos fueron indicados.
            var enemy = new EnemyBuilder(enemyPref)
                .SetColor(Color.blue)
                .SetPosition(2, 2, 1)
                .SetScale(3, 1, 4)
                .Build();
        }
    }
}
