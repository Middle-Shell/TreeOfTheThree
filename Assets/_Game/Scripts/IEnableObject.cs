using UnityEngine;

namespace Assets._Game.Scripts
{
    public interface IEnableObject
    {
        public void OnBecameVisible();
        public void OnBecameInvisible();
    }
}