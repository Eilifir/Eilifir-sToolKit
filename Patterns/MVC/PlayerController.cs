using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerView view;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private int heal = 5;
    private PlayerModel model;
    private PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        if (movement == null)
            movement = gameObject.AddComponent<PlayerMovement>();
        model = new PlayerModel(maxHealth);

        if (view == null)
            view = GetComponent<PlayerView>();
        RefreshView();
    }

    private void Update()
    {
        ReadMovementInput();
        ReadActions();
    }

    private void ReadMovementInput()
    {
        // Interpreta el input, pero delega el movimiento.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        movement.Move(direction);
    }

    private void ReadActions()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bool wasAlive = !model.IsDead;
            model.TakeDamage(damage);
            RefreshView();
            if (wasAlive && model.IsDead && view != null)
                view.ShowDeath();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            model.Heal(heal);
            RefreshView();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            model.ResetStats();
            RefreshView();
        }
    }

    public void AddCoin(int amount)
    {
        model.AddCoin(amount);
        RefreshView();
    }

    private void RefreshView()
    {
        if (view != null)
            view.Render(model);
    }
}
