using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARSceneManager : MonoBehaviour
{
    // UI element References
    public GameObject CardInfo;
    public GameObject ArGround;
    public Slider CarScaleSlider;
    public GameObject CommandList;

    // Reference for GameObjects
    private GameObject _selectedCar;
    private Material _selectedCarMaterial;
    [SerializeField] private List<GameObject> _cars;

    // Temp Material to keep orijinal Material 
    private Material _tempMaterial;

    // Localization
    internal LanguageInfo Language;

    void Start()
    {
        // Set up Localization
        if (PlayerPrefs.GetInt("Language") == 0)
            Language = Resources.Load(@"Language\ENG") as LanguageInfo;
        else
            Language = Resources.Load(@"Language\TR") as LanguageInfo;

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

        _sliderPastValue = CarScaleSlider.value;
        CarScaleSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private float _sliderPastValue;
    // Slider Value Change Checker
    public void ValueChangeCheck()
    {
        if (Mathf.Abs(_sliderPastValue - CarScaleSlider.value) <= 0.05f)
            return;

        if (_sliderPastValue < CarScaleSlider.value)
            _selectedCar.transform.localScale += Vector3.one/10;
        else
            _selectedCar.transform.localScale -= Vector3.one/10;

        _sliderPastValue = CarScaleSlider.value;

    }

    // Return to main menu
    public void GoToMainMenu()
    {
        ChangeCarMaterial(true);
        SceneManager.LoadScene("MainMenu");
    }

    // When Quit App, fix the material
    void OnApplicationQuit()
    {
        ChangeCarMaterial(true);
    }

    // ******************************** Voice Controlled Commends Sections ********************************* //

    // Trigger Car Open/Close Driver Door Animation
    public void OpenTheDoor(bool yes)
    {
        _selectedCar.GetComponent<Animator>().ResetTrigger("OpenTheDoor");
        _selectedCar.GetComponent<Animator>().ResetTrigger("CloseTheDoor");
        if (yes)
            _selectedCar.GetComponent<Animator>().SetTrigger("OpenTheDoor");
        else
            _selectedCar.GetComponent<Animator>().SetTrigger("CloseTheDoor");

    }

    // Open Commands Section
    public void OpenCommands(bool yes)
    {
        if (yes)
        {
            // Localization for commands
            CommandList.transform.GetChild(0).GetComponent<Text>().text = Language.Commands[3];
            CommandList.transform.GetChild(1).GetComponent<Text>().text = Language.Commands[0];
            CommandList.transform.GetChild(2).GetComponent<Text>().text = Language.Commands[1];
            CommandList.transform.GetChild(3).GetComponent<Text>().text = Language.Commands[2];
            CommandList.SetActive(true);
        }
        else
            CommandList.SetActive(false);
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

}
