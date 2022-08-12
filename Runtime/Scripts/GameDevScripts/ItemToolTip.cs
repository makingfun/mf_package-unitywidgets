﻿using TMPro;
using UnityEngine;

namespace unity_widgets.Runtime.Scripts.GameDevScripts
{
    /// <summary>
    /// Root of the tooltip prefab to expose properties to other classes.
    /// </summary>
    public class ItemTooltip : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI titleText;
        [SerializeField] TextMeshProUGUI bodyText;

        public void Setup(string title, string body)
        {
            titleText.text = title;
            bodyText.text = body;
        }
    }
}