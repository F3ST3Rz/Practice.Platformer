using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _countCoins;

    private Transform[] _transformPoints;
    private int _countPoints;

    private void Start()
    {
        _countPoints = transform.childCount;
        _transformPoints = new Transform[_countPoints];

        for (int i = 0; i < _countPoints; i++)
        {
            _transformPoints[i] = transform.GetChild(i);
        }

        InstantiateCoin();
    }

    private void InstantiateCoin()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            Vector3 randomPosition = _transformPoints[Random.Range(0, _countPoints)].position;
            Coin newCoin = Instantiate(_prefab, randomPosition, Quaternion.identity);
        }
    }  
}
