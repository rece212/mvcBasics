namespace mvcBasics.Models
{
    public class StaffContext
    {
        public static List<Staff> staffObject = new List<Staff>();
        public StaffContext() 
        {
            if (staffObject.Count == 0)
            {
                staffObject.Add(new Staff(1, "Amber", "Baby staff member", "1234", "2003"));
                staffObject.Add(new Staff(2, "Jessica", "staff member", "4321", "2003"));
                staffObject.Add(new Staff(3, "George", "Mini staff member", "09876543", "2003"));
            }
        
        }
    }
}
