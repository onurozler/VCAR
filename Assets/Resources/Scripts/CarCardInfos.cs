using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CarCardInfos : MonoBehaviour
{
    public string SelectedCar;

    private CarInfo CarInf;

    private Text Manufacturer;
    private Text Name;
    private Text Production;
    private Text Engine;
    private Image CarImage;


    void Start()
    {
        // Get Language
        int language = PlayerPrefs.GetInt("Language");

        // Load Car Infos
        CarInf = Resources.Load(@"CarInfos\"+SelectedCar) as CarInfo;

        // Assign Components
        Manufacturer = transform.GetChild(1).GetComponent<Text>();
        Name = transform.GetChild(2).GetComponent<Text>();
        Production = transform.GetChild(3).GetComponent<Text>();
        Engine = transform.GetChild(4).GetComponent<Text>();
        CarImage = transform.GetChild(0).GetComponent<Image>();

        // Assign Values
        Manufacturer.text = (language == 0 ? "Manufacturer : " : "Üretici : ") + CarInf.Manufacturer;
        Name.text = (language == 0 ? "Name : " : "İsim : ") + CarInf.Name;
        Production.text = (language == 0 ? "Production : " : "Üretim : ") + CarInf.Production;
        Engine.text = (language == 0 ? "Engine : " : "Motor : ") + CarInf.Engine;
        CarImage.sprite = CarInf.CarImage;


    }

}
