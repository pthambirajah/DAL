using System;
using DAL;
using DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class StaffManager
    {

        public IStaffDB StaffDb { get; }

        public StaffManager(IConfiguration configuration)
        {
            StaffDb = new StaffDB(configuration);
        }

        public int GetStaffId(int id)
        {
            return StaffDb.GetStaffId(id);
        }

        public Staff GetStaff(int id)
        {
            return StaffDb.GetStaff(id);
        }

        public Staff AddStaff(Staff staff)
        {
            return StaffDb.AddStaff(staff);
        }

        public int UpdateStaff(Staff staff)
        {
            return StaffDb.UpdateStaff(staff);
        }

        public int DeleteStaff(int id)
        {
            return StaffDb.DeleteStaff(id);
        }

    }
}
