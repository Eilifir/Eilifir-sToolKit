using UnityEngine;

public class WeightedRandom<T> : MonoBehaviour
{
    public T RandomWeighted(T[] values, int[] weights)
    {
        int total = 0;
        foreach (int weight in weights)
            total += weight;
        int randomNumber = Random.RandomRange(1, total);
        int cursor = 0;
        int arrayPosition = 0;
        for (int i = 0;i < weights.Length; i++)
        {
            cursor += weights[i];
            if (cursor >= randomNumber)
            {
                arrayPosition = i;
                break;
            }
        }
        return values[arrayPosition];
    }
}
