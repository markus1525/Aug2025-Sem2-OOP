namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> currentItems;

        public Inventory(List<Item> listInput){
            currentItems = new List<Item>();

            for(int i = 0; i < listInput.Count; i++){
                Item a = listInput[i];

                currentItems.Add(a);
                
            }
        }
    }
}
