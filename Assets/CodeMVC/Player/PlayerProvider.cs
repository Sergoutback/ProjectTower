using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CodeMVC.Data
{
    public class PlayerProvider : MonoBehaviour
    {
        public event Action<bool> OnTriggetEnterChange;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        public float Speed => _speed;
        public float JumpForce => _jumpForce;
        public Vector2 Position => transform.position;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggetEnterChange?.Invoke(other.gameObject.GetComponent<TilemapCollider2D>());
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggetEnterChange?.Invoke(other.gameObject.GetComponent<TilemapCollider2D>());
        }
    }
}