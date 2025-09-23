namespace HelloWorld{
    public class Car{

        public WindScreen windScreen; //association relationship (has-a)
        public List<Wheel> carWheels; //aggregation relationship

        public Message currentTicket; //independency relationship



        public Car(){
            windScreen = new WindScreen(10, 20);
            carWheels = new List<Wheel>();

            Wheel wheel1 = new Wheel(20,"michelin");
            Wheel wheel2 = new Wheel(20,"michelin");
            Wheel wheel3 = new Wheel(20,"michelin");
            Wheel wheel4 = new Wheel(20,"michelin");

            carWheels.Add(wheel1);
            carWheels.Add(wheel2);
            carWheels.Add(wheel3);
            carWheels.Add(wheel4);

            currentTicket = new Message("This is the ticket today");
            
        }
        public void getCurrentTicket(Message todayTicket){
            currentTicket = todayTicket;
        }

    }
    
    
}