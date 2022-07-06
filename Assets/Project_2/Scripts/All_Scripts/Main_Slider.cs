using UnityEngine;
using UnityEngine.UI;

namespace Project_2
{
    public class Main_Slider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Text text;
        [SerializeField] private string saveVolumeKey;
        [SerializeField] private string sliderTag;
        [SerializeField] private string textVolumeTag;
        [SerializeField] [Range(-80.0f, 0.0f)] private float volume;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(this.saveVolumeKey))
            {
                this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
                GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
                if (sliderObj != null)
                {
                    this.slider = sliderObj.GetComponent<Slider>();
                    this.slider.value = this.volume;
                }
            }
            else
            {
                this.volume = 0f;
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }
        }

        private void LateUpdate()
        {
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.volume = slider.value;
                GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
                if (textObj != null)
                {
                    this.text = textObj.GetComponent<Text>();

                    this.text.text = Mathf.Round(this.volume + 80) + "%";
                }
            }
        }
    }
}
