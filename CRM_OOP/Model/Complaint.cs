using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_OOP
{
    public enum ComplaintStatus { Opened, InProcess, Resolved }

    public class Complaint
    {

        // Static/Class Data Members
        public static int MaxDaysToClose=0;

        public Complaint()
        {
            Status = ComplaintStatus.Opened;
            CreationDate= DateTime.Now;
        }


        public Complaint(int id,int customerid,string description="")
        {
            Id = id;
            CustomerID = customerid;
            Status= ComplaintStatus.Opened;
            Description = description;
            CreationDate= DateTime.Now;

        }

        //Access Modifiers (public,private)
        // instance Data Members 
        public int Id { get;  set; }
        public int CustomerID { get;  set; }
        public ComplaintStatus Status{ get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        // Method Members
        public void ChangeStatus(ComplaintStatus sts)
        {
            Status = sts;
        }
    }

    public class LandlineComplaint : Complaint
    {
        public LandlineComplaint()
        {
                
        }

        //Data Members
        public string LandlineNumer { get; set; }
        public string Address { get; set; }


    }

}
