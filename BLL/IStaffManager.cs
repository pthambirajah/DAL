using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IStaffManager
    {
        IStaffDB StaffDB { get; }

        Staff AddStaff(Staff staff);


        Staff UpdateStaff(Staff staff);

        Staff DeleteStaff(int id);
    }
}
