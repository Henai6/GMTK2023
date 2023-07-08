using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomInput
{
    public class TetrisController : MonoBehaviour
    {
        private AbstractInputReader _ir;
        private bool _isReseted;
        private bool _isLevelHorizontal;
        public Tile[] form; //use contain level base
        public Tile[] addedForm; //used contain added pieces
        public GameObject tileHolder;
        public Sprite sprite;
        private void Awake()
        {
            this.transform.position = new Vector3(0.5f,0,0);
            form = new Tile[10];
            for (int i = 0; i < 10; i++)
            {
                Position p = new Position(i, 0);
                GameObject obj = Instantiate(tileHolder, OuterGrid.TranslateToGridCoordinates(p), Quaternion.identity);
                obj.GetComponent<SpriteRenderer>().sprite = this.sprite;
                form[i] = obj.GetComponent<Tile>();
                form[i].Initialize(p);
            }
        }
        private void Start()
        {
            _ir = GetComponent<AbstractInputReader>();
        }
        private void Update()
        {
            if (_isReseted && _ir.movement.sqrMagnitude > 0.1f)
            {
                _isReseted = false;
                gameDirection? dir = null;
                if (_ir.movement.x < -0.8f) dir = gameDirection.Left;
                if (_ir.movement.y > 0.8f) dir = gameDirection.Up;
                if (_ir.movement.x > 0.8f) dir = gameDirection.Right;
                if (_ir.movement.y < -0.8f) dir = gameDirection.Down;
                switch (dir)
                {
                    case gameDirection.Left:
                        foreach (Tile t in form) t.AddX(-1);
                        break;
                    case gameDirection.Up:
                        foreach (Tile t in form) t.AddY(1);
                        break;
                    case gameDirection.Right:
                        foreach (Tile t in form) t.AddX(1);
                        break;
                    case gameDirection.Down:
                        foreach (Tile t in form) t.AddY(-1);
                        break;
                    default:
                        Debug.Log("error dir");
                        return;
                }
                EventDispatcher.Instance.MoveEvent((int)dir);
            }
            if (_ir.movement.sqrMagnitude < 0.1f) _isReseted = true;
            if (_ir.isJumping)
            {
                string s = "";
                foreach (Tile t in form) {
                    s += t.position.ToString();
                }
            }
        }
        private void Rotate()
        {
            
        } 
    }
}