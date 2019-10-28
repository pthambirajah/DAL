using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
namespace BLL
{
    public interface IAvailibility
    {
        IAvailibility HotelsDB { get; }

        List<Availibility> GetHotels();



        Hotel AddHotel(Hotel hotel);


        Hotel UpdateHotel(Hotel hotel);

        Hotel DeleteHotel(int id);
    }
}
