using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneManager : MonoBehaviour
{
    public GameObject CardInfo;
    public GameObject ArGround;

    // Reference for GameObjects
    private GameObject _selectedCar;
    [SerializeField] private List<GameObject> _cars;


    void Start()
    {
        // Added Cars to List
        _cars = new List<GameObject>();
        foreach (Transform car in ArGround.transform)
        {
            _cars.Add(car.gameObject);
        }

        // Visible the car
        _selectedCar = _cars[PlayerPrefs.GetInt("CurrentCar")];
        _selectedCar.SetActive(true);

        CardInfo.GetComponent<CarCardInfos>().SelectedCar = _selectedCar.name;
    }

    public void OpenCardInfo(bool yes)
    {
        if (yes)
            CardInfo.SetActive(true);
        else
            CardInfo.SetActive(false);
    }

    void Update()
    {
        
    }
}
