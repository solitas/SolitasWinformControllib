namespace ControlTest
{
    public enum DataType
    {
        Type1,
        Type2,
        Type3
    }

    public class DataModel
    {
        private string _label;
        private string _address;
        private string _comment;
        private DataType _type;
        
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public DataType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DataModel()
        {

        }
    }
}
