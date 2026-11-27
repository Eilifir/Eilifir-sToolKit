using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Renderer bodyRenderer;

    public void Render(PlayerModel model)
    {
        if (model == null) return;

        if (healthText != null)
            healthText.text = $"Health: {model.CurrentHealth}/{model.MaxHealth}";

        if (coinsText != null)
            coinsText.text = $"Coins: {model.Coins}";

        if (bodyRenderer != null)
        {
            float healthRatio = (float)model.CurrentHealth / model.MaxHealth;
            bodyRenderer.material.color = Color.Lerp(Color.red, Color.green, healthRatio);
        }
    }

    public void ShowDeath()
    {
        Debug.Log("[VIEW] The player died. Show the game over screen if you like.");
    }
}
