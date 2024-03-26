using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            if (!doesNameExist(firstName, lastName)) return false;

            if (!emailValidation(email)) return false;

            if (!ageValidation(dateOfBirth)) return false;
            

            var client = ClientCreatrion(firstName, lastName, email, dateOfBirth, clientId, out var user);

            ClientImportanceAndCreditLimitSet(client, user);

            if (!DoesUserHasCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
            
        }

       

        private bool ageValidation(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }

    }
}
