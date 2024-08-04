using Core.Entities.UserEntities;
using Core.Messages;
using Data.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public class CustomerService:ICustomerServices
    {
        private UnitOfWork _unitOfWork;

        public CustomerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BuyProduct()
        {
            throw new NotImplementedException();
        }

        public bool Login()
        {
        LoginEMailInput: Messages.InputMessages("email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Messages.InvalidInputMeesages("email");
                goto LoginEMailInput;
            }
        LoginPasswordInput: Messages.InputMessages("pasword");

            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                Messages.InvalidInputMeesages(" password ");
                goto LoginPasswordInput;
            }
            var existAdmin = _unitOfWork.Admins.GetAdminByEmail(email);
            if (existAdmin is null)
            {
                Messages.InvalidInputMeesages("email or password");
                return false;
            }

            PasswordHasher<Admin> passwordHasher = new PasswordHasher<Admin>();
            var result = passwordHasher.VerifyHashedPassword(existAdmin, existAdmin.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                Messages.InvalidInputMeesages("email or password");
                return false;
            }
            return true;
        }

        public void ProductFilterByName()
        {
            throw new NotImplementedException();
        }

        public void ProductHistory()
        {
            throw new NotImplementedException();
        }

        public void ProductHistoryByDate()
        {
            throw new NotImplementedException();
        }
    }
}
