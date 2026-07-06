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

        public Complaint()
        {
            Status = ComplaintStatus.Opened;
        }


        public Complaint(int id,int customerid,string description="")
        {
            Id = id;
            CustomerID = customerid;
            Status= ComplaintStatus.Opened;
            Description = description;

        }

        //Access Modifiers (public,private)
        // Data Members 
        public int Id { get;  set; }
        public int CustomerID { get;  set; }
        public ComplaintStatus Status{ get; set; }
        public string Description { get; set; }


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
