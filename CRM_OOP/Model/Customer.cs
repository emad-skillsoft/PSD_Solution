namespace CRM_OOP
{
    public class Customer
    {
        //Default Constructor
        public Customer()
        {
                
        }

        //Overloaded Constructor
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;    
        }

        //Data Members (Properties)
        public int Id { get;  set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }

    }
}
