using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCoins {get; private set;}

    public UnityEvent<PlayerInventory> OnDiamondCollected;
    

    public void DiamondCollected()
    {
        NumberOfCoins++;
        OnDiamondCollected.Invoke(this);
    }
}