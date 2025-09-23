using System.Security.Principal;

namespace HelloWorld{
    public class WindScreen{

        private int width;
        private int height;

        public WindScreen(int WidthInput, int HeightInput){
            width = WidthInput;
            height = HeightInput;
        }

        public int getWidth(){
            return width;
        }

        public int getHeight(){
            return height;
        }

    }
    
    
}