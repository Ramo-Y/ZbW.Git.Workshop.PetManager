namespace PetManager
{
    using System;

    public class Pet
    {
        public Pet(DateTime birthday)
        {
            Birthday = birthday;
        }

        public int GetAge { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime Birthday { get; set; }
    }
}