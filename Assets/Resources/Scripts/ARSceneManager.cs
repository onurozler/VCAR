using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARSceneManager : MonoBehaviour
{
    // UI element References
    public GameObject CardInfo;
    public GameObject ArGround;
    public Slider CarScaleSlider;

    // Reference for GameObjects
    private GameObject _selectedCar;
    private Material _selectedCarMaterial;
    [SerializeField] private List<GameObject> _cars;

    // Temp Material to keep orjinal Material 
    private Material _tempMaterial;

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

        // Send Car name to Card infos
        CardInfo.GetComponent<CarCardInfos>().SelectedCar = _selectedCar.name;

        // Get Material of Selected Car
        _selectedCarMaterial = Resources.Load(@"Materials\" + _selectedCar.name + @"\CarMaterial") as Material;

        // Assign Temp Material
        if (_selectedCarMaterial != null)
        {
            _tempMaterial = new Material(_selectedCarMaterial.shader);
            _tempMaterial.CopyPropertiesFromMaterial(_selectedCarMaterial);
        }

        // Starting slider Value
        CarScaleSlider.value = 0.5f;
    }

    // Change Car Material
    public void ChangeCarMaterial(bool returnOldMaterial)
    {
        if (returnOldMaterial)
            _selectedCarMaterial.CopyPropertiesFromMaterial(_tempMaterial);
        else
            _selectedCarMaterial.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    
    // Activate Card Info
    public void OpenCardInfo(bool yes)
    {
        if (yes)
            CardInfo.SetActive(true);
        else
            CardInfo.SetActive(false);
    }

    public void GoToMainMenu()
    {
        ChangeCarMaterial(true);
        SceneManager.LoadScene("MainMenu");
    }

    // Update Car Scale
    void Update()
    {
        _selectedCar.transform.localScale = new Vector3(_selectedCar.transform.localScale.x, _selectedCar.transform.localScale.y, _selectedCar.transform.localScale.z) * CarScaleSlider.value;
    }

}
