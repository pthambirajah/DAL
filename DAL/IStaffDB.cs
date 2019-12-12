using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using DTO;

namespace DAL
{
    public interface IStaffDB
    {
        IConfiguration Configuration { get; }

        Staff AddStaff(Staff staff);
        int DeleteStaff(int id);
        Staff GetStaff(int id);

        int GetStaffId(int id);
        int UpdateStaff(Staff staff);
    }

}
