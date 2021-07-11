using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class GameManager : MonoBehaviour, IObserver
{
    [SerializeField] private Age[] ages;
    public Age[] Ages { get => ages; }

    public Age CurrentAge => (ages.Length > 0) ? ages[_currentAgeIndex] : null;
    private int _currentAgeIndex;

    private City CurrentCityPrefab => (CurrentAge.Cities.Length > 0) ? CurrentAge.Cities[_currentCityIndex] : null;
    private int _currentCityIndex = 0;
    public City CurrentCity => _currentCity;
    private City _currentCity;
    private int _citiesDone = 0;

    private bool _youWin = false;

    //Factory
    private Spawner _spawnerCity = new Spawner();
    [SerializeField] private Transform _spawnPosition;

    //SINGLETON
    public static GameManager instance;

    private void Awake()
    {
        //SINGLETON
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        SpawnCity();

        _currentCity.AddObserver(this);
    }

    private void Update()
    {
        if(CheckNoCities()) return;

       
    }

    private void SpawnCity()
    {
        if (CurrentCityPrefab != null)
        {
             _currentCity = _spawnerCity.Create(CurrentCityPrefab.gameObject, _spawnPosition.position).GetComponent<City>();
        }
    }

    private bool CheckNoCities()
    {
        if(CurrentAge.Cities.Length == 0)
        {
            Debug.LogWarning("No Cities!");

            return true;
        }

        return false;
    }

    public void AdvanceCity()
    {
        _citiesDone++;
        _currentCityIndex++;

        if (_currentCityIndex >= CurrentAge.Cities.Length)
        {
            _currentCityIndex = 0;
            _currentAgeIndex++;

            if (_currentAgeIndex >= ages.Length)
            {
                //YOU WIN
                _youWin = true;
                Debug.Log("You conquered all cities!");

                //REAPEAT LAST CITY
                _currentAgeIndex--;
                _currentCityIndex = ages[_currentAgeIndex].Cities.Length - 1;
            }
            else
            {
                Debug.Log($"You advanced to {CurrentAge.AgeName}!");
            }
        }

        SpawnCity();

        _currentCity.AddObserver(this);
    }

    public void OnNotify(ISubject subject, IEvent ev)
    {
        if(ev is EventDie)
        {
            Debug.Log("City conquered!");

            AdvanceCity();
        }
    }
}
