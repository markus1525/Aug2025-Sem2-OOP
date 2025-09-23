
namespace HelloWorld{
    public class Message{
        public string _text;

        public Message(string  txt){
            _text = txt;  
        }

        public void Print(){
            Console.WriteLine(_text);
        }

        public void SetMessage(string txt){
            _text = txt;
        }

        public string GetMessage(){
            return _text + " this is wrong";
        }
    }
}