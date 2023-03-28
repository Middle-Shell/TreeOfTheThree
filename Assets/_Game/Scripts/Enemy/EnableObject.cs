using UnityEngine;

namespace Assets._Game.Scripts.Enemy
{
    public class EnableObject : IEnableObject
    {
        [SerializeField] private GameObject _gameObject;

        public void Enable()
        {
            _gameObject.SetActive(true);
        }

        public void Disable()
        {
            _gameObject.SetActive(false);
        }
    }
}