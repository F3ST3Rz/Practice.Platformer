using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _countCoins;

    private void Start()
    {
        _countCoins = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            AddCoin();
            Destroy(coin.gameObject);
        }
    }

    private void AddCoin()
    {
        _countCoins++;
    }
}
