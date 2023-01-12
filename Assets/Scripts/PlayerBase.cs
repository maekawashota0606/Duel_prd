using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected Input _input;

    public struct Input
    {
        public bool attack;
        public bool avoid;
        public Vector2 look;
        public Vector2 move;

        public Input(bool attack, bool avoid, Vector2 look, Vector2 move)
        {
            this.attack = attack;
            this.avoid = avoid;
            this.look = look;
            this.move = move;
        }
    }

    public Input GetInput()
    {
        return _input;
    }

    public void InitInput()
    {
        // リフレクションとか使えば一括で回せるかも？
        _input.attack = false;
        _input.avoid = false;
        _input.look = Vector2.zero;
        _input.move = Vector2.zero;
    }
}
