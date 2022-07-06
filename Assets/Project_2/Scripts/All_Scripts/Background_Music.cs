using UnityEngine;

namespace Project_2
{
    public class Background_Music : MonoBehaviour
    {
        [Header("Tags")]
        [Tooltip("Unique Object Tag")]
        [SerializeField] private string createdTag;

        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(createdTag);
            if (obj != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.tag = createdTag;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
