namespace PetManager
{
    using System;

    public class Pet
    {
        public Pet(DateTime birthday)
        {
            Birthday = birthday;
        }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime Birthday { get; set; }

        public int GetAge()
        {
            var age = DateTime.Today.Year - Birthday.Year;
            return age;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pet))
            {
                return Equals(obj, this);
            }

            var pet = (Pet)obj;
            return string.Equals(this.Name, pet.Name) && Birthday.Equals(pet.Birthday) && string.Equals(this.Breed, pet.Breed);
        }
    }
}