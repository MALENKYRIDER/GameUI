using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Player _player;
    
    public float maxHealth = 10f;
    private float _currentHealth;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            Debug.Log("You picked a Diamond");
            return;
        }
        
        Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
        Color enemyColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        _renderer.color = enemyColor;
        other.gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        
        Debug.Log($"The player is {GetColorName(enemyColor)}");
        Debug.Log($"The enemy is {GetColorName(playerColor)}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out SpriteRenderer enemyRenderer))
            return;
        
        Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
        Color enemyColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        _renderer.color = enemyColor;
        other.gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        
        Debug.Log($"The player is {GetColorName(enemyColor)}");
        Debug.Log($"The enemy is {GetColorName(playerColor)}");
    }

    string GetColorName(Color color)
    {
        if (color == Color.red) return "Red";
        if (color == Color.blue) return "Blue";
        if (color == Color.green) return "Green";
        if (color == Color.yellow) return "Yellow";
        if (color == Color.black) return "Black";

        return "Unknown Color";
    }
}