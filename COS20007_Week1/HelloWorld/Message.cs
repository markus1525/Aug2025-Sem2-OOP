namespace HelloWorld
{
    public class Message
    {
        private string _text;
        //non-default contractor
        public Message(string txt)
        {
            _text = txt; //assign parameter to class field - initialize
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
        public string GetMessage(){
            return this._text;
        }
    }
}