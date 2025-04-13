using UnityEngine;
using System.Collections.Generic;

namespace M3
{
    public class LabelCycler : MonoBehaviour
    {
        public List<string> textList = new List<string>()
        {
            "Eras",
            "Space",
            "Politics",
            "Tanks",
            "Guns",
            "Bombs",
            "Aircraft",
            "Skyscrapers",
            "Factories",
            "Boats"
        };

        public float interval = 1f;

        private int currentIndex = 0;
        private float timer = 0f;

        void Start()
        {
            if (textList.Count > 0)
            {
                Buttonz.instance.labelText = textList[0];
            }
        }

        void Update()
        {
            if (textList.Count == 0) return;

            timer += Time.deltaTime;

            if (timer >= interval)
            {
                currentIndex = (currentIndex + 1) % textList.Count;
                Buttonz.instance.labelText = textList[currentIndex];
                timer = 0f;
            }
        }
    }
}
