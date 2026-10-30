using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class RoomService(RoomRepository roomRepository)
    {
        public async Task<List<Room>> GetAllRooms()
        {
            return await roomRepository.GetAll();
        }

        public async Task<Room?> GetRoomById(int id)
        {
            return await roomRepository.GetById(id);
        }

        public async Task AddRoom(Room room)
        {
            if (room.PricePerNight <= 0)
            {
                throw new ArgumentException("Room price must be greater than zero.");
            }

            await roomRepository.Add(room);
        }

        public async Task UpdateRoom(Room room)
        {
            Room? existingRoom = await roomRepository.GetById(room.RoomId);

            if (existingRoom == null)
            {
                throw new ArgumentException("Room not found.");
            }

            if (room.PricePerNight <= 0)
            {
                throw new ArgumentException("Room price must be greater than zero.");
            }

            await roomRepository.Update(room);
        }

        public async Task DeleteRoom(int id)
        {
            Room? room = await roomRepository.GetById(id);

            if (room == null)
            {
                throw new ArgumentException("Room not found.");
            }

            await roomRepository.Delete(id);
        }
    }
}