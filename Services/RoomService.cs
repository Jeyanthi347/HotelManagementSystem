using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class RoomService(RoomRepository roomRepository)
    {
        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public Room? GetRoomById(int id)
        {
            return roomRepository.GetById(id);
        }

        public void AddRoom(Room room)
        {
            if (room.PricePerNight <= 0)
            {
                throw new ArgumentException("Room price must be greater than zero.");
            }

            roomRepository.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            Room? existingRoom = roomRepository.GetById(room.RoomId);

            if (existingRoom == null)
            {
                throw new ArgumentException("Room not found.");
            }

            if (room.PricePerNight <= 0)
            {
                throw new ArgumentException("Room price must be greater than zero.");
            }

            roomRepository.Update(room);
        }

        public void DeleteRoom(int id)
        {
            Room? room = roomRepository.GetById(id);

            if (room == null)
            {
                throw new ArgumentException("Room not found.");
            }

            roomRepository.Delete(id);
        }
    }
}