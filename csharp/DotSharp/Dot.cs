using System;

namespace DotSharp
{
    public class Dot
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public Action<Dot, DotCell> OnEnterCell { get; set; }
        public object MetaData { get; set; }
        public bool IsStepped { get; set; }

        public Dot(int id, int value)
        {
            Id = id;
            Value = value;
            OnEnterCell = null;
            MetaData = null;
            IsStepped = false;
        }
        public Dot()
        {
            Id = 0;
            Value = 0;
            OnEnterCell = null;
            MetaData = null;
            IsStepped = false;
        }
        public override string ToString()
        {
            return $"({Id}|{Value})";
        }
    }
}