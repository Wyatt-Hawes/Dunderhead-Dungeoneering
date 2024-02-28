using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalSelector : MonoBehaviour
{
    [SerializeField] private Toggle English, Chinese;

    private void Start()
    {
        if (LocalizationSettings.SelectedLocale.Identifier == "en")
        {
            English.isOn = true;
        }
        else if (LocalizationSettings.SelectedLocale.Identifier == "zh-Hans")
        {
            Chinese.isOn = true;
        }

    }

    public void ChangeLocale(int localeID)
    {
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int _localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
    }
}
