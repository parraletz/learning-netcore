using Backend.Controllers;


namespace Backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            Console.WriteLine(people.Name);
            if (string.IsNullOrEmpty(people.Name) || 
                people.Name.Length > 100)
            {
                Console.WriteLine(people);
                return false;
            }
            return true;
        }
    }
}