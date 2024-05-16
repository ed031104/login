using NuGet.Protocol;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using BD;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
	public class UserService : UserI
	{

		private readonly UserContext _userPersistence;


		public UserService(UserContext context)
		{
			_userPersistence = context;
		}

		public void AddUser(User user)
		{
			User newUser = new User
			{
				Nombre = user.Nombre,
				Apellido = user.Apellido,
				Email = user.Email,
				Contrasena = user.Contrasena,
			};
			_userPersistence.User.Add(newUser);
			_userPersistence.SaveChangesAsync();
		}

		public void DeleteUser(string name)
		{
			_userPersistence.User.Remove(SearchUser(name));
		}

		public User SearchUser(string name)
		{
			try
			{
				User user = _userPersistence.User.FirstOrDefault(u => u.Nombre == name);
				if (user == null)
				{
					throw new Exception($"User with name '{name}' not found");
				}
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        public User SearchUserForEmail(string email)
        {
            try
            {
                User user = _userPersistence.User.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new Exception($"User with name '{email}' not found");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool searchUserExist(string name)
		{
			User user = SearchUser(name);
			return user != null ? true : false;
		}


		public  List<User> UserList()
		{
			List<User> user = _userPersistence.User.ToList();
			return user != null ? user : throw new Exception("User not found");
		}

		public void UpdateUser(User user)
		{
			_userPersistence.User.Update(user);
		}

		public bool Login(string email, string password)
		{
			var user = _userPersistence.User
						.FirstOrDefault(x => x.Email == email && x.Contrasena == password);
			return user != null ? true : false;
		}
	}
}
